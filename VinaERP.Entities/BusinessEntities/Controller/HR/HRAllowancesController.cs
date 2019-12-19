﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HRAllowances
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRAllowancesController
    //Created Date:Sunday, December 15, 2019
    //-----------------------------------------------------------

    public class HRAllowancesController : BaseBusinessController
    {
        public HRAllowancesController()
        {
            dal = new DALBaseProvider("HRAllowances", typeof(HRAllowancesInfo));
        }

        public DataSet GetAllowanceListByEmployeeIDAndAllowanceFromDate(int employeeID, DateTime dateFrom, DateTime dateTo)
        {
            return dal.GetDataSet("HRAllowances_GetAllowanceListByEmployeeIDAndAllowanceFromDate", employeeID, dateFrom, dateTo);
        }
    }
    #endregion
}