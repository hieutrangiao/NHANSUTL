﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region HREmployeeTimeSheetOTDetails
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HREmployeeTimeSheetOTDetailsController
    //Created Date:Thursday, December 19, 2019
    //-----------------------------------------------------------

    public class HREmployeeTimeSheetOTDetailsController : BaseBusinessController
    {
        public HREmployeeTimeSheetOTDetailsController()
        {
            dal = new DALBaseProvider("HREmployeeTimeSheetOTDetails", typeof(HREmployeeTimeSheetOTDetailsInfo));
        }

        public List<HREmployeeTimeSheetOTDetailsInfo> GetListTimeSheetOTDetailByEmployeeTimeSheet(int employeeTimeSheetID)
        {
            DataSet ds = dal.GetDataSet("HREmployeeTimeSheetOTDetails_GetListTimeSheetOTDetailByEmployeeTimeSheet", employeeTimeSheetID);
            return (List<HREmployeeTimeSheetOTDetailsInfo>)GetListFromDataSet(ds);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<HREmployeeTimeSheetOTDetailsInfo> list = new List<HREmployeeTimeSheetOTDetailsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeeTimeSheetOTDetailsInfo obj = (HREmployeeTimeSheetOTDetailsInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }
    }
    #endregion
}