﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HRDepartmentRoomGroups
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HRDepartmentRoomGroupsInfo
    //Created Date:Tuesday, June 14, 2016
    //-----------------------------------------------------------

    public class HRDepartmentRoomGroupsInfo : BusinessObject
    {
        public HRDepartmentRoomGroupsInfo()
        {
        }
        #region Variables
        protected int _hRDepartmentRoomGroupID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected int _fK_HRDepartmentRoomID;
        protected int _fK_HRDepartmentID;
        protected int _fK_BRBranchID;
        protected String _hRDepartmentRoomGroupNo = String.Empty;
        protected String _hRDepartmentRoomGroupName = String.Empty;
        protected String _hRDepartmentRoomGroupDesc = String.Empty;
        protected int _fK_BRBranchID2;

        #endregion

        #region Public properties
        public int HRDepartmentRoomGroupID
        {
            get { return _hRDepartmentRoomGroupID; }
            set
            {
                if (value != this._hRDepartmentRoomGroupID)
                {
                    _hRDepartmentRoomGroupID = value;
                    NotifyChanged("HRDepartmentRoomGroupID");
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
                    NotifyChanged("AAStatus");
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
                    NotifyChanged("AACreatedDate");
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
                    NotifyChanged("AACreatedUser");
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
                    NotifyChanged("AAUpdatedDate");
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
                    NotifyChanged("AAUpdatedUser");
                }
            }
        }
        public int FK_HRDepartmentRoomID
        {
            get { return _fK_HRDepartmentRoomID; }
            set
            {
                if (value != this._fK_HRDepartmentRoomID)
                {
                    _fK_HRDepartmentRoomID = value;
                    NotifyChanged("FK_HRDepartmentRoomID");
                }
            }
        }
        public int FK_HRDepartmentID
        {
            get { return _fK_HRDepartmentID; }
            set
            {
                if (value != this._fK_HRDepartmentID)
                {
                    _fK_HRDepartmentID = value;
                    NotifyChanged("FK_HRDepartmentID");
                }
            }
        }
        public int FK_BRBranchID
        {
            get { return _fK_BRBranchID; }
            set
            {
                if (value != this._fK_BRBranchID)
                {
                    _fK_BRBranchID = value;
                    NotifyChanged("FK_BRBranchID");
                }
            }
        }
        public String HRDepartmentRoomGroupNo
        {
            get { return _hRDepartmentRoomGroupNo; }
            set
            {
                if (value != this._hRDepartmentRoomGroupNo)
                {
                    _hRDepartmentRoomGroupNo = value;
                    NotifyChanged("HRDepartmentRoomGroupNo");
                }
            }
        }
        public String HRDepartmentRoomGroupName
        {
            get { return _hRDepartmentRoomGroupName; }
            set
            {
                if (value != this._hRDepartmentRoomGroupName)
                {
                    _hRDepartmentRoomGroupName = value;
                    NotifyChanged("HRDepartmentRoomGroupName");
                }
            }
        }
        public String HRDepartmentRoomGroupDesc
        {
            get { return _hRDepartmentRoomGroupDesc; }
            set
            {
                if (value != this._hRDepartmentRoomGroupDesc)
                {
                    _hRDepartmentRoomGroupDesc = value;
                    NotifyChanged("HRDepartmentRoomGroupDesc");
                }
            }
        }

        public int FK_BRBranchID2
        {
            get { return _fK_BRBranchID2; }
            set
            {
                if (value != this._fK_BRBranchID2)
                {
                    _fK_BRBranchID2 = value;
                    NotifyChanged("FK_BRBranchID2");
                }
            }
        }

        #endregion
    }
    #endregion
}