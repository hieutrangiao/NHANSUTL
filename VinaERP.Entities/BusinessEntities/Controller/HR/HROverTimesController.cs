﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HROverTimes
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HROverTimesController
    //Created Date:Sunday, December 15, 2019
    //-----------------------------------------------------------

    public class HROverTimesController : BaseBusinessController
    {
        public HROverTimesController()
        {
            dal = new DALBaseProvider("HROverTimes", typeof(HROverTimesInfo));
        }
    }
    #endregion
}