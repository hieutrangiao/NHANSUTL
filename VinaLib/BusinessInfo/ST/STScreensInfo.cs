﻿using System;
using System.Text;
using System.Collections.Generic;
namespace VinaLib
{
    #region STScreens
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:STScreensInfo
    //Created Date:Saturday, November 10, 2018
    //-----------------------------------------------------------

    public class STScreensInfo : BusinessObject
    {
        public STScreensInfo()
        {
        }
        #region Variables
        protected int _sTScreenID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _sTScreenCode = String.Empty;
        protected String _sTScreenName = String.Empty;
        protected String _sTScreenDesc = String.Empty;
        protected int _fK_STModuleID;
        protected String _sTScreenTag = String.Empty;
        protected int _sTScreenSortOrder;
        protected bool _sTScreenIsVisible = true;
        #endregion

        #region Public properties
        public int STScreenID
        {
            get { return _sTScreenID; }
            set
            {
                if (value != this._sTScreenID)
                {
                    _sTScreenID = value;
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
        public String STScreenCode
        {
            get { return _sTScreenCode; }
            set
            {
                if (value != this._sTScreenCode)
                {
                    _sTScreenCode = value;
                }
            }
        }
        public String STScreenName
        {
            get { return _sTScreenName; }
            set
            {
                if (value != this._sTScreenName)
                {
                    _sTScreenName = value;
                }
            }
        }
        public String STScreenDesc
        {
            get { return _sTScreenDesc; }
            set
            {
                if (value != this._sTScreenDesc)
                {
                    _sTScreenDesc = value;
                }
            }
        }
        public int FK_STModuleID
        {
            get { return _fK_STModuleID; }
            set
            {
                if (value != this._fK_STModuleID)
                {
                    _fK_STModuleID = value;
                }
            }
        }
        public String STScreenTag
        {
            get { return _sTScreenTag; }
            set
            {
                if (value != this._sTScreenTag)
                {
                    _sTScreenTag = value;
                }
            }
        }
        public int STScreenSortOrder
        {
            get { return _sTScreenSortOrder; }
            set
            {
                if (value != this._sTScreenSortOrder)
                {
                    _sTScreenSortOrder = value;
                }
            }
        }
        public bool STScreenIsVisible
        {
            get { return _sTScreenIsVisible; }
            set
            {
                if (value != this._sTScreenIsVisible)
                {
                    _sTScreenIsVisible = value;
                }
            }
        }
        #endregion
    }
    #endregion
}