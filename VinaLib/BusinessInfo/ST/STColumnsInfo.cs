﻿using System;
using System.Text;
using System.Collections.Generic;
namespace VinaLib
{
    #region STColumns
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:STColumnsInfo
    //Created Date:Sunday, November 11, 2018
    //-----------------------------------------------------------

    public class STColumnsInfo : BusinessObject
    {
        public STColumnsInfo()
        {
        }
        #region Variables
        protected int _sTColumnID;
        protected int _fK_STScreenID;
        protected String _sTColumnName = String.Empty;
        protected String _sTColumnFieldName = String.Empty;
        protected String _sTColumnControlName = String.Empty;
        protected int _sTColumnWidth;
        protected int _sTColumnVisibleIndex;
        #endregion

        #region Public properties
        public int STColumnID
        {
            get { return _sTColumnID; }
            set
            {
                if (value != this._sTColumnID)
                {
                    _sTColumnID = value;
                }
            }
        }
        public int FK_STScreenID
        {
            get { return _fK_STScreenID; }
            set
            {
                if (value != this._fK_STScreenID)
                {
                    _fK_STScreenID = value;
                }
            }
        }
        public String STColumnName
        {
            get { return _sTColumnName; }
            set
            {
                if (value != this._sTColumnName)
                {
                    _sTColumnName = value;
                }
            }
        }
        public String STColumnFieldName
        {
            get { return _sTColumnFieldName; }
            set
            {
                if (value != this._sTColumnFieldName)
                {
                    _sTColumnFieldName = value;
                }
            }
        }
        public String STColumnControlName
        {
            get { return _sTColumnControlName; }
            set
            {
                if (value != this._sTColumnControlName)
                {
                    _sTColumnControlName = value;
                }
            }
        }
        public int STColumnWidth
        {
            get { return _sTColumnWidth; }
            set
            {
                if (value != this._sTColumnWidth)
                {
                    _sTColumnWidth = value;
                }
            }
        }
        public int STColumnVisibleIndex
        {
            get { return _sTColumnVisibleIndex; }
            set
            {
                if (value != this._sTColumnVisibleIndex)
                {
                    _sTColumnVisibleIndex = value;
                }
            }
        }
        #endregion
    }
    #endregion
}