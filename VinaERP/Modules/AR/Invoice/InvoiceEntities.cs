using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaLib;

namespace VinaERP.Modules.Invoice
{
    public class InvoiceEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<ARInvoiceItemsInfo> InvoiceItemList { get; set; }
        #endregion

        #region Constructor
        public InvoiceEntities()
        {
            InvoiceItemList = new VinaList<ARInvoiceItemsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ARInvoicesInfo();
            SearchObject = new ARInvoicesInfo();
        }

        public override void InitModuleObjectList()
        {
            InvoiceItemList.InitVinaList(this,
                                            "ARInvoices",
                                            "ARInvoiceItems",
                                            VinaList<ARInvoiceItemsInfo>.cstRelationForeign);
            InvoiceItemList.ItemTableForeignKey = "FK_ARInvoiceID";
        }

        public override void InitGridControlInVinaList()
        {
            InvoiceItemList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ARInvoicesInfo mainObject = (ARInvoicesInfo)MainObject;
            mainObject.ARInvoiceDate = DateTime.Now;
            mainObject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;

            UpdateMainObjectBindingSource();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                InvoiceItemList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            InvoiceItemList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            InvoiceItemList.SaveItemObjects();
        }

        public void UpdateTotalAmount()
        {
            ARInvoicesInfo mainObject = (ARInvoicesInfo)MainObject;

            mainObject.ARInvoiceSubTotalAmount = InvoiceItemList.Sum(o=>o.ARInvoiceItemTotalAmount);
            VinaApp.RoundByCurrency(mainObject, "ARInvoiceSubTotalAmount", mainObject.FK_GECurrencyID);

            mainObject.ARInvoiceDiscountAmount = mainObject.ARInvoiceDiscountPercent / 100 * mainObject.ARInvoiceSubTotalAmount;
            VinaApp.RoundByCurrency(mainObject, "ARInvoiceDiscountAmount", mainObject.FK_GECurrencyID);

            mainObject.ARInvoiceTaxAmount = mainObject.ARInvoiceTaxPercent / 100 * (mainObject.ARInvoiceSubTotalAmount - mainObject.ARInvoiceDiscountAmount);
            VinaApp.RoundByCurrency(mainObject, "ARInvoiceTaxAmount", mainObject.FK_GECurrencyID);

            mainObject.ARInvoiceTotalAmount = mainObject.ARInvoiceSubTotalAmount - mainObject.ARInvoiceDiscountAmount + mainObject.ARInvoiceTaxAmount;
            VinaApp.RoundByCurrency(mainObject, "ARInvoiceTotalAmount", mainObject.FK_GECurrencyID);

            UpdateMainObjectBindingSource();
        }

        public void GenerateInvoiceItemList(List<ICShipmentItemsInfo> shipmentItems)
        {
            ARSaleOrderItemsController objSaleOrderItemsController = new ARSaleOrderItemsController();
            ARSaleOrderItemsInfo objSaleOrderItemsInfo;
            ARInvoiceItemsInfo objInvoiceItemsInfo;
            shipmentItems.ForEach(o =>
            {
                objSaleOrderItemsInfo = objSaleOrderItemsController.GetObjectByID(o.FK_ARSaleOrderItemID) as ARSaleOrderItemsInfo;
                objInvoiceItemsInfo = ToInvoiceItemFromSaleOrderItem(objSaleOrderItemsInfo);
                objInvoiceItemsInfo.FK_ICShipmentItemID = o.ICShipmentItemID;
                objInvoiceItemsInfo.ARInvoiceItemProductQty = o.ICShipmentItemProductQty;
                InvoiceItemList.Add(objInvoiceItemsInfo);
            });
            InvoiceItemList.GridControl.RefreshDataSource();
        }

        public ARInvoiceItemsInfo ToInvoiceItemFromSaleOrderItem(ARSaleOrderItemsInfo objSaleOrderItemsInfo)
        {
            return new ARInvoiceItemsInfo()
            {
                //FK_ARSaleOrderID = objSaleOrderItemsInfo.FK_ARSaleOrderID,
                //FK_ARSaleOrderItemID = objSaleOrderItemsInfo.ARSaleOrderItemID,
                FK_ICProductID = objSaleOrderItemsInfo.FK_ICProductID,
                FK_ICDepartmentID = objSaleOrderItemsInfo.FK_ICDepartmentID,
                FK_ICMeasureUnitID = objSaleOrderItemsInfo.FK_ICMeasureUnitID,
                FK_ICProductGroupID = objSaleOrderItemsInfo.FK_ICProductGroupID,
                ARInvoiceItemProductNo = objSaleOrderItemsInfo.ARSaleOrderItemProductNo,
                ARInvoiceItemProductName = objSaleOrderItemsInfo.ARSaleOrderItemProductName,
                ARInvoiceItemProductDesc = objSaleOrderItemsInfo.ARSaleOrderItemProductDesc,
                ARInvoiceItemProductType = objSaleOrderItemsInfo.ARSaleOrderItemProductType,
                ARInvoiceItemProductQty = objSaleOrderItemsInfo.ARSaleOrderItemProductQty,
                ARInvoiceItemProductUnitPrice = objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice,
                ARInvoiceItemDiscountAmount = objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount,
                ARInvoiceItemDiscountPercent = objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent,
                ARInvoiceItemTaxAmount = objSaleOrderItemsInfo.ARSaleOrderItemTaxAmount,
                ARInvoiceItemTaxPercent = objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent,
                ARInvoiceItemTotalAmount = objSaleOrderItemsInfo.ARSaleOrderItemTotalAmount
            };
        }
    }
}
