﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region APSuppliers
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:APSuppliersController
    //Created Date:13 Tháng Năm 2019
    //-----------------------------------------------------------

    public class APSuppliersController : BaseBusinessController
    {
        public APSuppliersController()
        {
            dal = new DALBaseProvider("APSuppliers", typeof(APSuppliersInfo));
        }
    }
    #endregion
}