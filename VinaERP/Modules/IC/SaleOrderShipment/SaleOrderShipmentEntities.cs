using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Utilities.GenaralLeadger;
using VinaLib;

namespace VinaERP.Modules.SaleOrderShipment
{
    public class SaleOrderShipmentEntities : GLShipmentEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties

        #endregion

        #region Constructor
        public SaleOrderShipmentEntities()
        {
            ShipmentItemsList = new VinaList<ICShipmentItemsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICShipmentsInfo();
            SearchObject = new ICShipmentsInfo();
        }

        public override void InitModuleObjectList()
        {
            ShipmentItemsList.InitVinaList(this,
                                            "ICShipments",
                                            "ICShipmentItems",
                                            VinaList<ICShipmentItemsInfo>.cstRelationForeign);
            ShipmentItemsList.ItemTableForeignKey = "FK_ICShipmentID";
        }

        public override void InitGridControlInVinaList()
        {
            ShipmentItemsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ICShipmentsInfo mainobject = MainObject as ICShipmentsInfo;
            mainobject.ICShipmentDate = DateTime.Now;
            mainobject.ICShipmentDeliveryDate = DateTime.Now;
            mainobject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;

            UpdateMainObjectBindingSource();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ShipmentItemsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            ShipmentItemsList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            ShipmentItemsList.SaveItemObjects();
        }

        public void UpdateTotalAmount()
        {
            ICShipmentsInfo mainobject = (ICShipmentsInfo)MainObject;
            mainobject.ICShipmentSubTotalAmount = ShipmentItemsList.Sum(o => o.ICShipmentItemTotalAmount);
            mainobject.ICShipmentDiscountAmount = mainobject.ICShipmentSubTotalAmount * mainobject.ICShipmentDiscountPercent / 100;
            mainobject.ICShipmentTaxAmount = (mainobject.ICShipmentSubTotalAmount - mainobject.ICShipmentDiscountAmount) * mainobject.ICShipmentTaxPercent / 100;
            mainobject.ICShipmentTotalAmount = mainobject.ICShipmentSubTotalAmount - mainobject.ICShipmentDiscountAmount + mainobject.ICShipmentTaxAmount;
            UpdateMainObjectBindingSource();
        }
    }
}
