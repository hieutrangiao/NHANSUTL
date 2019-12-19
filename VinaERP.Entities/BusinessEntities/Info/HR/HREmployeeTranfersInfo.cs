﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HREmployeeTranfers
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HREmployeeTranfersInfo
    //Created Date:Thursday, October 10, 2013
    //-----------------------------------------------------------

    public class HREmployeeTranfersInfo : BusinessObject
    {
        public HREmployeeTranfersInfo()
        {
        }
        #region Variables
        protected int _hREmployeeTranferID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _aACreatedUser = String.Empty;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected String _aAUpdatedUser = String.Empty;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected int _fK_HREmployeeID;
        protected int _fK_HRDepartmentID;
        protected int _fK_HRDepartmentRoomID;
        protected int _fK_BRBranchID;
        protected int _fK_HRLevelID;
        protected String _hREmployeeTranferType = String.Empty;
        protected DateTime _hREmployeeTranferDateFrom = DateTime.MaxValue;
        protected DateTime _hREmployeeTranferDateTo = DateTime.MaxValue;
        protected decimal _hREmployeeTranferSalary;
        protected decimal _hREmployeeTranferSalaryFactor;
        protected decimal _hREmployeeTranferExtraSalary;
        protected decimal _hREmployeeTranferAllowances;
        protected DateTime _hREmployeeTranferSignDate = DateTime.MaxValue;
        protected int _hREmployeeTranferSigner;
        protected String _hREmployeeTranferRemark = String.Empty;
        protected String _hREmployeeTranferNo = String.Empty;
        protected int _fK_HREmployeeContractID;
        protected String _hREmployeeTranferAllowanceAnother = String.Empty;
        protected String _hREmployeeTranferDecisionNumber = String.Empty;
        protected DateTime _hREmployeeTranferDateIssued = DateTime.MaxValue;
        protected int _fK_HREmployeeDecisionID;
        protected decimal _hREmployeeTranferExtraSalaryDate;

        #endregion

        #region Public properties
        public int HREmployeeTranferID
        {
            get { return _hREmployeeTranferID; }
            set
            {
                if (value != this._hREmployeeTranferID)
                {
                    _hREmployeeTranferID = value;
                    NotifyChanged("HREmployeeTranferID");
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
        public int FK_HREmployeeID
        {
            get { return _fK_HREmployeeID; }
            set
            {
                if (value != this._fK_HREmployeeID)
                {
                    _fK_HREmployeeID = value;
                    NotifyChanged("FK_HREmployeeID");
                }
            }
        }
        public int FK_HRDepartmentID
        {
            get { return _fK_HRDepartmentID; }
            set
            {
                if (value != this._fK_HRDepartmentID)
                {
                    _fK_HRDepartmentID = value;
                    NotifyChanged("FK_HRDepartmentID");
                }
            }
        }
        public int FK_HRDepartmentRoomID
        {
            get { return _fK_HRDepartmentRoomID; }
            set
            {
                if (value != this._fK_HRDepartmentRoomID)
                {
                    _fK_HRDepartmentRoomID = value;
                    NotifyChanged("FK_HRDepartmentRoomID");
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
                    NotifyChanged("FK_BRBranchID");
                }
            }
        }
        public int FK_HRLevelID
        {
            get { return _fK_HRLevelID; }
            set
            {
                if (value != this._fK_HRLevelID)
                {
                    _fK_HRLevelID = value;
                    NotifyChanged("FK_HRLevelID");
                }
            }
        }
        public String HREmployeeTranferType
        {
            get { return _hREmployeeTranferType; }
            set
            {
                if (value != this._hREmployeeTranferType)
                {
                    _hREmployeeTranferType = value;
                    NotifyChanged("HREmployeeTranferType");
                }
            }
        }
        public DateTime HREmployeeTranferDateFrom
        {
            get { return _hREmployeeTranferDateFrom; }
            set
            {
                if (value != this._hREmployeeTranferDateFrom)
                {
                    _hREmployeeTranferDateFrom = value;
                    NotifyChanged("HREmployeeTranferDateFrom");
                }
            }
        }
        public DateTime HREmployeeTranferDateTo
        {
            get { return _hREmployeeTranferDateTo; }
            set
            {
                if (value != this._hREmployeeTranferDateTo)
                {
                    _hREmployeeTranferDateTo = value;
                    NotifyChanged("HREmployeeTranferDateTo");
                }
            }
        }
        public decimal HREmployeeTranferSalary
        {
            get { return _hREmployeeTranferSalary; }
            set
            {
                if (value != this._hREmployeeTranferSalary)
                {
                    _hREmployeeTranferSalary = value;
                    NotifyChanged("HREmployeeTranferSalary");
                }
            }
        }
        public decimal HREmployeeTranferSalaryFactor
        {
            get { return _hREmployeeTranferSalaryFactor; }
            set
            {
                if (value != this._hREmployeeTranferSalaryFactor)
                {
                    _hREmployeeTranferSalaryFactor = value;
                    NotifyChanged("HREmployeeTranferSalaryFactor");
                }
            }
        }
        public decimal HREmployeeTranferExtraSalary
        {
            get { return _hREmployeeTranferExtraSalary; }
            set
            {
                if (value != this._hREmployeeTranferExtraSalary)
                {
                    _hREmployeeTranferExtraSalary = value;
                    NotifyChanged("HREmployeeTranferExtraSalary");
                }
            }
        }
        public decimal HREmployeeTranferAllowances
        {
            get { return _hREmployeeTranferAllowances; }
            set
            {
                if (value != this._hREmployeeTranferAllowances)
                {
                    _hREmployeeTranferAllowances = value;
                    NotifyChanged("HREmployeeTranferAllowances");
                }
            }
        }
        public DateTime HREmployeeTranferSignDate
        {
            get { return _hREmployeeTranferSignDate; }
            set
            {
                if (value != this._hREmployeeTranferSignDate)
                {
                    _hREmployeeTranferSignDate = value;
                    NotifyChanged("HREmployeeTranferSignDate");
                }
            }
        }
        public int HREmployeeTranferSigner
        {
            get { return _hREmployeeTranferSigner; }
            set
            {
                if (value != this._hREmployeeTranferSigner)
                {
                    _hREmployeeTranferSigner = value;
                    NotifyChanged("HREmployeeTranferSigner");
                }
            }
        }
        public String HREmployeeTranferRemark
        {
            get { return _hREmployeeTranferRemark; }
            set
            {
                if (value != this._hREmployeeTranferRemark)
                {
                    _hREmployeeTranferRemark = value;
                    NotifyChanged("HREmployeeTranferRemark");
                }
            }
        }
        public String HREmployeeTranferNo
        {
            get { return _hREmployeeTranferNo; }
            set
            {
                if (value != this._hREmployeeTranferNo)
                {
                    _hREmployeeTranferNo = value;
                    NotifyChanged("HREmployeeTranferNo");
                }
            }
        }
        public int FK_HREmployeeContractID
        {
            get { return _fK_HREmployeeContractID; }
            set
            {
                if (value != this._fK_HREmployeeContractID)
                {
                    _fK_HREmployeeContractID = value;
                    NotifyChanged("FK_HREmployeeContractID");
                }
            }
        }
        public String HREmployeeTranferAllowanceAnother
        {
            get { return _hREmployeeTranferAllowanceAnother; }
            set
            {
                if (value != this._hREmployeeTranferAllowanceAnother)
                {
                    _hREmployeeTranferAllowanceAnother = value;
                    NotifyChanged("HREmployeeTranferAllowanceAnother");
                }
            }
        }
        public String HREmployeeTranferDecisionNumber
        {
            get { return _hREmployeeTranferDecisionNumber; }
            set
            {
                if (value != this._hREmployeeTranferDecisionNumber)
                {
                    _hREmployeeTranferDecisionNumber = value;
                    NotifyChanged("HREmployeeTranferDecisionNumber");
                }
            }
        }
        public DateTime HREmployeeTranferDateIssued
        {
            get { return _hREmployeeTranferDateIssued; }
            set
            {
                if (value != this._hREmployeeTranferDateIssued)
                {
                    _hREmployeeTranferDateIssued = value;
                    NotifyChanged("HREmployeeTranferDateIssued");
                }
            }
        }
        public int FK_HREmployeeDecisionID
        {
            get { return _fK_HREmployeeDecisionID; }
            set
            {
                if (value != this._fK_HREmployeeDecisionID)
                {
                    _fK_HREmployeeDecisionID = value;
                    NotifyChanged("FK_HREmployeeDecisionID");
                }
            }
        }
        public decimal HREmployeeTranferExtraSalaryDate
        {
            get { return _hREmployeeTranferExtraSalaryDate; }
            set
            {
                if (value != this._hREmployeeTranferExtraSalaryDate)
                {
                    _hREmployeeTranferExtraSalaryDate = value;
                    NotifyChanged("HREmployeeTranferExtraSalaryDate");
                }
            }
        }

        #endregion


        public int HRDepartmentIDOld { get; set; }
        public int HRDepartmentRoomIDOld { get; set; }
        public int BRBranchIDOld { get; set; }
        public int HRLevelIDOld { get; set; }

        public string HREmployeeTranferSignerName { get; set; }
        public string HREmployeeTranferSignerAddress { get; set; }
        public string HREmployeeName { get; set; }
        public string HREmployeePhone { get; set; }
        public string HRLevelName { get; set; }
        public string HRSignerLevelName { get; set; }
        public string GENativeStateName { get; set; }
        public string HREmployeeCareer { get; set; }
        public string HREmployeeAddress { get; set; }
        public string HREmployeeIDNumber { get; set; }
        public DateTime HREmployeeIDCardDate { get; set; }
        public string GEIDCardStateProvinceName { get; set; }
        public DateTime HREmployeeBirthday { get; set; }
        public string HREmployeeDesc { get; set; }
        public string HREmployeeContractNo { get; set; }
        public DateTime HREmployeeContractSignDate { get; set; }
        public decimal HREmployeeContractExtralSalary { get; set; }

        public String HRDepartmentRoomNameOld { get; set; }
        public String HRLevelNameOld { get; set; }
        public String BRBranchName { get; set; }
    }
    #endregion
}