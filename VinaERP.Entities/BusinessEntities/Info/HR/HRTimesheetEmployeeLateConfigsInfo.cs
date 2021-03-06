﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HRTimesheetEmployeeLateConfigs
    //-----------------------------------------------------------
    //Generated By: BOS Studio
    //Class:HRTimesheetEmployeeLateConfigsInfo
    //Created Date:Thursday, December 6, 2018
    //-----------------------------------------------------------

    public class HRTimesheetEmployeeLateConfigsInfo : BusinessObject
    {
        public HRTimesheetEmployeeLateConfigsInfo()
        {
        }
        #region Variables
        protected int _hRTimesheetEmployeeLateConfigID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected String _hRTimesheetEmployeeLateConfigName = String.Empty;
        protected int _hRTimesheetEmployeeLateConfigTimeFrom;
        protected int _hRTimesheetEmployeeLateConfigTimeTo;
        protected int _hRTimesheetEmployeeLateConfigOTTime;
        protected decimal _hRTimesheetEmployeeLateConfigDeduct;
        protected String _hRTimesheetEmployeeLateConfigType = DefaultStatus;

        #endregion

        #region Public properties
        public int HRTimesheetEmployeeLateConfigID
        {
            get { return _hRTimesheetEmployeeLateConfigID; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigID)
                {
                    _hRTimesheetEmployeeLateConfigID = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigID");
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
        public String HRTimesheetEmployeeLateConfigName
        {
            get { return _hRTimesheetEmployeeLateConfigName; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigName)
                {
                    _hRTimesheetEmployeeLateConfigName = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigName");
                }
            }
        }
        public int HRTimesheetEmployeeLateConfigTimeFrom
        {
            get { return _hRTimesheetEmployeeLateConfigTimeFrom; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigTimeFrom)
                {
                    _hRTimesheetEmployeeLateConfigTimeFrom = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigTimeFrom");
                }
            }
        }
        public int HRTimesheetEmployeeLateConfigTimeTo
        {
            get { return _hRTimesheetEmployeeLateConfigTimeTo; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigTimeTo)
                {
                    _hRTimesheetEmployeeLateConfigTimeTo = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigTimeTo");
                }
            }
        }
        public int HRTimesheetEmployeeLateConfigOTTime
        {
            get { return _hRTimesheetEmployeeLateConfigOTTime; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigOTTime)
                {
                    _hRTimesheetEmployeeLateConfigOTTime = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigOTTime");
                }
            }
        }
        public decimal HRTimesheetEmployeeLateConfigDeduct
        {
            get { return _hRTimesheetEmployeeLateConfigDeduct; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigDeduct)
                {
                    _hRTimesheetEmployeeLateConfigDeduct = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigDeduct");
                }
            }
        }
        public String HRTimesheetEmployeeLateConfigType
        {
            get { return _hRTimesheetEmployeeLateConfigType; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateConfigType)
                {
                    _hRTimesheetEmployeeLateConfigType = value;
                    NotifyChanged("HRTimesheetEmployeeLateConfigType");
                }
            }
        }

        #endregion
    }
    #endregion
}