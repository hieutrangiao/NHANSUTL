﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HREmployeeOTs
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HREmployeeOTsController
    //Created Date:Sunday, December 15, 2019
    //-----------------------------------------------------------

    public class HREmployeeOTsController : BaseBusinessController
    {
        public HREmployeeOTsController()
        {
            dal = new DALBaseProvider("HREmployeeOTs", typeof(HREmployeeOTsInfo));
        }

        public DataSet GetAllDataByOverTimeID(int overTimeID)
        {
            return dal.GetDataSet("HREmployeeOTs_GetAllDataByOverTimeID", overTimeID);
        }

        public List<HREmployeeOTsInfo> GetEmployeeOTList(int? employeeID, DateTime dateFrom, DateTime dateTo)
        {
            DataSet ds = dal.GetDataSet("HREmployeeOTs_GetEmployeeOTList", employeeID, dateFrom, dateTo);
            List<HREmployeeOTsInfo> list = new List<HREmployeeOTsInfo>();
            HREmployeeOTsController objOverTimesController = new HREmployeeOTsController();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeeOTsInfo objEmployeeOTsInfo = (HREmployeeOTsInfo)objOverTimesController.GetObjectFromDataRow(row);
                    list.Add(objEmployeeOTsInfo);
                }
            }
            return list;
        }

        public List<HREmployeeOTsInfo> GetAllListOTByDate(DateTime dateFrom, DateTime dateTo)
        {
            DataSet ds = dal.GetDataSet("HREmployeeOTs_GetAllListOTByDate", dateFrom, dateTo);
            List<HREmployeeOTsInfo> list = new List<HREmployeeOTsInfo>();
            HREmployeeOTsController objOverTimesController = new HREmployeeOTsController();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeeOTsInfo objEmployeeOTsInfo = (HREmployeeOTsInfo)objOverTimesController.GetObjectFromDataRow(row);
                    list.Add(objEmployeeOTsInfo);
                }
            }
            return list;
        }

        public List<HREmployeeOTsInfo> GetListOTDiffDates(int? employeeID, DateTime dateFrom, DateTime dateTo)
        {
            DataSet ds = dal.GetDataSet("HREmployeeOTs_GetListOTDiffDates", employeeID, dateFrom, dateTo);
            List<HREmployeeOTsInfo> list = new List<HREmployeeOTsInfo>();
            HREmployeeOTsController objOverTimesController = new HREmployeeOTsController();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeeOTsInfo objEmployeeOTsInfo = (HREmployeeOTsInfo)objOverTimesController.GetObjectFromDataRow(row);
                    list.Add(objEmployeeOTsInfo);
                }
            }
            return list;
        }
    }
    #endregion
}