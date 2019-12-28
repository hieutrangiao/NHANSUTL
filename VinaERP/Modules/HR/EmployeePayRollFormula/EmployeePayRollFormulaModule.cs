using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.EmployeePayRollFormula
{

    public class EmployeePayRollFormulaModule : BaseModuleERP
    {
        #region Constant
        #endregion
        public EmployeePayRollFormulaModule()
        {
            CurrentModuleName = "EmployeePayRollFormula";
            CurrentModuleEntity = new EmployeePayRollFormulaEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }
        public void RemoveSelectedItemFromEmployeePayrollFormulaList()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            entity.EmployeePayrollFormulaItemsList.RemoveSelectedRowObjectFromList();
        }
        public void RemoveSelectedAllowanceConfig()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            entity.AllowanceConfigsList.RemoveSelectedRowObjectFromList();
        }
        public void RemoveSelectedTimesheetEmployeeLate()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            entity.TimesheetEmployeeLatesList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedFactor()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            entity.OTFactorsList.RemoveSelectedRowObjectFromList();
        }
        public void RemoveSelectedWorkingShift()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            entity.WorkingShiftsList.RemoveSelectedRowObjectFromList();
        }
        public void UpdateTimesheetEmployeeLate()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            HRTimesheetEmployeeLatesInfo objHRTimesheetEmployeeLatesInfo = (HRTimesheetEmployeeLatesInfo)entity.TimesheetEmployeeLatesList[entity.TimesheetEmployeeLatesList.CurrentIndex];
            if (objHRTimesheetEmployeeLatesInfo.FK_HRTimesheetEmployeeLateConfigID > 0)
            {
                HRTimesheetEmployeeLateConfigsController objTimesheetEmployeeLateConfigsController = new HRTimesheetEmployeeLateConfigsController();
                HRTimesheetEmployeeLateConfigsInfo objHRTimesheetEmployeeLateConfigsInfo = (HRTimesheetEmployeeLateConfigsInfo)objTimesheetEmployeeLateConfigsController.GetObjectByID(objHRTimesheetEmployeeLatesInfo.FK_HRTimesheetEmployeeLateConfigID);
                if (objHRTimesheetEmployeeLateConfigsInfo != null)
                {
                    objHRTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct = objHRTimesheetEmployeeLateConfigsInfo.HRTimesheetEmployeeLateConfigDeduct;
                    objHRTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateOTTime = objHRTimesheetEmployeeLateConfigsInfo.HRTimesheetEmployeeLateConfigOTTime;
                    objHRTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateTimeFrom = objHRTimesheetEmployeeLateConfigsInfo.HRTimesheetEmployeeLateConfigTimeFrom;
                    objHRTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateTimeTo = objHRTimesheetEmployeeLateConfigsInfo.HRTimesheetEmployeeLateConfigTimeTo;
                    objHRTimesheetEmployeeLatesInfo.FK_HRTimesheetEmployeeLateConfigID = objHRTimesheetEmployeeLateConfigsInfo.HRTimesheetEmployeeLateConfigID;
                }
            }
            entity.TimesheetEmployeeLatesList.GridControl.RefreshDataSource();
        }

        public void UpdateHROTFactor()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            HROTFactorsInfo objHROTFactorsInfo = (HROTFactorsInfo)entity.OTFactorsList[entity.OTFactorsList.CurrentIndex];
            if (objHROTFactorsInfo.FK_ADOTFactorID > 0)
            {
                ADOTFactorsController objADOTFactorsController = new ADOTFactorsController();
                ADOTFactorsInfo objADOTFactorsInfo = (ADOTFactorsInfo)objADOTFactorsController.GetObjectByID(objHROTFactorsInfo.FK_ADOTFactorID);

                if (objADOTFactorsInfo != null)
                {
                    objHROTFactorsInfo.FK_ADOTFactorID = objADOTFactorsInfo.ADOTFactorID;
                    objHROTFactorsInfo.HROTFactorValue = objADOTFactorsInfo.ADOTFactorValue;
                    objHROTFactorsInfo.HROTFactorType = objADOTFactorsInfo.ADOTFactorType;
                }
            }
            entity.OTFactorsList.GridControl.RefreshDataSource();
        }

        public void UpdateWorkingShift()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)CurrentModuleEntity;
            HRWorkingShiftsInfo objHRWorkingShiftsInfo = (HRWorkingShiftsInfo)entity.WorkingShiftsList[entity.WorkingShiftsList.CurrentIndex];
            if (objHRWorkingShiftsInfo.FK_ADWorkingShiftID > 0)
            {
                ADWorkingShiftsController objADWorkingShiftsController = new ADWorkingShiftsController();
                ADWorkingShiftsInfo objADWorkingShiftsInfo = (ADWorkingShiftsInfo)objADWorkingShiftsController.GetObjectByID(objHRWorkingShiftsInfo.FK_ADWorkingShiftID);
                if (objADWorkingShiftsInfo != null)
                {
                    objHRWorkingShiftsInfo.HRWorkingShiftDayOffWeek = objADWorkingShiftsInfo.ADWorkingShiftDayOffWeek;
                    objHRWorkingShiftsInfo.HRWorkingShiftDesc = objADWorkingShiftsInfo.ADWorkingShiftDesc;
                    objHRWorkingShiftsInfo.HRWorkingShiftFromTime = objADWorkingShiftsInfo.ADWorkingShiftFromTime;
                    objHRWorkingShiftsInfo.HRWorkingShiftIsDefault = objADWorkingShiftsInfo.ADWorkingShiftIsDefault;
                    objHRWorkingShiftsInfo.HRWorkingShiftNight = objADWorkingShiftsInfo.ADWorkingShiftNight;
                    objHRWorkingShiftsInfo.HRWorkingShiftTimeBreak = objADWorkingShiftsInfo.ADWorkingShiftTimeBreak;
                    objHRWorkingShiftsInfo.HRWorkingShiftToTime = objADWorkingShiftsInfo.ADWorkingShiftToTime;
                    objHRWorkingShiftsInfo.HRWorkingShiftWorkingTime = objADWorkingShiftsInfo.ADWorkingShiftWorkingTime;
                }
            }
            entity.WorkingShiftsList.GridControl.RefreshDataSource();
        }
    }
}
