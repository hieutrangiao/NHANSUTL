﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HRTimeKeepers
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRTimeKeepersController
    //Created Date:Friday, December 27, 2019
    //-----------------------------------------------------------

    public class HRTimeKeepersController : BaseBusinessController
    {
        public HRTimeKeepersController()
        {
            dal = new DALBaseProvider("HRTimeKeepers", typeof(HRTimeKeepersInfo));
        }
        public void DeleteDataDuplicateByDate(DateTime? dateFrom, DateTime? dateTo)
        {
            //dal.ExecuteStoredProcedure("HRTimeKeepers_DeleteDataDuplicateByDate", dateFrom, dateTo);
        }

        public List<HRTimeKeepersInfo> GetTimeKeeperByConditions(int? branchID, int? departmentID, int? departmentRoomID, int? departmentRoomGroupItemID, int? employeeID, int? machineID, DateTime? dateFrom, DateTime? dateTo)
        {
            DataSet ds = dal.GetDataSet("HRTimeKeepers_GetTimeKeeperByConditions", branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, machineID, dateFrom, dateTo);
            List<HRTimeKeepersInfo> list = new List<HRTimeKeepersInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HRTimeKeepersInfo obj = (HRTimeKeepersInfo)GetObjectFromDataRow(row);
                    obj.HRTimeKeeperTimeInOutModeName = row["HRTimeKeeperTimeInOutModeName"].ToString();
                    list.Add(obj);
                }
            }
            ds.Dispose();
            return list;
        }

        public List<HRTimeKeepersInfo> GetTimeKeeperByMachineAndDate(int? machineID, DateTime? dateFrom, DateTime? dateTo)
        {
            DataSet ds = dal.GetDataSet("HRTimeKeepers_GetTimeKeeperByMachineAndDate", machineID, dateFrom, dateTo);
            List<HRTimeKeepersInfo> list = new List<HRTimeKeepersInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HRTimeKeepersInfo obj = (HRTimeKeepersInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }

        public int CheckExistData(int machineID, DateTime dateCheck, string employeeNo)
        {
            return Convert.ToInt32(dal.GetSingleValue("HRTimeKeeperCompletes_CheckExistData", machineID, dateCheck, employeeNo));
        }

        public int CheckExistData(int machineID, DateTime dateCheck)
        {
            return Convert.ToInt32(dal.GetSingleValue("HRTimeKeepers_CheckExistData", machineID, dateCheck));
        }

        public int DeleteData(int machineID, DateTime dateCheck)
        {
            return Convert.ToInt32(dal.GetSingleValue("HRTimeKeepers_DeleteData", machineID, dateCheck));
        }
    }
    #endregion
}