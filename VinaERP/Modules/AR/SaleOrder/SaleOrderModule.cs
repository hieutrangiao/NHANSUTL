using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant;
using VinaERP.Common.Constant.IC;
using VinaERP.Common.Constant.ST;
using VinaERP.Modules.SaleOrder.UI;
using VinaERP.Report;
using VinaERP.Utilities.GenaralLeadger;
using VinaERP.Utilities.Helper;
using VinaLib;

namespace VinaERP.Modules.SaleOrder
{
    public class SaleOrderModule : BaseModuleERP
    {
        public SaleOrderModule()
        {
            this.CurrentModuleName = "SaleOrder";
            CurrentModuleEntity = new SaleOrderEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }
        public void AddItemFromSaleOrderItemsList(int productID)
        {
            if (Toolbar.IsNullOrNoneAction() || productID <= 0)
                return;

            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = objProductsController.GetObjectByID(productID) as ICProductsInfo;
            if (objProductsInfo == null)
                return;

            SaleOrderEntities entity = CurrentModuleEntity as SaleOrderEntities;
            ARSaleOrderItemsInfo objSaleOrderItemsInfo = objProductsInfo.ToSaleOrderItem();
            entity.SaleOrderItemsList.Add(objSaleOrderItemsInfo);
            entity.SaleOrderItemsList.GridControl.RefreshDataSource();
            UpdateTotalAmount();
        }

        public override int ActionSave()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)CurrentModuleEntity.MainObject;
            SetDefaultSaleOrderName();
            List<string> errorList = new List<string>();
            if (mainObject.FK_ARCustomerID == 0)
            {
                errorList.Add("Khách hàng không được để trống!");
            }
            if (mainObject.FK_GEPaymentTermID == 0)
            {
                errorList.Add("Điều khoản thanh toán không được bỏ trống!");
            }
            if (string.IsNullOrWhiteSpace(mainObject.ARSaleOrderPaymentMethodType))
            {
                errorList.Add("Phương thức thanh toán không được bỏ trống!");
            }
            if (mainObject.FK_GECurrencyID == 0 || mainObject.ARSaleOrderExchangeRate == 0)
            {
                errorList.Add("Vui lòng chọn loại tiền tề và tỷ giá!");
            }
            entity.SaleOrderItemsList.ForEach(o =>
            {
                if (o.ARSaleOrderItemGrantedFrom == ProductGrantedFrom.Inventory && o.FK_ICStockID == 0)
                {
                    errorList.Add("Vui lòng chọn kho cho sản phẩm có mã: " + o.ARSaleOrderItemProductNo);
                }
            });
            if (errorList.Count() > 0)
            {
                GuiErrorMessage guiError = new GuiErrorMessage(errorList);
                guiError.Module = this;
                guiError.ShowDialog();
                return 0;
            }
            return base.ActionSave();
        }

        public void ChangeCustomer(int customerID)
        {
            if (Toolbar.IsNullOrNoneAction() || customerID <= 0)
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)CurrentModuleEntity.MainObject;
            ARCustomersController objCustomersController = new ARCustomersController();
            ARCustomersInfo objCustomersInfo = objCustomersController.GetObjectByID(customerID) as ARCustomersInfo;
            if (objCustomersInfo == null)
                return;
            if (objCustomersInfo.ARCustomerActiveCheck == false)
            {
                MessageBox.Show("Khách hàng này đã bỏ hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mainObject.FK_ARCustomerID = customerID;
            mainObject.ARSaleOrderCustomerName = objCustomersInfo.ARCustomerName;
            mainObject.ARSaleOrderCustomerPhone = string.IsNullOrEmpty(objCustomersInfo.ARCustomerContactPhone1) ? (string.IsNullOrEmpty(objCustomersInfo.ARCustomerContactPhone2) ? string.Empty : objCustomersInfo.ARCustomerContactPhone2) : objCustomersInfo.ARCustomerContactPhone1;
            mainObject.FK_GECurrencyID = objCustomersInfo.FK_GECurrencyID;
            mainObject.FK_GEPaymentTermID = objCustomersInfo.FK_GEPaymentTermID;
            mainObject.ARSaleOrderPaymentMethodType = string.IsNullOrEmpty(objCustomersInfo.ARCustomerPaymentMethod) ? string.Empty : objCustomersInfo.ARCustomerPaymentMethod;
            mainObject.ARSaleOrderCustomerTaxCode = objCustomersInfo.ARCustomerTaxNumber;
            mainObject.ARSaleOrderCustomerAddress = objCustomersInfo.ARCustomerContactAddress;
            mainObject.ARSaleOrderCustomerDeliveryName = objCustomersInfo.ARCustomerName;
            mainObject.ARSaleOrderCustomerDeliveryPhone = mainObject.ARSaleOrderCustomerPhone;
            mainObject.ARSaleOrderCustomerDeliveryAddress = mainObject.ARSaleOrderCustomerAddress;
            mainObject.ARSaleOrderCustomerDeliveryAddress = mainObject.ARSaleOrderCustomerAddress;
            entity.UpdateMainObjectBindingSource();
        }

        public void GeneratePaymentTime(int paymentTermID)
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;

            GEPaymentTermsController objPaymentTermsController = new GEPaymentTermsController();
            GEPaymentTermsInfo objPaymentTermsInfo = objPaymentTermsController.GetObjectByID(paymentTermID) as GEPaymentTermsInfo;
            if (objPaymentTermsInfo == null)
                return;

            GEPaymentTermItemsController objPaymentTermItemsController = new GEPaymentTermItemsController();
            List<GEPaymentTermItemsInfo> paymentTermItems = objPaymentTermItemsController.GetListItemByPaymentTermID(paymentTermID);
            if (paymentTermItems.Count() <= 0)
                return;

            mainObject.FK_GEPaymentTermID = paymentTermID;
            if (entity.SaleOrderPaymentTimeList.Count() > 0)
                entity.SaleOrderPaymentTimeList.Clear();

            if (mainObject.ARSaleOrderTotalAmount == 0)
                return;

            ARSaleOrderPaymentTimesInfo objPayment;
            paymentTermItems.ForEach(o =>
            {
                objPayment = new ARSaleOrderPaymentTimesInfo();
                objPayment.ARSaleOrderPaymentTimePaymentType = o.GEPaymentTermItemPaymentType;
                objPayment.ARSaleOrderPaymentTimeStatus = "New";
                objPayment.ARSaleOrderPaymentTimeAmount = mainObject.ARSaleOrderTotalAmount * o.GEPaymentTermItemPaymentPercent / 100;
                objPayment.ARSaleOrderPaymentTimeDueAmount = mainObject.ARSaleOrderTotalAmount * o.GEPaymentTermItemPaymentPercent / 100;
                objPayment.FK_GEPaymentTermID = paymentTermID;
                objPayment.ARSaleOrderPaymentTimePaymentMethod = mainObject.ARSaleOrderPaymentMethodType;
                objPayment.FK_ARSaleOrderID = mainObject.ARSaleOrderID;
                objPayment.ARSaleOrderPaymentTimePaymentTermItemPaymentTime = o.GEPaymentTermItemPaymentTime;
                objPayment.ARSaleOrderPaymentTimePaymentTermItemDay = o.GEPaymentTermItemDay;
                objPayment.ARSaleOrderPaymentTimePaymentTermItemPercentPayment = o.GEPaymentTermItemPaymentPercent;
                objPayment.ARSaleOrderPaymentTimePaymentTermItemPaymentType = o.GEPaymentTermItemPaymentType;
                objPayment.ARSaleOrderPaymentTimePaymentTermItemType = o.GEPaymentTermItemPaymentType;
                objPayment.FK_GEPaymentTermItemID = o.GEPaymentTermItemID;
                if (o.GEPaymentTermItemPaymentTime == "IsContract")
                {
                    if (mainObject.ARSaleOrderDate.Date != DateTime.MaxValue.Date && mainObject.ARSaleOrderDate.Date != DateTime.MinValue.Date)
                    {
                        objPayment.ARSaleOrderPaymentTimeDate = mainObject.ARSaleOrderDate;
                        objPayment.ARSaleOrderPaymentTimeDueDate = mainObject.ARSaleOrderDate;
                    }
                }
                if (o.GEPaymentTermItemPaymentTime == "IsBeforeDelivery")
                {
                    if (mainObject.ARSaleOrderDeliveryDate.Date != DateTime.MaxValue.Date && mainObject.ARSaleOrderDeliveryDate.Date != DateTime.MinValue.Date)
                    {
                        objPayment.ARSaleOrderPaymentTimeDate = mainObject.ARSaleOrderDeliveryDate.AddDays(-o.GEPaymentTermItemDay);
                        objPayment.ARSaleOrderPaymentTimeDueDate = mainObject.ARSaleOrderDeliveryDate.AddDays(-o.GEPaymentTermItemDay);
                    }
                }
                if (o.GEPaymentTermItemPaymentTime == "IsAfterDelivery")
                {
                    if (mainObject.ARSaleOrderDeliveryDate.Date != DateTime.MaxValue.Date && mainObject.ARSaleOrderDeliveryDate.Date != DateTime.MinValue.Date)
                    {
                        objPayment.ARSaleOrderPaymentTimeDate = mainObject.ARSaleOrderDeliveryDate.AddDays(o.GEPaymentTermItemDay);
                        objPayment.ARSaleOrderPaymentTimeDueDate = mainObject.ARSaleOrderDeliveryDate.AddDays(o.GEPaymentTermItemDay);
                    }
                }
                if (o.GEPaymentTermItemPaymentTime == "IsSaleOrder")
                {
                    if (mainObject.ARSaleOrderDeliveryDate.Date != DateTime.MaxValue.Date && mainObject.ARSaleOrderDeliveryDate.Date != DateTime.MinValue.Date)
                    {
                        objPayment.ARSaleOrderPaymentTimeDate = mainObject.ARSaleOrderDeliveryDate.AddDays(o.GEPaymentTermItemDay);
                        objPayment.ARSaleOrderPaymentTimeDueDate = mainObject.ARSaleOrderDeliveryDate.AddDays(o.GEPaymentTermItemDay);
                    }
                }
                VinaApp.RoundByCurrency(objPayment, mainObject.FK_GECurrencyID);
                entity.SaleOrderPaymentTimeList.Add(objPayment);
                entity.SaleOrderPaymentTimeList.GridControl.RefreshDataSource();
            });
        }

        public void SaleOrderPaymentMethod(string paymentMethod)
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;

            entity.SaleOrderPaymentTimeList.ForEach(o =>
            {
                o.ARSaleOrderPaymentTimePaymentMethod = mainObject.ARSaleOrderPaymentMethodType;
            });
            entity.SaleOrderPaymentTimeList.GridControl.RefreshDataSource();
        }


        public void DeleteItemFromSaleOrderItemsList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            entity.SaleOrderItemsList.RemoveSelectedRowObjectFromList();
            UpdateTotalAmount();
        }

        public void DeleteItemFromSaleOrderPaymentTimeList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            entity.SaleOrderPaymentTimeList.RemoveSelectedRowObjectFromList();
        }

        public void ChangeDiscountPercent()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            UpdateTotalAmount();
        }

        public void ChangeTaxPercent()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            UpdateTotalAmount();
        }

        public void ChangeDiscountAmount()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            if (mainObject.ARSaleOrderSubTotalAmount != 0)
                mainObject.ARSaleOrderDiscountPercent = 100 * mainObject.ARSaleOrderDiscountAmount / mainObject.ARSaleOrderSubTotalAmount;
            else
                mainObject.ARSaleOrderDiscountPercent = 0;
            mainObject.ARSaleOrderDiscountPercent = Math.Round(mainObject.ARSaleOrderDiscountPercent, 2, MidpointRounding.AwayFromZero);
            UpdateTotalAmount();
        }

        public void ChangeTaxAmount()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            if (mainObject.ARSaleOrderSubTotalAmount - mainObject.ARSaleOrderDiscountAmount != 0)
                mainObject.ARSaleOrderTaxPercent = 100 * mainObject.ARSaleOrderTaxAmount / (mainObject.ARSaleOrderSubTotalAmount - mainObject.ARSaleOrderDiscountAmount);
            else
                mainObject.ARSaleOrderTaxPercent = 0;
            mainObject.ARSaleOrderTaxPercent = Math.Round(mainObject.ARSaleOrderTaxPercent, 2, MidpointRounding.AwayFromZero);
            UpdateTotalAmount();
        }

        public void ChangeItemFromSaleOrderItemsList(ARSaleOrderItemsInfo objSaleOrderItemsInfo)
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            if (objSaleOrderItemsInfo == null)
                return;

            objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount = (objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent / 100) * (objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice);
            objSaleOrderItemsInfo.ARSaleOrderItemTaxAmount = (objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent / 100) * (objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice - objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount);
            objSaleOrderItemsInfo.ARSaleOrderItemTotalAmount = objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice - objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount + objSaleOrderItemsInfo.ARSaleOrderItemTaxAmount;
            entity.SaleOrderItemsList.GridControl.RefreshDataSource();
            UpdateTotalAmount();
        }

        public void UpdateTotalAmount()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)CurrentModuleEntity.MainObject;
            entity.UpdateTotalAmount();
            GeneratePaymentTime(mainObject.FK_GEPaymentTermID);
        }

        public void SetDefaultSaleOrderName()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)CurrentModuleEntity.MainObject;

            if (!String.IsNullOrWhiteSpace(mainObject.ARSaleOrderName))
                return;

            if (mainObject.FK_ARCustomerID == 0)
                return;

            mainObject.ARSaleOrderName = string.Format("Bán hàng cho {0}", mainObject.ARSaleOrderCustomerName);
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            ParentScreen.SetEnableOfToolbarButton("Approved", false);
            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.ARSaleOrderID > 0)
            {
                ParentScreen.SetEnableOfToolbarButton("Approved", true);
                if (mainObject.ARSaleOrderStatus == "Approved")
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                    ParentScreen.SetEnableOfToolbarButton("Approved", false);
                }
            }
        }

        public override void ActionApproved()
        {
            base.ActionApproved();
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            List<ARSaleOrderItemsInfo> invetoryCheckList = new List<ARSaleOrderItemsInfo>();
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = new ICProductsInfo();
            entity.SaleOrderItemsList.ForEach(o =>
            {
                objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(o.FK_ICProductID);
                if (objProductsInfo == null)
                    return;

                if (o.ARSaleOrderItemGrantedFrom == ProductGrantedFrom.Inventory)
                    invetoryCheckList.Add((ARSaleOrderItemsInfo)o.Clone());
            });
            if (!IsValidInventoryStockQty(invetoryCheckList))
            {
                return;
            }
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            ARSaleOrdersController objSaleOrdersController = new ARSaleOrdersController();
            mainObject.ARSaleOrderStatus = "Approved";
            entity.UpdateMainObject();
            GLHelper.PostedTransactions(CurrentModuleName, mainObject.ARSaleOrderID, ModulePostingType.SaleOrder);
            InvalidateToolbar();
        }

        public bool IsValidInventoryStockQty(List<ARSaleOrderItemsInfo> saleOrderItemList)
        {
            bool isValid = true;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)CurrentModuleEntity.MainObject;
            List<ARSaleOrderItemsInfo> mergeList = MergeSaleOrderItemSameProduct(saleOrderItemList);
            ICTransactionsController objTransactionsController = new ICTransactionsController();
            decimal inventoryStockQty = 0;
            List<string> errorMessagesList = new List<string>();
            mergeList.ForEach(o =>
            {
                inventoryStockQty = objTransactionsController.GetAvailabilityQtyForSale(o.FK_ICProductID, o.FK_ICStockID, o.ARSaleOrderItemStockLotNo, mainObject.ARSaleOrderDate);
                if (inventoryStockQty >= o.ARSaleOrderItemProductQty)
                    return;

                errorMessagesList.Add(string.Format("Sản phẩm {0} không đủ tồn kho. Vui lòng kiểm tra lại!", o.ARSaleOrderItemProductNo));
            });
            if(errorMessagesList.Count() > 0)
            {
                GuiErrorMessage guiErrorMessage = new GuiErrorMessage(errorMessagesList);
                guiErrorMessage.Module = this;
                guiErrorMessage.ShowDialog();
                return false;
            }
            return isValid;
        }

        public List<ARSaleOrderItemsInfo> MergeSaleOrderItemSameProduct(List<ARSaleOrderItemsInfo> saleOrderItemList)
        {
            List<ARSaleOrderItemsInfo> mergeList = new List<ARSaleOrderItemsInfo>();
            mergeList = saleOrderItemList.GroupBy(o => new { o.FK_ICProductID, o.ARSaleOrderItemProductNo, o.FK_ICStockID, o.ARSaleOrderItemStockLotNo })
                                         .Select(o => new ARSaleOrderItemsInfo()
                                         {
                                             FK_ICProductID = o.Key.FK_ICProductID,
                                             ARSaleOrderItemProductNo = o.Key.ARSaleOrderItemProductNo,
                                             FK_ICStockID = o.Key.FK_ICStockID,
                                             ARSaleOrderItemStockLotNo = o.Key.ARSaleOrderItemStockLotNo,
                                             ARSaleOrderItemProductQty = o.Sum(item => item.ARSaleOrderItemProductQty)
                                         }).ToList();
            return mergeList;
        }

        public void ChangeCurrency(int currencyID)
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            mainObject.FK_GECurrencyID = currencyID;
            GECurrenciesInfo objCurrenciesInfo = VinaApp.CurrencyList.Where(o => o.GECurrencyID == currencyID).FirstOrDefault();
            mainObject.ARSaleOrderExchangeRate = objCurrenciesInfo == null ? 1 : objCurrenciesInfo.GECurrencyTransferRate;
            entity.UpdateMainObjectBindingSource();
            ChangeExchangeRate();
        }

        public void ChangeExchangeRate()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            entity.SaleOrderItemsList.ForEach(o =>
            {
                if (mainObject.ARSaleOrderExchangeRate != 0)
                    o.ARSaleOrderItemProductUnitPrice = o.ARSaleOrderItemProductBasicPrice / mainObject.ARSaleOrderExchangeRate;
                else
                    o.ARSaleOrderItemProductUnitPrice = 0;

                ChangeItemFromSaleOrderItemsList(o);
            });
            entity.SaleOrderItemsList.GridControl.RefreshDataSource();
            UpdateTotalAmount();
        }

        public void ChangeItemDiscountAmount()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrderItemsInfo objSaleOrderItemsInfo = entity.SaleOrderItemsList[entity.SaleOrderItemsList.CurrentIndex];
            if (objSaleOrderItemsInfo == null)
                return;

            if (objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount != 0 && (objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice) != 0)
                objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent = 100 * objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount / (objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice);
            else
                objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent = 0;
            objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent = Math.Round(objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent, 2, MidpointRounding.AwayFromZero);
            entity.SaleOrderItemsList.GridControl.RefreshDataSource();
        }

        public void ChangeItemTaxAmount()
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrderItemsInfo objSaleOrderItemsInfo = entity.SaleOrderItemsList[entity.SaleOrderItemsList.CurrentIndex];
            if (objSaleOrderItemsInfo == null)
                return;

            if (objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice - objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount > 0)
                objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent = 100 * objSaleOrderItemsInfo.ARSaleOrderItemTaxAmount / (objSaleOrderItemsInfo.ARSaleOrderItemProductQty * objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice - objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount);
            else
                objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent = 0;

            objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent = Math.Round(objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent, 2, MidpointRounding.AwayFromZero);
            entity.SaleOrderItemsList.GridControl.RefreshDataSource();
        }

        public override void ActionNew()
        {
            base.ActionNew();
        }

        public void ActionNewFromProposal()
        {
            ActionNew();
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            ARProposalsController objProposalsController = new ARProposalsController();
            List<ARProposalsInfo> proposalList = objProposalsController.GetAllProposalForOderring();
            guichooseProposal guiFind = new guichooseProposal(proposalList);
            guiFind.Module = this;
            guiFind.ShowDialog();
            if (guiFind.DialogResult != DialogResult.OK)
                return;
            ARProposalsInfo objProposalsInfo = (ARProposalsInfo)guiFind.SelectedObjects[0];
            if(objProposalsInfo != null)
            {
                mainObject.FK_ARCustomerID = objProposalsInfo.FK_ARCustomerID;
                mainObject.FK_ARProposalID = objProposalsInfo.ARProposalID;
                mainObject.FK_GECurrencyID = objProposalsInfo.FK_GECurrencyID;
                mainObject.ARSaleOrderDesc = objProposalsInfo.ARProposalDesc;
                mainObject.ARSaleOrderExchangeRate = objProposalsInfo.ARProposalExchangeRate;
                mainObject.ARSaleOrderPaymentMethodType = objProposalsInfo.ARProposalPaymentMethod;
                mainObject.ARSaleOrderSubTotalAmount = objProposalsInfo.ARProposalSubTotalAmount;
                mainObject.ARSaleOrderDiscountPercent = objProposalsInfo.ARProposalDiscountPerCent;
                mainObject.ARSaleOrderDiscountAmount = objProposalsInfo.ARProposalDiscountAmount;
                mainObject.ARSaleOrderTaxPercent = objProposalsInfo.ARProposalTaxPercent;
                mainObject.ARSaleOrderTaxAmount = objProposalsInfo.ARProposalTaxAmount;
                mainObject.ARSaleOrderTotalAmount = objProposalsInfo.ARProposalTotalAmount;
            }
            proposalList.Clear();
            proposalList = (List<ARProposalsInfo>)guiFind.SelectedObjects;
            proposalList.ForEach(o =>
            {
                ARProposalItemsController objProposalItemsController = new ARProposalItemsController();
                List<ARProposalItemsInfo> proposalItems = objProposalItemsController.GetAllItemByProopsalID(o.ARProposalID);
                proposalItems.ForEach(p =>
                {
                    ARSaleOrderItemsInfo objSaleOrderItemsInfo = new ARSaleOrderItemsInfo();
                    objSaleOrderItemsInfo.FK_ICProductID = p.FK_ICProductID;
                    objSaleOrderItemsInfo.FK_ICMeasureUnitID = p.FK_ICMeasureUnitID;
                    objSaleOrderItemsInfo.ARSaleOrderItemProductNo = p.ARProposalItemProductNo;
                    objSaleOrderItemsInfo.ARSaleOrderItemProductName = p.ARProposalItemProductName;
                    objSaleOrderItemsInfo.ARSaleOrderItemProductDesc = p.ARProposalItemDesc;
                    objSaleOrderItemsInfo.ARSaleOrderItemProductUnitPrice = p.ARProposalItemPrice;
                    objSaleOrderItemsInfo.ARSaleOrderItemProductQty = p.ARProposalItemQty;
                    objSaleOrderItemsInfo.ARSaleOrderItemDiscountPercent = p.ARProposalItemDiscountPercent;
                    objSaleOrderItemsInfo.ARSaleOrderItemDiscountAmount = p.ARProposalItemDiscountAmount;
                    objSaleOrderItemsInfo.ARSaleOrderItemTaxPercent = p.ARProposalItemTaxPercent;
                    objSaleOrderItemsInfo.ARSaleOrderItemTaxAmount = p.ARProposalItemTaxAmount;
                    objSaleOrderItemsInfo.ARSaleOrderItemTotalAmount = p.ARProposalItemTotalAmount;
                    entity.SaleOrderItemsList.Add(objSaleOrderItemsInfo);
                });
            });
            ChangeCustomer(mainObject.FK_ARCustomerID);
            entity.UpdateMainObjectBindingSource();
            entity.SaleOrderItemsList.GridControl.RefreshDataSource();
        }

        public void PrintOrder()
        {
            if (!Toolbar.IsNullOrNoneAction())
                return;
            ARSaleOrder report = new ARSaleOrder();
            InitializeSaleOrderReport(report);
            guiReportPreview reportPreview = new guiReportPreview(report);
            reportPreview.Show();
        }

        public void InitializeSaleOrderReport(ARSaleOrder report)
        {
            SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
            ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
            ARSaleOrderItemsController objSaleOrderItemsController = new ARSaleOrderItemsController();
            List<ARSaleOrderItemsInfo> soItemList = objSaleOrderItemsController.GetItemForSaleOrderReport(mainObject.ARSaleOrderID);
            report.bsARSaleOrderItems.DataSource = soItemList;
        }
    }
}
