﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ICStockLots
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICStockLotsInfo
    //Created Date:Wednesday, May 1, 2019
    //-----------------------------------------------------------

    public class ICStockLotsInfo : BusinessObject
    {
        public ICStockLotsInfo()
        {
        }
        #region Variables
        protected int _iCStockLotID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _iCStockLotNo = String.Empty;
        protected int _fK_ICProductID;
        protected String _iCStockLotProductNo = String.Empty;
        protected String _iCStockLotProductName = String.Empty;
        protected String _iCStockLotProductDesc = String.Empty;
        protected decimal _iCStockLotProductQty;
        protected int _fK_ICProductAttributeWoodTypeID;
        protected int _fK_ICProductAttributeColorID;
        protected String _iCStockLotProductWoodType = String.Empty;
        protected String _iCStockLotProductColor = String.Empty;
        protected decimal _iCStockLotProductHeight;
        protected decimal _iCStockLotProductWidth;
        protected decimal _iCStockLotProductLength;
        #endregion

        #region Public properties
        public int ICStockLotID
        {
            get { return _iCStockLotID; }
            set
            {
                if (value != this._iCStockLotID)
                {
                    _iCStockLotID = value;
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
        public String ICStockLotNo
        {
            get { return _iCStockLotNo; }
            set
            {
                if (value != this._iCStockLotNo)
                {
                    _iCStockLotNo = value;
                }
            }
        }
        public int FK_ICProductID
        {
            get { return _fK_ICProductID; }
            set
            {
                if (value != this._fK_ICProductID)
                {
                    _fK_ICProductID = value;
                }
            }
        }
        public String ICStockLotProductNo
        {
            get { return _iCStockLotProductNo; }
            set
            {
                if (value != this._iCStockLotProductNo)
                {
                    _iCStockLotProductNo = value;
                }
            }
        }
        public String ICStockLotProductName
        {
            get { return _iCStockLotProductName; }
            set
            {
                if (value != this._iCStockLotProductName)
                {
                    _iCStockLotProductName = value;
                }
            }
        }
        public String ICStockLotProductDesc
        {
            get { return _iCStockLotProductDesc; }
            set
            {
                if (value != this._iCStockLotProductDesc)
                {
                    _iCStockLotProductDesc = value;
                }
            }
        }
        public decimal ICStockLotProductQty
        {
            get { return _iCStockLotProductQty; }
            set
            {
                if (value != this._iCStockLotProductQty)
                {
                    _iCStockLotProductQty = value;
                }
            }
        }
        public int FK_ICProductAttributeWoodTypeID
        {
            get { return _fK_ICProductAttributeWoodTypeID; }
            set
            {
                if (value != this._fK_ICProductAttributeWoodTypeID)
                {
                    _fK_ICProductAttributeWoodTypeID = value;
                }
            }
        }
        public int FK_ICProductAttributeColorID
        {
            get { return _fK_ICProductAttributeColorID; }
            set
            {
                if (value != this._fK_ICProductAttributeColorID)
                {
                    _fK_ICProductAttributeColorID = value;
                }
            }
        }
        public String ICStockLotProductWoodType
        {
            get { return _iCStockLotProductWoodType; }
            set
            {
                if (value != this._iCStockLotProductWoodType)
                {
                    _iCStockLotProductWoodType = value;
                }
            }
        }
        public String ICStockLotProductColor
        {
            get { return _iCStockLotProductColor; }
            set
            {
                if (value != this._iCStockLotProductColor)
                {
                    _iCStockLotProductColor = value;
                }
            }
        }
        public decimal ICStockLotProductHeight
        {
            get { return _iCStockLotProductHeight; }
            set
            {
                if (value != this._iCStockLotProductHeight)
                {
                    _iCStockLotProductHeight = value;
                }
            }
        }
        public decimal ICStockLotProductWidth
        {
            get { return _iCStockLotProductWidth; }
            set
            {
                if (value != this._iCStockLotProductWidth)
                {
                    _iCStockLotProductWidth = value;
                }
            }
        }
        public decimal ICStockLotProductLength
        {
            get { return _iCStockLotProductLength; }
            set
            {
                if (value != this._iCStockLotProductLength)
                {
                    _iCStockLotProductLength = value;
                }
            }
        }
        #endregion
    }
    #endregion
}