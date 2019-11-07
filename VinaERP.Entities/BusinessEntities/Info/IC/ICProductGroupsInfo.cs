﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ICProductGroups
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICProductGroupsInfo
    //Created Date:Saturday, November 10, 2018
    //-----------------------------------------------------------

    public class ICProductGroupsInfo : BusinessObject
    {
        public ICProductGroupsInfo()
        {
        }
        #region Variables
        protected int _iCProductGroupID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected String _iCProductGroupNo = String.Empty;
        protected String _iCProductGroupName = String.Empty;
        protected String _iCProductGroupDesc = String.Empty;
        protected int _iCProductGroupParentID;
        protected int _fK_ICDepartmentID;
        protected bool _iCDepartmentActiveCheck = true;
        #endregion

        #region Public properties
        public int ICProductGroupID
        {
            get { return _iCProductGroupID; }
            set
            {
                if (value != this._iCProductGroupID)
                {
                    _iCProductGroupID = value;
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
        public DateTime AACreatedDate
        {
            get { return _aACreatedDate; }
            set
            {
                if (value != this._aACreatedDate)
                {
                    _aACreatedDate = value;
                }
            }
        }
        public String AACreatedUser
        {
            get { return _aACreatedUser; }
            set
            {
                if (value != this._aACreatedUser)
                {
                    _aACreatedUser = value;
                }
            }
        }
        public DateTime AAUpdatedDate
        {
            get { return _aAUpdatedDate; }
            set
            {
                if (value != this._aAUpdatedDate)
                {
                    _aAUpdatedDate = value;
                }
            }
        }
        public String AAUpdatedUser
        {
            get { return _aAUpdatedUser; }
            set
            {
                if (value != this._aAUpdatedUser)
                {
                    _aAUpdatedUser = value;
                }
            }
        }
        public String ICProductGroupNo
        {
            get { return _iCProductGroupNo; }
            set
            {
                if (value != this._iCProductGroupNo)
                {
                    _iCProductGroupNo = value;
                }
            }
        }
        public String ICProductGroupName
        {
            get { return _iCProductGroupName; }
            set
            {
                if (value != this._iCProductGroupName)
                {
                    _iCProductGroupName = value;
                }
            }
        }
        public String ICProductGroupDesc
        {
            get { return _iCProductGroupDesc; }
            set
            {
                if (value != this._iCProductGroupDesc)
                {
                    _iCProductGroupDesc = value;
                }
            }
        }
        public int ICProductGroupParentID
        {
            get { return _iCProductGroupParentID; }
            set
            {
                if (value != this._iCProductGroupParentID)
                {
                    _iCProductGroupParentID = value;
                }
            }
        }
        public int FK_ICDepartmentID
        {
            get { return _fK_ICDepartmentID; }
            set
            {
                if (value != this._fK_ICDepartmentID)
                {
                    _fK_ICDepartmentID = value;
                }
            }
        }
        public bool ICDepartmentActiveCheck
        {
            get { return _iCDepartmentActiveCheck; }
            set
            {
                if (value != this._iCDepartmentActiveCheck)
                {
                    _iCDepartmentActiveCheck = value;
                }
            }
        }
        #endregion
    }
    #endregion
}