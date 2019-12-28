using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaCommon;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.EmployeePayRollFormula
{
    public class EmployeePayRollFormulaEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeePayrollFormulaItemsInfo> EmployeePayrollFormulaItemsList { get; set; }
        public VinaList<HRWorkingShiftsInfo> WorkingShiftsList { get; set; }
        public VinaList<HROTFactorsInfo> OTFactorsList { get; set; }
        public VinaList<HRTimesheetEmployeeLatesInfo> TimesheetEmployeeLatesList { get; set; }
        public VinaList<HRTimesheetConfigsInfo> TimesheetConfigsList { get; set; }
        public VinaList<HRAllowanceConfigsInfo> AllowanceConfigsList { get; set; }
        #endregion

        #region Constructor
        public EmployeePayRollFormulaEntities()
            : base()
        {
            EmployeePayrollFormulaItemsList = new VinaList<HREmployeePayrollFormulaItemsInfo>();
            WorkingShiftsList = new VinaList<HRWorkingShiftsInfo>();
            OTFactorsList = new VinaList<HROTFactorsInfo>();
            TimesheetEmployeeLatesList = new VinaList<HRTimesheetEmployeeLatesInfo>();
            TimesheetConfigsList = new VinaList<HRTimesheetConfigsInfo>();
            AllowanceConfigsList = new VinaList<HRAllowanceConfigsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HREmployeePayrollFormulasInfo();
            SearchObject = new HREmployeePayrollFormulasInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeePayrollFormulaItemsList.InitVinaList(this,
                                             TableName.HREmployeePayrollFormulasTableName,
                                             TableName.HREmployeePayrollFormulaItemsTableName,
                                             VinaList<HREmployeePayrollFormulaItemsInfo>.cstRelationForeign);
            EmployeePayrollFormulaItemsList.ItemTableForeignKey = "FK_HREmployeePayrollFormulaID";

            WorkingShiftsList.InitVinaList(this,
                                             TableName.HREmployeePayrollFormulasTableName,
                                             TableName.HRWorkingShiftsTableName,
                                             VinaList<HRWorkingShiftsInfo>.cstRelationForeign);
            WorkingShiftsList.ItemTableForeignKey = "FK_HREmployeePayrollFormulaID";

            OTFactorsList.InitVinaList(this,
                                             TableName.HREmployeePayrollFormulasTableName,
                                             TableName.HROTFactorsTableName,
                                             VinaList<HROTFactorsInfo>.cstRelationForeign);
            OTFactorsList.ItemTableForeignKey = "FK_HREmployeePayrollFormulaID";

            TimesheetEmployeeLatesList.InitVinaList(this,
                                             TableName.HREmployeePayrollFormulasTableName,
                                             TableName.HRTimesheetEmployeeLatesTableName,
                                             VinaList<HRTimesheetEmployeeLatesInfo>.cstRelationForeign);
            TimesheetEmployeeLatesList.ItemTableForeignKey = "FK_HREmployeePayrollFormulaID";

            TimesheetConfigsList.InitVinaList(this,
                                             TableName.HREmployeePayrollFormulasTableName,
                                             TableName.HRTimesheetConfigsTableName,
                                             VinaList<HRTimesheetConfigsInfo>.cstRelationForeign);
            TimesheetConfigsList.ItemTableForeignKey = "FK_HREmployeePayrollFormulaID";

            AllowanceConfigsList.InitVinaList(this,
                                             TableName.HREmployeePayrollFormulasTableName,
                                             TableName.HRAllowanceConfigsTableName,
                                             VinaList<HRAllowanceConfigsInfo>.cstRelationForeign);
            AllowanceConfigsList.ItemTableForeignKey = "FK_HREmployeePayrollFormulaID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeePayrollFormulaItemsList.InitVinaListGridControl();
            WorkingShiftsList.InitVinaListGridControl();
            OTFactorsList.InitVinaListGridControl();
            TimesheetEmployeeLatesList.InitVinaListGridControl();
            TimesheetConfigsList.InitVinaListGridControl();
            AllowanceConfigsList.InitVinaListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeePayrollFormulaItemsList.SetDefaultListAndRefreshGridControl();
                WorkingShiftsList.SetDefaultListAndRefreshGridControl();
                OTFactorsList.SetDefaultListAndRefreshGridControl();
                TimesheetEmployeeLatesList.SetDefaultListAndRefreshGridControl();
                TimesheetConfigsList.SetDefaultListAndRefreshGridControl();
                AllowanceConfigsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            EmployeePayrollFormulaItemsList.Invalidate(iObjectID);
            WorkingShiftsList.Invalidate(iObjectID);
            OTFactorsList.Invalidate(iObjectID);
            TimesheetEmployeeLatesList.Invalidate(iObjectID);
            TimesheetConfigsList.Invalidate(iObjectID);
            AllowanceConfigsList.Invalidate(iObjectID);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            EmployeePayrollFormulaItemsList.SaveItemObjects();
            WorkingShiftsList.SaveItemObjects();
            OTFactorsList.SaveItemObjects();
            TimesheetEmployeeLatesList.SaveItemObjects();
            TimesheetConfigsList.SaveItemObjects();
            AllowanceConfigsList.SaveItemObjects();
        }
        #endregion
    }
}
