﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaLib
{
    #region GELookupColumns
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:GELookupColumnsInfo
    //Created Date:Saturday, November 10, 2018
    //-----------------------------------------------------------

    public class GELookupColumnsInfo : BusinessObject
    {
        public GELookupColumnsInfo()
        {
        }
        #region Variables
        protected int _gELookupColumnID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _fK_GELookupTableID;
        protected String _gELookupTableName = String.Empty;
        protected String _gELookupColumnFieldName = String.Empty;
        protected String _gELookupColumnCaption = String.Empty;
        protected int _gELookupColumnWidth;
        protected String _gELookupColumnFormatType = String.Empty;
        protected String _gELookupColumnFormatString = String.Empty;
        protected String _gELookupColumnDesc = String.Empty;
        #endregion

        #region Public properties
        public int GELookupColumnID
        {
            get { return _gELookupColumnID; }
            set
            {
                if (value != this._gELookupColumnID)
                {
                    _gELookupColumnID = value;
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
        public int FK_GELookupTableID
        {
            get { return _fK_GELookupTableID; }
            set
            {
                if (value != this._fK_GELookupTableID)
                {
                    _fK_GELookupTableID = value;
                }
            }
        }
        public String GELookupTableName
        {
            get { return _gELookupTableName; }
            set
            {
                if (value != this._gELookupTableName)
                {
                    _gELookupTableName = value;
                }
            }
        }
        public String GELookupColumnFieldName
        {
            get { return _gELookupColumnFieldName; }
            set
            {
                if (value != this._gELookupColumnFieldName)
                {
                    _gELookupColumnFieldName = value;
                }
            }
        }
        public String GELookupColumnCaption
        {
            get { return _gELookupColumnCaption; }
            set
            {
                if (value != this._gELookupColumnCaption)
                {
                    _gELookupColumnCaption = value;
                }
            }
        }
        public int GELookupColumnWidth
        {
            get { return _gELookupColumnWidth; }
            set
            {
                if (value != this._gELookupColumnWidth)
                {
                    _gELookupColumnWidth = value;
                }
            }
        }
        public String GELookupColumnFormatType
        {
            get { return _gELookupColumnFormatType; }
            set
            {
                if (value != this._gELookupColumnFormatType)
                {
                    _gELookupColumnFormatType = value;
                }
            }
        }
        public String GELookupColumnFormatString
        {
            get { return _gELookupColumnFormatString; }
            set
            {
                if (value != this._gELookupColumnFormatString)
                {
                    _gELookupColumnFormatString = value;
                }
            }
        }
        public String GELookupColumnDesc
        {
            get { return _gELookupColumnDesc; }
            set
            {
                if (value != this._gELookupColumnDesc)
                {
                    _gELookupColumnDesc = value;
                }
            }
        }
        #endregion
    }
    #endregion
}