using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.PaymentTerm
{
    public class PaymentTermEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<GEPaymentTermItemsInfo> PaymentTermItemList { get; set; }

        #endregion

        #region Constructor
        public PaymentTermEntities()
            : base()
        {
            PaymentTermItemList = new VinaList<GEPaymentTermItemsInfo>();

        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new GEPaymentTermsInfo();
            SearchObject = new GEPaymentTermsInfo();
        }

        public override void InitModuleObjectList()
        {
            PaymentTermItemList.InitVinaList(this,
                                             TableName.GEPaymentTermsTableName,
                                             TableName.GEPaymentTermItemsTableName,
                                             VinaList<GEPaymentTermItemsInfo>.cstRelationForeign);
            PaymentTermItemList.ItemTableForeignKey = "FK_GEPaymentTermID";
        }

        public override void InitGridControlInVinaList()
        {
            PaymentTermItemList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            GEPaymentTermsInfo mainObject = (GEPaymentTermsInfo)MainObject;
            mainObject.GEPaymentTermDate = DateTime.Now;
            mainObject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;

            UpdateMainObjectBindingSource();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                PaymentTermItemList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            PaymentTermItemList.Invalidate(iObjectID);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            PaymentTermItemList.SaveItemObjects();
        }
        #endregion
    }
}
