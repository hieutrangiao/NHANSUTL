﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HRArrangementShifts
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRArrangementShiftsController
    //Created Date:Thursday, December 19, 2019
    //-----------------------------------------------------------

    public class HRArrangementShiftsController : BaseBusinessController
    {
        public HRArrangementShiftsController()
        {
            dal = new DALBaseProvider("HRArrangementShifts", typeof(HRArrangementShiftsInfo));
        }
    }
    #endregion
}