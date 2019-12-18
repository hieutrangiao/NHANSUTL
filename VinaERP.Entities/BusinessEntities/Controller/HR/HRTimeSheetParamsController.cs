﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;


namespace VinaERP
{
    #region HRTimeSheetParams
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:HRTimeSheetParamsController
    //Created Date:Thursday, December 12, 2019
    //-----------------------------------------------------------

    public class HRTimeSheetParamsController : BaseBusinessController
    {
        public HRTimeSheetParamsController()
        {
            dal = new DALBaseProvider("HRTimeSheetParams", typeof(HRTimeSheetParamsInfo));
        }

        public override System.Collections.IList GetListFromDataSet(DataSet ds)
        {
            List<HRTimeSheetParamsInfo> timeSheetParamList = new List<HRTimeSheetParamsInfo>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = (HRTimeSheetParamsInfo)GetObjectFromDataRow(row);
                    timeSheetParamList.Add(objTimeSheetParamsInfo);
                }
            }
            return timeSheetParamList;
        }

        public List<HRTimeSheetParamsInfo> GetOTTimeSheetParamsList()
        {
            DataSet ds = dal.GetDataSet("HRTimeSheetParams_GetOTTimeSheetParamList");
            return (List<HRTimeSheetParamsInfo>)GetListFromDataSet(ds);
        }

        public List<HRTimeSheetParamsInfo> GetTimeSheetParamsByTimeSheetType(string timeSheetParamType)
        {
            DataSet ds = dal.GetDataSet("HRTimeSheetParams_GetTimeSheetParamList", timeSheetParamType);
            return (List<HRTimeSheetParamsInfo>)GetListFromDataSet(ds);
        }
    }
    #endregion
}