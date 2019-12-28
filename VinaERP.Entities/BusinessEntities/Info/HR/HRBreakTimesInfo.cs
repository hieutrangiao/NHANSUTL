﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HRBreakTimes
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HRBreakTimesInfo
    //Created Date:Tuesday, June 14, 2016
    //-----------------------------------------------------------

    public class HRBreakTimesInfo : BusinessObject
    {
        public HRBreakTimesInfo()
        {
        }
        #region Variables
        protected int _hRBreakTimeID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected String _hRBreakTimeName = String.Empty;
        protected DateTime _hRBreakTimeFromTime = DateTime.MaxValue;
        protected DateTime _hRBreakTimeToTime = DateTime.MaxValue;
        protected int _fK_HREmployeePayrollFormulaID;
        protected int _hRBreakTimeMaxOutTime;
        protected int _hRBreakTimeMinRegisterOverTime;
        protected String _hRBreakTimeType = String.Empty;
        protected String _hRBreakTimeTimeSheetType = String.Empty;
        protected int _fK_HRWorkingShiftID;

        #endregion

        #region Public properties
        public int HRBreakTimeID
        {
            get { return _hRBreakTimeID; }
            set
            {
                if (value != this._hRBreakTimeID)
                {
                    _hRBreakTimeID = value;
                    NotifyChanged("HRBreakTimeID");
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
        public String HRBreakTimeName
        {
            get { return _hRBreakTimeName; }
            set
            {
                if (value != this._hRBreakTimeName)
                {
                    _hRBreakTimeName = value;
                    NotifyChanged("HRBreakTimeName");
                }
            }
        }
        public DateTime HRBreakTimeFromTime
        {
            get { return _hRBreakTimeFromTime; }
            set
            {
                if (value != this._hRBreakTimeFromTime)
                {
                    _hRBreakTimeFromTime = value;
                    NotifyChanged("HRBreakTimeFromTime");
                }
            }
        }
        public DateTime HRBreakTimeToTime
        {
            get { return _hRBreakTimeToTime; }
            set
            {
                if (value != this._hRBreakTimeToTime)
                {
                    _hRBreakTimeToTime = value;
                    NotifyChanged("HRBreakTimeToTime");
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
        public int HRBreakTimeMaxOutTime
        {
            get { return _hRBreakTimeMaxOutTime; }
            set
            {
                if (value != this._hRBreakTimeMaxOutTime)
                {
                    _hRBreakTimeMaxOutTime = value;
                    NotifyChanged("HRBreakTimeMaxOutTime");
                }
            }
        }
        public int HRBreakTimeMinRegisterOverTime
        {
            get { return _hRBreakTimeMinRegisterOverTime; }
            set
            {
                if (value != this._hRBreakTimeMinRegisterOverTime)
                {
                    _hRBreakTimeMinRegisterOverTime = value;
                    NotifyChanged("HRBreakTimeMinRegisterOverTime");
                }
            }
        }
        public String HRBreakTimeType
        {
            get { return _hRBreakTimeType; }
            set
            {
                if (value != this._hRBreakTimeType)
                {
                    _hRBreakTimeType = value;
                    NotifyChanged("HRBreakTimeType");
                }
            }
        }
        public String HRBreakTimeTimeSheetType
        {
            get { return _hRBreakTimeTimeSheetType; }
            set
            {
                if (value != this._hRBreakTimeTimeSheetType)
                {
                    _hRBreakTimeTimeSheetType = value;
                    NotifyChanged("HRBreakTimeTimeSheetType");
                }
            }
        }
        public int FK_HRWorkingShiftID
        {
            get { return _fK_HRWorkingShiftID; }
            set
            {
                if (value != this._fK_HRWorkingShiftID)
                {
                    _fK_HRWorkingShiftID = value;
                    NotifyChanged("FK_HRWorkingShiftID");
                }
            }
        }

        #endregion

        #region extra
        public DateTime WorkingTimeIn { get; set; }
        public DateTime WorkingTimeOut { get; set; }

        public DateTime WorkingTimeOTIn { get; set; }
        public DateTime WorkingTimeOTOut { get; set; }

        public DateTime NghiTruaTimeFrom { get; set; }
        public DateTime NghiTruaTimeTo { get; set; }

        public bool IsOT { get; set; }

        public string OTType { get; set; }
        #endregion
    }
    #endregion
}