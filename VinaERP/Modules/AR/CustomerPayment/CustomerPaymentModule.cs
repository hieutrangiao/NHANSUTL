using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant;
using VinaERP.Common.Constant.IC;
using VinaERP.Common.Constant.ST;
using VinaERP.Modules.CustomerPayment.UI;
using VinaERP.Utilities.GenaralLeadger;
using VinaERP.Utilities.Helper;
using VinaLib;

namespace VinaERP.Modules.CustomerPayment
{
    public class CustomerPaymentModule : BaseModuleERP
    {
        #region Constant
        public const string CustomerPaymentDetailsGridControlName = "fld_dgcARCustomerPaymentDetails";
        #endregion

        public CustomerPaymentModule()
        {
            this.CurrentModuleName = "CustomerPayment";
            CurrentModuleEntity = new CustomerPaymentEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();

            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentDetailsGridControl gridControl = Controls[CustomerPaymentModule.CustomerPaymentDetailsGridControlName] as ARCustomerPaymentDetailsGridControl;
            gridControl.CustomerPaymentDetailList = entity.CustomerPaymentDetailsList;
            gridControl.InitGridControlDataSource();
        }

        public override void ActionNew()
        {
            base.ActionNew();

            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)entity.MainObject;

            ARCustomerPaymentTimePaymentsController objCustomerPaymentTimePaymentsController = new ARCustomerPaymentTimePaymentsController();
            List<ARCustomerPaymentTimePaymentsInfo> listCustomerPaymentTimePaymentsInfo = objCustomerPaymentTimePaymentsController.GetDocumentForCustomerPayment();
            guiChooseCustomerPaymentTimePayments guiFind = new guiChooseCustomerPaymentTimePayments(listCustomerPaymentTimePaymentsInfo);
            guiFind.Module = this;
            DialogResult rs = guiFind.ShowDialog();
            if (rs != DialogResult.OK)
            {
                ActionCancel();
                return;
            }
            listCustomerPaymentTimePaymentsInfo = guiFind.SelectedObjects as List<ARCustomerPaymentTimePaymentsInfo>;

            ARCustomerPaymentTimePaymentsInfo objCustomerPaymentTimePaymentsInfo = listCustomerPaymentTimePaymentsInfo.FirstOrDefault();
            mainObject.FK_ARCustomerID = objCustomerPaymentTimePaymentsInfo.FK_ARCustomerID;
            mainObject.FK_GECurrencyID = objCustomerPaymentTimePaymentsInfo.FK_GECurrencyID;
            mainObject.ARCustomerPaymentPaymentMethodType = objCustomerPaymentTimePaymentsInfo.ARCustomerPaymentPaymentMethodType;
            mainObject.ARCustomerPaymentSenderName = objCustomerPaymentTimePaymentsInfo.ARCustomerPaymentSenderName;

            entity.CustomerPaymentTimePaymentsList.Invalidate(listCustomerPaymentTimePaymentsInfo);
            UpdateTotalAmount();
            entity.UpdateMainObjectBindingSource();
        }

        public void ChangeCustomer(int customerID)
        {
            if (Toolbar.IsNullOrNoneAction() || customerID <= 0)
                return;

            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)CurrentModuleEntity.MainObject;
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
            mainObject.ARCustomerPaymentSenderName = objCustomersInfo.ARCustomerName;
            mainObject.ARCustomerPaymentPaymentMethodType = string.IsNullOrEmpty(objCustomersInfo.ARCustomerPaymentMethod) ? string.Empty : objCustomersInfo.ARCustomerPaymentMethod;
            entity.UpdateMainObjectBindingSource();
        }

        public void ChangeCurrency(int currencyID)
        {
            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)entity.MainObject;
            mainObject.FK_GECurrencyID = currencyID;
            GECurrenciesInfo objCurrenciesInfo = VinaApp.CurrencyList.Where(o => o.GECurrencyID == currencyID).FirstOrDefault();
            mainObject.ARCustomerPaymentExchangeRate = objCurrenciesInfo == null ? 1 : objCurrenciesInfo.GECurrencyTransferRate;
            entity.UpdateMainObjectBindingSource();
            ChangeExchangeRate();
        }

        public void ChangeExchangeRate()
        {
            UpdateTotalAmount();
        }


        public void UpdateTotalAmount()
        {
            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)CurrentModuleEntity.MainObject;
            entity.UpdateTotalAmount();
            ARCustomerPaymentDetailsGridControl gridControl = (ARCustomerPaymentDetailsGridControl)Controls[CustomerPaymentModule.CustomerPaymentDetailsGridControlName];
            gridControl.PaymentAmount = mainObject.ARCustomerPaymentTotalAmount;
            gridControl.ProposeRemainingAmount();
        }

        //public override void InvalidateToolbar()
        //{
        //    base.InvalidateToolbar();
        //    SaleOrderEntities entity = (SaleOrderEntities)CurrentModuleEntity;
        //    ARSaleOrdersInfo mainObject = (ARSaleOrdersInfo)entity.MainObject;
        //    ParentScreen.SetEnableOfToolbarButton("Approved", false);
        //    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
        //    if (mainObject.ARSaleOrderID > 0)
        //    {
        //        ParentScreen.SetEnableOfToolbarButton("Approved", true);
        //        if (mainObject.ARSaleOrderStatus == "Approved")
        //        {
        //            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
        //            ParentScreen.SetEnableOfToolbarButton("Approved", false);
        //        }
        //    }
        //}

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);

            ARCustomerPaymentsInfo objCustomerPaymentsInfo = (ARCustomerPaymentsInfo)CurrentModuleEntity.MainObject;
            ARCustomerPaymentDetailsGridControl gridControl = (ARCustomerPaymentDetailsGridControl)Controls[CustomerPaymentModule.CustomerPaymentDetailsGridControlName];
            gridControl.PaymentAmount = objCustomerPaymentsInfo.ARCustomerPaymentTotalAmount;
        }

        public override int ActionSave()
        {
            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)CurrentModuleEntity.MainObject;
            SetDefaultCustomerPaymentName();
            List<string> errorList = new List<string>();
            if (mainObject.FK_ARCustomerID == 0)
            {
                errorList.Add("Khách hàng không được để trống!");
            }
            if (string.IsNullOrWhiteSpace(mainObject.ARCustomerPaymentPaymentMethodType))
            {
                errorList.Add("Phương thức thanh toán không được bỏ trống!");
            }
            if (mainObject.FK_GECurrencyID == 0 || mainObject.ARCustomerPaymentExchangeRate == 0)
            {
                errorList.Add("Vui lòng chọn loại tiền tề và tỷ giá!");
            }
            entity.CustomerPaymentTimePaymentsList.ForEach(p =>
            {
                if (p.ARCustomerPaymentTimePaymentAmount > p.ARCustomerPaymentTimePaymentRemainAmount)
                {
                    errorList.Add("Số tiền thanh toán vượt quá số tiền còn lại!");
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

        public void SetDefaultCustomerPaymentName()
        {
            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)CurrentModuleEntity.MainObject;

            if (!String.IsNullOrWhiteSpace(mainObject.ARCustomerPaymentName))
                return;

            if (mainObject.FK_ARCustomerID == 0)
                return;

            mainObject.ARCustomerPaymentName = string.Format("Thu tiền của khách hàng {0}", mainObject.ARCustomerPaymentSenderName);
        }

        public void DeleteItemFromCustomerPaymentTimePaymentsList()
        {
            if (Toolbar.IsNullOrNoneAction())
                return;

            CustomerPaymentEntities entity = (CustomerPaymentEntities)CurrentModuleEntity;
            entity.CustomerPaymentTimePaymentsList.RemoveSelectedRowObjectFromList();
            UpdateTotalAmount();
        }

        public static void CreateCustomerPaymentDetails(ARCustomerPaymentsInfo objCustomerPaymentsInfo, List<ARCustomerPaymentDetailsInfo> lstPaymentDetails)
        {
            ARCustomerPaymentDetailsController objCustomerPaymentDetailsController = new ARCustomerPaymentDetailsController();
            if (lstPaymentDetails != null)
            {
                foreach (ARCustomerPaymentDetailsInfo objCustomerPaymentDetailsInfo in lstPaymentDetails)
                {
                    objCustomerPaymentDetailsInfo.FK_ARCustomerPaymentID = objCustomerPaymentsInfo.ARCustomerPaymentID;
                    objCustomerPaymentDetailsController.CreateObject(objCustomerPaymentDetailsInfo);
                }
            }
        }

        public static void UpdateCustomerPaymentDetails(ARCustomerPaymentsInfo customerPayment, List<ARCustomerPaymentDetailsInfo> paymentDetails)
        {
            ARCustomerPaymentDetailsController objCustomerPaymentDetailsController = new ARCustomerPaymentDetailsController();
            List<ARCustomerPaymentDetailsInfo> oldPaymentDetails = objCustomerPaymentDetailsController.GetDetailsByPaymentID(customerPayment.ARCustomerPaymentID);

            foreach (ARCustomerPaymentDetailsInfo oldPaymentDetail in oldPaymentDetails)
            {
                //RollbackRelativeDataOfPaymentDetail((ARCustomerPaymentDetailsInfo)oldPaymentDetail);
            }
            foreach (ARCustomerPaymentDetailsInfo paymentDetail in paymentDetails)
            {
                ARCustomerPaymentDetailsInfo oldPaymentDetail = oldPaymentDetails.Where(pd => pd.ARCustomerPaymentDetailPaymentMethodType == paymentDetail.ARCustomerPaymentDetailPaymentMethodType).FirstOrDefault();
                if (oldPaymentDetail != null)
                {
                    //UpdateRelativeDataOfPaymentDetail(paymentDetail, customerPayment.FK_ARCustomerID);

                    paymentDetail.FK_ARCustomerPaymentID = oldPaymentDetail.FK_ARCustomerPaymentID;
                    paymentDetail.ARCustomerPaymentDetailID = oldPaymentDetail.ARCustomerPaymentDetailID;
                    objCustomerPaymentDetailsController.UpdateObject(paymentDetail);
                }
            }
        }

        //private static void UpdateRelativeDataOfPaymentDetail(ARCustomerPaymentDetailsInfo paymentDetail, int customerID)
        //{
        //    VinaDbUtil dbUtil = new VinaDbUtil();
        //    if (paymentDetail.ARCustomerPaymentDetailAmount != 0)
        //    {
        //        if (paymentDetail.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.Account.ToString())
        //        {
        //            ARCustomersController objCustomersController = new ARCustomersController();
        //            ARCustomersInfo objCustomersInfo = (ARCustomersInfo)objCustomersController.GetObjectByID(customerID);
        //            if (objCustomersInfo != null)
        //            {
        //                objCustomersInfo.AAUpdatedUser = VinaApp.CurrentUserName;
        //                objCustomersInfo.AAUpdatedDate = DateTime.Now;
        //                objCustomersInfo.ARCustomer += paymentDetail.ARCustomerPaymentDetailAmount;
        //                objCustomersController.UpdateObject(objCustomersInfo);
        //            }
        //        }
        //        else if (paymentDetail.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.OwingExchange.ToString())
        //        {
        //            ARInvoicesController objInvoicesController = new ARInvoicesController();
        //            string[] invoiceNumbers = paymentDetail.ARCustomerPaymentDetailInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //            decimal paymentAmount = paymentDetail.ARCustomerPaymentDetailAmount;
        //            for (int i = 0; i < invoiceNumbers.Length; i++)
        //            {
        //                string invoiceNo = invoiceNumbers[i].Trim();
        //                if (paymentAmount > 0)
        //                {
        //                    ARInvoicesInfo invoice = (ARInvoicesInfo)objInvoicesController.GetObjectByNo(invoiceNo);
        //                    if (invoice != null)
        //                    {
        //                        decimal dueAmount = Math.Min(Math.Abs(invoice.ARInvoiceBalanceDue), paymentAmount);
        //                        invoice.ARInvoiceBalanceDue += dueAmount;
        //                        objInvoicesController.UpdateObject(invoice);
        //                        paymentAmount -= dueAmount;
        //                        dbUtil.SetPropertyValue(paymentDetail, string.Format("ARCustomerPaymentDetailSubAmount{0}", i + 1), dueAmount);
        //                    }
        //                }
        //            }
        //        }
        //        else if (paymentDetail.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.CreditNote.ToString() ||
        //                paymentDetail.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.GiftVoucher.ToString())
        //        {
        //            ARCreditNotesController objCreditNotesController = new ARCreditNotesController();
        //            string[] creditNoteNumbers = paymentDetail.ARCustomerPaymentDetailInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //            decimal paymentAmount = paymentDetail.ARCustomerPaymentDetailAmount;
        //            for (int i = 0; i < creditNoteNumbers.Length; i++)
        //            {
        //                string creditNoteNo = creditNoteNumbers[i].Trim();
        //                if (paymentAmount > 0)
        //                {
        //                    ARCreditNotesInfo objCreditNotesInfo = (ARCreditNotesInfo)objCreditNotesController.GetObjectByNo(creditNoteNo);
        //                    if (objCreditNotesInfo != null)
        //                    {
        //                        decimal dueAmount = Math.Min(objCreditNotesInfo.ARCreditNoteTotalAmount - objCreditNotesInfo.ARCreditNoteDueAmount, paymentAmount);
        //                        objCreditNotesInfo.ARCreditNoteDueAmount += dueAmount;
        //                        objCreditNotesController.UpdateObject(objCreditNotesInfo);
        //                        paymentAmount -= dueAmount;
        //                        dbUtil.SetPropertyValue(paymentDetail, string.Format("ARCustomerPaymentDetailSubAmount{0}", i + 1), dueAmount);
        //                    }
        //                }
        //            }
        //        }
        //        else if (paymentDetail.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.DepositTransfer.ToString())
        //        {
        //            ARCustomerPaymentsController customerPaymentController = new ARCustomerPaymentsController();
        //            ARSaleOrdersController saleOrderController = new ARSaleOrdersController();

        //            string[] customerPaymentNumbers = paymentDetail.ARCustomerPaymentDetailInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //            decimal paymentAmount = paymentDetail.ARCustomerPaymentDetailAmount;
        //            for (int i = 0; i < customerPaymentNumbers.Length; i++)
        //            {
        //                string customerPaymentNo = customerPaymentNumbers[i].Trim();
        //                if (paymentAmount > 0)
        //                {
        //                    ARCustomerPaymentsInfo customerPayment = (ARCustomerPaymentsInfo)customerPaymentController.GetObjectByNo(customerPaymentNo);
        //                    if (customerPayment != null)
        //                    {
        //                        ARSaleOrdersInfo saleOrder = saleOrderController.GetSaleOrderByDepositNo(customerPaymentNo);
        //                        decimal transferedAmount = customerPaymentController.GetTransferedDepositAmountByASpecifiedDeposit(customerPayment.ARCustomerPaymentNo);
        //                        decimal balance = customerPayment.ARCustomerPaymentTotalAmount - transferedAmount;
        //                        decimal dueAmount = Math.Min(Math.Abs(balance), paymentAmount);
        //                        saleOrder.ARSaleOrderDepositBalance -= dueAmount;
        //                        saleOrder.ARSaleOrderBalanceDue += dueAmount;
        //                        saleOrderController.UpdateObject(saleOrder);
        //                        paymentAmount -= dueAmount;
        //                        dbUtil.SetPropertyValue(paymentDetail, string.Format("ARCustomerPaymentDetailSubAmount{0}", i + 1), dueAmount);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //public static void RollbackRelativeDataOfPaymentDetail(ARCustomerPaymentDetailsInfo paymentDetail)
        //{
        //    BOSDbUtil dbUtil = new BOSDbUtil();
        //    if (paymentDetail.ARPaymentMethodCombo == PaymentMethod.OwingExchange.ToString())
        //    {
        //        ARInvoicesController objInvoicesController = new ARInvoicesController();
        //        string[] invoiceNumbers = paymentDetail.ARCustomerPaymentDetailInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        decimal paymentAmount = paymentDetail.ARCustomerPaymentDetailAmount;
        //        for (int i = 0; i < invoiceNumbers.Length; i++)
        //        {
        //            string invoiceNo = invoiceNumbers[i].Trim();
        //            if (paymentAmount > 0)
        //            {
        //                ARInvoicesInfo invoice = (ARInvoicesInfo)objInvoicesController.GetObjectByNo(invoiceNo);
        //                if (invoice != null)
        //                {
        //                    decimal dueAmount = Convert.ToDecimal(dbUtil.GetPropertyValue(paymentDetail, string.Format("ARCustomerPaymentDetailSubAmount{0}", i + 1)));
        //                    invoice.ARInvoiceBalanceDue -= dueAmount;
        //                    objInvoicesController.UpdateObject(invoice);
        //                    paymentAmount -= dueAmount;
        //                }
        //            }
        //        }
        //    }
        //    else if (paymentDetail.ARPaymentMethodCombo == PaymentMethod.CreditNote.ToString() ||
        //               paymentDetail.ARPaymentMethodCombo == PaymentMethod.GiftVoucher.ToString())
        //    {
        //        ARCreditNotesController objCreditNotesController = new ARCreditNotesController();
        //        string[] creditNoteNumbers = paymentDetail.ARCustomerPaymentDetailInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        decimal paymentAmount = paymentDetail.ARCustomerPaymentDetailAmount;
        //        for (int i = 0; i < creditNoteNumbers.Length; i++)
        //        {
        //            string creditNoteNo = creditNoteNumbers[i].Trim();
        //            if (paymentAmount > 0)
        //            {
        //                ARCreditNotesInfo objCreditNotesInfo = (ARCreditNotesInfo)objCreditNotesController.GetObjectByNo(creditNoteNo);
        //                if (objCreditNotesInfo != null)
        //                {
        //                    decimal dueAmount = Convert.ToDecimal(dbUtil.GetPropertyValue(paymentDetail, string.Format("ARCustomerPaymentDetailSubAmount{0}", i + 1)));
        //                    objCreditNotesInfo.ARCreditNoteDueAmount -= dueAmount;
        //                    objCreditNotesController.UpdateObject(objCreditNotesInfo);
        //                    paymentAmount -= dueAmount;
        //                }
        //            }
        //        }
        //    }
        //    else if (paymentDetail.ARPaymentMethodCombo == PaymentMethod.DepositTransfer.ToString())
        //    {
        //        ARCustomerPaymentsController customerPaymentController = new ARCustomerPaymentsController();
        //        ARSaleOrdersController saleOrderController = new ARSaleOrdersController();

        //        string[] customerPaymentNumbers = paymentDetail.ARCustomerPaymentDetailInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        decimal paymentAmount = paymentDetail.ARCustomerPaymentDetailAmount;
        //        for (int i = 0; i < customerPaymentNumbers.Length; i++)
        //        {
        //            string customerPaymentNo = customerPaymentNumbers[i].Trim();
        //            if (paymentAmount > 0)
        //            {
        //                ARCustomerPaymentsInfo customerPayment = (ARCustomerPaymentsInfo)customerPaymentController.GetObjectByNo(customerPaymentNo);
        //                if (customerPayment != null)
        //                {
        //                    ARSaleOrdersInfo saleOrder = saleOrderController.GetSaleOrderByDepositNo(customerPaymentNo);
        //                    decimal dueAmount = Convert.ToDecimal(dbUtil.GetPropertyValue(paymentDetail, string.Format("ARCustomerPaymentDetailSubAmount{0}", i + 1)));
        //                    saleOrder.ARSaleOrderDepositBalance += dueAmount;
        //                    saleOrder.ARSaleOrderBalanceDue -= dueAmount;
        //                    saleOrderController.UpdateObject(saleOrder);
        //                    paymentAmount -= dueAmount;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
