﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HRTimeSheetParams
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HRTimeSheetParamsInfo
    //Created Date:Thursday, April 12, 2018
    //-----------------------------------------------------------

    public class HRTimeSheetParamsInfo : BusinessObject
    {
        public HRTimeSheetParamsInfo()
        {
            IsWorkSchedule = false;
            IsPause = false;
        }
        #region Variables
        protected int _hRTimeSheetParamID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _hRTimeSheetParamNo = String.Empty;
        protected String _hRTimeSheetParamName = String.Empty;
        protected String _hRTimeSheetParamDesc = String.Empty;
        protected String _hRTimeSheetParamType = String.Empty;
        protected decimal _hRTimeSheetParamValue1;
        protected decimal _hRTimeSheetParamValue2;
        protected bool _isDefault = true;
        protected bool _isOTCalculated = true;
        protected bool _hRTimeSheetParamNight = true;
        protected bool _isAllowedLeave = true;
        protected int _fK_ADWorkingShiftID;
        protected bool _isWorkSchedule = true;
        protected bool _isPause = true;

        #endregion

        #region Public properties
        public int HRTimeSheetParamID
        {
            get { return _hRTimeSheetParamID; }
            set
            {
                if (value != this._hRTimeSheetParamID)
                {
                    _hRTimeSheetParamID = value;
                    NotifyChanged("HRTimeSheetParamID");
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
        public String HRTimeSheetParamNo
        {
            get { return _hRTimeSheetParamNo; }
            set
            {
                if (value != this._hRTimeSheetParamNo)
                {
                    _hRTimeSheetParamNo = value;
                    NotifyChanged("HRTimeSheetParamNo");
                }
            }
        }
        public String HRTimeSheetParamName
        {
            get { return _hRTimeSheetParamName; }
            set
            {
                if (value != this._hRTimeSheetParamName)
                {
                    _hRTimeSheetParamName = value;
                    NotifyChanged("HRTimeSheetParamName");
                }
            }
        }
        public String HRTimeSheetParamDesc
        {
            get { return _hRTimeSheetParamDesc; }
            set
            {
                if (value != this._hRTimeSheetParamDesc)
                {
                    _hRTimeSheetParamDesc = value;
                    NotifyChanged("HRTimeSheetParamDesc");
                }
            }
        }
        public String HRTimeSheetParamType
        {
            get { return _hRTimeSheetParamType; }
            set
            {
                if (value != this._hRTimeSheetParamType)
                {
                    _hRTimeSheetParamType = value;
                    NotifyChanged("HRTimeSheetParamType");
                }
            }
        }
        public decimal HRTimeSheetParamValue1
        {
            get { return _hRTimeSheetParamValue1; }
            set
            {
                if (value != this._hRTimeSheetParamValue1)
                {
                    _hRTimeSheetParamValue1 = value;
                    NotifyChanged("HRTimeSheetParamValue1");
                }
            }
        }
        public decimal HRTimeSheetParamValue2
        {
            get { return _hRTimeSheetParamValue2; }
            set
            {
                if (value != this._hRTimeSheetParamValue2)
                {
                    _hRTimeSheetParamValue2 = value;
                    NotifyChanged("HRTimeSheetParamValue2");
                }
            }
        }
        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (value != this._isDefault)
                {
                    _isDefault = value;
                    NotifyChanged("IsDefault");
                }
            }
        }
        public bool IsOTCalculated
        {
            get { return _isOTCalculated; }
            set
            {
                if (value != this._isOTCalculated)
                {
                    _isOTCalculated = value;
                    NotifyChanged("IsOTCalculated");
                }
            }
        }
        public bool HRTimeSheetParamNight
        {
            get { return _hRTimeSheetParamNight; }
            set
            {
                if (value != this._hRTimeSheetParamNight)
                {
                    _hRTimeSheetParamNight = value;
                    NotifyChanged("HRTimeSheetParamNight");
                }
            }
        }
        public bool IsAllowedLeave
        {
            get { return _isAllowedLeave; }
            set
            {
                if (value != this._isAllowedLeave)
                {
                    _isAllowedLeave = value;
                    NotifyChanged("IsAllowedLeave");
                }
            }
        }
        public int FK_ADWorkingShiftID
        {
            get { return _fK_ADWorkingShiftID; }
            set
            {
                if (value != this._fK_ADWorkingShiftID)
                {
                    _fK_ADWorkingShiftID = value;
                    NotifyChanged("FK_ADWorkingShiftID");
                }
            }
        }
        public bool IsWorkSchedule
        {
            get { return _isWorkSchedule; }
            set
            {
                if (value != this._isWorkSchedule)
                {
                    _isWorkSchedule = value;
                    NotifyChanged("IsWorkSchedule");
                }
            }
        }
        public bool IsPause
        {
            get { return _isPause; }
            set
            {
                if (value != this._isPause)
                {
                    _isPause = value;
                    NotifyChanged("IsPause");
                }
            }
        }

        #endregion
    }
    #endregion
}