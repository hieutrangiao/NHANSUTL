using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaLib;
using VinaERP.Common.Constant;
using System.Data;

namespace VinaERP.Modules.CustomerPayment
{
    public class CustomerPaymentEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<ARCustomerPaymentDetailsInfo> CustomerPaymentDetailsList { get; set; }

        public VinaList<ARCustomerPaymentTimePaymentsInfo> CustomerPaymentTimePaymentsList { get; set; }
        #endregion

        #region Constructor
        public CustomerPaymentEntities()
        {
            CustomerPaymentTimePaymentsList = new VinaList<ARCustomerPaymentTimePaymentsInfo>();
            CustomerPaymentDetailsList = new VinaList<ARCustomerPaymentDetailsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ARCustomerPaymentsInfo();
            SearchObject = new ARCustomerPaymentsInfo();
        }

        public override void InitModuleObjectList()
        {
            CustomerPaymentTimePaymentsList.InitVinaList(this,
                                            "ARCustomerPayments",
                                            "ARCustomerPaymentTimePayments",
                                            VinaList<ARCustomerPaymentTimePaymentsInfo>.cstRelationForeign);
            CustomerPaymentTimePaymentsList.ItemTableForeignKey = "FK_ARCustomerPaymentID";

            CustomerPaymentDetailsList.InitVinaList(this,
                                            "ARCustomerPayments",
                                            "ARCustomerPaymentDetails",
                                            VinaList<ARCustomerPaymentDetailsInfo>.cstRelationForeign);
            CustomerPaymentDetailsList.ItemTableForeignKey = "FK_ARCustomerPaymentID";
        }

        public override void InitGridControlInVinaList()
        {
            CustomerPaymentTimePaymentsList.InitVinaListGridControl();
            CustomerPaymentDetailsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)MainObject;
            mainObject.ARCustomerPaymentDate = DateTime.Now;
            mainObject.ARCustomerPaymentStatus = "New";
            mainObject.ARCustomerPaymentExchangeRate = 1;
            mainObject.FK_HREmployeeID = VinaApp.CurrentUserInfo.FK_HREmployeeID;

            UpdateMainObjectBindingSource();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                CustomerPaymentTimePaymentsList.SetDefaultListAndRefreshGridControl();
                List<ARCustomerPaymentDetailsInfo> paymentDetails = GetDefaultPaymentMethods();
                CustomerPaymentDetailsList.Invalidate(paymentDetails);
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        public override void InvalidateModuleObjects(int iObjectID)
        {
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)MainObject;
            CustomerPaymentTimePaymentsList.Invalidate(iObjectID);
            ARCustomerPaymentDetailsController objCustomerPaymentDetailsController = new ARCustomerPaymentDetailsController();
            DataSet ds = objCustomerPaymentDetailsController.GetAllDataByForeignColumn("FK_ARCustomerPaymentID", mainObject.ARCustomerPaymentID);
            CustomerPaymentDetailsList.Invalidate(ds);
        }

        public override void SaveModuleObjects()
        {
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)MainObject;
            CustomerPaymentTimePaymentsList.SaveItemObjects();
            //Save payment details                 
            if (Module.Toolbar.IsNewAction())
            {
                CustomerPaymentModule.CreateCustomerPaymentDetails(mainObject, CustomerPaymentDetailsList);
            }
            else
            {
                CustomerPaymentModule.UpdateCustomerPaymentDetails(mainObject, CustomerPaymentDetailsList);
            }
        }

        public void UpdateTotalAmount()
        {
            ARCustomerPaymentsInfo mainObject = (ARCustomerPaymentsInfo)MainObject;

            foreach(ARCustomerPaymentTimePaymentsInfo item in CustomerPaymentTimePaymentsList)
            {
                item.ARCustomerPaymentTimePaymentPercent = item.ARCustomerPaymentTimePaymentAmount / item.ARCustomerPaymentTimePaymentTotalAmount * 100;
            }
            mainObject.ARCustomerPaymentTotalAmount = CustomerPaymentTimePaymentsList.Sum(p => p.ARCustomerPaymentTimePaymentAmount);
            VinaApp.RoundByCurrency(mainObject, "ARCustomerPaymentTotalAmount", mainObject.FK_GECurrencyID);

            mainObject.ARCustomerPaymentExchangeAmount = mainObject.ARCustomerPaymentExchangeRate * mainObject.ARCustomerPaymentTotalAmount;
            VinaApp.RoundByCurrency(mainObject, "ARCustomerPaymentExchangeAmount", mainObject.FK_GECurrencyID);

            UpdateMainObjectBindingSource();
        }

        private List<ARCustomerPaymentDetailsInfo> GetDefaultPaymentMethods()
        {
            ARCustomerPaymentDetailsController objCustomerPaymentDetailsController = new ARCustomerPaymentDetailsController();
            List<ARCustomerPaymentDetailsInfo> paymentDetailList = objCustomerPaymentDetailsController.GetDefaultPaymentDetails();
            paymentDetailList = paymentDetailList.Where(p =>
                                    p.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.Cash.ToString() ||
                                    p.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.BankTransfer.ToString() ||
                                    p.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.CashSec.ToString() ||
                                    p.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.DepositTransfer.ToString() ||
                                    p.ARCustomerPaymentDetailPaymentMethodType == PaymentMethod.CreditCard.ToString()).ToList();
            return paymentDetailList;
        }
    }
}
