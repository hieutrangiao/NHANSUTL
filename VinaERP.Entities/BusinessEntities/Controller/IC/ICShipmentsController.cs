﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region ICShipments
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICShipmentsController
    //Created Date:Saturday, December 1, 2018
    //-----------------------------------------------------------

    public class ICShipmentsController : BaseBusinessController
    {
        public ICShipmentsController()
        {
            dal = new DALBaseProvider("ICShipments", typeof(ICShipmentsInfo));
        }
    }
    #endregion
}