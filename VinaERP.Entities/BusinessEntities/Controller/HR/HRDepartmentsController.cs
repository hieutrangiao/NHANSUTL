﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HRDepartments
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRDepartmentsController
    //Created Date:Friday, December 13, 2019
    //-----------------------------------------------------------

    public class HRDepartmentsController : BaseBusinessController
    {
        public HRDepartmentsController()
        {
            dal = new DALBaseProvider("HRDepartments", typeof(HRDepartmentsInfo));
        }
    }
    #endregion
}