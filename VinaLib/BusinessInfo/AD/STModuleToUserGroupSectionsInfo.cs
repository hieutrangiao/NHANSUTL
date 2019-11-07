﻿using System;
using System.Text;
using System.Collections.Generic;
namespace VinaLib
{
    #region STModuleToUserGroupSections
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:STModuleToUserGroupSectionsInfo
    //Created Date:Thursday, November 15, 2018
    //-----------------------------------------------------------

    public class STModuleToUserGroupSectionsInfo : BusinessObject
    {
        public STModuleToUserGroupSectionsInfo()
        {
        }
        #region Variables
        protected int _sTModuleToUserGroupSectionID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _sTUserGroupSectionID;
        protected int _fK_STModuleID;
        protected int _sTModuleToUserGroupSectionSortOrder;
        #endregion

        #region Public properties
        public int STModuleToUserGroupSectionID
        {
            get { return _sTModuleToUserGroupSectionID; }
            set
            {
                if (value != this._sTModuleToUserGroupSectionID)
                {
                    _sTModuleToUserGroupSectionID = value;
                }
            }
        }
        public String AAStatus
        {
            get { return _aAStatus; }
            set
            {
                if (value != this._aAStatus)
                {
                    _aAStatus = value;
                }
            }
        }
        public int STUserGroupSectionID
        {
            get { return _sTUserGroupSectionID; }
            set
            {
                if (value != this._sTUserGroupSectionID)
                {
                    _sTUserGroupSectionID = value;
                }
            }
        }
        public int FK_STModuleID
        {
            get { return _fK_STModuleID; }
            set
            {
                if (value != this._fK_STModuleID)
                {
                    _fK_STModuleID = value;
                }
            }
        }
        public int STModuleToUserGroupSectionSortOrder
        {
            get { return _sTModuleToUserGroupSectionSortOrder; }
            set
            {
                if (value != this._sTModuleToUserGroupSectionSortOrder)
                {
                    _sTModuleToUserGroupSectionSortOrder = value;
                }
            }
        }
        #endregion
    }
    #endregion
}