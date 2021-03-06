﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region HREmployeePayRolls
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HREmployeePayRollsController
    //Created Date:Friday, December 20, 2019
    //-----------------------------------------------------------

    public class HREmployeePayRollsController : BaseBusinessController
    {
        public HREmployeePayRollsController()
        {
            dal = new DALBaseProvider("HREmployeePayRolls", typeof(HREmployeePayRollsInfo));
        }

        public List<HREmployeePayRollsInfo> GetEmployeePayRollByPayRollIDAndUserGroup(int payRollID, int userGroupID)
        {
            DataSet ds = dal.GetDataSet("HREmployeePayRolls_GetEmployeePayRollByPayRollIDAndUserGroup", payRollID, userGroupID);
            return (List<HREmployeePayRollsInfo>)GetListFromDataSet(ds);
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<HREmployeePayRollsInfo> list = new List<HREmployeePayRollsInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HREmployeePayRollsInfo obj = (HREmployeePayRollsInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }
    }
    #endregion
}