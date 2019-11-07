﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using VinaLib;

namespace VinaLib
{
    #region ADUserGroupSections
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ADUserGroupSectionsController
    //Created Date:Thursday, November 15, 2018
    //-----------------------------------------------------------

    public class ADUserGroupSectionsController : BaseBusinessController
    {
        public ADUserGroupSectionsController()
        {
            dal = new DALBaseProvider("ADUserGroupSections", typeof(ADUserGroupSectionsInfo));
        }

        public DataSet GetUserGroupSectionByUserGroupID(int iUserGroupID)
        {
            return this.GetDataSet(string.Format("SELECT * FROM ADUserGroupSections WHERE [AAStatus] = 'Alive' AND FK_ADUserGroupID = {0} ORDER BY ADUserGroupSectionSortOrder", (object)iUserGroupID));
        }

        public int GetMaxSortOrderSectionByUserGroupID(int iUserGroupID)
        {
            int num = 0;
            try
            {
                DataSet dataSet = this.dal.GetDataSet("ADUserGroupSections_SelectMaxADUserGroupSortOrderSectionByADUserGroupID", (object)iUserGroupID);
                if (dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].Rows[0][0] != null)
                        num = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;
        }
    }
    #endregion
}