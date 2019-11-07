using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant;
using VinaERP.Common.Constant.IC;
using VinaERP.Modules.SaleOrderShipment.UI;
using VinaERP.Report;
using VinaERP.Utilities.GenaralLeadger;
using VinaERP.Utilities.Helper;
using VinaLib;
using VinaERP.Report;

namespace VinaERP.Modules.SaleOrderShipment
{
    public class SaleOrderShipmentModule : GLShipmentModule
    {
        public SaleOrderShipmentModule()
        {
            this.CurrentModuleName = "SaleOrderShipment";
            CurrentModuleEntity = new SaleOrderShipmentEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            SaleOrderShipmentEntities entity = CurrentModuleEntity as SaleOrderShipmentEntities;
            ICShipmentsInfo mainobject = entity.MainObject as ICShipmentsInfo;
            entity.ShipmentItemsList.EndCurrentEdit();
            entity.UpdateTotalAmount();
            List<string> errorMessages = new List<string>();
            if (mainobject.FK_ICStockID == 0)
            {
                errorMessages.Add("Kho không được bỏ trống!");
            }
            if (mainobject.FK_GECurrencyID == 0 || mainobject.ICShipmentExchangeRate == 0)
            {
                errorMessages.Add("Vui lòng chọn loại tiền tề và tỷ giá!");
            }
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = new ICProductsInfo();
            entity.ShipmentItemsList.ForEach(o =>
            {
                objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(o.FK_ICProductID);
                if (objProductsInfo.ICPriceCalculationMethodType == PriceCalculationMethod.Specific && string.IsNullOrWhiteSpace(o.ICShipmentItemStockLotNo))
                    errorMessages.Add("Vui lòng nhập mã lô cho sản phẩm: " + o.ICShipmentItemProductNo);
            });
            if (errorMessages.Count() > 0)
            {
                GuiErrorMessage guiError = new GuiErrorMessage(errorMessages);
                guiError.Module = this;
                guiError.ShowDialog();
                return 0;
            }

            SetDefaultShipmentName();
            return base.ActionSave();
        }

        public void AddItemFromSaleOrderShipmentItemsList(int productID)
        {
            if (Toolbar.IsNullOrNoneAction() || productID == 0)
                return;

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo == null)
                return;

            SaleOrderShipmentEntities entity = CurrentModuleEntity as SaleOrderShipmentEntities;
            entity.ShipmentItemsList.Add(objProductsInfo.ToShipmentItem());
            entity.ShipmentItemsList.GridControl.RefreshDataSource();
            entity.UpdateTotalAmount();
        }

        public void NewFromManual()
        {
            base.ActionNew();
        }

        public void NewFromSaleOrder()
        {
            base.ActionNew();
            SaleOrderShipmentEntities entity = CurrentModuleEntity as SaleOrderShipmentEntities;
            ICShipmentsInfo mainobject = entity.MainObject as ICShipmentsInfo;

            ARSaleOrderItemsController objSaleOrderItemsController = new ARSaleOrderItemsController();
            List<ARSaleOrderItemsInfo> saleOrderItems = objSaleOrderItemsController.GetSaleOrderItemForSaleOrderShipment();

            guiChooseSaleOrderItem guiFind = new guiChooseSaleOrderItem(saleOrderItems);
            guiFind.Module = this;
            DialogResult rs = guiFind.ShowDialog();
            if (rs != DialogResult.OK)
            {
                ActionCancel();
                return;
            }
            saleOrderItems = guiFind.SelectedObjects;
            ARSaleOrderItemsInfo objSaleOrderItemsInfo = saleOrderItems.FirstOrDefault();

            if (objSaleOrderItemsInfo == null)
                objSaleOrderItemsInfo = new ARSaleOrderItemsInfo();

            ARSaleOrdersController objSaleOrdersController = new ARSaleOrdersController();
            ARSaleOrdersInfo objSaleOrdersInfo = (ARSaleOrdersInfo)objSaleOrdersController.GetObjectByID(objSaleOrderItemsInfo.FK_ARSaleOrderID);
            if (objSaleOrdersInfo == null)
                objSaleOrdersInfo = new ARSaleOrdersInfo();

            mainobject.FK_ARSaleOrderID = objSaleOrdersInfo.ARSaleOrderID;
            mainobject.FK_ARCustomerID = objSaleOrdersInfo.FK_ARCustomerID;
            mainobject.ICShipmentDiscountPercent = objSaleOrdersInfo.ARSaleOrderDiscountPercent;
            mainobject.ICShipmentTaxPercent = objSaleOrdersInfo.ARSaleOrderTaxPercent;
            mainobject.FK_GECurrencyID = objSaleOrdersInfo.FK_GECurrencyID;
            mainobject.ICShipmentExchangeRate = objSaleOrdersInfo.ARSaleOrderExchangeRate;
            mainobject.ICShipmentDeliveryDate = objSaleOrdersInfo.ARSaleOrderDeliveryDate;
            List<ICShipmentItemsInfo> shipmentItemList = new List<ICShipmentItemsInfo>();
            ICShipmentItemsInfo objShipmentItemsInfo = new ICShipmentItemsInfo();
            saleOrderItems.ForEach(o =>
            {
                objShipmentItemsInfo = new ICShipmentItemsInfo();
                objShipmentItemsInfo = o.ToShipmentItem();
                shipmentItemList.Add(objShipmentItemsInfo);
            });
            entity.ShipmentItemsList.Invalidate(shipmentItemList);
            entity.UpdateMainObjectBindingSource();
            entity.UpdateTotalAmount();
        }

        public void DeleteItemFromShipmentItemsList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            entity.ShipmentItemsList.RemoveSelectedRowObjectFromList();
            entity.UpdateTotalAmount();
        }

        public void SetDefaultShipmentName()
        {
            SaleOrderShipmentEntities entity = CurrentModuleEntity as SaleOrderShipmentEntities;
            ICShipmentsInfo mainObject = entity.MainObject as ICShipmentsInfo;

            if (!String.IsNullOrWhiteSpace(mainObject.ICShipmentName))
                return;

            if (mainObject.FK_ARSaleOrderID == 0)
                return;

            ARSaleOrdersController objSaleOrdersController = new ARSaleOrdersController();
            ARSaleOrdersInfo objSaleOrdersInfo = objSaleOrdersController.GetObjectByID(mainObject.FK_ARSaleOrderID) as ARSaleOrdersInfo;
            if (objSaleOrdersInfo == null)
                return;

            mainObject.ICShipmentName = string.Format("Chứng từ xuất kho của đơn bán hàng {0}", objSaleOrdersInfo.ARSaleOrderNo);
        }

        public override void InvalidateToolbar()
        {
            SaleOrderShipmentEntities entity = CurrentModuleEntity as SaleOrderShipmentEntities;
            ICShipmentsInfo mainObject = entity.MainObject as ICShipmentsInfo;

            base.InvalidateToolbar();
            if (mainObject.ICShipmentID > 0)
            {
                ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit,
                        mainObject.ICShipmentPostedStatus != PostedTransactionStatus.Posted.ToString());

                if (mainObject.ICShipmentStatus == ShipmentStatus.Complete)
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                }
            }
        }

        public void ChangeCurrency(int currencyID)
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainObject = (ICShipmentsInfo)entity.MainObject;
            mainObject.FK_GECurrencyID = currencyID;
            GECurrenciesInfo objCurrenciesInfo = VinaApp.CurrencyList.Where(o => o.GECurrencyID == currencyID).FirstOrDefault();
            mainObject.ICShipmentExchangeRate = objCurrenciesInfo == null ? 1 : objCurrenciesInfo.GECurrencyTransferRate;
            ChangeExchangeRate();
            entity.UpdateMainObjectBindingSource();
        }

        public void ChangeExchangeRate()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainObject = (ICShipmentsInfo)entity.MainObject;
            entity.ShipmentItemsList.ForEach(o =>
            {
                if (mainObject.ICShipmentExchangeRate != 0)
                    o.ICShipmentItemProductUnitPrice = o.ICShipmentItemProductBasicPrice / mainObject.ICShipmentExchangeRate;
                else
                    o.ICShipmentItemProductUnitPrice = 0;

                ChangeItemFromShipmentItemsList(o);
            });
            entity.ShipmentItemsList.GridControl.RefreshDataSource();
            entity.UpdateTotalAmount();
        }

        public void ChangeItemFromShipmentItemsList(ICShipmentItemsInfo objShipmentItemsInfo)
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            if (objShipmentItemsInfo == null)
                return;

            objShipmentItemsInfo.ICShipmentItemProductExchangeQty = objShipmentItemsInfo.ICShipmentItemProductQty * objShipmentItemsInfo.ICShipmentItemProductFactor;
            objShipmentItemsInfo.ICShipmentItemDiscountAmount = (objShipmentItemsInfo.ICShipmentItemDiscountPercent / 100) * (objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice);
            objShipmentItemsInfo.ICShipmentItemTaxAmount = (objShipmentItemsInfo.ICShipmentItemTaxPercent / 100) * (objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice - objShipmentItemsInfo.ICShipmentItemDiscountAmount);
            objShipmentItemsInfo.ICShipmentItemTotalAmount = objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice - objShipmentItemsInfo.ICShipmentItemDiscountAmount + objShipmentItemsInfo.ICShipmentItemTaxAmount;
            entity.ShipmentItemsList.GridControl.RefreshDataSource();
            entity.UpdateTotalAmount();
        }

        public void ChangeDiscountPercent()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            entity.UpdateTotalAmount();
        }

        public void ChangeTaxPercent()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            entity.UpdateTotalAmount();
        }

        public void ChangeDiscountAmount()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainObject = (ICShipmentsInfo)entity.MainObject;
            if (mainObject.ICShipmentSubTotalAmount != 0)
                mainObject.ICShipmentDiscountPercent = 100 * mainObject.ICShipmentDiscountAmount / mainObject.ICShipmentSubTotalAmount;
            else
                mainObject.ICShipmentDiscountPercent = 0;
            mainObject.ICShipmentDiscountPercent = Math.Round(mainObject.ICShipmentDiscountPercent, 2, MidpointRounding.AwayFromZero);
            entity.UpdateTotalAmount();
        }

        public void ChangeTaxAmount()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainObject = (ICShipmentsInfo)entity.MainObject;
            if (mainObject.ICShipmentSubTotalAmount - mainObject.ICShipmentDiscountAmount != 0)
                mainObject.ICShipmentTaxPercent = 100 * mainObject.ICShipmentTaxAmount / (mainObject.ICShipmentSubTotalAmount - mainObject.ICShipmentDiscountAmount);
            else
                mainObject.ICShipmentTaxPercent = 0;
            mainObject.ICShipmentTaxPercent = Math.Round(mainObject.ICShipmentTaxPercent, 2, MidpointRounding.AwayFromZero);
            entity.UpdateTotalAmount();
        }

        public void ChangeItemDiscountAmount()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentItemsInfo objShipmentItemsInfo = entity.ShipmentItemsList[entity.ShipmentItemsList.CurrentIndex];
            if (objShipmentItemsInfo == null)
                return;

            if (objShipmentItemsInfo.ICShipmentItemDiscountAmount != 0 && (objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice) != 0)
                objShipmentItemsInfo.ICShipmentItemDiscountPercent = 100 * objShipmentItemsInfo.ICShipmentItemDiscountAmount / (objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice);
            else
                objShipmentItemsInfo.ICShipmentItemDiscountPercent = 0;
            objShipmentItemsInfo.ICShipmentItemDiscountPercent = Math.Round(objShipmentItemsInfo.ICShipmentItemDiscountPercent, 2, MidpointRounding.AwayFromZero);
            entity.ShipmentItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeItemTaxAmount()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentItemsInfo objShipmentItemsInfo = entity.ShipmentItemsList[entity.ShipmentItemsList.CurrentIndex];
            if (objShipmentItemsInfo == null)
                return;

            if (objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice - objShipmentItemsInfo.ICShipmentItemDiscountAmount > 0)
                objShipmentItemsInfo.ICShipmentItemTaxPercent = 100 * objShipmentItemsInfo.ICShipmentItemTaxAmount / (objShipmentItemsInfo.ICShipmentItemProductExchangeQty * objShipmentItemsInfo.ICShipmentItemProductUnitPrice - objShipmentItemsInfo.ICShipmentItemDiscountAmount);
            else
                objShipmentItemsInfo.ICShipmentItemTaxPercent = 0;

            objShipmentItemsInfo.ICShipmentItemTaxPercent = Math.Round(objShipmentItemsInfo.ICShipmentItemTaxPercent, 2, MidpointRounding.AwayFromZero);
            entity.ShipmentItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeItemMeasureUnit()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentItemsInfo objShipmentItemsInfo = entity.ShipmentItemsList[entity.ShipmentItemsList.CurrentIndex];
            if (objShipmentItemsInfo == null)
                return;

            ICProductMeasureUnitsController controller = new ICProductMeasureUnitsController();
            ICProductMeasureUnitsInfo measureUnit = controller.GetProductMeasureUnitByProductIDAndMeasureUnitID(objShipmentItemsInfo.FK_ICProductID, objShipmentItemsInfo.FK_ICMeasureUnitID);
            objShipmentItemsInfo.ICShipmentItemProductFactor = measureUnit.ICProductMeasureUnitFactor;
            objShipmentItemsInfo.ICShipmentItemProductExchangeQty = objShipmentItemsInfo.ICShipmentItemProductQty * objShipmentItemsInfo.ICShipmentItemProductFactor;
            entity.ShipmentItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeStock(int stockID)
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainobject = (ICShipmentsInfo)CurrentModuleEntity.MainObject;
            mainobject.FK_ICStockID = stockID;
            entity.UpdateMainObjectBindingSource();
            DialogResult rs = MessageBox.Show("Bạn có muốn thay đổi kho cho toàn bộ sản phẩm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;

            entity.ShipmentItemsList.ForEach(o =>
            {
                o.FK_ICStockID = stockID;
                o.ICShipmentItemStockLotNo = string.Empty;
            });

            entity.ShipmentItemsList.GridControl.RefreshDataSource();
        }

        public override void ActionComplete()
        {
            base.ActionComplete();
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainobject = (ICShipmentsInfo)CurrentModuleEntity.MainObject;
            if (!IsValidInventoryStock())
                return;

            mainobject.ICShipmentStatus = ShipmentStatus.Complete;
            entity.UpdateMainObject();
            ActionPosted();
        }

        public bool IsValidInventoryStock()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo mainobject = (ICShipmentsInfo)CurrentModuleEntity.MainObject;
            List<ICShipmentItemsInfo> mergeList = MergeSaleOrderItemSameProduct(entity.ShipmentItemsList.Select(o => (ICShipmentItemsInfo)o.Clone()).ToList());
            ICTransactionsController objTransactionsController = new ICTransactionsController();
            decimal inventoryStockQty = 0;
            List<string> errorMessagesList = new List<string>();
            mergeList.ForEach(o =>
            {
                inventoryStockQty = objTransactionsController.GetAvailabilityQtyForShipment(o.FK_ICProductID, o.FK_ICStockID, o.ICShipmentItemStockLotNo, mainobject.ICShipmentDate);
                if (inventoryStockQty >= o.ICShipmentItemProductQty)
                    return;

                errorMessagesList.Add(string.Format("Sản phẩm {0} không đủ tồn kho. Vui lòng kiểm tra lại!", o.ICShipmentItemProductNo));
            });

            if (errorMessagesList.Count() > 0)
            {
                GuiErrorMessage guiErrorMessage = new GuiErrorMessage(errorMessagesList);
                guiErrorMessage.Module = this;
                guiErrorMessage.ShowDialog();
                return false;
            }
            return true;
        }

        public List<ICShipmentItemsInfo> MergeSaleOrderItemSameProduct(List<ICShipmentItemsInfo> shipmentItemList)
        {
            List<ICShipmentItemsInfo> mergeList = new List<ICShipmentItemsInfo>();
            mergeList = shipmentItemList.GroupBy(o => new { o.FK_ICProductID, o.ICShipmentItemProductNo, o.FK_ICStockID, o.ICShipmentItemStockLotNo })
                                        .Select(o => new ICShipmentItemsInfo()
                                        {
                                            FK_ICProductID = o.Key.FK_ICProductID,
                                            ICShipmentItemProductNo = o.Key.ICShipmentItemProductNo,
                                            FK_ICStockID = o.Key.FK_ICStockID,
                                            ICShipmentItemStockLotNo = o.Key.ICShipmentItemStockLotNo,
                                            ICShipmentItemProductQty = o.Sum(item => item.ICShipmentItemProductQty)
                                        }).ToList();
            return mergeList;
        }
		
		public override void ActionPrint()
        {
            if (!Toolbar.IsNullOrNoneAction())
                return;
            ICSaleOrderShipment report = new ICSaleOrderShipment();
            InitializeSaleOrderShipmentReport(report);
            guiReportPreview reportPreview = new guiReportPreview(report);
            reportPreview.Show();
        }

        public void InitializeSaleOrderShipmentReport(ICSaleOrderShipment report)
        {
            SaleOrderShipmentEntities entity = CurrentModuleEntity as SaleOrderShipmentEntities;
            ICShipmentsInfo mainObject = entity.MainObject as ICShipmentsInfo;
            ICShipmentItemsController objShipmentItemsController = new ICShipmentItemsController();
            List<ICShipmentItemsInfo> shipmentItemList = objShipmentItemsController.GetShipmentItemForReport(mainObject.ICShipmentID);
            report.bsICShipmentItems.DataSource = shipmentItemList;
        }
    }
}
