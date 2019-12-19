﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region ADWorkingShifts
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ADWorkingShiftsController
    //Created Date:Thursday, December 12, 2019
    //-----------------------------------------------------------

    public class ADWorkingShiftsController : BaseBusinessController
    {
        public ADWorkingShiftsController()
        {
            dal = new DALBaseProvider("ADWorkingShifts", typeof(ADWorkingShiftsInfo));
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<ADWorkingShiftsInfo> list = new List<ADWorkingShiftsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ADWorkingShiftsInfo obj = (ADWorkingShiftsInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }

        public List<ADWorkingShiftsInfo> GetWorkingShiftsByEmployeePayrollFormulaID(int employeePayrollFormulaID, bool isDefault)
        {
            DataSet ds = dal.GetDataSet("ADWorkingShifts_GetWorkingShiftsByEmployeePayrollFormulaID", employeePayrollFormulaID, isDefault);
            return (List<ADWorkingShiftsInfo>)GetListFromDataSet(ds);
        }
    }
    #endregion
}