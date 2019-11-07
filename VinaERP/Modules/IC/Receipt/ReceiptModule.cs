using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant;
using VinaERP.Common.Constant.IC;
using VinaERP.Report;
using VinaERP.Utilities.GenaralLeadger;
using VinaERP.Utilities.Helper;
using VinaLib;

namespace VinaERP.Modules.Receipt
{
    public class ReceiptModule : GLReceiptModule
    {
        public ReceiptModule()
        {
            this.CurrentModuleName = "Receipt";
            CurrentModuleEntity = new ReceiptEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainobject = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            entity.ReceiptItemsList.EndCurrentEdit();
            entity.UpdateTotalAmount();
            List<string> errorMessages = new List<string>();
            if (mainobject.FK_ICStockID == 0)
            {
                errorMessages.Add("Kho không được bỏ trống!");
            }
            if (mainobject.FK_GECurrencyID == 0 || mainobject.ICReceiptExchangeRate == 0)
            {
                errorMessages.Add("Vui lòng chọn loại tiền tề và tỷ giá!");
            }
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = new ICProductsInfo();
            entity.ReceiptItemsList.ForEach(o =>
            {
                objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(o.FK_ICProductID);
                if (objProductsInfo.ICPriceCalculationMethodType == PriceCalculationMethod.Specific && string.IsNullOrWhiteSpace(o.ICReceiptItemStockLotNo))
                    errorMessages.Add("Vui lòng nhập mã lô cho sản phẩm: " + o.ICReceiptItemProductNo);
            });
            if (errorMessages.Count() > 0)
            {
                GuiErrorMessage guiError = new GuiErrorMessage(errorMessages);
                guiError.Module = this;
                guiError.ShowDialog();
                return 0;
            }
            int iObjectID = base.ActionSave();
            if (iObjectID > 0)
            {
                this.ActionComplete();
            }
            return iObjectID;
        }

        public override void ActionComplete()
        {
            base.ActionComplete();
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainobject = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            mainobject.ICReceiptStatus = ReceiptStatus.Complete;
            entity.UpdateMainObject();
            ActionPosted();
        }

        public void AddItemToReceiptItemsList(int productID)
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainobject = (ICReceiptsInfo)CurrentModuleEntity.MainObject;

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo == null)
                return;

            ICReceiptItemsInfo objReceiptItemsInfo = objProductsInfo.ToReceiptItem();
            entity.ReceiptItemsList.Add(objReceiptItemsInfo);
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
            entity.UpdateTotalAmount();
            entity.UpdateMainObjectBindingSource();
        }

        public void ChangeStock(int stockID)
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainobject = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            mainobject.FK_ICStockID = stockID;
            entity.UpdateMainObjectBindingSource();
            DialogResult rs = MessageBox.Show("Bạn có muốn thay đổi kho cho toàn bộ sản phẩm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;

            entity.ReceiptItemsList.ForEach(o =>
            {
                o.FK_ICStockID = stockID;
                o.ICReceiptItemStockLotNo = string.Empty;
            });

            entity.ReceiptItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeReceiptProductLotNo()
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thay đổi mã lô hàng cho toàn bộ sản phẩm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;

            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainobject = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = new ICProductsInfo();
            entity.ReceiptItemsList.ForEach(o =>
            {
                objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(o.FK_ICProductID);
                if (objProductsInfo == null)
                    return;

                if (objProductsInfo.ICPriceCalculationMethodType != PriceCalculationMethod.Specific)
                    return;

                o.ICReceiptItemStockLotNo = mainobject.ICReceiptProductLotNo;
            });
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
        }

        public override void InvalidateToolbar()
        {
            ICReceiptsInfo receipt = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            if (receipt.ICReceiptID > 0)
            {
                //ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit,
                        receipt.ICReceiptPostedStatus != PostedTransactionStatus.Posted.ToString());
            }

            base.InvalidateToolbar();
        }

        public void ChangeCurrency(int currencyID)
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainObject = (ICReceiptsInfo)entity.MainObject;
            mainObject.FK_GECurrencyID = currencyID;
            GECurrenciesInfo objCurrenciesInfo = VinaApp.CurrencyList.Where(o => o.GECurrencyID == currencyID).FirstOrDefault();
            mainObject.ICReceiptExchangeRate = objCurrenciesInfo == null ? 1 : objCurrenciesInfo.GECurrencyTransferRate;
            ChangeExchangeRate();
            entity.UpdateMainObjectBindingSource();
        }

        public void ChangeExchangeRate()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainObject = (ICReceiptsInfo)entity.MainObject;
            entity.ReceiptItemsList.ForEach(o =>
            {
                if (mainObject.ICReceiptExchangeRate != 0)
                    o.ICReceiptItemProductUnitPrice = o.ICReceiptItemProductBasicPrice / mainObject.ICReceiptExchangeRate;
                else
                    o.ICReceiptItemProductUnitPrice = 0;

                ChangeItemFromReceiptItemsList(o);
            });
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
            entity.UpdateTotalAmount();
        }

        public void DeleteItemFromReceiptItemList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            entity.ReceiptItemsList.RemoveSelectedRowObjectFromList();
            entity.UpdateTotalAmount();
        }

        public void ChangeItemMeasureUnit()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptItemsInfo objReceiptItemsInfo = entity.ReceiptItemsList[entity.ReceiptItemsList.CurrentIndex];
            if (objReceiptItemsInfo == null)
                return;

            ICProductMeasureUnitsController controller = new ICProductMeasureUnitsController();
            ICProductMeasureUnitsInfo measureUnit = controller.GetProductMeasureUnitByProductIDAndMeasureUnitID(objReceiptItemsInfo.FK_ICProductID, objReceiptItemsInfo.FK_ICMeasureUnitID);
            objReceiptItemsInfo.ICReceiptItemProductFactor = measureUnit.ICProductMeasureUnitFactor;
            objReceiptItemsInfo.ICReceiptItemProductExchangeQty = objReceiptItemsInfo.ICReceiptItemProductQty * objReceiptItemsInfo.ICReceiptItemProductFactor;
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeItemDiscountAmount()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptItemsInfo objReceiptItemsInfo = entity.ReceiptItemsList[entity.ReceiptItemsList.CurrentIndex];
            if (objReceiptItemsInfo == null)
                return;

            if (objReceiptItemsInfo.ICReceiptItemDiscountAmount != 0 && (objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice) != 0)
                objReceiptItemsInfo.ICReceiptItemDiscountPercent = 100 * objReceiptItemsInfo.ICReceiptItemDiscountAmount / (objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice);
            else
                objReceiptItemsInfo.ICReceiptItemDiscountPercent = 0;
            objReceiptItemsInfo.ICReceiptItemDiscountPercent = Math.Round(objReceiptItemsInfo.ICReceiptItemDiscountPercent, 2, MidpointRounding.AwayFromZero);
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeItemTaxAmount()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptItemsInfo objReceiptItemsInfo = entity.ReceiptItemsList[entity.ReceiptItemsList.CurrentIndex];
            if (objReceiptItemsInfo == null)
                return;

            if (objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice - objReceiptItemsInfo.ICReceiptItemDiscountAmount > 0)
                objReceiptItemsInfo.ICReceiptItemTaxPercent = 100 * objReceiptItemsInfo.ICReceiptItemTaxAmount / (objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice - objReceiptItemsInfo.ICReceiptItemDiscountAmount);
            else
                objReceiptItemsInfo.ICReceiptItemTaxPercent = 0;

            objReceiptItemsInfo.ICReceiptItemTaxPercent = Math.Round(objReceiptItemsInfo.ICReceiptItemTaxPercent, 2, MidpointRounding.AwayFromZero);
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeItemFromReceiptItemsList(ICReceiptItemsInfo objReceiptItemsInfo)
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            if (objReceiptItemsInfo == null)
                return;

            objReceiptItemsInfo.ICReceiptItemProductExchangeQty = objReceiptItemsInfo.ICReceiptItemProductQty * objReceiptItemsInfo.ICReceiptItemProductFactor;
            objReceiptItemsInfo.ICReceiptItemDiscountAmount = (objReceiptItemsInfo.ICReceiptItemDiscountPercent / 100) * (objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice);
            objReceiptItemsInfo.ICReceiptItemTaxAmount = (objReceiptItemsInfo.ICReceiptItemTaxPercent / 100) * (objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice - objReceiptItemsInfo.ICReceiptItemDiscountAmount);
            objReceiptItemsInfo.ICReceiptItemTotalAmount = objReceiptItemsInfo.ICReceiptItemProductExchangeQty * objReceiptItemsInfo.ICReceiptItemProductUnitPrice - objReceiptItemsInfo.ICReceiptItemDiscountAmount + objReceiptItemsInfo.ICReceiptItemTaxAmount;
            entity.ReceiptItemsList.GridControl.RefreshDataSource();
            entity.UpdateTotalAmount();
        }

        public void ChangeDiscountPercent()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            entity.UpdateTotalAmount();
        }

        public void ChangeTaxPercent()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            entity.UpdateTotalAmount();
        }

        public void ChangeDiscountAmount()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainObject = (ICReceiptsInfo)entity.MainObject;
            if (mainObject.ICReceiptSubTotalAmount != 0)
                mainObject.ICReceiptDiscountPercent = 100 * mainObject.ICReceiptDiscountAmount / mainObject.ICReceiptSubTotalAmount;
            else
                mainObject.ICReceiptDiscountPercent = 0;
            mainObject.ICReceiptDiscountPercent = Math.Round(mainObject.ICReceiptDiscountPercent, 2, MidpointRounding.AwayFromZero);
            entity.UpdateTotalAmount();
        }

        public void ChangeTaxAmount()
        {
            ReceiptEntities entity = (ReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo mainObject = (ICReceiptsInfo)entity.MainObject;
            if (mainObject.ICReceiptSubTotalAmount - mainObject.ICReceiptDiscountAmount != 0)
                mainObject.ICReceiptTaxPercent = 100 * mainObject.ICReceiptTaxAmount / (mainObject.ICReceiptSubTotalAmount - mainObject.ICReceiptDiscountAmount);
            else
                mainObject.ICReceiptTaxPercent = 0;
            mainObject.ICReceiptTaxPercent = Math.Round(mainObject.ICReceiptTaxPercent, 2, MidpointRounding.AwayFromZero);
            entity.UpdateTotalAmount();
        }
    }
}
