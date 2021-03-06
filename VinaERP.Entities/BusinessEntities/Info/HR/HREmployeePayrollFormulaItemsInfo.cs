﻿using System;
using System.Text;
using System.Collections.Generic;
using VinaLib;
namespace VinaERP
{
    #region HREmployeePayrollFormulaItems
    //-----------------------------------------------------------
    //Generated By: Vina Studio
    //Class:HREmployeePayrollFormulaItemsInfo
    //Created Date:Tuesday, June 14, 2016
    //-----------------------------------------------------------

    public class HREmployeePayrollFormulaItemsInfo : BusinessObject
    {
        public HREmployeePayrollFormulaItemsInfo()
        {
        }
        #region Variables
        protected int _hREmployeePayrollFormulaItemID;
        protected String _aAStatus = DefaultAAStatus;
        protected int _fK_HREmployeePayrollFormulaID;
        protected int _fK_HRTimesheetGroupID;
        protected String _hREmployeePayrollFormulaSalaryType = String.Empty;
        protected String _hREmployeePayrollFormulaSalaryTypeOption = String.Empty;
        protected String _hREmployeePayrollFormulaSalaryRemark = String.Empty;
        #endregion

        #region Public properties
        public int HREmployeePayrollFormulaItemID
        {
            get { return _hREmployeePayrollFormulaItemID; }
            set
            {
                if (value != this._hREmployeePayrollFormulaItemID)
                {
                    _hREmployeePayrollFormulaItemID = value;
                    NotifyChanged("HREmployeePayrollFormulaItemID");
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
        public int FK_HREmployeePayrollFormulaID
        {
            get { return _fK_HREmployeePayrollFormulaID; }
            set
            {
                if (value != this._fK_HREmployeePayrollFormulaID)
                {
                    _fK_HREmployeePayrollFormulaID = value;
                    NotifyChanged("FK_HREmployeePayrollFormulaID");
                }
            }
        }
        public int FK_HRTimesheetGroupID
        {
            get { return _fK_HRTimesheetGroupID; }
            set
            {
                if (value != this._fK_HRTimesheetGroupID)
                {
                    _fK_HRTimesheetGroupID = value;
                    NotifyChanged("FK_HRTimesheetGroupID");
                }
            }
        }
        public String HREmployeePayrollFormulaSalaryType
        {
            get { return _hREmployeePayrollFormulaSalaryType; }
            set
            {
                if (value != this._hREmployeePayrollFormulaSalaryType)
                {
                    _hREmployeePayrollFormulaSalaryType = value;
                    NotifyChanged("HREmployeePayrollFormulaSalaryType");
                }
            }
        }
        public String HREmployeePayrollFormulaSalaryTypeOption
        {
            get { return _hREmployeePayrollFormulaSalaryTypeOption; }
            set
            {
                if (value != this._hREmployeePayrollFormulaSalaryTypeOption)
                {
                    _hREmployeePayrollFormulaSalaryTypeOption = value;
                    NotifyChanged("HREmployeePayrollFormulaSalaryTypeOption");
                }
            }
        }
        public String HREmployeePayrollFormulaSalaryRemark
        {
            get { return _hREmployeePayrollFormulaSalaryRemark; }
            set
            {
                if (value != this._hREmployeePayrollFormulaSalaryRemark)
                {
                    _hREmployeePayrollFormulaSalaryRemark = value;
                    NotifyChanged("HREmployeePayrollFormulaSalaryRemark");
                }
            }
        }
        #endregion
    }
    #endregion
}