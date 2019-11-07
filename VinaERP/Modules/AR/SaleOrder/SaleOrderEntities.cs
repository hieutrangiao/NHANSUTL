using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaLib;

namespace VinaERP.Modules.SaleOrder
{
    public class SaleOrderEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<ARSaleOrderItemsInfo> SaleOrderItemsList { get; set; }

        public VinaList<ARSaleOrderPaymentTimesInfo> SaleOrderPaymentTimeList { get; set; }
        #endregion

        #region Constructor
        public SaleOrderEntities()
        {
            SaleOrderItemsList = new VinaList<ARSaleOrderItemsInfo>();
            SaleOrderPaymentTimeList = new VinaList<ARSaleOrderPaymentTimesInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ARSaleOrdersInfo();
            SearchObject = new ARSaleOrdersInfo();
        }

        public override void InitModuleObjectList()
        {
            SaleOrderItemsList.InitVinaList(this,
                                            "ARSaleOrders",
                                            "ARSaleOrderItems",
                                            VinaList<ARSaleOrderItemsInfo>.cstRelationForeign);
            SaleOrderItemsList.ItemTableForeignKey = "FK_ARSaleOrderID";

            SaleOrderPaymentTimeList.InitVinaList(this,
                                            "ARSaleOrders",
                                            "ARSaleOrderPaymentTimes",
                                            VinaList<ARSaleOrderPaymentTimesInfo>.cstRelationForeign);
            SaleOrderPaymentTimeList.ItemTableForeignKey = "FK_ARSaleOrderID";
        }

        public override void InitGridControlInVinaList()
        {
            SaleOrderItemsList.InitVinaListGridControl();
            SaleOrderPaymentTimeList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)MainObject;
            mainObject.ARSaleOrderDate = DateTime.Now;
            mainObject.ARSaleOrderDeliveryDate = DateTime.Now;
            mainObject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;

            UpdateMainObjectBindingSource();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                SaleOrderItemsList.SetDefaultListAndRefreshGridControl();
                SaleOrderPaymentTimeList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            SaleOrderItemsList.Invalidate(iObjectID);
            SaleOrderPaymentTimeList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            SaleOrderItemsList.SaveItemObjects();
            SaleOrderPaymentTimeList.SaveItemObjects();
        }

        public void UpdateTotalAmount()
        {
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)MainObject;

            mainObject.ARSaleOrderSubTotalAmount = SaleOrderItemsList.Sum(o=>o.ARSaleOrderItemTotalAmount);
            VinaApp.RoundByCurrency(mainObject, "ARSaleOrderSubTotalAmount", mainObject.FK_GECurrencyID);

            mainObject.ARSaleOrderDiscountAmount = mainObject.ARSaleOrderDiscountPercent / 100 * mainObject.ARSaleOrderSubTotalAmount;
            VinaApp.RoundByCurrency(mainObject, "ARSaleOrderDiscountAmount", mainObject.FK_GECurrencyID);

            mainObject.ARSaleOrderTaxAmount = mainObject.ARSaleOrderTaxPercent / 100 * (mainObject.ARSaleOrderSubTotalAmount - mainObject.ARSaleOrderDiscountAmount);
            VinaApp.RoundByCurrency(mainObject, "ARSaleOrderTaxAmount", mainObject.FK_GECurrencyID);

            mainObject.ARSaleOrderTotalAmount = mainObject.ARSaleOrderSubTotalAmount - mainObject.ARSaleOrderDiscountAmount + mainObject.ARSaleOrderTaxAmount;
            VinaApp.RoundByCurrency(mainObject, "ARSaleOrderTotalAmount", mainObject.FK_GECurrencyID);

            UpdateMainObjectBindingSource();
        }
    }
}
