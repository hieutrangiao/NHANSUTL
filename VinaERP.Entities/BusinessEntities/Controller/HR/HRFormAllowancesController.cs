﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;
using System.Collections;

namespace VinaERP
{
    #region HRFormAllowances
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRFormAllowancesController
    //Created Date:Tuesday, December 10, 2019
    //-----------------------------------------------------------

    public class HRFormAllowancesController : BaseBusinessController
    {
        public HRFormAllowancesController()
        {
            dal = new DALBaseProvider("HRFormAllowances", typeof(HRFormAllowancesInfo));
        }

        public override IList GetListFromDataSet(DataSet ds)
        {
            List<HRFormAllowancesInfo> list = new List<HRFormAllowancesInfo>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HRFormAllowancesInfo obj = (HRFormAllowancesInfo)GetObjectFromDataRow(row);
                    list.Add(obj);
                }
            }
            return list;
        }

        public List<HRFormAllowancesInfo> GetAllFormAllowances()
        {
            DataSet ds = dal.GetAllObject();
            return (List<HRFormAllowancesInfo>)GetListFromDataSet(ds);
        }
    }
    #endregion
}