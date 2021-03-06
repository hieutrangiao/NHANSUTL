﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ICVitualTransactions
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ICVitualTransactionsInfo
    //Created Date:Sunday, April 28, 2019
    //-----------------------------------------------------------

    public class ICVitualTransactionsInfo : BusinessObject
    {
        public ICVitualTransactionsInfo()
        {
        }
        #region Variables
        protected int _iCVitualTransactionID;
        protected String _aAStatus = DefaultAAStatus;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected int _iCVitualTransactionReferenceID;
        protected String _iCVitualTransactionReferenceNo = String.Empty;
        protected String _iCVitualTransactionModuleName = String.Empty;
        protected String _iCVitualTransactionModuleType = String.Empty;
        protected DateTime _iCVitualTransactionDate = DateTime.MaxValue;
        protected int _iCVitualTransactionRefItemID;
        protected int _fK_HREmployeeID;
        protected int _fK_BRBranchID;
        protected int _fK_ACObjectID;
        protected String _aCObjectType = String.Empty;
        protected String _iCVitualTransactionDesc = String.Empty;
        protected String _iCVitualTransactionDetailDesc = String.Empty;
        protected int _fK_GECurrencyID;
        protected decimal _iCVitualTransactionExchangeRate;
        protected int _fK_ARSaleOrderID;
        protected int _fK_ICStockID;
        protected int _fK_ICProductID;
        protected int _fK_ICMeasureUnitID;
        protected String _iCVitualTransactionType = String.Empty;
        protected bool _iCVitualTransactionIsSpecificCalculation = true;
        protected bool _iCVitualTransactionIsAverageCalculation = true;
        protected String _iCVitualTransactionReceiptSerialNo = String.Empty;
        protected decimal _iCVitualTransactionQty;
        protected decimal _iCVitualTransactionFactor;
        protected decimal _iCVitualTransactionExchangeQty;
        protected decimal _iCVitualTransactionUnitCost;
        protected decimal _iCVitualTransactionTotalCost;
        protected decimal _iCVitualTransactionExchangeUnitCost;
        protected decimal _iCVitualTransactionExchangeTotalCost;
        protected decimal _iCVitualTransactionLength;
        protected decimal _iCVitualTransactionWidth;
        protected decimal _iCVitualTransactionHeight;
        protected String _iCVitualTransactionPurposeType = String.Empty;
        #endregion

        #region Public properties
        public int ICVitualTransactionID
        {
            get { return _iCVitualTransactionID; }
            set
            {
                if (value != this._iCVitualTransactionID)
                {
                    _iCVitualTransactionID = value;
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
        public int ICVitualTransactionReferenceID
        {
            get { return _iCVitualTransactionReferenceID; }
            set
            {
                if (value != this._iCVitualTransactionReferenceID)
                {
                    _iCVitualTransactionReferenceID = value;
                }
            }
        }
        public String ICVitualTransactionReferenceNo
        {
            get { return _iCVitualTransactionReferenceNo; }
            set
            {
                if (value != this._iCVitualTransactionReferenceNo)
                {
                    _iCVitualTransactionReferenceNo = value;
                }
            }
        }
        public String ICVitualTransactionModuleName
        {
            get { return _iCVitualTransactionModuleName; }
            set
            {
                if (value != this._iCVitualTransactionModuleName)
                {
                    _iCVitualTransactionModuleName = value;
                }
            }
        }
        public String ICVitualTransactionModuleType
        {
            get { return _iCVitualTransactionModuleType; }
            set
            {
                if (value != this._iCVitualTransactionModuleType)
                {
                    _iCVitualTransactionModuleType = value;
                }
            }
        }
        public DateTime ICVitualTransactionDate
        {
            get { return _iCVitualTransactionDate; }
            set
            {
                if (value != this._iCVitualTransactionDate)
                {
                    _iCVitualTransactionDate = value;
                }
            }
        }
        public int ICVitualTransactionRefItemID
        {
            get { return _iCVitualTransactionRefItemID; }
            set
            {
                if (value != this._iCVitualTransactionRefItemID)
                {
                    _iCVitualTransactionRefItemID = value;
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
                }
            }
        }
        public int FK_BRBranchID
        {
            get { return _fK_BRBranchID; }
            set
            {
                if (value != this._fK_BRBranchID)
                {
                    _fK_BRBranchID = value;
                }
            }
        }
        public int FK_ACObjectID
        {
            get { return _fK_ACObjectID; }
            set
            {
                if (value != this._fK_ACObjectID)
                {
                    _fK_ACObjectID = value;
                }
            }
        }
        public String ACObjectType
        {
            get { return _aCObjectType; }
            set
            {
                if (value != this._aCObjectType)
                {
                    _aCObjectType = value;
                }
            }
        }
        public String ICVitualTransactionDesc
        {
            get { return _iCVitualTransactionDesc; }
            set
            {
                if (value != this._iCVitualTransactionDesc)
                {
                    _iCVitualTransactionDesc = value;
                }
            }
        }
        public String ICVitualTransactionDetailDesc
        {
            get { return _iCVitualTransactionDetailDesc; }
            set
            {
                if (value != this._iCVitualTransactionDetailDesc)
                {
                    _iCVitualTransactionDetailDesc = value;
                }
            }
        }
        public int FK_GECurrencyID
        {
            get { return _fK_GECurrencyID; }
            set
            {
                if (value != this._fK_GECurrencyID)
                {
                    _fK_GECurrencyID = value;
                }
            }
        }
        public decimal ICVitualTransactionExchangeRate
        {
            get { return _iCVitualTransactionExchangeRate; }
            set
            {
                if (value != this._iCVitualTransactionExchangeRate)
                {
                    _iCVitualTransactionExchangeRate = value;
                }
            }
        }
        public int FK_ARSaleOrderID
        {
            get { return _fK_ARSaleOrderID; }
            set
            {
                if (value != this._fK_ARSaleOrderID)
                {
                    _fK_ARSaleOrderID = value;
                }
            }
        }
        public int FK_ICStockID
        {
            get { return _fK_ICStockID; }
            set
            {
                if (value != this._fK_ICStockID)
                {
                    _fK_ICStockID = value;
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
        public int FK_ICMeasureUnitID
        {
            get { return _fK_ICMeasureUnitID; }
            set
            {
                if (value != this._fK_ICMeasureUnitID)
                {
                    _fK_ICMeasureUnitID = value;
                }
            }
        }
        public String ICVitualTransactionType
        {
            get { return _iCVitualTransactionType; }
            set
            {
                if (value != this._iCVitualTransactionType)
                {
                    _iCVitualTransactionType = value;
                }
            }
        }
        public bool ICVitualTransactionIsSpecificCalculation
        {
            get { return _iCVitualTransactionIsSpecificCalculation; }
            set
            {
                if (value != this._iCVitualTransactionIsSpecificCalculation)
                {
                    _iCVitualTransactionIsSpecificCalculation = value;
                }
            }
        }
        public bool ICVitualTransactionIsAverageCalculation
        {
            get { return _iCVitualTransactionIsAverageCalculation; }
            set
            {
                if (value != this._iCVitualTransactionIsAverageCalculation)
                {
                    _iCVitualTransactionIsAverageCalculation = value;
                }
            }
        }
        public String ICVitualTransactionReceiptSerialNo
        {
            get { return _iCVitualTransactionReceiptSerialNo; }
            set
            {
                if (value != this._iCVitualTransactionReceiptSerialNo)
                {
                    _iCVitualTransactionReceiptSerialNo = value;
                }
            }
        }
        public decimal ICVitualTransactionQty
        {
            get { return _iCVitualTransactionQty; }
            set
            {
                if (value != this._iCVitualTransactionQty)
                {
                    _iCVitualTransactionQty = value;
                }
            }
        }
        public decimal ICVitualTransactionFactor
        {
            get { return _iCVitualTransactionFactor; }
            set
            {
                if (value != this._iCVitualTransactionFactor)
                {
                    _iCVitualTransactionFactor = value;
                }
            }
        }
        public decimal ICVitualTransactionExchangeQty
        {
            get { return _iCVitualTransactionExchangeQty; }
            set
            {
                if (value != this._iCVitualTransactionExchangeQty)
                {
                    _iCVitualTransactionExchangeQty = value;
                }
            }
        }
        public decimal ICVitualTransactionUnitCost
        {
            get { return _iCVitualTransactionUnitCost; }
            set
            {
                if (value != this._iCVitualTransactionUnitCost)
                {
                    _iCVitualTransactionUnitCost = value;
                }
            }
        }
        public decimal ICVitualTransactionTotalCost
        {
            get { return _iCVitualTransactionTotalCost; }
            set
            {
                if (value != this._iCVitualTransactionTotalCost)
                {
                    _iCVitualTransactionTotalCost = value;
                }
            }
        }
        public decimal ICVitualTransactionExchangeUnitCost
        {
            get { return _iCVitualTransactionExchangeUnitCost; }
            set
            {
                if (value != this._iCVitualTransactionExchangeUnitCost)
                {
                    _iCVitualTransactionExchangeUnitCost = value;
                }
            }
        }
        public decimal ICVitualTransactionExchangeTotalCost
        {
            get { return _iCVitualTransactionExchangeTotalCost; }
            set
            {
                if (value != this._iCVitualTransactionExchangeTotalCost)
                {
                    _iCVitualTransactionExchangeTotalCost = value;
                }
            }
        }
        public decimal ICVitualTransactionLength
        {
            get { return _iCVitualTransactionLength; }
            set
            {
                if (value != this._iCVitualTransactionLength)
                {
                    _iCVitualTransactionLength = value;
                }
            }
        }
        public decimal ICVitualTransactionWidth
        {
            get { return _iCVitualTransactionWidth; }
            set
            {
                if (value != this._iCVitualTransactionWidth)
                {
                    _iCVitualTransactionWidth = value;
                }
            }
        }
        public decimal ICVitualTransactionHeight
        {
            get { return _iCVitualTransactionHeight; }
            set
            {
                if (value != this._iCVitualTransactionHeight)
                {
                    _iCVitualTransactionHeight = value;
                }
            }
        }
        public String ICVitualTransactionPurposeType
        {
            get { return _iCVitualTransactionPurposeType; }
            set
            {
                if (value != this._iCVitualTransactionPurposeType)
                {
                    _iCVitualTransactionPurposeType = value;
                }
            }
        }
        #endregion
    }
    #endregion
}