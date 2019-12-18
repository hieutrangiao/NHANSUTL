﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region HRLeaveDays
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRLeaveDaysController
    //Created Date:Sunday, December 15, 2019
    //-----------------------------------------------------------

    public class HRLeaveDaysController : BaseBusinessController
    {
        public HRLeaveDaysController()
        {
            dal = new DALBaseProvider("HRLeaveDays", typeof(HRLeaveDaysInfo));
        }

        public List<HRLeaveDaysInfo> GetLeaveDayOnYearByHREmployeeID(int? employeeID)
        {
            DataSet ds = dal.GetDataSet("HRLeaveDays_GetLeaveDayOnYearByHREmployeeID", employeeID);
            List<HRLeaveDaysInfo> leaveDays = new List<HRLeaveDaysInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HRLeaveDaysInfo leaveDay = (HRLeaveDaysInfo)GetObjectFromDataRow(row);
                    leaveDays.Add(leaveDay);
                }
            }
            return leaveDays;
        }

        public void DeleteByEmployeeIDAndDate(int employeeID, DateTime date)
        {
            dal.ExecuteStoredProcedure("HRLeaveDays_DeleteByEmployeeIDAndDate", employeeID, date);
        }

        public List<HRLeaveDaysInfo> GetLeaveDaysList(int? branchID, int? departmentID, int? departmentRoomID, int? departmentRoomGroupItemID, int? employeeID, DateTime? dateFrom, DateTime? dateTo)
        {
            DataSet ds = dal.GetDataSet("HRLeaveDays_GetLeaveDayList", branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, dateFrom, dateTo);
            return (List<HRLeaveDaysInfo>)GetListFromDataSet(ds);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<HRLeaveDaysInfo> list = new List<HRLeaveDaysInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HRLeaveDaysInfo obj = (HRLeaveDaysInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }
    }
    #endregion
}