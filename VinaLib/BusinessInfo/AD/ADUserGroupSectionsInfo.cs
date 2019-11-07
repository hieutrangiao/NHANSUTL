﻿using System;
using System.Text;
using System.Collections.Generic;

namespace VinaLib
{
    #region ADUserGroupSections
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ADUserGroupSectionsInfo
    //Created Date:Thursday, November 15, 2018
    //-----------------------------------------------------------

    public class ADUserGroupSectionsInfo : BusinessObject
    {
        public ADUserGroupSectionsInfo()
        {
        }
        #region Variables
        protected int _aDUserGroupSectionID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _fK_ADUserGroupID;
        protected String _aDUserGroupSectionName = String.Empty;
        protected String _aDUserGroupSectionDesc = String.Empty;
        protected int _aDUserGroupSectionSortOrder;
        #endregion

        #region Public properties
        public int ADUserGroupSectionID
        {
            get { return _aDUserGroupSectionID; }
            set
            {
                if (value != this._aDUserGroupSectionID)
                {
                    _aDUserGroupSectionID = value;
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
        public int FK_ADUserGroupID
        {
            get { return _fK_ADUserGroupID; }
            set
            {
                if (value != this._fK_ADUserGroupID)
                {
                    _fK_ADUserGroupID = value;
                }
            }
        }
        public String ADUserGroupSectionName
        {
            get { return _aDUserGroupSectionName; }
            set
            {
                if (value != this._aDUserGroupSectionName)
                {
                    _aDUserGroupSectionName = value;
                }
            }
        }
        public String ADUserGroupSectionDesc
        {
            get { return _aDUserGroupSectionDesc; }
            set
            {
                if (value != this._aDUserGroupSectionDesc)
                {
                    _aDUserGroupSectionDesc = value;
                }
            }
        }
        public int ADUserGroupSectionSortOrder
        {
            get { return _aDUserGroupSectionSortOrder; }
            set
            {
                if (value != this._aDUserGroupSectionSortOrder)
                {
                    _aDUserGroupSectionSortOrder = value;
                }
            }
        }
        #endregion
    }
    #endregion
}