﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region ICPriceCalculationMethods
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICPriceCalculationMethodsController
    //Created Date:Sunday, April 28, 2019
    //-----------------------------------------------------------

    public class ICPriceCalculationMethodsController : BaseBusinessController
    {
        public ICPriceCalculationMethodsController()
        {
            dal = new DALBaseProvider("ICPriceCalculationMethods", typeof(ICPriceCalculationMethodsInfo));
        }
    }
    #endregion
}