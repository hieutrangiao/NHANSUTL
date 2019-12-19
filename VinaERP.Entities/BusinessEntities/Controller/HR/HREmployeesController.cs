﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region HREmployees
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HREmployeesController
    //Created Date:Monday, December 3, 2018
    //-----------------------------------------------------------

    public class HREmployeesController : BaseBusinessController
    {
        public HREmployeesController()
        {
            dal = new DALBaseProvider("HREmployees", typeof(HREmployeesInfo));
        }

        public void UpdateInsAllEmployee(decimal result)
        {
            dal.ExecuteStoredProcedure("HREmployees_UpdateInsAllEmployee", result);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<HREmployeesInfo> list = new List<HREmployeesInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeesInfo obj = (HREmployeesInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }

        public List<HREmployeesInfo> GetAllEmployees()
        {
            DataSet ds = dal.GetAllObject();
            return (List<HREmployeesInfo>)GetListFromDataSet(ds);
        }

        public List<HREmployeesInfo> GetEmployeeList(int? branchID, int? departmentID, int? departmentRoomID, int? departmentRoomGroupItemID, string status)
        {
            DataSet ds = dal.GetDataSet("HREmployees_GetEmployeeList", branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, status);
            List<HREmployeesInfo> employees = new List<HREmployeesInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)GetObjectFromDataRow(row);
                    employees.Add(objEmployeesInfo);
                }
            }
            return employees;
        }

        public HREmployeesInfo GetEmployeeByID(int employeeID)
        {
            DataSet ds = dal.GetDataSet("HREmployees_GetEmployeeByID", employeeID);
            List<HREmployeesInfo> employees = (List<HREmployeesInfo>)GetListFromDataSet(ds);
            if (employees != null && employees.Count > 0)
                return employees[0];
            return null;
        }
    }
    #endregion
}