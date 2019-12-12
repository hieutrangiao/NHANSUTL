﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ADTimesheetConfigs
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:ADTimesheetConfigsInfo
    //Created Date:Tuesday, December 11, 2018
    //-----------------------------------------------------------

    public class ADTimesheetConfigsInfo : BusinessObject
    {
        public ADTimesheetConfigsInfo()
        {
        }
        #region Variables
        protected int _aDTimesheetConfigID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _aDTimesheetConfigJan;
        protected int _aDTimesheetConfigFeb;
        protected int _aDTimesheetConfigMar;
        protected int _aDTimesheetConfigApr;
        protected int _aDTimesheetConfigMay;
        protected int _aDTimesheetConfigJun;
        protected int _aDTimesheetConfigJul;
        protected int _aDTimesheetConfigAug;
        protected int _aDTimesheetConfigSep;
        protected int _aDTimesheetConfigOct;
        protected int _aDTimesheetConfigNov;
        protected int _aDTimesheetConfigDec;
        protected DateTime _aDTimesheetConfigYear = DateTime.MaxValue;
        #endregion

        #region Public properties
        public int ADTimesheetConfigID
        {
            get { return _aDTimesheetConfigID; }
            set
            {
                if (value != this._aDTimesheetConfigID)
                {
                    _aDTimesheetConfigID = value;
                    NotifyChanged("ADTimesheetConfigID");
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
        public int ADTimesheetConfigJan
        {
            get { return _aDTimesheetConfigJan; }
            set
            {
                if (value != this._aDTimesheetConfigJan)
                {
                    _aDTimesheetConfigJan = value;
                    NotifyChanged("ADTimesheetConfigJan");
                }
            }
        }
        public int ADTimesheetConfigFeb
        {
            get { return _aDTimesheetConfigFeb; }
            set
            {
                if (value != this._aDTimesheetConfigFeb)
                {
                    _aDTimesheetConfigFeb = value;
                    NotifyChanged("ADTimesheetConfigFeb");
                }
            }
        }
        public int ADTimesheetConfigMar
        {
            get { return _aDTimesheetConfigMar; }
            set
            {
                if (value != this._aDTimesheetConfigMar)
                {
                    _aDTimesheetConfigMar = value;
                    NotifyChanged("ADTimesheetConfigMar");
                }
            }
        }
        public int ADTimesheetConfigApr
        {
            get { return _aDTimesheetConfigApr; }
            set
            {
                if (value != this._aDTimesheetConfigApr)
                {
                    _aDTimesheetConfigApr = value;
                    NotifyChanged("ADTimesheetConfigApr");
                }
            }
        }
        public int ADTimesheetConfigMay
        {
            get { return _aDTimesheetConfigMay; }
            set
            {
                if (value != this._aDTimesheetConfigMay)
                {
                    _aDTimesheetConfigMay = value;
                    NotifyChanged("ADTimesheetConfigMay");
                }
            }
        }
        public int ADTimesheetConfigJun
        {
            get { return _aDTimesheetConfigJun; }
            set
            {
                if (value != this._aDTimesheetConfigJun)
                {
                    _aDTimesheetConfigJun = value;
                    NotifyChanged("ADTimesheetConfigJun");
                }
            }
        }
        public int ADTimesheetConfigJul
        {
            get { return _aDTimesheetConfigJul; }
            set
            {
                if (value != this._aDTimesheetConfigJul)
                {
                    _aDTimesheetConfigJul = value;
                    NotifyChanged("ADTimesheetConfigJul");
                }
            }
        }
        public int ADTimesheetConfigAug
        {
            get { return _aDTimesheetConfigAug; }
            set
            {
                if (value != this._aDTimesheetConfigAug)
                {
                    _aDTimesheetConfigAug = value;
                    NotifyChanged("ADTimesheetConfigAug");
                }
            }
        }
        public int ADTimesheetConfigSep
        {
            get { return _aDTimesheetConfigSep; }
            set
            {
                if (value != this._aDTimesheetConfigSep)
                {
                    _aDTimesheetConfigSep = value;
                    NotifyChanged("ADTimesheetConfigSep");
                }
            }
        }
        public int ADTimesheetConfigOct
        {
            get { return _aDTimesheetConfigOct; }
            set
            {
                if (value != this._aDTimesheetConfigOct)
                {
                    _aDTimesheetConfigOct = value;
                    NotifyChanged("ADTimesheetConfigOct");
                }
            }
        }
        public int ADTimesheetConfigNov
        {
            get { return _aDTimesheetConfigNov; }
            set
            {
                if (value != this._aDTimesheetConfigNov)
                {
                    _aDTimesheetConfigNov = value;
                    NotifyChanged("ADTimesheetConfigNov");
                }
            }
        }
        public int ADTimesheetConfigDec
        {
            get { return _aDTimesheetConfigDec; }
            set
            {
                if (value != this._aDTimesheetConfigDec)
                {
                    _aDTimesheetConfigDec = value;
                    NotifyChanged("ADTimesheetConfigDec");
                }
            }
        }
        public DateTime ADTimesheetConfigYear
        {
            get { return _aDTimesheetConfigYear; }
            set
            {
                if (value != this._aDTimesheetConfigYear)
                {
                    _aDTimesheetConfigYear = value;
                    NotifyChanged("ADTimesheetConfigYear");
                }
            }
        }
        #endregion
    }
    #endregion
}