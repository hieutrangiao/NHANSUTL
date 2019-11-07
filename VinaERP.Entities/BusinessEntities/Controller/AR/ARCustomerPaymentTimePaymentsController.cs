﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region ARCustomerPaymentTimePayments
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ARCustomerPaymentTimePaymentsController
    //Created Date:Sunday, June 2, 2019
    //-----------------------------------------------------------

    public class ARCustomerPaymentTimePaymentsController : BaseBusinessController
    {
        public ARCustomerPaymentTimePaymentsController()
        {
            dal = new DALBaseProvider("ARCustomerPaymentTimePayments", typeof(ARCustomerPaymentTimePaymentsInfo));
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<ARCustomerPaymentTimePaymentsInfo> CustomerPaymentTimePaymentsList = new List<ARCustomerPaymentTimePaymentsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ARCustomerPaymentTimePaymentsInfo objCustomerPaymentTimePaymentsInfo = (ARCustomerPaymentTimePaymentsInfo)GetObjectFromDataRow(row);
                    CustomerPaymentTimePaymentsList.Add(objCustomerPaymentTimePaymentsInfo);
                }
            }
            return CustomerPaymentTimePaymentsList;
        }

        public List<ARCustomerPaymentTimePaymentsInfo> GetDocumentForCustomerPayment()
        {
            DataSet ds = dal.GetDataSet("ARCustomerPaymentTimePayments_GetDocumentForCustomerPayment");
            return (List<ARCustomerPaymentTimePaymentsInfo>)GetListFromDataSet(ds);
        }
    }
    #endregion
}