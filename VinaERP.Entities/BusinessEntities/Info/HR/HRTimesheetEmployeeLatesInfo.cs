﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HRTimesheetEmployeeLates
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HRTimesheetEmployeeLatesInfo
    //Created Date:Tuesday, June 14, 2016
    //-----------------------------------------------------------

    public class HRTimesheetEmployeeLatesInfo : BusinessObject
    {
        public HRTimesheetEmployeeLatesInfo()
        {
        }
        #region Variables
        protected int _hRTimesheetEmployeeLateID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected String _hRTimesheetEmployeeLateName = String.Empty;
        protected int _hRTimesheetEmployeeLateTimeFrom;
        protected int _hRTimesheetEmployeeLateTimeTo;
        protected int _hRTimesheetEmployeeLateOTTime;
        protected decimal _hRTimesheetEmployeeLateDeduct;
        protected int _fK_HREmployeePayrollFormulaID;
        protected int _fK_HRTimesheetEmployeeLateConfigID;
        protected String _hRTimesheetEmployeeLateConfigType = String.Empty;

        #endregion

        #region Public properties
        public int HRTimesheetEmployeeLateID
        {
            get { return _hRTimesheetEmployeeLateID; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateID)
                {
                    _hRTimesheetEmployeeLateID = value;
                    NotifyChanged("HRTimesheetEmployeeLateID");
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
        public String HRTimesheetEmployeeLateName
        {
            get { return _hRTimesheetEmployeeLateName; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateName)
                {
                    _hRTimesheetEmployeeLateName = value;
                    NotifyChanged("HRTimesheetEmployeeLateName");
                }
            }
        }
        public int HRTimesheetEmployeeLateTimeFrom
        {
            get { return _hRTimesheetEmployeeLateTimeFrom; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateTimeFrom)
                {
                    _hRTimesheetEmployeeLateTimeFrom = value;
                    NotifyChanged("HRTimesheetEmployeeLateTimeFrom");
                }
            }
        }
        public int HRTimesheetEmployeeLateTimeTo
        {
            get { return _hRTimesheetEmployeeLateTimeTo; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateTimeTo)
                {
                    _hRTimesheetEmployeeLateTimeTo = value;
                    NotifyChanged("HRTimesheetEmployeeLateTimeTo");
                }
            }
        }
        public int HRTimesheetEmployeeLateOTTime
        {
            get { return _hRTimesheetEmployeeLateOTTime; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateOTTime)
                {
                    _hRTimesheetEmployeeLateOTTime = value;
                    NotifyChanged("HRTimesheetEmployeeLateOTTime");
                }
            }
        }
        public decimal HRTimesheetEmployeeLateDeduct
        {
            get { return _hRTimesheetEmployeeLateDeduct; }
            set
            {
                if (value != this._hRTimesheetEmployeeLateDeduct)
                {
                    _hRTimesheetEmployeeLateDeduct = value;
                    NotifyChanged("HRTimesheetEmployeeLateDeduct");
                }
            }
        }
        public int FK_HREmployeePayrollFormulaID
        {
            get { return _fK_HREmployeePayrollFormulaID; }
            set
            {
                if (value != this._fK_HREmployeePayrollFormulaID)
                {
                    _fK_HREmployeePayrollFormulaID = value;
                    NotifyChanged("FK_HREmployeePayrollFormulaID");
                }
            }
        }
        public int FK_HRTimesheetEmployeeLateConfigID
        {
            get { return _fK_HRTimesheetEmployeeLateConfigID; }
            set
            {
                if (value != this._fK_HRTimesheetEmployeeLateConfigID)
                {
                    _fK_HRTimesheetEmployeeLateConfigID = value;
                    NotifyChanged("FK_HRTimesheetEmployeeLateConfigID");
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