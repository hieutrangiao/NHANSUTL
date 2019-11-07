﻿using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace VinaLib
{
    #region STModuleToUserGroupSections
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:STModuleToUserGroupSectionsController
    //Created Date:Thursday, November 15, 2018
    //-----------------------------------------------------------

    public class STModuleToUserGroupSectionsController : BaseBusinessController
    {
        public STModuleToUserGroupSectionsController()
        {
            dal = new DALBaseProvider("STModuleToUserGroupSections", typeof(STModuleToUserGroupSectionsInfo));
        }

        public DataSet GetAllModuleToUserGroupSectionByUserGroupSectionID(int iUserGroupSectionID)
        {
            return this.dal.GetDataSet("STModuleToUserGroupSections_GetAllModulesByUserGroupSectionID", (object)iUserGroupSectionID);
        }

        public STModuleToUserGroupSectionsInfo GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleID(int iUserGroupSectionID, int moduleID)
        {
            DataSet dataSet = this.GetDataSet(string.Format("SELECT * FROM STModuleToUserGroupSections WHERE STUserGroupSectionID = {0} AND STModuleID = {1}", (object)iUserGroupSectionID, (object)moduleID));
            if (dataSet.Tables[0] == null && dataSet.Tables[0].Rows.Count == 0)
                return (STModuleToUserGroupSectionsInfo)null;
            return (STModuleToUserGroupSectionsInfo)new STModuleToUserGroupSectionsController().GetObjectFromDataRow(dataSet.Tables[0].Rows[0]);
        }

        public void DeleteAllModuleToUserGroupSectionByUserGroupSectionID(int iUserGroupSectionID)
        {
            this.dal.GetDataSet("STModuleToUserGroupSections_DeleteBySTUserGroupSectionID", iUserGroupSectionID);
        }
    }
    #endregion
}