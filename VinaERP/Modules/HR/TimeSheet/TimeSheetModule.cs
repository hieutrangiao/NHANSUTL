using BOSERP.Modules.TimeSheet;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.TimeSheet
{

    public class TimeSheetModule : BaseModuleERP
    {
        #region Constant
        public const string TimeSheetTypeLookupEditName = "fld_lkeHRTimeSheetType";
        public const string TimeSheetValueTextBoxName = "fld_txtHRTimeSheetValue";
        #endregion
        #region Public Properties
        private decimal HoursPerDay = 0;
        #endregion
        public TimeSheetModule()
        {
            CurrentModuleName = "TimeSheet";
            CurrentModuleEntity = new TimeSheetEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            InitializeTimeSheetEntryGridControl();
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo mainObject = (HRTimeSheetsInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HRTimeSheetID > 0)
            {
                if(mainObject.HRTimeSheetStatus == TimeSheetStatus.New.ToString())
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
                }
                else
                {
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                }
            }
            
        }

        public void RemoveSelectedItemFromTimeSheetItemList()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            entity.EmployeeTimeSheetsList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)entity.MainObject;
            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeTimeSheetsList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                HRLeaveDaysController objLeaveDaysController = new HRLeaveDaysController();
                List<HRLeaveDaysInfo> leaveDays = objLeaveDaysController.GetLeaveDayList(timeSheet.HRTimeSheetFromDate, timeSheet.HRTimeSheetToDate);

                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    if (!entity.EmployeeTimeSheetsList.Exists("FK_HREmployeeID", objEmployeesInfo.HREmployeeID))
                    {
                        //set default employee information
                        HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo = SetEmployeeTimeSheetInfoFromEmployee(objEmployeesInfo);

                        //add default holiday timesheet param
                        AddDefaulTimeSheetEntries(objEmployeeTimeSheetsInfo);

                        List<HRTimeSheetEntrysInfo> timeSheetEntrys = objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.Where(t => t.FK_HREmployeeID == objEmployeeTimeSheetsInfo.FK_HREmployeeID).ToList();

                        //Add time sheet entries from leave days
                        List<HRLeaveDaysInfo> employeeLeaveDays = leaveDays.Where(ld => ld.FK_HREmployeeID == objEmployeeTimeSheetsInfo.FK_HREmployeeID).ToList();
                        foreach (HRLeaveDaysInfo employeeLeaveDay in employeeLeaveDays)
                        {
                            HRTimeSheetEntrysInfo entry = timeSheetEntrys.Where(e => e.FK_HREmployeeID == employeeLeaveDay.FK_HREmployeeID &&
                                                                                e.HRTimeSheetEntryDate.Date == employeeLeaveDay.HRLeaveDayDate.Date).FirstOrDefault();
                            if (entry != null)
                            {
                                entry.FK_HRTimeSheetParamID = employeeLeaveDay.FK_HRTimeSheetParamID;
                            }
                            else
                            {
                                entry = new HRTimeSheetEntrysInfo();
                                entry.FK_HREmployeeID = employeeLeaveDay.FK_HREmployeeID;
                                entry.FK_HRTimeSheetParamID = employeeLeaveDay.FK_HRTimeSheetParamID;
                                entry.HRTimeSheetEntryDate = employeeLeaveDay.HRLeaveDayDate;
                                timeSheetEntrys.Add(entry);
                            }
                        }

                        //EmployeesList.Add(objEmployeesInfo);

                        objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList = timeSheetEntrys;
                        //entity.SetEmployeeTimeSheetValue(objEmployeeTimeSheetsInfo);
                        //UpdateTimeSheetTotalQty(objEmployeeTimeSheetsInfo);
                        entity.EmployeeTimeSheetsList.Add(objEmployeeTimeSheetsInfo);
                        LoadTimeKeeper(timeSheet.HRTimeSheetFromDate.Date, timeSheet.HRTimeSheetToDate.Date, null, false, objEmployeesInfo.HREmployeeID);
                    }
                }
                entity.EmployeeTimeSheetsList.GridControl.RefreshDataSource();
            }
        }

        private HREmployeeTimeSheetsInfo SetEmployeeTimeSheetInfoFromEmployee(HREmployeesInfo objEmployeesInfo)
        {
            HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo = new HREmployeeTimeSheetsInfo();
            BRBranchsController objBranchsController = new BRBranchsController();

            if (objEmployeesInfo != null)
            {
                objEmployeeTimeSheetsInfo.FK_HREmployeeID = objEmployeesInfo.HREmployeeID;
                objEmployeeTimeSheetsInfo.FK_HRDepartmentRoomID = objEmployeesInfo.FK_HRDepartmentRoomID;
                objEmployeeTimeSheetsInfo.HRDepartmentName = objEmployeesInfo.HRDepartmentName;
                objEmployeeTimeSheetsInfo.HRDepartmentRoomName = objEmployeesInfo.HRDepartmentRoomName;
                objEmployeeTimeSheetsInfo.HRDepartmentRoomGroupItemName = objEmployeesInfo.HRDepartmentRoomGroupItemName;
                objEmployeeTimeSheetsInfo.HREmployeeName = objEmployeesInfo.HREmployeeName;
                objEmployeeTimeSheetsInfo.HREmployeeNo = objEmployeesInfo.HREmployeeNo;
                objEmployeeTimeSheetsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                objEmployeeTimeSheetsInfo.HREmployeeStartWorkingTime = objEmployeesInfo.HREmployeeStartWorkingTime;
                objEmployeeTimeSheetsInfo.HREmployeeEndWorkingTime = objEmployeesInfo.HREmployeeEndWorkingTime;
                objEmployeeTimeSheetsInfo.HREmployeeHoursPerDay = objEmployeesInfo.HREmployeeHoursPerDay;
                BRBranchsInfo objBranchsInfo = (BRBranchsInfo)objBranchsController.GetObjectByID(objEmployeesInfo.FK_BRBranchID);
                if (objBranchsInfo != null)
                {
                    objEmployeeTimeSheetsInfo.BRBranchName = objBranchsInfo.BRBranchName;
                }
            }

            return objEmployeeTimeSheetsInfo;

        }

        public int NumOfDayInMonth()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            int numDays = (int)(objTimeSheetsInfo.HRTimeSheetToDate.Date - objTimeSheetsInfo.HRTimeSheetFromDate.Date).TotalDays + 1;
            return numDays;
        }
        public override void ActionNew()
        {
            base.ActionNew();
            InitializeTimeSheetEntryGridControl();
        }

        public override void ActionComplete()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }

        public void RemoveEmployeeFromTimeSheetList()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            BandedGridView bandedView = (BandedGridView)entity.EmployeeTimeSheetsList.GridControl.MainView;
            if (bandedView.FocusedRowHandle >= 0)
            {
                int index = bandedView.GetDataSourceRowIndex(bandedView.FocusedRowHandle);
                entity.EmployeeTimeSheetsList.RemoveAt(index);
                bandedView.RefreshData();
            }
        }

        public void UpdateTimeSheetTotalQty(HREmployeeTimeSheetsInfo employeeTimeSheet)
        {
            employeeTimeSheet.HREmployeeTimeSheetWorkingQty = 0;
            employeeTimeSheet.HREmployeeTimeSheetWorkingSalaryFactor = 0;
            employeeTimeSheet.HREmployeeTimeSheetOTQty = 0;
            employeeTimeSheet.HREmployeeTimeSheetOTSalaryFactor = 0;
            employeeTimeSheet.HREmployeeTimeSheetLeaveQty = 0;
            employeeTimeSheet.HREmployeeTimeSheetLeaveSalaryFactor = 0;
            //employeeTimeSheet.HREmployeeTimeSheetWorkDayQty = 0;
            employeeTimeSheet.HREmployeeTimeSheetNghiLe = 0;

            //get hour per day
            HoursPerDay = GetHourPerDay();

            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            HRTimeSheetEntrysController objTimeSheetEntrysController = new HRTimeSheetEntrysController();
            List<string> employeeTimeSheetDayList = new List<string> {  employeeTimeSheet.HREmployeeTimeSheetDate1, employeeTimeSheet.HREmployeeTimeSheetDate2,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate3, employeeTimeSheet.HREmployeeTimeSheetDate4,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate5, employeeTimeSheet.HREmployeeTimeSheetDate6,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate7, employeeTimeSheet.HREmployeeTimeSheetDate8,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate9, employeeTimeSheet.HREmployeeTimeSheetDate10,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate11, employeeTimeSheet.HREmployeeTimeSheetDate12,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate13, employeeTimeSheet.HREmployeeTimeSheetDate14,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate15, employeeTimeSheet.HREmployeeTimeSheetDate16,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate17, employeeTimeSheet.HREmployeeTimeSheetDate18,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate19, employeeTimeSheet.HREmployeeTimeSheetDate20,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate21, employeeTimeSheet.HREmployeeTimeSheetDate22,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate23, employeeTimeSheet.HREmployeeTimeSheetDate24,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate25, employeeTimeSheet.HREmployeeTimeSheetDate26,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate27, employeeTimeSheet.HREmployeeTimeSheetDate28,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate29, employeeTimeSheet.HREmployeeTimeSheetDate30,
                                                                        employeeTimeSheet.HREmployeeTimeSheetDate31 };

            employeeTimeSheet.HRTimeSheetEntrysList.ForEach(e => e.FK_HRTimeSheetParamID = 0);
            if (employeeTimeSheet.HREmployeeTimeSheetOTDetailsList != null)
                foreach (var item in employeeTimeSheet.HREmployeeTimeSheetOTDetailsList)
                {
                    item.HREmployeeTimeSheetOTDetailHours = 0;
                }
            int numDays = NumOfDayInMonth();
            for (int i = 0; i < numDays; i++)
            {
                string[] paramNumbers = employeeTimeSheetDayList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                DateTime currentDate = objTimeSheetsInfo.HRTimeSheetFromDate.AddDays(i);
                decimal mainEntryValue = 0;

                for (int j = 0; j < paramNumbers.Length; j++)
                {
                    string paramNo = paramNumbers[j].Trim();
                    HRTimeSheetParamsInfo param = entity.TimeSheetParams.Where(p => p.HRTimeSheetParamNo == paramNo).FirstOrDefault();
                    if (param != null)
                    {
                        HRTimeSheetEntrysInfo timeSheetEntry = employeeTimeSheet.HRTimeSheetEntrysList.Where(e => e.HRTimeSheetEntryDate.Date == currentDate.Date &&
                                                                                                                //e.HRTimeSheetParamNo == paramNo &&
                                                                                                                e.FK_HRTimeSheetParamID == param.HRTimeSheetParamID &&
                                                                                                                employeeTimeSheet.FK_HREmployeeID == e.FK_HREmployeeID)
                                                                                                              .FirstOrDefault();
                        if (timeSheetEntry == null)
                        {
                            timeSheetEntry = new HRTimeSheetEntrysInfo();
                            timeSheetEntry.FK_HREmployeeTimeSheetID = employeeTimeSheet.HREmployeeTimeSheetID;
                            timeSheetEntry.FK_HRTimeSheetID = employeeTimeSheet.FK_HRTimeSheetID;
                            timeSheetEntry.FK_HREmployeeID = employeeTimeSheet.FK_HREmployeeID;
                            timeSheetEntry.FK_HRTimeSheetParamID = param.HRTimeSheetParamID;
                            timeSheetEntry.HRTimeSheetEntryDate = currentDate;
                            timeSheetEntry.FK_ADWorkingShiftID = param.FK_ADWorkingShiftID;
                            timeSheetEntry.IsCommonParam = false;
                            if (param.HRTimeSheetParamType != TimeSheetParamType.Day.ToString() && param.HRTimeSheetParamType != TimeSheetParamType.Hour.ToString())
                            {
                                timeSheetEntry.IsCommonParam = true;
                            }
                            if (param.HRTimeSheetParamType == TimeSheetParamType.Day.ToString())
                            {
                                timeSheetEntry.HRTimeSheetEntryWorkingQty = param.HRTimeSheetParamValue1 * param.HRTimeSheetParamValue2;
                                timeSheetEntry.HRTimeSheetEntryWorkingHours = timeSheetEntry.HRTimeSheetEntryWorkingQty * HoursPerDay;
                            }
                            else
                            {
                                timeSheetEntry.HRTimeSheetEntryWorkingHours = param.HRTimeSheetParamValue1 * param.HRTimeSheetParamValue2;
                                timeSheetEntry.HRTimeSheetEntryWorkingQty = timeSheetEntry.HRTimeSheetEntryWorkingHours / HoursPerDay;
                            }
                            employeeTimeSheet.HRTimeSheetEntrysList.Add(timeSheetEntry);
                        }
                        else
                        {
                            timeSheetEntry.FK_HREmployeeTimeSheetID = employeeTimeSheet.HREmployeeTimeSheetID;
                            timeSheetEntry.FK_HRTimeSheetID = employeeTimeSheet.FK_HRTimeSheetID;
                            timeSheetEntry.FK_HREmployeeID = employeeTimeSheet.FK_HREmployeeID;
                            timeSheetEntry.FK_HRTimeSheetParamID = param.HRTimeSheetParamID;
                            timeSheetEntry.HRTimeSheetEntryDate = currentDate;
                            timeSheetEntry.FK_ADWorkingShiftID = param.FK_ADWorkingShiftID;
                            timeSheetEntry.IsCommonParam = false;
                            if (param.HRTimeSheetParamType != TimeSheetParamType.Day.ToString() && param.HRTimeSheetParamType != TimeSheetParamType.Hour.ToString())
                            {
                                timeSheetEntry.IsCommonParam = true;
                            }
                            if (param.HRTimeSheetParamType == TimeSheetParamType.Day.ToString())
                            {
                                timeSheetEntry.HRTimeSheetEntryWorkingQty = param.HRTimeSheetParamValue1 * param.HRTimeSheetParamValue2;
                                timeSheetEntry.HRTimeSheetEntryWorkingHours = timeSheetEntry.HRTimeSheetEntryWorkingQty * HoursPerDay;
                            }
                            else
                            {
                                timeSheetEntry.HRTimeSheetEntryWorkingHours = param.HRTimeSheetParamValue1 * param.HRTimeSheetParamValue2;
                                timeSheetEntry.HRTimeSheetEntryWorkingQty = timeSheetEntry.HRTimeSheetEntryWorkingHours / HoursPerDay;
                            }
                        }

                        List<HROTFactorsInfo> factors = GetOTFactors(employeeTimeSheet, timeSheetEntry, param);

                        if (param.HRTimeSheetParamType == TimeSheetParamType.Day.ToString() ||
                            param.HRTimeSheetParamType == TimeSheetParamType.Hour.ToString())
                        {
                            if (param.IsOTCalculated)
                            {
                                //HieuNT [Ưu tiên lấy hệ số tăng ca theo HREmployeeOTFactor]
                                if (timeSheetEntry.IsOTFactor)
                                {
                                    timeSheetEntry.HRTimeSheetEntryWorkingHours = param.HRTimeSheetParamValue1 * timeSheetEntry.HRTimeSheetEntryFactor;
                                    timeSheetEntry.HRTimeSheetEntryWorkingQty = timeSheetEntry.HRTimeSheetEntryWorkingHours / HoursPerDay;

                                    employeeTimeSheet.HREmployeeTimeSheetOTQty += param.HRTimeSheetParamValue1;
                                    employeeTimeSheet.HREmployeeTimeSheetOTSalaryFactor += param.HRTimeSheetParamValue1 * timeSheetEntry.HRTimeSheetEntryFactor;
                                    foreach (var item in employeeTimeSheet.HREmployeeTimeSheetOTDetailsList)
                                    {
                                        if (item.HREmployeeTimeSheetOTDetailFactor == timeSheetEntry.HRTimeSheetEntryFactor)
                                        {
                                            item.HREmployeeTimeSheetOTDetailHours += param.HRTimeSheetParamValue1;
                                        }
                                    }
                                }
                                else
                                    if (factors != null && factors.Count != 0)
                                {

                                    timeSheetEntry.HRTimeSheetEntryWorkingHours = param.HRTimeSheetParamValue1 * factors[0].HROTFactorValue;
                                    timeSheetEntry.HRTimeSheetEntryWorkingQty = timeSheetEntry.HRTimeSheetEntryWorkingHours / HoursPerDay;

                                    employeeTimeSheet.HREmployeeTimeSheetOTQty += param.HRTimeSheetParamValue1;
                                    employeeTimeSheet.HREmployeeTimeSheetOTSalaryFactor += param.HRTimeSheetParamValue1 * factors[0].HROTFactorValue;
                                    foreach (var item in employeeTimeSheet.HREmployeeTimeSheetOTDetailsList)
                                    {
                                        if (item.HREmployeeTimeSheetOTDetailFactor == factors[0].HROTFactorValue)
                                        {
                                            item.HREmployeeTimeSheetOTDetailHours += param.HRTimeSheetParamValue1;
                                        }
                                    }
                                }
                                else
                                {
                                    timeSheetEntry.HRTimeSheetEntryWorkingHours = param.HRTimeSheetParamValue1 * param.HRTimeSheetParamValue2;
                                    timeSheetEntry.HRTimeSheetEntryWorkingQty = timeSheetEntry.HRTimeSheetEntryWorkingHours / HoursPerDay;

                                    employeeTimeSheet.HREmployeeTimeSheetOTQty += param.HRTimeSheetParamValue1;
                                    employeeTimeSheet.HREmployeeTimeSheetOTSalaryFactor += param.HRTimeSheetParamValue1 * param.HRTimeSheetParamValue2;
                                    foreach (var item in employeeTimeSheet.HREmployeeTimeSheetOTDetailsList)
                                    {
                                        if (item.HREmployeeTimeSheetOTDetailFactor == param.HRTimeSheetParamValue2)
                                        {
                                            item.HREmployeeTimeSheetOTDetailHours += param.HRTimeSheetParamValue1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                mainEntryValue = param.HRTimeSheetParamValue1;
                                decimal totalOTTime = factors.Sum(f => f.OTTime);
                                employeeTimeSheet.HREmployeeTimeSheetWorkingQty += param.HRTimeSheetParamValue1 - totalOTTime;
                                employeeTimeSheet.HREmployeeTimeSheetWorkingSalaryFactor += (param.HRTimeSheetParamValue1 - totalOTTime) * param.HRTimeSheetParamValue2;
                                employeeTimeSheet.HREmployeeTimeSheetOTQty += factors.Sum(f => f.OTTime * f.HROTFactorValue);
                                employeeTimeSheet.HREmployeeTimeSheetOTSalaryFactor += factors.Sum(f => f.OTTime * f.HROTFactorValue) * param.HRTimeSheetParamValue2;
                            }
                        }
                        else if (param.HRTimeSheetParamType.Equals(TimeSheetParamType.Common.ToString()) && !param.HRTimeSheetParamNo.Equals("LE"))
                        {
                            if (objTimeSheetsInfo.HRTimeSheetType.Equals(TimeSheetType.Day.ToString()))
                            {
                                employeeTimeSheet.HREmployeeTimeSheetLeaveQty += param.HRTimeSheetParamValue1 / HoursPerDay;
                                employeeTimeSheet.HREmployeeTimeSheetLeaveSalaryFactor += (param.HRTimeSheetParamValue1 / HoursPerDay) * param.HRTimeSheetParamValue2;
                            }
                            if (objTimeSheetsInfo.HRTimeSheetType.Equals(TimeSheetType.Hour.ToString()))
                            {
                                employeeTimeSheet.HREmployeeTimeSheetLeaveQty += 8 - mainEntryValue;
                                employeeTimeSheet.HREmployeeTimeSheetLeaveSalaryFactor += (8 - mainEntryValue) * param.HRTimeSheetParamValue2;
                            }
                        }
                        else if (param.HRTimeSheetParamType.Equals(TimeSheetParamType.LE.ToString()))
                        {
                            if (objTimeSheetsInfo.HRTimeSheetType.Equals(TimeSheetType.Day.ToString()))
                            {
                                employeeTimeSheet.HREmployeeTimeSheetNghiLe += param.HRTimeSheetParamValue1 / HoursPerDay;
                            }
                            if (objTimeSheetsInfo.HRTimeSheetType.Equals(TimeSheetType.Hour.ToString()))
                            {
                                employeeTimeSheet.HREmployeeTimeSheetNghiLe += 8 - mainEntryValue;
                            }
                        }
                    }
                }
            }
            if (employeeTimeSheet.HRTimeSheetEntrysList != null)
            {
                employeeTimeSheet.HRTimeSheetEntrysList.RemoveAll(o => o.FK_HRTimeSheetParamID == 0);
            }
            entity.UpdateMainObjectBindingSource();
        }

        private decimal GetHourPerDay()
        {
            decimal hourPerDay = 0;
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            string objConfigValuesInfo = objConfigValuesController.GetValueByConfigKey("HoursPerDay").ToString();
            if (objConfigValuesInfo != null)
            {
                hourPerDay = decimal.Parse(objConfigValuesInfo);
            }
            return hourPerDay;
        }

        public List<HROTFactorsInfo> GetOTFactors(HREmployeeTimeSheetsInfo employeeTimeSheet, HRTimeSheetEntrysInfo entry, HRTimeSheetParamsInfo param)
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            decimal holidayFactorValue = 0;
            HROTFactorsController objOTFactorsController = new HROTFactorsController();

            List<HROTFactorsInfo> workingDayFactors = entity.OTFactors.Where(f => f.HROTFactorType == OTFactorType.WorkingDay.ToString() &&
                                                                                f.HREmployeeID == employeeTimeSheet.FK_HREmployeeID &&
                                                                                f.HROTFactorValue == param.HRTimeSheetParamValue2).ToList();

            List<HROTFactorsInfo> holidayFactors = entity.OTFactors.Where(f => f.HROTFactorType == OTFactorType.Holiday.ToString() &&
                                                                                f.HREmployeeID == employeeTimeSheet.FK_HREmployeeID &&
                                                                                f.HROTFactorValue == param.HRTimeSheetParamValue2).ToList();
            List<HROTFactorsInfo> endOfWeekFactors = entity.OTFactors.Where(f => f.HROTFactorType == OTFactorType.EndOfWeek.ToString() &&
                                                                                f.HREmployeeID == employeeTimeSheet.FK_HREmployeeID &&
                                                                                f.HROTFactorValue == param.HRTimeSheetParamValue2).ToList();

            if (!VinaApp.IsEndOfWeek(entry.HRTimeSheetEntryDate.DayOfWeek) && param.IsOTCalculated)
            {
                if (workingDayFactors.Count > 0)
                {
                    holidayFactorValue = workingDayFactors[0].HROTFactorValue;
                }
            }
            if (VinaApp.IsEndOfWeek(entry.HRTimeSheetEntryDate.DayOfWeek) && param.IsOTCalculated)
            {
                if (endOfWeekFactors.Count > 0)
                {
                    holidayFactorValue = endOfWeekFactors[0].HROTFactorValue;
                }
            }
            if (CheckHoliday(entry.HRTimeSheetEntryDate))
            {
                if (holidayFactors.Count > 0)
                {
                    // Get max holiday factor value if day is end of week and holiday
                    if (holidayFactors[0].HROTFactorValue > holidayFactorValue)
                    {
                        holidayFactorValue = holidayFactors[0].HROTFactorValue;
                    }
                }
            }

            //Add end of week and holiday factor to the returned result
            List<HROTFactorsInfo> result = new List<HROTFactorsInfo>();
            if (holidayFactorValue > 0)
            {
                HROTFactorsInfo holidayFactor = new HROTFactorsInfo();
                holidayFactor.OTTime = param.HRTimeSheetParamValue1;
                holidayFactor.HROTFactorValue = holidayFactorValue;
                result.Add(holidayFactor);
            }

            //Add working factor in case the time sheet is hour-calculated
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)entity.MainObject;
            decimal startHour = employeeTimeSheet.HREmployeeStartWorkingTime.Hour;
            decimal endHour = employeeTimeSheet.HREmployeeEndWorkingTime.Hour;
            if (param.HRTimeSheetParamValue1 > employeeTimeSheet.HREmployeeHoursPerDay)
            {
                endHour += param.HRTimeSheetParamValue1 - employeeTimeSheet.HREmployeeHoursPerDay;
            }
            if (timeSheet.HRTimeSheetType == TimeSheetType.Hour.ToString())
            {
                //List<HREmployeeOTFactorsInfo> workingFactors = entity.OTFactors.Where(f => f.HROTFactorType == OTFactorType.WorkingDay.ToString() &&
                //                                                                    f.FK_HREmployeeID == employeeTimeSheet.FK_HREmployeeID).ToList();
                List<HROTFactorsInfo> workingFactors = entity.OTFactors.Where(f => f.HROTFactorType == OTFactorType.WorkingDay.ToString() &&
                                                                                    f.HREmployeeID == employeeTimeSheet.FK_HREmployeeID).ToList();


                foreach (HROTFactorsInfo workingFactor in workingFactors)
                {
                    decimal factorFromHour = workingFactor.HROTFactorFromTime.Hour;
                    decimal factorToHour = workingFactor.HROTFactorToTime.Hour;
                    if (factorToHour == 0)
                    {
                        factorToHour = 24;
                    }

                    if (workingFactor.HROTFactorValue > holidayFactorValue)
                    {
                        if (endHour > factorToHour)
                        {
                            if (startHour <= factorToHour)
                            {
                                workingFactor.OTTime = factorToHour - Math.Max(factorFromHour, startHour);
                                result.Add(workingFactor);
                            }
                        }
                        else if (endHour > factorFromHour)
                        {
                            workingFactor.OTTime = endHour - Math.Max(factorFromHour, startHour);
                            result.Add(workingFactor);
                        }
                    }
                }
            }

            return result;
        }

        public bool CheckHoliday(DateTime dayOfMonth)
        {
            return VinaApp.IsHoliday(dayOfMonth);
        }

        public List<string> GetColumnFieldNameByTypeEndOfWeek()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            List<string> list = new List<string>();
            int numDays = NumOfDayInMonth();
            for (int i = 1; i <= numDays; i++)
            {
                DateTime dayofMonth = objTimeSheetsInfo.HRTimeSheetFromDate.AddDays(i - 1);
                DayOfWeek dayOfWeek = dayofMonth.DayOfWeek;
                if (VinaApp.IsEndOfWeek(dayOfWeek))
                {
                    string columnName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", i.ToString());
                    list.Add(columnName);
                }
            }
            return list;
        }

        public List<string> GetColumnFieldNameByTypeHoliday()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            List<string> list = new List<string>();
            HRCalendarEntrysController objCalendarEntrysController = new HRCalendarEntrysController();
            List<HRCalendarEntrysInfo> entries = objCalendarEntrysController.GetCalendarEntryByDateAndCalenderType(CalendarType.Holiday.ToString(), objTimeSheetsInfo.HRTimeSheetFromDate, objTimeSheetsInfo.HRTimeSheetToDate);
            foreach (HRCalendarEntrysInfo objCalendarEntrysInfo in entries)
            {
                int day = (int)objCalendarEntrysInfo.HRCalendarEntryDate.Day;
                string columnName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", day);
                list.Add(columnName);
            }
            return list;
        }

        public void AddDefaulTimeSheetEntries(HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo)
        {
            objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.Clear();

            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRTimeSheetParamsInfo> timeSheetParams = entity.TimeSheetParams;
            HRTimeSheetParamsInfo defaultParam = (HRTimeSheetParamsInfo)timeSheetParams.Where(
                                                                                        p => p.IsDefault == true &&
                                                                                        p.HRTimeSheetParamType == objTimeSheetsInfo.HRTimeSheetType).FirstOrDefault();
            //TODO: Need to refactor this as we don't have a better way to get holiday param currently
            HRTimeSheetParamsInfo holidayParam = timeSheetParams.Where(p => p.HRTimeSheetParamType == TimeSheetParamType.LE.ToString()).FirstOrDefault();
            if (defaultParam != null)
            {
                VinaDbUtil dbUtil = new VinaDbUtil();
                // fill column if end of week
                List<string> columnFieldNameEndOfWeek = GetColumnFieldNameByTypeEndOfWeek();
                // fill column if holiday
                List<string> columnFieldNameHoliday = GetColumnFieldNameByTypeHoliday();
                int numDays = NumOfDayInMonth();
                for (int i = 1; i <= numDays; i++)
                {
                    DateTime currentDate = objTimeSheetsInfo.HRTimeSheetFromDate.Date.AddDays(i - 1);
                    HRTimeSheetEntrysInfo entry = new HRTimeSheetEntrysInfo();
                    entry.FK_HREmployeeTimeSheetID = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID;
                    entry.FK_HRTimeSheetID = objEmployeeTimeSheetsInfo.FK_HRTimeSheetID;
                    entry.FK_HREmployeeID = objEmployeeTimeSheetsInfo.FK_HREmployeeID;
                    entry.HRTimeSheetEntryDate = currentDate;

                    //Set default param to entry
                    //entry.FK_HRTimeSheetParamID = defaultParam.HRTimeSheetParamID;
                    String propertyName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", i);
                    bool isHoliday = columnFieldNameHoliday.Exists(delegate (string holiday) { return propertyName == holiday; });
                    if (isHoliday && holidayParam != null)
                    {
                        entry.FK_HRTimeSheetParamID = holidayParam.HRTimeSheetParamID;
                    }

                    bool isEndOfWeek = columnFieldNameEndOfWeek.Exists(delegate (string endOfWeek) { return propertyName == endOfWeek; });
                    if (!isEndOfWeek)
                    {
                        objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.Add(entry);
                    }
                }
            }
        }

        public void LoadTimeKeeper(DateTime dateFrom, DateTime dateTo, string employeeCardNo, bool isReset, int? employeeID)
        {
            List<HRTimeSheetEntrysInfo> timeEntries = new List<HRTimeSheetEntrysInfo>();
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)CurrentModuleEntity.MainObject;
            HRTimeKeeperCompletesController objTimeKeeperCompletesController = new HRTimeKeeperCompletesController();
            HREmployeesController objEmployeesController = new HREmployeesController();
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;

            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            List<ADWorkingShiftsInfo> list = new List<ADWorkingShiftsInfo>();
            list = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());

            foreach (HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo in entity.EmployeeTimeSheetsList)
            {
                if (employeeID > 0 && objEmployeeTimeSheetsInfo.FK_HREmployeeID != employeeID)
                {
                    continue;
                }
                string employeeCardNoInFor = "";
                if (employeeCardNo != null)
                {
                    employeeCardNoInFor = employeeCardNo;
                    if (employeeCardNo != objEmployeeTimeSheetsInfo.HREmployeeCardNumber)
                    {
                        goto ENDFOR;
                    }
                }
                else
                {
                    employeeCardNoInFor = objEmployeeTimeSheetsInfo.HREmployeeCardNumber;
                }
                List<HRTimeKeeperCompletesInfo> timeKeeperCompleteList = new List<HRTimeKeeperCompletesInfo>();
                timeKeeperCompleteList = objTimeKeeperCompletesController.GetTimeKeeperByDate(employeeCardNoInFor, dateFrom, dateTo);
                if (string.IsNullOrEmpty(objEmployeeTimeSheetsInfo.HREmployeeCardNumber)) continue;
                if (!string.IsNullOrEmpty(employeeCardNo) && objEmployeeTimeSheetsInfo.HREmployeeCardNumber != employeeCardNo) continue;
                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(objEmployeeTimeSheetsInfo.FK_HREmployeeID);
                objEmployeeTimeSheetsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                int daysInMonth = NumOfDayInMonth();

                for (int i = 1; i <= daysInMonth; i++)
                {
                    DateTime dt = timeSheet.HRTimeSheetFromDate.AddDays(i - 1).Date;
                    if (dt < dateFrom.Date || dt > dateTo.Date) continue;

                    List<HRTimeKeeperCompletesInfo> listTemp = timeKeeperCompleteList.Where(p => p.HRTimeKeeperCompletesEmployeeCardNo == objEmployeeTimeSheetsInfo.HREmployeeCardNumber &&
                        p.HRTimeKeeperCompleteDate == dt.Date).OrderBy(p => p.FK_HROverTimeID).ThenBy(p => p.HRTimeKeeperCompleteTimeCheck).ToList(); //HRTimeKeeperCompleteTimeCheck
                    if (list != null)
                    {
                        List<ADWorkingShiftsInfo> list2 = list.Where(o => o.ADWorkingShiftFromTime.TimeOfDay > o.ADWorkingShiftToTime.TimeOfDay).ToList();
                        if (list2 != null && list2.Count > 0)
                        {
                            list2.ForEach(x =>
                            {
                                listTemp = listTemp.Where(o => o.FK_ADWorkingShiftID != x.ADWorkingShiftID).ToList();
                            });
                        }
                    }
                    for (int j = 0; j < listTemp.Count - 1; j += 2)
                    {
                        HRTimeSheetEntrysInfo objTimeSheetEntrysInfo = new HRTimeSheetEntrysInfo();
                        objTimeSheetEntrysInfo.FK_HREmployeeID = objEmployeeTimeSheetsInfo.FK_HREmployeeID;
                        objTimeSheetEntrysInfo.FK_HREmployeeTimeSheetID = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID;
                        objTimeSheetEntrysInfo.FK_HRTimeSheetID = objEmployeeTimeSheetsInfo.FK_HRTimeSheetID;
                        objTimeSheetEntrysInfo.HREmployeeCardNumber = objEmployeeTimeSheetsInfo.HREmployeeCardNumber;
                        objTimeSheetEntrysInfo.HRTimeSheetEntryDate = dt;
                        if (listTemp[j].HRTimeKeeperCompleteInOutMode == 0)
                        {
                            if (listTemp[j].HRTimeKeeperCompleteTimeCheck != listTemp[j + 1].HRTimeKeeperCompleteTimeCheck)
                            {
                                objTimeSheetEntrysInfo.HRTimeSheetEntryFrom = listTemp[j].HRTimeKeeperCompleteTimeCheck;
                                objTimeSheetEntrysInfo.HRTimeSheetEntryTo = listTemp[j + 1].HRTimeKeeperCompleteTimeCheck;
                                objTimeSheetEntrysInfo.FK_ADWorkingShiftID = listTemp[j].FK_ADWorkingShiftID;
                                objTimeSheetEntrysInfo.FK_HROverTimeID = listTemp[j].FK_HROverTimeID;
                                timeEntries.Add(objTimeSheetEntrysInfo);
                            }
                        }
                        else
                        {
                            if (listTemp[j].HRTimeKeeperCompleteTimeCheck != listTemp[j + 1].HRTimeKeeperCompleteTimeCheck)
                            {
                                objTimeSheetEntrysInfo.HRTimeSheetEntryFrom = listTemp[j + 1].HRTimeKeeperCompleteTimeCheck;
                                objTimeSheetEntrysInfo.HRTimeSheetEntryTo = listTemp[j].HRTimeKeeperCompleteTimeCheck;
                                objTimeSheetEntrysInfo.FK_ADWorkingShiftID = listTemp[j + 1].FK_ADWorkingShiftID;
                                objTimeSheetEntrysInfo.FK_HROverTimeID = listTemp[j + 1].FK_HROverTimeID;
                                timeEntries.Add(objTimeSheetEntrysInfo);
                            }
                        }
                    }
                }
            ENDFOR:;
            }

            //if (list != null)
            //{
            //    List<ADWorkingShiftsInfo> list2 = list.Where(o => o.ADWorkingShiftFromTime.TimeOfDay > o.ADWorkingShiftToTime.TimeOfDay).ToList();
            //    if (list2 != null && list2.Count > 0)
            //    {
            //        foreach (HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo in entity.EmployeeTimeSheetsList)
            //        {
            //            if (employeeID > 0 && objEmployeeTimeSheetsInfo.FK_HREmployeeID != employeeID)
            //            {
            //                continue;
            //            }
            //            string employeeCardNoInFor = "";
            //            if (employeeCardNo != null)
            //            {
            //                employeeCardNoInFor = employeeCardNo;
            //                if (employeeCardNo != objEmployeeTimeSheetsInfo.HREmployeeCardNumber)
            //                {
            //                    goto ENDFOR2;
            //                }
            //            }
            //            else
            //            {
            //                employeeCardNoInFor = objEmployeeTimeSheetsInfo.HREmployeeCardNumber;
            //            }
            //            List<HRTimeKeeperCompletesInfo> timeKeeperCompleteList = new List<HRTimeKeeperCompletesInfo>();
            //            timeKeeperCompleteList = objTimeKeeperCompletesController.GetTimeKeeperByDate(employeeCardNoInFor, dateFrom, dateTo.AddDays(1));
            //            if (string.IsNullOrEmpty(objEmployeeTimeSheetsInfo.HREmployeeCardNumber)) continue;
            //            if (!string.IsNullOrEmpty(employeeCardNo) && objEmployeeTimeSheetsInfo.HREmployeeCardNumber != employeeCardNo) continue;
            //            HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(objEmployeeTimeSheetsInfo.FK_HREmployeeID);
            //            objEmployeeTimeSheetsInfo.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            //            int daysInMonth = NumOfDayInMonth();

            //            for (int i = 1; i <= daysInMonth; i++)
            //            {
            //                DateTime dt = timeSheet.HRTimeSheetFromDate.AddDays(i - 1).Date;
            //                if (dt < dateFrom.Date || dt > dateTo.Date) continue;

            //                List<HRTimeKeeperCompletesInfo> listTemp =
            //                    timeKeeperCompleteList
            //                    .Where(p => p.HRTimeKeeperCompletesEmployeeCardNo == objEmployeeTimeSheetsInfo.HREmployeeCardNumber
            //                        && (p.HRTimeKeeperCompleteDate.Date >= dt.Date && p.HRTimeKeeperCompleteDate <= dt.AddDays(1).Date))
            //                    .OrderBy(p => p.FK_HROverTimeID)
            //                    .ThenBy(p => p.HRTimeKeeperCompleteTimeCheck)
            //                    .ToList();
            //                List<ADWorkingShiftsInfo> list3 = list.Where(o => o.ADWorkingShiftFromTime.TimeOfDay < o.ADWorkingShiftToTime.TimeOfDay).ToList();
            //                list3.ForEach(x =>
            //                {
            //                    listTemp = listTemp.Where(o => o.FK_ADWorkingShiftID != x.ADWorkingShiftID)
            //                        .OrderBy(p => p.FK_HROverTimeID)
            //                        .ThenBy(p => p.HRTimeKeeperCompleteTimeCheck)
            //                        .ToList();
            //                });

            //                list2.ForEach(o =>
            //                {
            //                    for (int j = 0; j < listTemp.Count - 1; j += 1)
            //                    {
            //                        HRTimeSheetEntrysInfo objTimeSheetEntrysInfo = new HRTimeSheetEntrysInfo();
            //                        objTimeSheetEntrysInfo.FK_HREmployeeID = objEmployeeTimeSheetsInfo.FK_HREmployeeID;
            //                        objTimeSheetEntrysInfo.FK_HREmployeeTimeSheetID = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID;
            //                        objTimeSheetEntrysInfo.FK_HRTimeSheetID = objEmployeeTimeSheetsInfo.FK_HRTimeSheetID;
            //                        objTimeSheetEntrysInfo.HREmployeeCardNumber = objEmployeeTimeSheetsInfo.HREmployeeCardNumber;
            //                        objTimeSheetEntrysInfo.HRTimeSheetEntryDate = dt;

            //                        if (o.ADWorkingShiftID == listTemp[j].FK_ADWorkingShiftID)
            //                        {
            //                            if (listTemp[j].FK_HROverTimeID > 0 && listTemp[j + 1].FK_HROverTimeID > 0)
            //                            {
            //                                objTimeSheetEntrysInfo.FK_ADWorkingShiftID = listTemp[j].FK_ADWorkingShiftID;
            //                                objTimeSheetEntrysInfo.FK_HROverTimeID = listTemp[j].FK_HROverTimeID;
            //                                objTimeSheetEntrysInfo.HRTimeSheetEntryFrom = listTemp[j].HRTimeKeeperCompleteTimeCheck;
            //                                objTimeSheetEntrysInfo.HRTimeSheetEntryTo = listTemp[j + 1].HRTimeKeeperCompleteTimeCheck;
            //                                timeEntries.Add(objTimeSheetEntrysInfo);
            //                            }
            //                            else
            //                            {
            //                                objTimeSheetEntrysInfo.FK_ADWorkingShiftID = listTemp[j].FK_ADWorkingShiftID;
            //                                objTimeSheetEntrysInfo.FK_HROverTimeID = listTemp[j].FK_HROverTimeID;

            //                                if (listTemp[j].HRTimeKeeperCompleteTimeCheck.TimeOfDay >= o.ADWorkingShiftTimeKeepInFrom.TimeOfDay
            //                                    && listTemp[j].HRTimeKeeperCompleteTimeCheck.TimeOfDay <= o.ADWorkingShiftTimeKeepInTo.TimeOfDay)
            //                                {
            //                                    objTimeSheetEntrysInfo.HRTimeSheetEntryFrom = listTemp[j].HRTimeKeeperCompleteTimeCheck;
            //                                }

            //                                if (listTemp[j + 1].HRTimeKeeperCompleteTimeCheck.TimeOfDay >= o.ADWorkingShiftTimeKeepOutFrom.TimeOfDay
            //                                    && listTemp[j + 1].HRTimeKeeperCompleteTimeCheck.TimeOfDay <= o.ADWorkingShiftTimeKeepOutTo.TimeOfDay)
            //                                {
            //                                    objTimeSheetEntrysInfo.HRTimeSheetEntryTo = listTemp[j + 1].HRTimeKeeperCompleteTimeCheck;
            //                                    timeEntries.Add(objTimeSheetEntrysInfo);
            //                                }
            //                                else
            //                                {
            //                                    DateTime date = listTemp[j + 1].HRTimeKeeperCompleteTimeCheck.AddDays(1);
            //                                    DateTime date2 = new DateTime(date.Year, date.Month, date.Day, o.ADWorkingShiftTimeKeepOutTo.Hour, o.ADWorkingShiftTimeKeepOutTo.Minute, o.ADWorkingShiftTimeKeepOutTo.Second);
            //                                    if (listTemp[j + 1].HRTimeKeeperCompleteTimeCheck.TimeOfDay >= o.ADWorkingShiftTimeKeepInFrom.TimeOfDay
            //                                        && listTemp[j + 1].HRTimeKeeperCompleteTimeCheck <= date2
            //                                        && objTimeSheetEntrysInfo.HRTimeSheetEntryFrom.Date != DateTime.MaxValue.Date
            //                                        && listTemp[j + 1].HRTimeKeeperCompleteTimeCheck.Date == objTimeSheetEntrysInfo.HRTimeSheetEntryFrom.Date
            //                                        && objTimeSheetEntrysInfo.HRTimeSheetEntryDate.Date == objTimeSheetEntrysInfo.HRTimeSheetEntryFrom.Date)
            //                                    {
            //                                        objTimeSheetEntrysInfo.HRTimeSheetEntryTo = listTemp[j + 1].HRTimeKeeperCompleteTimeCheck;
            //                                        timeEntries.Add(objTimeSheetEntrysInfo);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                });
            //            }
            //        ENDFOR2:;
            //        }
            //    }
            //}
            AddEmployeesFromTimeKeeper(timeEntries, dateFrom, dateTo, isReset, employeeID);
        }

        public void AddEmployeesFromTimeKeeper(List<HRTimeSheetEntrysInfo> timeEntries, DateTime dateFrom, DateTime dateTo, bool isReset, int? employeeID)
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)CurrentModuleEntity.MainObject;

            if (timeEntries == null)
                timeEntries = new List<HRTimeSheetEntrysInfo>();

            HRTimesheetEmployeeLatesController objTimesheetEmployeeLatesController = new HRTimesheetEmployeeLatesController();
            HRWorkingShiftsController workingShiftController = new HRWorkingShiftsController();
            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            List<ADWorkingShiftsInfo> workingShiftList = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());

            List<HRTimeSheetEntrysInfo> timeEntriesByOT = new List<HRTimeSheetEntrysInfo>();
            HRTimeSheetEntrysInfo objTimeSheetEntrysInfo = new HRTimeSheetEntrysInfo();
            timeEntries.ForEach(o =>
            {
                objTimeSheetEntrysInfo = (HRTimeSheetEntrysInfo)o.Clone();
                timeEntriesByOT.Add(objTimeSheetEntrysInfo);
            });
            //get time sheet params
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRTimeSheetParamsInfo> timeSheetParamsList = objTimeSheetParamsController.GetTimeSheetParamsList(timeSheet.HRTimeSheetType);
            List<HRTimeSheetParamsInfo> allTimeSheetParamsList = objTimeSheetParamsController.GetTimeSheetParamsList();
            List<HRTimeSheetParamsInfo> otTimeSheetParamsList = objTimeSheetParamsController.GetOTTimeSheetParamsList();

            //get employee's leave days
            HRLeaveDaysController objLeaveDaysController = new HRLeaveDaysController();
            List<HRLeaveDaysInfo> leaveDays = objLeaveDaysController.GetLeaveDayListByHRTimeSheet(dateFrom, dateTo);

            HREmployeesController objEmployeesController = new HREmployeesController();

            //get hour per day
            HoursPerDay = GetHourPerDay();

            //add time sheeet entries from employee's work schedule
            List<HRTimeSheetEntrysInfo> workScheduleEntries = AddTimeSheetEntryFromEmployeeWorkSchedule();

            List<string> columnFieldNameHoliday = GetColumnFieldNameByTypeHoliday();
            List<HRTimeSheetEntrysInfo> timeKeeperEntries = new List<HRTimeSheetEntrysInfo>();
            List<HRTimeSheetEntrysInfo> timeKeeperEntriesClone = new List<HRTimeSheetEntrysInfo>();
            List<HRTimeSheetEntrysInfo> removedEntries = null;
            #region add time sheet entry from schedule
            int maxMinuteLate = 60;
            //add time sheet entry from schedule
            foreach (var item in timeEntries)
            {
                if (item.FK_ADWorkingShiftID > 0)
                {
                    List<HRTimeSheetEntrysInfo> temp = timeEntries.Where(p => (p.FK_HREmployeeID == item.FK_HREmployeeID &&
                                                p.HRTimeSheetEntryDate.Date == item.HRTimeSheetEntryDate.Date)).ToList();
                    HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(item.FK_HREmployeeID);

                    item.HRTimeSheetEntryWorkingHours = 0;
                    item.HRTimeSheetEntryWorkingQty = 0;
                    DateTime dateMinTimeSheet = DateTime.MaxValue;
                    DateTime dateMaxTimeSheet = DateTime.MinValue;
                    DateTime dateMaxTimeSheetOT = DateTime.MinValue;

                    dateMinTimeSheet = item.HRTimeSheetEntryFrom;
                    dateMaxTimeSheet = item.HRTimeSheetEntryTo;

                    if (timeSheet.HRTimeSheetType == TimeSheetType.Hour.ToString())
                    {
                        HRTimeSheetParamsInfo info = GetTimeSheetParam(timeSheetParamsList, item.HRTimeSheetEntryWorkingHours, false);
                        if (info != null)
                        {
                            item.FK_HRTimeSheetParamID = info.HRTimeSheetParamID;
                        }
                    }
                    else
                    {
                        #region Holiday
                        bool isHoliday = false;

                        if (VinaApp.IsHoliday(item.HRTimeSheetEntryDate))
                        {
                            isHoliday = true;
                        }

                        #endregion
                        item.HRTimeSheetEntryFrom = dateMinTimeSheet;
                        item.HRTimeSheetEntryTo = dateMaxTimeSheet;
                        if (objEmployeesInfo.FK_HREmployeePayrollFormulaID > 0 && !isHoliday && workingShiftList.Count() > 0)
                        {
                            ADWorkingShiftsInfo objWorkingShiftsInfo = (ADWorkingShiftsInfo)workingShiftList.FirstOrDefault(o => o.ADWorkingShiftID == item.FK_ADWorkingShiftID);
                            if (objWorkingShiftsInfo != null)
                            {
                                DateTime dateMinWorkingShift = DateTime.ParseExact(dateMinTimeSheet.ToString("dd/MM/yyyy") + " " + objWorkingShiftsInfo.ADWorkingShiftFromTime.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                DateTime dateMaxWorkingShift = DateTime.ParseExact(dateMinTimeSheet.ToString("dd/MM/yyyy") + " " + objWorkingShiftsInfo.ADWorkingShiftToTime.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                                //Làm việc từ ngày hôm nay sang ngày hôm sau : EX:12h trưa tới 6h sáng hôm sau
                                //Ca làm việc chỉ có từ giờ đến giờ
                                if (dateMaxWorkingShift.Date != DateTime.MaxValue.Date && dateMaxWorkingShift <= dateMinWorkingShift) dateMaxWorkingShift = dateMaxWorkingShift.AddDays(1);
                                int n = (int)(item.HRTimeSheetEntryDate.Date - timeSheet.HRTimeSheetFromDate.Date).TotalDays + 1;
                                String propertyName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", n);
                                if (dateMinTimeSheet < dateMinWorkingShift) dateMinTimeSheet = dateMinWorkingShift;

                                if (dateMaxTimeSheet >= dateMaxWorkingShift)
                                {
                                    dateMaxTimeSheetOT = dateMaxTimeSheet;
                                    dateMaxTimeSheet = dateMaxWorkingShift;
                                }
                                decimal workingShiftMinutes = Convert.ToDecimal((dateMaxWorkingShift - dateMinWorkingShift).TotalMinutes);
                                decimal workingMinutes = Convert.ToDecimal((dateMaxTimeSheet - dateMinTimeSheet).TotalMinutes);
                                decimal factor = 0;

                                if (workingMinutes > 0 && workingShiftMinutes > 0)
                                {
                                    factor = workingMinutes / workingShiftMinutes;
                                }
                                if (dateMinTimeSheet <= dateMinWorkingShift)
                                {
                                    //Đúng giờ
                                    if (dateMaxTimeSheet >= dateMaxWorkingShift)
                                    {
                                        decimal totalBreakTimeMinutes = (decimal)(objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay - objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay).TotalMinutes;
                                        if (totalBreakTimeMinutes > 0)
                                        {
                                            workingShiftMinutes -= totalBreakTimeMinutes;
                                            workingMinutes -= totalBreakTimeMinutes;
                                        }
                                        if (workingMinutes > 0 && workingShiftMinutes > 0)
                                        {
                                            factor = Math.Round(workingMinutes / workingShiftMinutes, 4);
                                        }
                                    }
                                    // Về sớm hoặc làm 1 buổi
                                    else
                                    {
                                        HRTimesheetEmployeeLatesInfo objTimesheetEmployeeLatesInfoBackSoon = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(dateMaxWorkingShift - dateMaxTimeSheet).TotalMinutes, TimesheetEmployeeLateConfigType.BackSoon.ToString());
                                        if (objTimesheetEmployeeLatesInfoBackSoon != null)
                                        {
                                            dateMaxTimeSheet = dateMaxWorkingShift;
                                            if (objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct == 0 && objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct != 0)
                                            {
                                                dateMaxTimeSheet = dateMaxTimeSheet.AddMinutes((double)(-objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct));
                                            }
                                        }
                                        else
                                        {
                                            objTimesheetEmployeeLatesInfoBackSoon = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay - dateMaxTimeSheet.TimeOfDay).TotalMinutes, TimesheetEmployeeLateConfigType.BackSoon.ToString());
                                            if (objTimesheetEmployeeLatesInfoBackSoon != null)
                                            {
                                                dateMaxTimeSheet = DateTime.ParseExact(dateMaxTimeSheet.ToString("dd/MM/yyyy") + " " + objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                                if (objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct == 0 && objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct != 0)
                                                {
                                                    dateMaxTimeSheet = dateMaxTimeSheet.AddMinutes((double)(-objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct));
                                                }
                                            }
                                        }
                                        workingShiftMinutes = Convert.ToDecimal((dateMaxWorkingShift - dateMinWorkingShift).TotalMinutes);
                                        workingMinutes = Convert.ToDecimal((dateMaxTimeSheet - dateMinTimeSheet).TotalMinutes);

                                        DateTime breakTimeFrom =
                                        dateMinTimeSheet.TimeOfDay < objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay ? objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom : dateMinTimeSheet;
                                        DateTime breakTimeTo =
                                            dateMaxTimeSheet.TimeOfDay < objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay ? dateMaxTimeSheet : objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo;

                                        decimal totalWokingShiftBreakTimeMinutes = (decimal)(objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay - objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay).TotalMinutes;
                                        decimal totalBreakTimeMinutes = (decimal)(breakTimeTo.TimeOfDay - breakTimeFrom.TimeOfDay).TotalMinutes;

                                        if (totalWokingShiftBreakTimeMinutes > 0 && (objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay < dateMaxWorkingShift.TimeOfDay))
                                            workingShiftMinutes -= totalWokingShiftBreakTimeMinutes;
                                        if (totalBreakTimeMinutes > 0)
                                        {
                                            workingMinutes -= totalBreakTimeMinutes;
                                        }

                                        if (workingMinutes > 0 && workingShiftMinutes > 0)
                                        {
                                            //factor = Math.Round(workingMinutes / workingShiftMinutes, 4);
                                            factor = Math.Ceiling((workingMinutes / workingShiftMinutes) * 10000) / 10000;
                                        }

                                        if (objTimesheetEmployeeLatesInfoBackSoon != null)
                                        {
                                            factor = factor - objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct;
                                        }
                                    }
                                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetTimeSheetParam(timeSheetParamsList, factor, objWorkingShiftsInfo.ADWorkingShiftID, false);
                                    item.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
                                    item.HRTimeSheetEntryWorkingHours = HoursPerDay * objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                    item.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                }
                                else if (dateMinTimeSheet > dateMinWorkingShift)
                                {
                                    HRTimesheetEmployeeLatesInfo objTimesheetEmployeeLatesInfo = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(dateMinTimeSheet - dateMinWorkingShift).TotalMinutes, TimesheetEmployeeLateConfigType.ComeLate.ToString());
                                    if (objTimesheetEmployeeLatesInfo != null)
                                    {
                                        dateMinTimeSheet = dateMinWorkingShift;
                                        if (objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct == 0 && objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct != 0)
                                        {
                                            dateMinTimeSheet = dateMinTimeSheet.AddMinutes((double)objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct);
                                        }
                                    }
                                    else
                                    {
                                        objTimesheetEmployeeLatesInfo = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(dateMinTimeSheet.TimeOfDay - objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay).TotalMinutes, TimesheetEmployeeLateConfigType.ComeLate.ToString());
                                        if (objTimesheetEmployeeLatesInfo != null)
                                        {
                                            dateMinTimeSheet = DateTime.ParseExact(dateMinTimeSheet.ToString("dd/MM/yyyy") + " " + objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                            if (objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct == 0 && objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct != 0)
                                            {
                                                dateMinTimeSheet = dateMinTimeSheet.AddMinutes((double)objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct);
                                            }
                                        }
                                    }
                                    //Đi trễ
                                    workingShiftMinutes = Convert.ToDecimal((dateMaxWorkingShift - dateMinWorkingShift).TotalMinutes);
                                    workingMinutes = Convert.ToDecimal((dateMaxTimeSheet - dateMinTimeSheet).TotalMinutes);

                                    if (dateMaxTimeSheet >= dateMaxWorkingShift)
                                    {
                                        DateTime breakTimeFrom =
                                            dateMinTimeSheet.TimeOfDay < objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay ? objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom : dateMinTimeSheet;
                                        DateTime breakTimeTo =
                                            dateMaxTimeSheet.TimeOfDay < objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay ? dateMaxTimeSheet : objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo;

                                        decimal totalWokingShiftBreakTimeMinutes = (decimal)(objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay - objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay).TotalMinutes;
                                        decimal totalBreakTimeMinutes = (decimal)(breakTimeTo.TimeOfDay - breakTimeFrom.TimeOfDay).TotalMinutes;

                                        if (totalWokingShiftBreakTimeMinutes > 0 && (objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay < dateMaxWorkingShift.TimeOfDay))
                                            workingShiftMinutes -= totalWokingShiftBreakTimeMinutes;
                                        if (totalBreakTimeMinutes > 0)
                                        {
                                            workingMinutes -= totalBreakTimeMinutes;
                                        }

                                        if (workingMinutes > 0 && workingShiftMinutes > 0)
                                        {
                                            factor = Math.Ceiling((workingMinutes / workingShiftMinutes) * 10000) / 10000;
                                        }
                                    }
                                    // Về sớm hoặc làm 1 buổi
                                    else
                                    {
                                        HRTimesheetEmployeeLatesInfo objTimesheetEmployeeLatesInfoBackSoon = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(dateMaxWorkingShift - dateMaxTimeSheet).TotalMinutes, TimesheetEmployeeLateConfigType.BackSoon.ToString());
                                        if (objTimesheetEmployeeLatesInfoBackSoon != null)
                                        {
                                            dateMaxTimeSheet = dateMaxWorkingShift;
                                            if (objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct == 0 && objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct != 0)
                                            {
                                                dateMaxTimeSheet = dateMaxTimeSheet.AddMinutes((double)(-objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct));
                                            }
                                        }
                                        else
                                        {
                                            objTimesheetEmployeeLatesInfoBackSoon = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay - dateMaxTimeSheet.TimeOfDay).TotalMinutes, TimesheetEmployeeLateConfigType.BackSoon.ToString());
                                            if (objTimesheetEmployeeLatesInfoBackSoon != null)
                                            {
                                                dateMaxTimeSheet = DateTime.ParseExact(dateMaxTimeSheet.ToString("dd/MM/yyyy") + " " + objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                                if (objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct == 0 && objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct != 0)
                                                {
                                                    dateMaxTimeSheet = dateMaxTimeSheet.AddMinutes((double)(-objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct));
                                                }
                                            }
                                        }
                                        workingShiftMinutes = Convert.ToDecimal((dateMaxWorkingShift - dateMinWorkingShift).TotalMinutes);
                                        workingMinutes = Convert.ToDecimal((dateMaxTimeSheet - dateMinTimeSheet).TotalMinutes);

                                        DateTime breakTimeFrom =
                                            dateMinTimeSheet.TimeOfDay < objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay ? objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom : dateMinTimeSheet;
                                        DateTime breakTimeTo =
                                            dateMaxTimeSheet.TimeOfDay < objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay ? dateMaxTimeSheet : objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo;

                                        decimal totalWokingShiftBreakTimeMinutes = (decimal)(objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay - objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay).TotalMinutes;
                                        decimal totalBreakTimeMinutes = (decimal)(breakTimeTo.TimeOfDay - breakTimeFrom.TimeOfDay).TotalMinutes;

                                        if (totalWokingShiftBreakTimeMinutes > 0 && (objWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay < dateMaxWorkingShift.TimeOfDay))
                                            workingShiftMinutes -= totalWokingShiftBreakTimeMinutes;
                                        if (totalBreakTimeMinutes > 0)
                                        {
                                            workingMinutes -= totalBreakTimeMinutes;
                                        }

                                        if (workingMinutes > 0 && workingShiftMinutes > 0)
                                        {
                                            //factor = Math.Round(workingMinutes / workingShiftMinutes, 4);
                                            factor = Math.Ceiling((workingMinutes / workingShiftMinutes) * 10000) / 10000;
                                        }

                                        if (objTimesheetEmployeeLatesInfoBackSoon != null)
                                        {
                                            factor = factor - objTimesheetEmployeeLatesInfoBackSoon.HRTimesheetEmployeeLateDeduct;
                                        }
                                    }

                                    if (objTimesheetEmployeeLatesInfo != null)
                                    {
                                        decimal val = factor - objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct;
                                        if (val < 0)
                                        {
                                            val = 0;
                                        }
                                        HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetTimeSheetParam(timeSheetParamsList, val, objWorkingShiftsInfo.ADWorkingShiftID, false);
                                        if (objTimeSheetParamsInfo != null)
                                        {
                                            item.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
                                            item.HRTimeSheetEntryWorkingHours = HoursPerDay * objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                            item.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                        }
                                    }
                                    else
                                    {
                                        if (factor < 0)
                                        {
                                            factor = 0;
                                        }
                                        HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetTimeSheetParam(timeSheetParamsList, factor, objWorkingShiftsInfo.ADWorkingShiftID, false);
                                        if (objTimeSheetParamsInfo != null)
                                        {
                                            item.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
                                            item.HRTimeSheetEntryWorkingHours = HoursPerDay * objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                            item.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    HRTimeSheetEntrysInfo item1 = (HRTimeSheetEntrysInfo)item.Clone();
                    item1.HRTimeSheetEntryFrom = dateMinTimeSheet;
                    item1.HRTimeSheetEntryTo = dateMaxTimeSheet;
                    timeKeeperEntriesClone.Add(item1);
                    ///timeKeeperEntries.Add(item1);
                }
            }

            entity.EmployeeTimeSheetsList.ForEach(h =>
            {
                if (timeKeeperEntriesClone != null && timeKeeperEntriesClone.Count > 0)
                {
                    timeKeeperEntriesClone = timeKeeperEntriesClone.OrderBy(o => o.FK_ADWorkingShiftID).ThenBy(o => o.HRTimeSheetEntryDate.Date).ThenBy(o => o.HREmployeeCardNumber).ToList();

                    int daysInMonth = NumOfDayInMonth();

                    if (workingShiftList != null)
                    {
                        workingShiftList.ForEach(o =>
                        {
                            for (int i = 1; i <= daysInMonth; i++)
                            {
                                DateTime dt = timeSheet.HRTimeSheetFromDate.AddDays(i - 1).Date;
                                List<HRTimeSheetEntrysInfo> list = timeKeeperEntriesClone.Where(x => x.FK_ADWorkingShiftID == o.ADWorkingShiftID
                                                                                                    && x.HRTimeSheetEntryDate.Date == dt.Date
                                                                                                    && h.FK_HREmployeeID == x.FK_HREmployeeID).ToList();
                                if (list != null && list.Count > 0)
                                {
                                    HRTimeSheetEntrysInfo objTimeSheetEntrysInfoClone = new HRTimeSheetEntrysInfo();
                                    objTimeSheetEntrysInfoClone = list[0];

                                    for (int j = 1; j < list.Count; j++)
                                    {
                                        if (objTimeSheetEntrysInfoClone.HRTimeSheetEntryFrom > list[j].HRTimeSheetEntryFrom)
                                        {
                                            objTimeSheetEntrysInfoClone.HRTimeSheetEntryFrom = list[j].HRTimeSheetEntryFrom;
                                        }
                                        if (objTimeSheetEntrysInfoClone.HRTimeSheetEntryTo < list[j].HRTimeSheetEntryTo)
                                        {
                                            objTimeSheetEntrysInfoClone.HRTimeSheetEntryTo = list[j].HRTimeSheetEntryTo;
                                        }
                                        objTimeSheetEntrysInfoClone.HRTimeSheetEntryWorkingHours += list[j].HRTimeSheetEntryWorkingHours;
                                        objTimeSheetEntrysInfoClone.HRTimeSheetEntryWorkingQty += list[j].HRTimeSheetEntryWorkingQty;
                                    }

                                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetTimeSheetParam(timeSheetParamsList, objTimeSheetEntrysInfoClone.HRTimeSheetEntryWorkingQty, o.ADWorkingShiftID, false);
                                    if (objTimeSheetParamsInfo != null)
                                    {
                                        objTimeSheetEntrysInfoClone.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
                                        objTimeSheetEntrysInfoClone.HRTimeSheetEntryWorkingHours = HoursPerDay * objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                        objTimeSheetEntrysInfoClone.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                        objTimeSheetEntrysInfoClone.FK_ADWorkingShiftID = o.ADWorkingShiftID;
                                    }

                                    if (objTimeSheetEntrysInfoClone != null)
                                    {
                                        timeKeeperEntries.Add(objTimeSheetEntrysInfoClone);
                                    }
                                }
                            }
                        });
                    }
                }
            });

            #endregion
            #region work schedule


            foreach (var item in workScheduleEntries)
            {
                List<HRTimeSheetEntrysInfo> temp = workScheduleEntries.Where(p => (p.FK_HREmployeeID == item.FK_HREmployeeID &&
                                            p.HRTimeSheetEntryDate.Date == item.HRTimeSheetEntryDate.Date)).ToList();

                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(item.FK_HREmployeeID);
                item.HRTimeSheetEntryWorkingHours = 0;
                item.HRTimeSheetEntryWorkingQty = 0;
                DateTime dateMinTimeSheet = DateTime.MaxValue;
                DateTime dateMaxTimeSheet = DateTime.MinValue;
                foreach (var i in temp)
                {
                    if (i.HRTimeSheetEntryFrom < dateMinTimeSheet) dateMinTimeSheet = i.HRTimeSheetEntryFrom;
                    if (i.HRTimeSheetEntryTo > dateMaxTimeSheet) dateMaxTimeSheet = i.HRTimeSheetEntryTo;
                }

                if (timeSheet.HRTimeSheetType == TimeSheetType.Hour.ToString())
                {
                    HRTimeSheetParamsInfo info = GetTimeSheetParam(timeSheetParamsList, item.HRTimeSheetEntryWorkingHours, true);
                    if (info != null)
                    {
                        item.FK_HRTimeSheetParamID = info.HRTimeSheetParamID;
                    }
                }
                else
                {
                    item.HRTimeSheetEntryFrom = dateMinTimeSheet;
                    item.HRTimeSheetEntryTo = dateMaxTimeSheet;
                    if (objEmployeesInfo.FK_HREmployeePayrollFormulaID > 0)
                    {
                        //get default working shift for work schedule
                        HRWorkingShiftsInfo objWorkingShiftsInfo = workingShiftController.
                                            GetDefaultWorkingShiftByPayrollFormulaIDAndWorkingShiftDayOfWeek(objEmployeesInfo.FK_HREmployeePayrollFormulaID,
                                                                                                            WorkingShiftDayOffWeek.All.ToString());
                        if (objWorkingShiftsInfo != null)
                        {
                            ADWorkingShiftsInfo objADWorkingShiftsInfo = (ADWorkingShiftsInfo)workingShiftList.FirstOrDefault(o => o.ADWorkingShiftID == objWorkingShiftsInfo.FK_ADWorkingShiftID);

                            if (objADWorkingShiftsInfo != null)
                            {
                                DateTime dateMinWorkingShift = dateMinTimeSheet.Date.AddHours(objWorkingShiftsInfo.HRWorkingShiftFromTime.Hour)
                                                                            .AddMinutes(objWorkingShiftsInfo.HRWorkingShiftFromTime.Minute);
                                DateTime dateMaxWorkingShift = dateMaxTimeSheet.Date.AddHours(objWorkingShiftsInfo.HRWorkingShiftToTime.Hour)
                                                                            .AddMinutes(objWorkingShiftsInfo.HRWorkingShiftToTime.Minute);

                                DateTime dateBreakTimeFrom = dateMinTimeSheet.TimeOfDay < objADWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay
                                                            ? objADWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom : dateMinTimeSheet;
                                DateTime dateBreakTimeTo = dateMaxTimeSheet.TimeOfDay > objADWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay
                                                            ? objADWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo : dateMaxTimeSheet;

                                if (dateMaxWorkingShift <= dateMinWorkingShift) dateMaxWorkingShift = dateMaxWorkingShift.AddDays(1);

                                if (dateMinTimeSheet < dateMinWorkingShift)
                                    dateMinTimeSheet = dateMinWorkingShift;
                                if (dateMaxTimeSheet > dateMaxWorkingShift)
                                    dateMaxTimeSheet = dateMaxWorkingShift;

                                decimal workingShiftMinutes = Convert.ToDecimal((dateMaxWorkingShift - dateMinWorkingShift).TotalMinutes);
                                decimal workingMinutes = Convert.ToDecimal((dateMaxTimeSheet - dateMinTimeSheet).TotalMinutes);

                                int totalBreakTime = (int)(objADWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay
                                                     - objADWorkingShiftsInfo.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay).TotalMinutes;
                                int totalBreakTimeWorkSchedule = (int)(dateBreakTimeTo.TimeOfDay - dateBreakTimeFrom.TimeOfDay).TotalMinutes;

                                if (totalBreakTime > 0)
                                {
                                    workingShiftMinutes = workingShiftMinutes - totalBreakTime;
                                }

                                if (totalBreakTimeWorkSchedule > 0)
                                {
                                    workingMinutes = workingMinutes - totalBreakTimeWorkSchedule;
                                }
                                decimal factor = workingMinutes / workingShiftMinutes;
                                HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetTimeSheetParam(timeSheetParamsList, factor, true);
                                item.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
                                item.HRTimeSheetEntryWorkingHours = HoursPerDay * objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                item.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                            }
                        }

                    }

                    HRTimeSheetEntrysInfo item1 = (HRTimeSheetEntrysInfo)item.Clone();
                    item1.HRTimeSheetEntryFrom = dateMinTimeSheet;
                    item1.HRTimeSheetEntryTo = dateMaxTimeSheet;
                    timeKeeperEntries.Add(item1);
                }
            }
            #endregion

            #region OT
            HROTFactorsController objOTFactorsController = new HROTFactorsController();
            List<HROTFactorsInfo> objOTFactorsList2 = objOTFactorsController.GetAllOTFactors();
            List<HRTimeSheetEntrysInfo> timeSheetEntry = new List<HRTimeSheetEntrysInfo>();
            foreach (HREmployeeTimeSheetsInfo item in entity.EmployeeTimeSheetsList)
            {
                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(item.FK_HREmployeeID);
                HREmployeeOTsController objEmployeeOTsController = new HREmployeeOTsController();
                List<HREmployeeOTsInfo> listOTs = objEmployeeOTsController.GetEmployeeOTList(item.FK_HREmployeeID, dateFrom, dateTo);

                foreach (var ot in listOTs)
                {
                    int n = ot.HREmployeeOTDate.Day;
                    String propertyName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", n);

                    //24-01-2019
                    timeSheetEntry = timeEntriesByOT.Where(tke => tke.HRTimeSheetEntryDate.Date == ot.HREmployeeOTDate.Date
                        && tke.FK_HREmployeeID == item.FK_HREmployeeID).ToList();

                    DateTime otDate = ot.HREmployeeOTFromDate;
                    DateTime otDateFrom = ot.HREmployeeOTFromDate;
                    DateTime otDateTo = ot.HREmployeeOTToDate;

                    DateTime dateMinTimeSheet = DateTime.MaxValue;
                    DateTime dateMaxTimeSheet = DateTime.MinValue;

                    if (timeSheetEntry.Count() > 0)
                    {
                        foreach (var i in timeSheetEntry)
                        {
                            if (i.HRTimeSheetEntryFrom < dateMinTimeSheet)
                                dateMinTimeSheet = i.HRTimeSheetEntryFrom;
                            if (i.HRTimeSheetEntryTo > dateMaxTimeSheet)
                                dateMaxTimeSheet = i.HRTimeSheetEntryTo;
                        }

                        if (otDateFrom <= dateMinTimeSheet && otDateTo >= dateMaxTimeSheet)
                        {
                            otDateFrom = dateMinTimeSheet;
                            otDateTo = dateMaxTimeSheet;
                        }
                        else if (otDateFrom <= dateMinTimeSheet && otDateTo < dateMaxTimeSheet)
                        {
                            otDateFrom = dateMinTimeSheet;
                            timeSheetEntry.ForEach(o =>
                            {
                                if (otDateTo >= o.HRTimeSheetEntryFrom && otDateTo < o.HRTimeSheetEntryTo)
                                {
                                    otDateTo = ot.HREmployeeOTToDate;
                                }
                            });
                        }
                        else if (otDateFrom > dateMinTimeSheet && otDateTo >= dateMaxTimeSheet)
                        {
                            otDateTo = dateMaxTimeSheet;
                        }
                        else if (otDateFrom > dateMinTimeSheet && otDateTo < dateMaxTimeSheet)
                        {
                            otDateFrom = ot.HREmployeeOTFromDate;
                            timeSheetEntry.ForEach(o =>
                            {
                                if (otDateTo >= o.HRTimeSheetEntryFrom && otDateTo < o.HRTimeSheetEntryTo)
                                {
                                    otDateTo = ot.HREmployeeOTToDate;
                                }
                            });
                        }
                        else
                        {
                            timeSheetEntry.ForEach(o =>
                            {
                                if (otDateFrom <= o.HRTimeSheetEntryFrom)
                                {
                                    if (otDateTo > o.HRTimeSheetEntryFrom && otDateTo <= o.HRTimeSheetEntryTo)
                                    {
                                        otDateFrom = o.HRTimeSheetEntryFrom;
                                    }
                                    else if (otDateTo > o.HRTimeSheetEntryTo)
                                    {
                                        otDateFrom = o.HRTimeSheetEntryFrom;
                                        otDateTo = o.HRTimeSheetEntryTo;
                                    }
                                }
                                else if (otDateFrom > o.HRTimeSheetEntryFrom && otDateFrom < o.HRTimeSheetEntryTo)
                                {
                                    if (otDateTo > o.HRTimeSheetEntryTo)
                                    {
                                        otDateTo = o.HRTimeSheetEntryTo;
                                    }
                                }
                            });
                        }
                        ot.HREmployeeOTFromDate = otDateFrom;
                        ot.HREmployeeOTToDate = otDateTo;

                        HRTimesheetEmployeeLatesInfo objTimesheetEmployeeLatesInfo = objTimesheetEmployeeLatesController.GetTimesheetEmployee(objEmployeesInfo.FK_HREmployeePayrollFormulaID, (int)(otDateFrom - otDate).TotalMinutes, TimesheetEmployeeLateConfigType.ComeLate.ToString());
                        if (objTimesheetEmployeeLatesInfo != null)
                        {
                            if (objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct == 0)
                            {
                                ot.HREmployeeOTFromDate = otDate;
                            }
                        }

                        decimal minutes = Convert.ToDecimal((ot.HREmployeeOTToDate - ot.HREmployeeOTFromDate).TotalMinutes);

                        List<HROTFactorsInfo> objOTFactorsList = new List<HROTFactorsInfo>();
                        if (columnFieldNameHoliday.IndexOf(propertyName) > -1)
                        {
                            objOTFactorsList = objOTFactorsList2.Where(p => (p.FK_HREmployeePayrollFormulaID == objEmployeesInfo.FK_HREmployeePayrollFormulaID &&
                                p.HROTFactorType == OTFactorType.Holiday.ToString())).ToList();
                        }
                        else if (VinaApp.IsEndOfWeek(ot.HREmployeeOTDate.DayOfWeek))
                        {
                            objOTFactorsList = objOTFactorsList2.Where(p => (p.FK_HREmployeePayrollFormulaID == objEmployeesInfo.FK_HREmployeePayrollFormulaID &&
                                    p.HROTFactorType == OTFactorType.EndOfWeek.ToString())).ToList();
                        }
                        else
                        {
                            objOTFactorsList = objOTFactorsList2.Where(p => (p.FK_HREmployeePayrollFormulaID == objEmployeesInfo.FK_HREmployeePayrollFormulaID &&
                                    p.HROTFactorType == OTFactorType.WorkingDay.ToString())).ToList();
                        }
                        foreach (var objOTFactor in objOTFactorsList)
                        {
                            DateTime d1 = DateTime.ParseExact(ot.HREmployeeOTDate.ToString("dd/MM/yyyy") + " " + objOTFactor.HROTFactorFromTime.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            DateTime d2 = DateTime.ParseExact(ot.HREmployeeOTDate.ToString("dd/MM/yyyy") + " " + objOTFactor.HROTFactorToTime.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            objOTFactor.HROTFactorFromTime = d1;
                            if (d2 < d1)
                            {
                                d2 = d2.AddDays(1);
                            }
                            objOTFactor.HROTFactorToTime = d2;
                        }

                        decimal f = 0;
                        decimal otHours = 0;
                        DateTime fromDate = dateFrom;
                        DateTime toDate = dateTo;

                        foreach (var objOTFactor in objOTFactorsList)
                        {
                            decimal time = 0;
                            decimal totalMinutes = 0;
                            fromDate = ot.HREmployeeOTFromDate < objOTFactor.HROTFactorFromTime ? objOTFactor.HROTFactorFromTime : ot.HREmployeeOTFromDate;
                            toDate = ot.HREmployeeOTToDate < objOTFactor.HROTFactorToTime ? ot.HREmployeeOTToDate : objOTFactor.HROTFactorToTime;
                            totalMinutes = Convert.ToDecimal((toDate - fromDate).TotalMinutes);

                            time = Math.Round(totalMinutes / 60, 5);

                            if (objTimesheetEmployeeLatesInfo != null)
                            {
                                if (objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct != 0)
                                {
                                    time = time - objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateDeduct * 8;
                                }
                                else if (objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateOTTime != 0)
                                {
                                    time = Math.Round((totalMinutes - objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateOTTime) / 60, 5);
                                }
                            }

                            if (time < 0)
                            {
                                time = 0;
                            }

                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt.Columns.Add("TimeValue", typeof(decimal));
                            dt.Columns.Add("FactorValue", typeof(decimal));
                            dt.Columns.Add("IsOTFactor", typeof(bool));
                            dt.Columns.Add("isOTCalculated", typeof(bool));
                            dt.Columns.Add("TimeSheetParamType", typeof(string));
                            if (ot.HREmployeeOTFactor == 1)
                            {
                                {
                                    decimal timeDetail = (timeSheet.HRTimeSheetType == TimeSheetType.Day.ToString()) ? time / HoursPerDay : time;
                                    //dt.Rows.Add(new Object[] { timeDetail, ot.HREmployeeOTFactor, true, false, timeSheet.HRTimeSheetType });
                                    dt.Rows.Add(new Object[] { time, ot.HREmployeeOTFactor, true, true, TimeSheetType.Hour.ToString() });
                                }
                            }
                            else if (ot.HREmployeeOTFactor > 0)
                            {
                                dt.Rows.Add(new Object[] { time, ot.HREmployeeOTFactor, true, true, TimeSheetType.Hour.ToString() });
                            }
                            else
                            {
                                dt.Rows.Add(new Object[] { time, objOTFactor.HROTFactorValue, false, true, TimeSheetType.Hour.ToString() });
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetAllTimeSheetParamByIsOTCalculated(allTimeSheetParamsList, (bool)dt.Rows[i]["isOTCalculated"], (string)dt.Rows[i]["TimeSheetParamType"], (decimal)dt.Rows[i]["TimeValue"], (decimal)dt.Rows[i]["FactorValue"]);
                                if (objTimeSheetParamsInfo != null && objTimeSheetParamsInfo.HRTimeSheetParamID != 0)
                                {
                                    otHours = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                                    f = objTimeSheetParamsInfo.HRTimeSheetParamValue1 * (decimal)dt.Rows[i]["FactorValue"];
                                    HRTimeSheetEntrysInfo obj = new HRTimeSheetEntrysInfo();
                                    bool isOTCalculated = (bool)dt.Rows[i]["isOTCalculated"];
                                    obj.FK_HREmployeeID = item.FK_HREmployeeID;
                                    obj.FK_HREmployeeTimeSheetID = item.HREmployeeTimeSheetID;
                                    obj.FK_HRTimeSheetID = item.FK_HRTimeSheetID;
                                    obj.HRTimeSheetEntryDate = ot.HREmployeeOTDate;
                                    obj.FK_HRTimeSheetParamID = objTimeSheetParamsInfo.HRTimeSheetParamID;
                                    obj.HRTimeSheetEntryFrom = fromDate;
                                    obj.HRTimeSheetEntryTo = toDate;
                                    obj.HRTimeSheetParamNo = objTimeSheetParamsInfo.HRTimeSheetParamNo;
                                    if (isOTCalculated)// Tính tăng ca
                                    {
                                        obj.HRTimeSheetEntryWorkingQty = f / HoursPerDay;
                                        obj.HRTimeSheetEntryWorkingHours = f;
                                        obj.IsOTFactor = (bool)dt.Rows[i]["IsOTFactor"];
                                        obj.HRTimeSheetEntryFactor = objTimeSheetParamsInfo.HRTimeSheetParamValue2;
                                    }
                                    else// Tính ngày công
                                    {
                                        if (objTimeSheetParamsInfo.HRTimeSheetParamType == TimeSheetParamType.Day.ToString())
                                        {
                                            obj.HRTimeSheetEntryWorkingQty = (decimal)dt.Rows[i]["TimeValue"];
                                            obj.HRTimeSheetEntryWorkingHours = (decimal)dt.Rows[i]["TimeValue"] * HoursPerDay;
                                        }
                                        else
                                        {
                                            obj.HRTimeSheetEntryWorkingHours = (decimal)dt.Rows[i]["TimeValue"];
                                            obj.HRTimeSheetEntryWorkingQty = (decimal)dt.Rows[i]["TimeValue"] / HoursPerDay;
                                        }
                                        obj.HRTimeSheetEntryFactor = 0;
                                    }

                                    timeKeeperEntries.Add(obj);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region EmployeeTimeSheetsList
            {
                List<HREmployeeTimeSheetsInfo> employeeTimeSheets = new List<HREmployeeTimeSheetsInfo>();
                //TODO: Need to refactor this as we don't have a better way to get holiday param currently
                List<HRTimeSheetParamsInfo> holidayParamList = entity.TimeSheetParams.Where(p => p.HRTimeSheetParamType == TimeSheetParamType.LE.ToString()).ToList();
                HRTimeSheetParamsInfo holidayParam = entity.TimeSheetParams.Where(p => p.HRTimeSheetParamType == TimeSheetParamType.LE.ToString()).FirstOrDefault();
                HRTimeSheetParamsInfo defaultParam = entity.TimeSheetParams.Where(p => p.IsDefault == true).FirstOrDefault();
                HREmployeesInfo objEmployeesInfo = new HREmployeesInfo();
                HREmployeeArrangementShiftsController objEmployeeArrangementShiftsController = new HREmployeeArrangementShiftsController();
                HRArrangementShiftEntrysController objArrangementShiftEntrysController = new HRArrangementShiftEntrysController();
                List<HRArrangementShiftEntrysInfo> arrangementShiftEntrys = new List<HRArrangementShiftEntrysInfo>();

                foreach (HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo in entity.EmployeeTimeSheetsList)
                {
                    objEmployeesInfo = entity.EmployeesList.FirstOrDefault(o => o.HREmployeeID == objEmployeeTimeSheetsInfo.FK_HREmployeeID);
                    List<HRTimeSheetEntrysInfo> timeSheetEntrys = timeKeeperEntries.Where(t => t.FK_HREmployeeID == objEmployeeTimeSheetsInfo.FK_HREmployeeID).ToList();
                    List<HREmployeeTimeSheetOTDetailsInfo> timeSheetOTDetails = new List<HREmployeeTimeSheetOTDetailsInfo>();
                    // Add time sheet entries for holiday days
                    int daysInMonth = NumOfDayInMonth();
                    ADWorkingShiftsInfo objADWorkingShiftsInfo = new ADWorkingShiftsInfo();
                    if (objEmployeesInfo != null && objEmployeesInfo.FK_HREmployeePayrollFormulaID > 0)
                    {
                        List<ADWorkingShiftsInfo> listWorkingShifts = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetWorkingShiftsByEmployeePayrollFormulaID(objEmployeesInfo.FK_HREmployeePayrollFormulaID, true);
                        if (listWorkingShifts != null && listWorkingShifts.Count > 0)
                        {
                            objADWorkingShiftsInfo = (ADWorkingShiftsInfo)listWorkingShifts.FirstOrDefault();
                        }
                    }

                    ADWorkingShiftsInfo objADWorkingShiftsInfoDefault = new ADWorkingShiftsInfo();
                    if (workingShiftList.Count() > 0)
                    {
                        objADWorkingShiftsInfoDefault = (ADWorkingShiftsInfo)workingShiftList.Where(o => o.ADWorkingShiftID == objEmployeesInfo.FK_ADWorkingShiftID).FirstOrDefault();
                    }

                    for (DateTime dt = dateFrom; dt <= dateTo; dt = dt.AddDays(1))
                    {
                        int i = dt.Day;
                        String propertyName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", i);
                        bool isHoliday = columnFieldNameHoliday.Exists(delegate (string holiday) { return propertyName == holiday; });
                        DateTime date = dt.Date;
                        if (isHoliday && holidayParam != null && holidayParamList.Count() > 0)
                        {
                            List<ADWorkingShiftsInfo> workingShiftList2 = new List<ADWorkingShiftsInfo>();
                            if (objADWorkingShiftsInfo != null && objADWorkingShiftsInfo.ADWorkingShiftID > 0)
                            {
                                workingShiftList2.Add(objADWorkingShiftsInfo);
                            }

                            if (objEmployeesInfo.HREmployeePayRollCalculatedWorkType == EmployeePayRollCalculatedWorkType.TableWork.ToString())
                            {
                                workingShiftList2.Clear();
                                arrangementShiftEntrys = (List<HRArrangementShiftEntrysInfo>)objArrangementShiftEntrysController.GetKHRArrangementShiftEntryByFK_HREmployeeIDAndDate(objEmployeesInfo.HREmployeeID, dt.Date);
                                if (arrangementShiftEntrys.Count() > 0)
                                {
                                    arrangementShiftEntrys.ForEach(o =>
                                    {
                                        ADWorkingShiftsInfo obj = new ADWorkingShiftsInfo();
                                        obj = (ADWorkingShiftsInfo)workingShiftList.Where(x => x.ADWorkingShiftID == o.FK_ADWorkingShiftID).FirstOrDefault();
                                        workingShiftList2.Add(obj);
                                    });
                                }
                            }
                            else if (objEmployeesInfo.HREmployeePayRollCalculatedWorkType == EmployeePayRollCalculatedWorkType.Default.ToString())
                            {
                                if (objADWorkingShiftsInfoDefault != null)
                                {
                                    workingShiftList2.Clear();
                                    workingShiftList2.Add(objADWorkingShiftsInfoDefault);
                                }
                            }

                            if (workingShiftList2 != null && workingShiftList2.Count > 0)
                            {
                                timeSheetEntrys.RemoveAll(e => e.HRTimeSheetEntryDate.Date == date && holidayParamList.Exists(o => o.HRTimeSheetParamID == e.FK_HRTimeSheetParamID));
                                HRTimeSheetParamsInfo objholidayParam = new HRTimeSheetParamsInfo();

                                workingShiftList2.ForEach(o =>
                                {
                                    HRTimeSheetEntrysInfo entry = new HRTimeSheetEntrysInfo();
                                    objholidayParam = (HRTimeSheetParamsInfo)holidayParamList.FirstOrDefault();
                                    if (objholidayParam != null)
                                    {
                                        entry.FK_HRTimeSheetParamID = objholidayParam.HRTimeSheetParamID;
                                        entry.HRTimeSheetEntryWorkingHours = objholidayParam.HRTimeSheetParamValue1 * objholidayParam.HRTimeSheetParamValue2;
                                        entry.FK_HREmployeeID = objEmployeeTimeSheetsInfo.FK_HREmployeeID;
                                        entry.HRTimeSheetEntryWorkingQty = entry.HRTimeSheetEntryWorkingHours / HoursPerDay;
                                        entry.HRTimeSheetEntryDate = date;
                                        timeSheetEntrys.Add(entry);
                                    }
                                });
                            }
                            else
                            {
                                HRTimeSheetEntrysInfo entry = timeSheetEntrys.Where(e => e.HRTimeSheetEntryDate.Date == date && holidayParamList.Exists(o => o.HRTimeSheetParamID == e.FK_HRTimeSheetParamID)).FirstOrDefault();
                                if (entry != null)
                                {
                                    if (entry.FK_HRTimeSheetParamID == 0)
                                    {
                                        entry.FK_HRTimeSheetParamID = holidayParam.HRTimeSheetParamID;
                                        entry.HRTimeSheetEntryWorkingHours = holidayParam.HRTimeSheetParamValue1 * holidayParam.HRTimeSheetParamValue2;
                                        entry.HRTimeSheetEntryWorkingQty = entry.HRTimeSheetEntryWorkingHours / HoursPerDay;
                                    }
                                }
                                else
                                {
                                    entry = new HRTimeSheetEntrysInfo();
                                    entry.FK_HREmployeeID = objEmployeeTimeSheetsInfo.FK_HREmployeeID;
                                    entry.FK_HRTimeSheetParamID = holidayParam.HRTimeSheetParamID;
                                    entry.HRTimeSheetEntryWorkingHours = holidayParam.HRTimeSheetParamValue1 * holidayParam.HRTimeSheetParamValue2;
                                    entry.HRTimeSheetEntryWorkingQty = entry.HRTimeSheetEntryWorkingHours / HoursPerDay;
                                    entry.HRTimeSheetEntryDate = date;
                                    timeSheetEntrys.Add(entry);
                                }
                            }
                        }
                    }

                    //Add time sheet entries from leave days
                    List<HRLeaveDaysInfo> employeeLeaveDays = leaveDays.Where(ld => ld.FK_HREmployeeID == objEmployeeTimeSheetsInfo.FK_HREmployeeID).ToList();
                    foreach (HRLeaveDaysInfo employeeLeaveDay in employeeLeaveDays)
                    {
                        {
                            HRTimeSheetEntrysInfo entry = new HRTimeSheetEntrysInfo();
                            entry.FK_HREmployeeID = employeeLeaveDay.FK_HREmployeeID;
                            entry.FK_HRTimeSheetParamID = employeeLeaveDay.FK_HRTimeSheetParamID;
                            HRTimeSheetParamsInfo obj = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(employeeLeaveDay.FK_HRTimeSheetParamID);
                            if (obj != null)
                            {
                                entry.HRTimeSheetEntryWorkingHours = obj.HRTimeSheetParamValue1 * obj.HRTimeSheetParamValue2;
                                //entry.HRTimeSheetEntryWorkingQty = entry.HRTimeSheetEntryWorkingHours / HoursPerDay;
                                HRTimeSheetParamsInfo objTimeSheetParamsInfo = GetTimeSheetParam(timeSheetParamsList, entry.HRTimeSheetEntryWorkingHours / HoursPerDay, false, 0, false);
                                entry.HRTimeSheetEntryWorkingQty = objTimeSheetParamsInfo.HRTimeSheetParamValue1;
                            }
                            entry.HRTimeSheetEntryDate = employeeLeaveDay.HRLeaveDayDate;
                            timeSheetEntrys.Add(entry);
                        }
                    }
                    foreach (var item in timeSheetEntrys)
                    {
                        if (item.FK_HRTimeSheetParamID == 0)
                        {
                            item.HRTimeSheetEntryWorkingHours = 0;
                            item.HRTimeSheetEntryWorkingQty = 0;
                        }
                    }

                    if (isReset)
                    {
                        if (employeeID > 0)
                        {
                            if (employeeID == objEmployeeTimeSheetsInfo.FK_HREmployeeID)
                            {
                                DateTime d = dateFrom;
                                while (d.Date <= dateTo.Date)
                                {
                                    objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.RemoveAll(item => item.HRTimeSheetEntryDate.Date == d);
                                    d = d.AddDays(1);
                                }
                            }
                        }
                        else
                        {
                            DateTime d = dateFrom;
                            while (d.Date <= dateTo.Date)
                            {
                                objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.RemoveAll(item => item.HRTimeSheetEntryDate.Date == d);
                                d = d.AddDays(1);
                            }
                        }
                    }

                    if (timeSheetEntrys != null)
                    {
                        timeSheetEntrys.ForEach(o =>
                        {
                            objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.RemoveAll(item => item.HRTimeSheetEntryDate.Date == o.HRTimeSheetEntryDate.Date);
                        });
                        objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList.AddRange(timeSheetEntrys);
                    }

                    List<HRTimeSheetParamsInfo> OTFactorlist = objTimeSheetParamsController.GetDistinctOTTimeSheetParamsList();
                    foreach (var otfactor in OTFactorlist)
                    {
                        HREmployeeTimeSheetOTDetailsInfo objEmployeeTimeSheetOTDetailsInfo = new HREmployeeTimeSheetOTDetailsInfo();
                        objEmployeeTimeSheetOTDetailsInfo.HREmployeeTimeSheetOTDetailFactor = otfactor.HRTimeSheetParamValue2;
                        objEmployeeTimeSheetOTDetailsInfo.HREmployeeTimeSheetOTDetailName = otfactor.HRTimeSheetParamValue2.ToString();
                        foreach (var item in objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList)
                        {
                            HRTimeSheetParamsInfo obj = (HRTimeSheetParamsInfo)objTimeSheetParamsController.GetObjectByID(item.FK_HRTimeSheetParamID);
                            if (obj != null && obj.HRTimeSheetParamValue2 == otfactor.HRTimeSheetParamValue2 && obj.IsOTCalculated && obj.HRTimeSheetParamValue2 > 0)
                            {
                                objEmployeeTimeSheetOTDetailsInfo.HREmployeeTimeSheetOTDetailHours += item.HRTimeSheetEntryWorkingHours / obj.HRTimeSheetParamValue2;
                            }
                        }
                        timeSheetOTDetails.Add(objEmployeeTimeSheetOTDetailsInfo);
                    }
                    if (employeeID > 0)
                    {
                        if (objEmployeeTimeSheetsInfo.FK_HREmployeeID == employeeID)
                        {
                            objEmployeeTimeSheetsInfo.HREmployeeTimeSheetOTDetailsList = timeSheetOTDetails;
                            //Set employee time sheet value
                            entity.SetEmployeeTimeSheetValue(objEmployeeTimeSheetsInfo);
                            //Update time sheet total quantity

                            UpdateTimeSheetTotalQty(objEmployeeTimeSheetsInfo);
                        }

                    }
                    else
                    {
                        objEmployeeTimeSheetsInfo.HREmployeeTimeSheetOTDetailsList = timeSheetOTDetails;
                        //Set employee time sheet value
                        entity.SetEmployeeTimeSheetValue(objEmployeeTimeSheetsInfo);
                        //Update time sheet total quantity

                        UpdateTimeSheetTotalQty(objEmployeeTimeSheetsInfo);
                    }

                    if (employeeID == null || employeeID == 0)
                    {
                        employeeTimeSheets.Add(objEmployeeTimeSheetsInfo);
                    }
                    //employeeTimeSheets.Add(objEmployeeTimeSheetsInfo);                                        
                }
                if (employeeID == null || employeeID == 0)
                {
                    foreach (HREmployeeTimeSheetsInfo item in employeeTimeSheets)
                    {
                        HREmployeeTimeSheetsInfo check = entity.EmployeeTimeSheetsList.Where(x => x.FK_HREmployeeID == item.FK_HREmployeeID).FirstOrDefault();
                        if (check == null)
                            entity.EmployeeTimeSheetsList.Add(item);
                        else
                        {
                            if (entity.EmployeeTimeSheetsList.IndexOf(check) >= 0)
                                entity.EmployeeTimeSheetsList.RemoveAt(entity.EmployeeTimeSheetsList.IndexOf(check));
                            entity.EmployeeTimeSheetsList.Add(item);
                        }

                    }
                    //entity.EmployeeTimeSheetsList.Invalidate(employeeTimeSheets);
                    employeeTimeSheets.Clear();
                }
            }
            #endregion
        }

        private List<HRTimeSheetEntrysInfo> AddTimeSheetEntryFromEmployeeWorkSchedule()
        {
            List<HRTimeSheetEntrysInfo> timeEntries = new List<HRTimeSheetEntrysInfo>();

            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)CurrentModuleEntity.MainObject;

            DateTime dateFrom = timeSheet.HRTimeSheetFromDate;
            DateTime dateTo = timeSheet.HRTimeSheetToDate;

            HREmployeesController objEmployeesController = new HREmployeesController();

            //get employee's work schedule
            HREmployeeWorkSchedulesController objEmployeeWorkSchedulesController = new HREmployeeWorkSchedulesController();
            List<HREmployeeWorkSchedulesInfo> employeeWorkScheduleList = objEmployeeWorkSchedulesController.GetByEmployeeID(dateFrom, dateTo, null);

            foreach (var employeeWorkSchedule in employeeWorkScheduleList)
            {
                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(employeeWorkSchedule.FK_HREmployeeID);
                if (objEmployeesInfo != null)
                {
                    //loop from EmployeeWorkScheduleDateFrom to EmployeeWorkScheduleDateTo to date to create time sheet entries for the employee
                    for (DateTime dt = employeeWorkSchedule.HREmployeeWorkScheduleDateFrom.Date;
                                    dt < employeeWorkSchedule.HREmployeeWorkScheduleDateTo; dt = dt.AddDays(1))
                    {
                        HRTimeSheetEntrysInfo obj = new HRTimeSheetEntrysInfo();
                        obj.FK_HREmployeeID = employeeWorkSchedule.FK_HREmployeeID;
                        obj.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
                        obj.HRTimeSheetEntryDate = dt.Date;
                        if (dt.Date == employeeWorkSchedule.HREmployeeWorkScheduleDateFrom.Date)
                        {
                            obj.HRTimeSheetEntryFrom = employeeWorkSchedule.HREmployeeWorkScheduleDateFrom;
                            if (employeeWorkSchedule.HREmployeeWorkScheduleDateTo.Date == employeeWorkSchedule.HREmployeeWorkScheduleDateFrom.Date)
                                obj.HRTimeSheetEntryTo = DateTime.ParseExact(employeeWorkSchedule.HREmployeeWorkScheduleDateFrom.ToString("dd/MM/yyyy") + " " +
                                            employeeWorkSchedule.HREmployeeWorkScheduleDateTo.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            else
                                obj.HRTimeSheetEntryTo = employeeWorkSchedule.HREmployeeWorkScheduleDateFrom.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        }
                        else
                        {
                            obj.HRTimeSheetEntryFrom = dt;
                            if (dt.Date == employeeWorkSchedule.HREmployeeWorkScheduleDateTo.Date)
                                obj.HRTimeSheetEntryTo = dt.AddHours(employeeWorkSchedule.HREmployeeWorkScheduleDateTo.Hour)
                                                            .AddMinutes(employeeWorkSchedule.HREmployeeWorkScheduleDateTo.Minute)
                                                            .AddSeconds(employeeWorkSchedule.HREmployeeWorkScheduleDateTo.Second);
                            else
                                obj.HRTimeSheetEntryTo = dt.AddHours(23).AddMinutes(59).AddSeconds(59);
                        }
                        timeEntries.Add(obj);
                    }
                }
                //}
            }

            return timeEntries;
        }

        private HRTimeSheetParamsInfo GetTimeSheetParam(List<HRTimeSheetParamsInfo> timeSheetParamsList, decimal val, bool isOT, int workingID, bool isWorkSchedule)
        {
            HRTimeSheetParamsInfo obj = timeSheetParamsList.Where(p => (p.IsOTCalculated == isOT && p.HRTimeSheetParamValue1 <= val && p.FK_ADWorkingShiftID == workingID && p.IsWorkSchedule == isWorkSchedule))
                .OrderByDescending(p => p.HRTimeSheetParamValue1).FirstOrDefault();
            if (obj == null) obj = new HRTimeSheetParamsInfo();
            return obj;
        }
        private HRTimeSheetParamsInfo GetTimeSheetParam(List<HRTimeSheetParamsInfo> timeSheetParamsList, decimal val, int workingShiftID, bool isWorkSchedule)
        {
            return GetTimeSheetParam(timeSheetParamsList, val, false, workingShiftID, isWorkSchedule);
        }
        private HRTimeSheetParamsInfo GetTimeSheetParam(List<HRTimeSheetParamsInfo> timeSheetParamsList, decimal val, bool isWorkSchedule)
        {
            return GetTimeSheetParam(timeSheetParamsList, val, false, 0, isWorkSchedule);
        }

        private HRTimeSheetParamsInfo GetAllTimeSheetParamByIsOTCalculated(List<HRTimeSheetParamsInfo> timeSheetParamsList, bool isOTCalculated, string timeSheetParamType, decimal value1, decimal value2)
        {
            HRTimeSheetParamsInfo obj = timeSheetParamsList.Where(p => (p.IsOTCalculated == isOTCalculated && p.HRTimeSheetParamType == timeSheetParamType &&
                                                            p.HRTimeSheetParamValue1 <= value1 && p.HRTimeSheetParamValue2 == value2))
                .OrderByDescending(p => p.HRTimeSheetParamValue1).FirstOrDefault();
            if (obj == null) obj = new HRTimeSheetParamsInfo();
            return obj;
        }

        public void InitializeTimeSheetEntryGridControl()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            HREmployeeTimeSheetsGridControl gridControl = (HREmployeeTimeSheetsGridControl)Controls["fld_dgcHREmployeeTimeSheets"];
            gridControl.InitializeControl();
            InitColumnRepository(objTimeSheetsInfo.HRTimeSheetType);
        }

        public void InitColumnRepository(string timeSheetType)
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)entity.MainObject;
            VinaGridControl timeSheetEntrysGridControl = (VinaGridControl)Controls["fld_dgcHREmployeeTimeSheets"];
            RepositoryItemCheckedComboBoxEdit reposItemCheckedCombo = new RepositoryItemCheckedComboBoxEdit();

            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRTimeSheetParamsInfo> mainParams = objTimeSheetParamsController.GetTimeSheetParamsByTimeSheetType(timeSheetType);
            List<HRTimeSheetParamsInfo> commonParams = objTimeSheetParamsController.GetTimeSheetParamsByTimeSheetType(TimeSheetParamType.Common.ToString());
            List<HRTimeSheetParamsInfo> otParams = objTimeSheetParamsController.GetOTTimeSheetParamsList();

            mainParams = mainParams.Concat(commonParams).ToList();
            mainParams = mainParams.Concat(otParams).ToList();
            reposItemCheckedCombo.DataSource = mainParams;

            reposItemCheckedCombo.DisplayMember = "HRTimeSheetParamNo";
            reposItemCheckedCombo.ValueMember = "HRTimeSheetParamNo";
            timeSheetEntrysGridControl.RepositoryItems.Add(reposItemCheckedCombo);
            GridView gridView = (GridView)timeSheetEntrysGridControl.MainView;
            for (int i = 4; i < gridView.Columns.Count; i++)
            {
                if (gridView.Columns[i] != gridView.Columns["HREmployeeTimeSheetNghiLe"])
                {
                    gridView.Columns[i].ColumnEdit = reposItemCheckedCombo;
                }
            }
            reposItemCheckedCombo.EditValueChanged += new EventHandler(ReposItemCheckedCombo_EditValueChanged);
        }
        private void ReposItemCheckedCombo_EditValueChanged(object sender, EventArgs e)
        {
            CheckedComboBoxEdit checkCombo = (CheckedComboBoxEdit)sender;
            string value = checkCombo.EditValue.ToString();
            if ( MessageBox.Show("Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
            {
                value = checkCombo.OldEditValue.ToString();
            }
            string comboText = String.Empty;
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            HRTimeSheetParamsInfo objTimeSheetParamsInfo = new HRTimeSheetParamsInfo();
            string[] arrayValue = value.Split(',');
            for (int i = 0; i < arrayValue.Length; i++)
            {
                if (arrayValue[i].Trim() != String.Empty)
                {
                    int paramID = objTimeSheetParamsController.GetObjectIDByNo(arrayValue[i].Trim());
                    comboText += String.Format("{0}, ", objTimeSheetParamsController.GetObjectNoByID(paramID));
                }
            }
            if (comboText.Length > 2)
            {
                checkCombo.Text = comboText.Substring(0, comboText.Length - 2);
            }
            else if (comboText.Length <= 2)
            {
                checkCombo.Text = "";
            }
        }

        public void ChangeTimeSheetType(string timeSheetType)
        {
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)CurrentModuleEntity.MainObject;
            timeSheet.HRTimeSheetType = timeSheetType;
            InvalidateTimeSheetValues();
            InitializeTimeSheetEntryGridControl();
        }

        private void InvalidateTimeSheetValues()
        {
            TimeSheetEntities entity = (TimeSheetEntities)CurrentModuleEntity;
            foreach (HREmployeeTimeSheetsInfo employeeTimeSheet in entity.EmployeeTimeSheetsList)
            {
                entity.SetEmployeeTimeSheetValue(employeeTimeSheet);
                UpdateTimeSheetTotalQty(employeeTimeSheet);
            }
        }

        public void ChangeTimeSheetTime()
        {
            InvalidateTimeSheetValues();
            InitializeTimeSheetEntryGridControl();
        }
    }
}
