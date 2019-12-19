﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HREmployeeTimeSheetOTDetails
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HREmployeeTimeSheetOTDetailsInfo
    //Created Date:17 Tháng Chín 2015
    //-----------------------------------------------------------

    public class HREmployeeTimeSheetOTDetailsInfo : BusinessObject
    {
        public HREmployeeTimeSheetOTDetailsInfo()
        {
        }
        #region Variables
        protected int _hREmployeeTimeSheetOTDetailID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected int _fK_HREmployeeTimeSheetID;
        protected int _fK_HRTimeSheetParamID;
        protected String _hREmployeeTimeSheetOTDetailName = String.Empty;
        protected decimal _hREmployeeTimeSheetOTDetailFactor;
        protected decimal _hREmployeeTimeSheetOTDetailHours;
        #endregion

        #region Public properties
        public int HREmployeeTimeSheetOTDetailID
        {
            get { return _hREmployeeTimeSheetOTDetailID; }
            set
            {
                if (value != this._hREmployeeTimeSheetOTDetailID)
                {
                    _hREmployeeTimeSheetOTDetailID = value;
                    NotifyChanged("HREmployeeTimeSheetOTDetailID");
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
        public String HREmployeeTimeSheetOTDetailName
        {
            get { return _hREmployeeTimeSheetOTDetailName; }
            set
            {
                if (value != this._hREmployeeTimeSheetOTDetailName)
                {
                    _hREmployeeTimeSheetOTDetailName = value;
                    NotifyChanged("HREmployeeTimeSheetOTDetailName");
                }
            }
        }
        public decimal HREmployeeTimeSheetOTDetailFactor
        {
            get { return _hREmployeeTimeSheetOTDetailFactor; }
            set
            {
                if (value != this._hREmployeeTimeSheetOTDetailFactor)
                {
                    _hREmployeeTimeSheetOTDetailFactor = value;
                    NotifyChanged("HREmployeeTimeSheetOTDetailFactor");
                }
            }
        }
        public decimal HREmployeeTimeSheetOTDetailHours
        {
            get { return _hREmployeeTimeSheetOTDetailHours; }
            set
            {
                if (value != this._hREmployeeTimeSheetOTDetailHours)
                {
                    _hREmployeeTimeSheetOTDetailHours = value;
                    NotifyChanged("HREmployeeTimeSheetOTDetailHours");
                }
            }
        }
        #endregion
    }
    #endregion
}