﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HRTimeSheetEntrys
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HRTimeSheetEntrysInfo
    //Created Date:Tuesday, March 29, 2011
    //-----------------------------------------------------------

    public class HRTimeSheetEntrysInfo : BusinessObject
    {
        public HRTimeSheetEntrysInfo()
        {
            IsCommonParam = false;
        }

        #region Variables
        protected int _hRTimeSheetEntryID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _fK_HREmployeeTimeSheetID;
        protected int _fK_HRTimeSheetID;
        protected int _fK_HREmployeeID;
        protected int _fK_HRTimeSheetParamID;
        protected DateTime _hRTimeSheetEntryDate = DateTime.MaxValue;
        protected DateTime _hRTimeSheetEntryFrom = DateTime.MaxValue;
        protected DateTime _hRTimeSheetEntryTo = DateTime.MaxValue;
        protected decimal _hRTimeSheetEntryWorkingHours;
        protected decimal _hRTimeSheetEntryWorkingQty = 0;
        protected decimal _hRTimeSheetEntryFactor;
        protected int _fK_ADWorkingShiftID;
        protected int _fK_HROverTimeID;
        protected bool _isCommonParam = true;

        #endregion

        #region Public properties
        public int HRTimeSheetEntryID
        {
            get { return _hRTimeSheetEntryID; }
            set
            {
                if (value != this._hRTimeSheetEntryID)
                {
                    _hRTimeSheetEntryID = value;
                    NotifyChanged("HRTimeSheetEntryID");
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
        public int FK_HREmployeeTimeSheetID
        {
            get { return _fK_HREmployeeTimeSheetID; }
            set
            {
                if (value != this._fK_HREmployeeTimeSheetID)
                {
                    _fK_HREmployeeTimeSheetID = value;
                    NotifyChanged("FK_HREmployeeTimeSheetID");
                }
            }
        }
        public int FK_HRTimeSheetID
        {
            get { return _fK_HRTimeSheetID; }
            set
            {
                if (value != this._fK_HRTimeSheetID)
                {
                    _fK_HRTimeSheetID = value;
                    NotifyChanged("FK_HRTimeSheetID");
                }
            }
        }
        public int FK_HREmployeeID
        {
            get { return _fK_HREmployeeID; }
            set
            {
                if (value != this._fK_HREmployeeID)
                {
                    _fK_HREmployeeID = value;
                    NotifyChanged("FK_HREmployeeID");
                }
            }
        }
        public int FK_HRTimeSheetParamID
        {
            get { return _fK_HRTimeSheetParamID; }
            set
            {
                if (value != this._fK_HRTimeSheetParamID)
                {
                    _fK_HRTimeSheetParamID = value;
                    NotifyChanged("FK_HRTimeSheetParamID");
                }
            }
        }
        public DateTime HRTimeSheetEntryDate
        {
            get { return _hRTimeSheetEntryDate; }
            set
            {
                if (value != this._hRTimeSheetEntryDate)
                {
                    _hRTimeSheetEntryDate = value;
                    NotifyChanged("HRTimeSheetEntryDate");
                }
            }
        }
        public DateTime HRTimeSheetEntryFrom
        {
            get { return _hRTimeSheetEntryFrom; }
            set
            {
                if (value != this._hRTimeSheetEntryFrom)
                {
                    _hRTimeSheetEntryFrom = value;
                    NotifyChanged("HRTimeSheetEntryFrom");
                }
            }
        }
        public DateTime HRTimeSheetEntryTo
        {
            get { return _hRTimeSheetEntryTo; }
            set
            {
                if (value != this._hRTimeSheetEntryTo)
                {
                    _hRTimeSheetEntryTo = value;
                    NotifyChanged("HRTimeSheetEntryTo");
                }
            }
        }
        public decimal HRTimeSheetEntryWorkingHours
        {
            get { return _hRTimeSheetEntryWorkingHours; }
            set
            {
                if (value != this._hRTimeSheetEntryWorkingHours)
                {
                    _hRTimeSheetEntryWorkingHours = value;
                    NotifyChanged("HRTimeSheetEntryWorkingHours");
                }
            }
        }
        public decimal HRTimeSheetEntryWorkingQty
        {
            get { return _hRTimeSheetEntryWorkingQty; }
            set
            {
                if (value != this._hRTimeSheetEntryWorkingQty)
                {
                    _hRTimeSheetEntryWorkingQty = value;
                    NotifyChanged("HRTimeSheetEntryWorkingQty");
                }
            }
        }
        public decimal HRTimeSheetEntryFactor
        {
            get { return _hRTimeSheetEntryFactor; }
            set
            {
                if (value != this._hRTimeSheetEntryFactor)
                {
                    _hRTimeSheetEntryFactor = value;
                    NotifyChanged("HRTimeSheetEntryFactor");
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
        public int FK_HROverTimeID
        {
            get { return _fK_HROverTimeID; }
            set
            {
                if (value != this._fK_HROverTimeID)
                {
                    _fK_HROverTimeID = value;
                    NotifyChanged("FK_HROverTimeID");
                }
            }
        }
        public bool IsCommonParam
        {
            get { return _isCommonParam; }
            set
            {
                if (value != this._isCommonParam)
                {
                    _isCommonParam = value;
                    NotifyChanged("IsCommonParam");
                }
            }
        }

        #endregion

        #region Extra Properties
        public String HREmployeeCardNumber { get; set; }
        public String HRTimeSheetParamNo { get; set; }
        public Boolean IsOT { get; set; }
        public Boolean IsOTFactor { get; set; }
        public decimal HRTimeSheetParamValue1 { get; set; }
        public decimal HRTimeSheetParamValue2 { get; set; }
        public string HRTimeSheetParamType { get; set; }
        public int FK_ADWorkingShiftForParamID { get; set; }
        #endregion
    }
    #endregion
}