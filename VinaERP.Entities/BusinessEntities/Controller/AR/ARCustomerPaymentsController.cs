﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region ARCustomerPayments
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ARCustomerPaymentsController
    //Created Date:Friday, May 31, 2019
    //-----------------------------------------------------------

    public class ARCustomerPaymentsController : BaseBusinessController
    {
        public ARCustomerPaymentsController()
        {
            dal = new DALBaseProvider("ARCustomerPayments", typeof(ARCustomerPaymentsInfo));
        }
    }
    #endregion
}