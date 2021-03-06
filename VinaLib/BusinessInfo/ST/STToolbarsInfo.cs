﻿using System;
using System.Text;
using System.Collections.Generic;
namespace VinaLib
{
    #region STToolbars
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:STToolbarsInfo
    //Created Date:Saturday, November 10, 2018
    //-----------------------------------------------------------

    public class STToolbarsInfo : BusinessObject
    {
        public STToolbarsInfo()
        {
        }
        #region Variables
        protected int _sTToolbarID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _sTToolbarName = String.Empty;
        protected String _sTToolbarDesc = String.Empty;
        protected String _sTToolbarTag = String.Empty;
        protected int _fK_STModuleID;
        protected String _sTToolbarCaption = String.Empty;
        protected String _sTToolbarGroup = String.Empty;
        protected int _sTToolbarOrder;
        protected int _sTToolbarParentID;
        protected bool _sTToolbarVisible = true;
        #endregion

        #region Public properties
        public int STToolbarID
        {
            get { return _sTToolbarID; }
            set
            {
                if (value != this._sTToolbarID)
                {
                    _sTToolbarID = value;
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
        public String STToolbarName
        {
            get { return _sTToolbarName; }
            set
            {
                if (value != this._sTToolbarName)
                {
                    _sTToolbarName = value;
                }
            }
        }
        public String STToolbarDesc
        {
            get { return _sTToolbarDesc; }
            set
            {
                if (value != this._sTToolbarDesc)
                {
                    _sTToolbarDesc = value;
                }
            }
        }
        public String STToolbarTag
        {
            get { return _sTToolbarTag; }
            set
            {
                if (value != this._sTToolbarTag)
                {
                    _sTToolbarTag = value;
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
        public String STToolbarCaption
        {
            get { return _sTToolbarCaption; }
            set
            {
                if (value != this._sTToolbarCaption)
                {
                    _sTToolbarCaption = value;
                }
            }
        }
        public String STToolbarGroup
        {
            get { return _sTToolbarGroup; }
            set
            {
                if (value != this._sTToolbarGroup)
                {
                    _sTToolbarGroup = value;
                }
            }
        }
        public int STToolbarOrder
        {
            get { return _sTToolbarOrder; }
            set
            {
                if (value != this._sTToolbarOrder)
                {
                    _sTToolbarOrder = value;
                }
            }
        }
        public int STToolbarParentID
        {
            get { return _sTToolbarParentID; }
            set
            {
                if (value != this._sTToolbarParentID)
                {
                    _sTToolbarParentID = value;
                }
            }
        }
        public bool STToolbarVisible
        {
            get { return _sTToolbarVisible; }
            set
            {
                if (value != this._sTToolbarVisible)
                {
                    _sTToolbarVisible = value;
                }
            }
        }
        #endregion
    }
    #endregion
}