﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ICStocks
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICStocksInfo
    //Created Date:Saturday, December 1, 2018
    //-----------------------------------------------------------

    public class ICStocksInfo : BusinessObject
    {
        public ICStocksInfo()
        {
        }
        #region Variables
        protected int _iCStockID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _iCStockNo = String.Empty;
        protected String _iCStockName = String.Empty;
        protected String _iCStockDesc = String.Empty;
        protected String _iCStockType = String.Empty;
        protected bool _iCStockActiveCheck = true;
        #endregion

        #region Public properties
        public int ICStockID
        {
            get { return _iCStockID; }
            set
            {
                if (value != this._iCStockID)
                {
                    _iCStockID = value;
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
        public String AACreatedUser
        {
            get { return _aACreatedUser; }
            set
            {
                if (value != this._aACreatedUser)
                {
                    _aACreatedUser = value;
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
                }
            }
        }
        public String ICStockNo
        {
            get { return _iCStockNo; }
            set
            {
                if (value != this._iCStockNo)
                {
                    _iCStockNo = value;
                }
            }
        }
        public String ICStockName
        {
            get { return _iCStockName; }
            set
            {
                if (value != this._iCStockName)
                {
                    _iCStockName = value;
                }
            }
        }
        public String ICStockDesc
        {
            get { return _iCStockDesc; }
            set
            {
                if (value != this._iCStockDesc)
                {
                    _iCStockDesc = value;
                }
            }
        }
        public String ICStockType
        {
            get { return _iCStockType; }
            set
            {
                if (value != this._iCStockType)
                {
                    _iCStockType = value;
                }
            }
        }
        public bool ICStockActiveCheck
        {
            get { return _iCStockActiveCheck; }
            set
            {
                if (value != this._iCStockActiveCheck)
                {
                    _iCStockActiveCheck = value;
                }
            }
        }
        #endregion
    }
    #endregion
}