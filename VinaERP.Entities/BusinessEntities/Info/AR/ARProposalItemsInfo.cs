﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region ARProposalItems
    //-----------------------------------------------------------
    //Generated By:VinaERP Studio
    //Class:ARProposalItemsInfo
    //Created Date:Tuesday, May 21, 2019
    //-----------------------------------------------------------

    public class ARProposalItemsInfo : BusinessObject
    {
        public ARProposalItemsInfo()
        {
        }
        #region Variables
        protected int _aRProposalItemID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _fK_ARProposalID;
        protected int _fK_ICDepartmentID;
        protected int _fK_ICProductGroupID;
        protected int _fK_ICProductID;
        protected String _aRProposalItemProductType = String.Empty;
        protected String _aRProposalItemProductNo = String.Empty;
        protected String _aRProposalItemProductName = String.Empty;
        protected String _aRProposalItemDesc = String.Empty;
        protected decimal _aRProposalItemProductUnitPrice;
        protected decimal _aRProposalItemQty;
        protected decimal _aRProposalItemPrice;
        protected decimal _aRProposalItemTaxAmount;
        protected decimal _aRProposalItemDiscountAmount;
        protected decimal _aRProposalItemNetAmount;
        protected decimal _aRProposalItemTotalAmount;
        protected int _fK_ICMeasureUnitID;
        protected int _fK_APSupplierID;
        protected decimal _aRProposalItemHeight;
        protected decimal _aRProposalItemWidth;
        protected decimal _aRProposalItemLength;
        protected decimal _aRProposalItemDiscountPercent;
        protected decimal _aRProposalItemTaxPercent;
        #endregion

        #region Public properties
        public int ARProposalItemID
        {
            get { return _aRProposalItemID; }
            set
            {
                if (value != this._aRProposalItemID)
                {
                    _aRProposalItemID = value;
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
        public int FK_ARProposalID
        {
            get { return _fK_ARProposalID; }
            set
            {
                if (value != this._fK_ARProposalID)
                {
                    _fK_ARProposalID = value;
                }
            }
        }
        public int FK_ICDepartmentID
        {
            get { return _fK_ICDepartmentID; }
            set
            {
                if (value != this._fK_ICDepartmentID)
                {
                    _fK_ICDepartmentID = value;
                }
            }
        }
        public int FK_ICProductGroupID
        {
            get { return _fK_ICProductGroupID; }
            set
            {
                if (value != this._fK_ICProductGroupID)
                {
                    _fK_ICProductGroupID = value;
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
        public String ARProposalItemProductType
        {
            get { return _aRProposalItemProductType; }
            set
            {
                if (value != this._aRProposalItemProductType)
                {
                    _aRProposalItemProductType = value;
                }
            }
        }
        public String ARProposalItemProductNo
        {
            get { return _aRProposalItemProductNo; }
            set
            {
                if (value != this._aRProposalItemProductNo)
                {
                    _aRProposalItemProductNo = value;
                }
            }
        }
        public String ARProposalItemProductName
        {
            get { return _aRProposalItemProductName; }
            set
            {
                if (value != this._aRProposalItemProductName)
                {
                    _aRProposalItemProductName = value;
                }
            }
        }
        public String ARProposalItemDesc
        {
            get { return _aRProposalItemDesc; }
            set
            {
                if (value != this._aRProposalItemDesc)
                {
                    _aRProposalItemDesc = value;
                }
            }
        }
        public decimal ARProposalItemProductUnitPrice
        {
            get { return _aRProposalItemProductUnitPrice; }
            set
            {
                if (value != this._aRProposalItemProductUnitPrice)
                {
                    _aRProposalItemProductUnitPrice = value;
                }
            }
        }
        public decimal ARProposalItemQty
        {
            get { return _aRProposalItemQty; }
            set
            {
                if (value != this._aRProposalItemQty)
                {
                    _aRProposalItemQty = value;
                }
            }
        }
        public decimal ARProposalItemPrice
        {
            get { return _aRProposalItemPrice; }
            set
            {
                if (value != this._aRProposalItemPrice)
                {
                    _aRProposalItemPrice = value;
                }
            }
        }
        public decimal ARProposalItemTaxAmount
        {
            get { return _aRProposalItemTaxAmount; }
            set
            {
                if (value != this._aRProposalItemTaxAmount)
                {
                    _aRProposalItemTaxAmount = value;
                }
            }
        }
        public decimal ARProposalItemDiscountAmount
        {
            get { return _aRProposalItemDiscountAmount; }
            set
            {
                if (value != this._aRProposalItemDiscountAmount)
                {
                    _aRProposalItemDiscountAmount = value;
                }
            }
        }
        public decimal ARProposalItemNetAmount
        {
            get { return _aRProposalItemNetAmount; }
            set
            {
                if (value != this._aRProposalItemNetAmount)
                {
                    _aRProposalItemNetAmount = value;
                }
            }
        }
        public decimal ARProposalItemTotalAmount
        {
            get { return _aRProposalItemTotalAmount; }
            set
            {
                if (value != this._aRProposalItemTotalAmount)
                {
                    _aRProposalItemTotalAmount = value;
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
        public int FK_APSupplierID
        {
            get { return _fK_APSupplierID; }
            set
            {
                if (value != this._fK_APSupplierID)
                {
                    _fK_APSupplierID = value;
                }
            }
        }
        public decimal ARProposalItemHeight
        {
            get { return _aRProposalItemHeight; }
            set
            {
                if (value != this._aRProposalItemHeight)
                {
                    _aRProposalItemHeight = value;
                }
            }
        }
        public decimal ARProposalItemWidth
        {
            get { return _aRProposalItemWidth; }
            set
            {
                if (value != this._aRProposalItemWidth)
                {
                    _aRProposalItemWidth = value;
                }
            }
        }
        public decimal ARProposalItemLength
        {
            get { return _aRProposalItemLength; }
            set
            {
                if (value != this._aRProposalItemLength)
                {
                    _aRProposalItemLength = value;
                }
            }
        }
        public decimal ARProposalItemDiscountPercent
        {
            get { return _aRProposalItemDiscountPercent; }
            set
            {
                if (value != this._aRProposalItemDiscountPercent)
                {
                    _aRProposalItemDiscountPercent = value;
                }
            }
        }
        public decimal ARProposalItemTaxPercent
        {
            get { return _aRProposalItemTaxPercent; }
            set
            {
                if (value != this._aRProposalItemTaxPercent)
                {
                    _aRProposalItemTaxPercent = value;
                }
            }
        }
        #endregion
    }
    #endregion
}