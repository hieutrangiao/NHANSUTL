using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;
using VinaLib.BaseProvider;
using VinaERP.Modules.ManagerTimeKeeper.UI;
using VinaCommon;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using VinaERP.Common.Constant.HR;
using zkemkeeper;
using VinaERP.Common;

namespace VinaERP.Modules.ManagerTimeKeeper
{

    public class ManagerTimeKeeperModule : BaseModuleERP
    {
        #region Public Properties
        //public HRTimeKeeperCompletesGridControl TimeKeeperCompletesGridControl;
        public List<HREmployeesInfo> EmployeeWorkingShiftList;
        public List<HREmployeeOTsInfo> AllEmployeeOTList;
        public List<HRTimeKeeperCompletesInfo> TimeKeeperCompletesClone;
        #region DMMT100
        public DateTime mt100DateFrom;
        public DateTime mt100DateTo;
        public int mt100BranchID;
        public int mt100DepartmentID;
        public int mt100DepartmentRoomID;
        public int mt100DepartmentRoomGroupItemID;
        public HRMachineTimeKeepersInfo CurenMachineTimeKeeper;
        #endregion
        #endregion
        public ManagerTimeKeeperModule()
        {
            CurrentModuleName = "ManagerTimeKeeper";
            CurrentModuleEntity = new ManagerTimeKeeperEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            EmployeeWorkingShiftList = new List<HREmployeesInfo>();
            AllEmployeeOTList = new List<HREmployeeOTsInfo>();
            //TimeKeeperCompletesGridControl = (HRTimeKeeperCompletesGridControl)Controls["fld_dgcHRTimeKeeperCompletes"];
            GetEmployeesList();
            GetMachineTimeKeepersList();
        }

        public void GetEmployeesList()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public void GetMachineTimeKeepersList()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HRMachineTimeKeepersController objMachineTimeKeepersController = new HRMachineTimeKeepersController();
            entity.MachineTimeKeepersList.Invalidate(objMachineTimeKeepersController.GetAllObjectList());
        }

        public override void InitializeScreens()
        {
            this.ParentScreen.LeftPanelContainer.Hide();
            DMMT100 DMMT100 = new DMMT100();
            DMMT100.ScreenCode = "DMMT100";
            DMMT100.Module = this;
            DMMT100.Height -= 100;
            DMMT100.InitGridControl();
            Screens.Add(DMMT100);
            DMMT100.AddControlsToParentScreen();

            DMMT101 DMMT101 = new DMMT101();
            DMMT101.ScreenCode = "DMMT101";
            DMMT101.Module = this;
            DMMT101.Height -= 100;
            DMMT101.InitGridControl();
            Screens.Add(DMMT101);
            DMMT101.AddControlsToParentScreen();

            DMMT102 DMMT102 = new DMMT102();
            DMMT102.ScreenCode = "DMMT102";
            DMMT102.Module = this;
            DMMT102.Height -= 100;
            DMMT102.InitGridControl();
            Screens.Add(DMMT102);
            DMMT102.AddControlsToParentScreen();
        }

        public void AddBackupList(HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            if (entity.TimeKeeperCompleteBackupList2.Where(o => o.HRTimeKeeperCompleteDate == objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate
                                                                && o.HRTimeKeeperCompletesEmployeeCardNo == objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo
                                                                && o.FK_HRTimeKeeperID == objTimeKeeperCompletesInfo.FK_HRTimeKeeperID).Count() == 0)
            {
                entity.TimeKeeperCompleteBackupList2.Add(objTimeKeeperCompletesInfo);
            }
            else
            {
                entity.TimeKeeperCompleteBackupList2.Remove(entity.TimeKeeperCompleteBackupList2.Where(o => o.HRTimeKeeperCompleteDate == objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate
                                                            && o.HRTimeKeeperCompletesEmployeeCardNo == objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo
                                                            && o.FK_HRTimeKeeperID == objTimeKeeperCompletesInfo.FK_HRTimeKeeperID).FirstOrDefault());

                entity.TimeKeeperCompleteBackupList2.Add(objTimeKeeperCompletesInfo);
            }
        }

        public void CalculateData(int branchId, int departmentID, int departmentRoomID, int departmentRoomGroupItemID, int employeeID, DateTime dateFrom, DateTime dateTo)
        {
            mt100DateFrom = dateFrom;
            mt100DateTo = dateTo;
            mt100BranchID = branchId;
            mt100DepartmentID = departmentID;
            mt100DepartmentRoomID = departmentRoomID;
            mt100DepartmentRoomGroupItemID = departmentRoomGroupItemID;

            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            entity.TimeKeeperCompleteBackupList = new List<HRTimeKeeperCompletesInfo>();
            entity.TimeKeeperCompleteBackupList2 = new List<HRTimeKeeperCompletesInfo>();

            HRTimeKeepersController objTimeKeepersController = new HRTimeKeepersController();
            HREmployeeOTsController objEmployeeOTsController = new HREmployeeOTsController();
            HREmployeesController objEmployeesController = new HREmployeesController();
            List<HRTimeKeepersInfo> keeperList;

            AllEmployeeOTList = (List<HREmployeeOTsInfo>)objEmployeeOTsController.GetAllListOTByDate(dateFrom, dateTo);
            EmployeeWorkingShiftList = objEmployeesController.GetEmployeeWorkingShiftList();
            TimeKeeperCompletesClone = new List<HRTimeKeeperCompletesInfo>();
            objTimeKeepersController.DeleteDataDuplicateByDate(dateFrom, dateTo);
            keeperList = objTimeKeepersController.GetTimeKeeperByConditions(branchId, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, 0, dateFrom, dateTo.AddDays(1));
            if (entity.TimeKeeperCompleteBackupList != null)
            {
                entity.TimeKeeperCompleteBackupList.Clear();
            }
            List<HRTimeKeeperCompletesInfo> listComplate = ConvertTimeKeeperListToComplete3(keeperList, dateFrom, dateTo);
            entity.TimeKeeperCompletesList.Invalidate(listComplate);
            GridView view = (GridView)entity.TimeKeeperCompletesList.GridControl.MainView;
            view.ExpandAllGroups();
        }

        public bool CheckSameTime(HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo, List<HRTimeKeeperCompletesInfo> listDataComplete)
        {
            //if (TimeKeeperCompletesGridControl == null)
            //    return false;
            bool result = false;
            if (listDataComplete != null)
            {
                HRTimeKeeperCompletesInfo objTimeKeeperCompleteSamesInfo = listDataComplete.Where(x => x.HRTimeKeeperCompleteDate == objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate &&
                                                                                                        x.HRTimeKeeperCompletesEmployeeCardNo == objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo &&
                                                                                                        x.HRTimeKeeperCompleteTimeCheck == objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck &&
                                                                                                        x.HRTimeKeeperCompleteInOutMode != objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode).FirstOrDefault();
                if (objTimeKeeperCompleteSamesInfo != null)
                {
                    objTimeKeeperCompleteSamesInfo.SameDateTime = "False";
                    objTimeKeeperCompletesInfo.SameDateTime = "False";
                    result = true;
                }
                else
                {
                    objTimeKeeperCompletesInfo.SameDateTime = "";
                }
            }
            return result;
        }

        public bool CheckNotInOverTime(HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo, int MinRegisterOverTime, bool isChangeTimeCheck)
        {
            //if (TimeKeeperCompletesGridControl == null)
            //    return false;
            bool result = false;
            //List<HRTimeKeeperCompletesInfo> listDataComplete = (List<HRTimeKeeperCompletesInfo>)TimeKeeperCompletesGridControl.DataSource;
            if (EmployeeWorkingShiftList != null)
            {
                HREmployeesInfo WorkingShift = EmployeeWorkingShiftList.Where(x => x.HREmployeeCardNumber == objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo).FirstOrDefault();
                if (WorkingShift != null)
                {
                    DateTime d1 = DateTime.ParseExact(objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck.ToString("dd/MM/yyyy") + " "
                        + WorkingShift.HRWorkingShiftToTime.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    if (objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode == 1 // Thoi gian ra lon hon thoi gian lam viec + 60 phut => la tang ca
                        && objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck >= d1.AddMinutes((double)MinRegisterOverTime))
                    {
                        //Kiểm tra đăng ký TC
                        HREmployeeOTsInfo objEmployeeOTsInfo = AllEmployeeOTList.Where(x => x.FK_HREmployeeID == WorkingShift.HREmployeeID
                                                                                        && x.HREmployeeOTDate.Date == objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate.Date).FirstOrDefault();
                        if (objEmployeeOTsInfo == null || objEmployeeOTsInfo.HREmployeeOTID == 0)
                        {
                            result = true;

                        }
                        else
                        {
                            if (isChangeTimeCheck)
                            {
                                objTimeKeeperCompletesInfo.NotInOverTime = "";
                            }
                        }

                    }
                    else
                    {
                        objTimeKeeperCompletesInfo.NotInOverTime = "";
                    }
                }

            }
            return result;
        }

        public bool CheckOverTimeAbsence(HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo, int MinRegisterOverTime, bool isChangeTimeCheck)
        {
            //if (TimeKeeperCompletesGridControl == null)
            //    return false;
            bool result = false;
            if (EmployeeWorkingShiftList != null)
            {
                HREmployeeOTsInfo objEmployeeOTsInfo = AllEmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo
                                                                                        && x.HREmployeeOTDate.Date == objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate).FirstOrDefault();
                if (objEmployeeOTsInfo != null && objEmployeeOTsInfo.HREmployeeOTID > 0)
                {
                    HREmployeesInfo WorkingShift = EmployeeWorkingShiftList.Where(x => x.HREmployeeCardNumber == objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo).FirstOrDefault();
                    if (WorkingShift != null && WorkingShift.HREmployeeID > 0)
                    {
                        DateTime d1 = DateTime.ParseExact(objEmployeeOTsInfo.HREmployeeOTDate.ToString("dd/MM/yyyy") + " "
                        + objEmployeeOTsInfo.HREmployeeOTFromDate.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        if (objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode == 1 // Thoi gian ra lon hon thoi gian lam viec + 60 phut => la tang ca
                            && objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck <= d1.AddMinutes((double)MinRegisterOverTime))
                        {
                            //Kiểm tra đăng ký TC
                            result = true;
                            objTimeKeeperCompletesInfo.RegisterOverTimeAbsence = DateTime.ParseExact(objEmployeeOTsInfo.HREmployeeOTDateEnd.ToString("dd/MM/yyyy") + " "
                        + objEmployeeOTsInfo.HREmployeeOTToDate.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            if (isChangeTimeCheck)
                            {
                                objTimeKeeperCompletesInfo.OverTimeAbsence = "";
                            }
                        }
                    }
                }


            }
            return result;
        }

        public void ChangeCompleteDate(HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo)
        {
            if (objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate.Date != objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck.Date)
            {
                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = DateTime.ParseExact(objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate.ToString("dd/MM/yyyy") + " "
                                     + objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = DateTime.ParseExact(objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate.ToString("dd/MM/yyyy") + " "
                                     + objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck.ToString("HH:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


            }
        }

        private List<HRTimeKeeperCompletesInfo> ConvertTimeKeeperListToComplete3(List<HRTimeKeepersInfo> timeKeeperList, DateTime dateFrom, DateTime dateTo)
        {
            List<HRTimeKeeperCompletesInfo> list = new List<HRTimeKeeperCompletesInfo>();
            DateTime from = dateFrom.Date;
            DateTime to = dateTo.Date;
            HREmployeeOTsController objEmployeeOTsController = new HREmployeeOTsController();
            List<HREmployeeOTsInfo> EmployeeOTList = (List<HREmployeeOTsInfo>)objEmployeeOTsController.GetListOTDiffDates(null, from.AddDays(-1), to);

            Hashtable listEmployee = new Hashtable();
            foreach (HRTimeKeepersInfo item in timeKeeperList)
            {
                if (!listEmployee.ContainsKey(item.HRTimeKeeperEmployeeCardNo))
                {
                    listEmployee.Add(item.HRTimeKeeperEmployeeCardNo, item.HRTimeKeeperEmployeeNo);
                }
            }
            string cardNo = string.Empty;
            List<HRTimeKeepersInfo> listTemp = new List<HRTimeKeepersInfo>();
            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo employeesInfo;
            HREmployeePayrollFormulasController objEmployeePayrollFormulasController = new HREmployeePayrollFormulasController();
            HREmployeePayrollFormulasInfo objEmployeePayrollFormulasInfo = new HREmployeePayrollFormulasInfo();
            List<HREmployeesInfo> EmployeeList = objEmployeesController.GetEmployeeCardNumberList(null, null, null, null);

            HRBreakTimesController objBreakTimesController = new HRBreakTimesController();
            List<HRBreakTimesInfo> BreakTimeList = objBreakTimesController.GetBreakTimeList();

            HREmployeeArrangementShiftsController objEmployeeArrangementShiftsController = new HREmployeeArrangementShiftsController();
            HRArrangementShiftEntrysController objArrangementShiftEntrysController = new HRArrangementShiftEntrysController();
            List<HRArrangementShiftEntrysInfo> arrangementShiftEntrys;
            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            List<ADWorkingShiftsInfo> workingShiftList = new List<ADWorkingShiftsInfo>();
            workingShiftList = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());

            HRWorkingShiftsController objHRWorkingShiftsController = new HRWorkingShiftsController();
            HRWorkingShiftsInfo objHRWorkingShiftsInfo = new HRWorkingShiftsInfo();

            foreach (var item in listEmployee.Keys)
            {
                cardNo = item.ToString();
                employeesInfo = EmployeeList.Where(x => x.HREmployeeCardNumber == cardNo).FirstOrDefault(); ;
                if (employeesInfo != null)
                {
                    bool checkarrangementShift = true;
                    from = dateFrom.Date;
                    ADWorkingShiftsInfo objADWorkingShiftsInfo = new ADWorkingShiftsInfo();
                    objEmployeePayrollFormulasInfo = (HREmployeePayrollFormulasInfo)objEmployeePayrollFormulasController.GetObjectByID(employeesInfo.FK_HREmployeePayrollFormulaID);
                    if (objEmployeePayrollFormulasInfo != null)
                    {
                        List<HRWorkingShiftsInfo> listWorkingShifts = (List<HRWorkingShiftsInfo>)objHRWorkingShiftsController.GetWorkingShiftByPayrollFormulaID(objEmployeePayrollFormulasInfo.HREmployeePayrollFormulaID);
                        if (listWorkingShifts != null && listWorkingShifts.Count > 0)
                        {
                            objHRWorkingShiftsInfo = listWorkingShifts.Where(o => o.HRWorkingShiftIsDefault == true).FirstOrDefault();
                            if (objHRWorkingShiftsInfo != null)
                            {
                                objADWorkingShiftsInfo = (ADWorkingShiftsInfo)workingShiftList.Where(o => o.ADWorkingShiftID == objHRWorkingShiftsInfo.FK_ADWorkingShiftID).FirstOrDefault();
                            }
                        }
                    }

                    ADWorkingShiftsInfo objADWorkingShiftsInfoDefault = (ADWorkingShiftsInfo)workingShiftList.Where(o => o.ADWorkingShiftID == employeesInfo.FK_ADWorkingShiftID).FirstOrDefault();

                    while (from <= to)
                    {
                        List<ADWorkingShiftsInfo> workingShiftList2 = new List<ADWorkingShiftsInfo>();
                        if (objADWorkingShiftsInfo != null && objADWorkingShiftsInfo.ADWorkingShiftID > 0)
                        {
                            workingShiftList2.Add(objADWorkingShiftsInfo);
                        }

                        if (employeesInfo.HREmployeePayRollCalculatedWorkType == EmployeePayRollCalculatedWorkType.TableWork.ToString())
                        {
                            workingShiftList2.Clear();
                            arrangementShiftEntrys = (List<HRArrangementShiftEntrysInfo>)objArrangementShiftEntrysController.GetKHRArrangementShiftEntryByFK_HREmployeeIDAndDate(employeesInfo.HREmployeeID, from.Date);
                            if (arrangementShiftEntrys.Count() > 0)
                            {
                                checkarrangementShift = true;
                                arrangementShiftEntrys.ForEach(o =>
                                {
                                    ADWorkingShiftsInfo obj = new ADWorkingShiftsInfo();
                                    obj = (ADWorkingShiftsInfo)workingShiftList.Where(x => x.ADWorkingShiftID == o.FK_ADWorkingShiftID).FirstOrDefault();
                                    workingShiftList2.Add(obj);
                                });
                            }
                            else
                            {
                                checkarrangementShift = false;
                            }
                        }
                        else if (employeesInfo.HREmployeePayRollCalculatedWorkType == EmployeePayRollCalculatedWorkType.Default.ToString())
                        {
                            if (objADWorkingShiftsInfoDefault != null)
                            {
                                workingShiftList2.Clear();
                                workingShiftList2.Add(objADWorkingShiftsInfoDefault);
                            }
                        }
                        {
                            List<HREmployeeOTsInfo> EmployeeOTsListDefult = (List<HREmployeeOTsInfo>)AllEmployeeOTList.Where(x => x.HREmployeeCardNumber == employeesInfo.HREmployeeCardNumber
                                                                                                    && x.HREmployeeOTDate.Date == from.Date).ToList();
                            listTemp = timeKeeperList.Where(p => (p.HRTimeKeeperEmployeeCardNo == cardNo &&
                                    p.HRTimeKeeperDate.Date == from.Date)).OrderBy(p => p.HRTimeKeeperTimeOut).ToList();
                            if (listTemp.Count >= 1)
                            {
                                HRBreakTimesInfo objBreakTimesInfo = new HRBreakTimesInfo();
                                if (BreakTimeList != null)
                                    objBreakTimesInfo = BreakTimeList.Where(x => x.FK_HREmployeePayrollFormulaID == employeesInfo.FK_HREmployeePayrollFormulaID).FirstOrDefault();

                                int leftTime = 0;
                                int BreakTimeMinRegisterOverTime = 0;
                                if (objBreakTimesInfo != null)
                                {
                                    leftTime = objBreakTimesInfo.HRBreakTimeMaxOutTime;
                                    BreakTimeMinRegisterOverTime = objBreakTimesInfo.HRBreakTimeMinRegisterOverTime;
                                }

                                List<HRTimeKeeperCompletesInfo> completeListItemReult = new List<HRTimeKeeperCompletesInfo>();

                                if (objEmployeePayrollFormulasInfo != null)
                                {
                                    if (workingShiftList2.Count > 0 || (EmployeeOTsListDefult != null && EmployeeOTsListDefult.Count > 0))
                                    {
                                        if (objEmployeePayrollFormulasInfo.HREmployeePayrollFormulaHandleTypeCombo == EmployeePayrollFormulaHandleTypeCombo.FirstLast.ToString())
                                        {
                                            completeListItemReult = ConvertTimeKeeperMultiInOutToComplete3(listTemp, employeesInfo, EmployeeOTList, timeKeeperList, BreakTimeList, workingShiftList2, EmployeeOTsListDefult, objEmployeePayrollFormulasInfo.HREmployeePayrollFormulaHandleTypeCombo);
                                        }
                                        else
                                        {
                                            completeListItemReult = ConvertTimeKeeperMultiInOutToComplete3(listTemp, employeesInfo, EmployeeOTList, timeKeeperList, BreakTimeList, workingShiftList2, EmployeeOTsListDefult, objEmployeePayrollFormulasInfo.HREmployeePayrollFormulaHandleTypeCombo);
                                        }
                                    }
                                    else
                                    {
                                        completeListItemReult = ConvertTimeKeeperMultiInOutToComplete2(listTemp, employeesInfo, EmployeeOTList, timeKeeperList, BreakTimeList);
                                    }
                                }
                                foreach (HRTimeKeeperCompletesInfo completeListItemReultItem in completeListItemReult)
                                {
                                    HRTimeKeeperCompletesInfo objTimeKeeperCompleteSamesInfo = completeListItemReult.Where(x => x.HRTimeKeeperCompleteDate == completeListItemReultItem.HRTimeKeeperCompleteDate &&
                                                                                                           x.HRTimeKeeperCompletesEmployeeCardNo == completeListItemReultItem.HRTimeKeeperCompletesEmployeeCardNo &&
                                                                                                           x.HRTimeKeeperCompleteTimeCheck == completeListItemReultItem.HRTimeKeeperCompleteTimeCheck &&
                                                                                                           x.HRTimeKeeperCompleteInOutMode != completeListItemReultItem.HRTimeKeeperCompleteInOutMode).FirstOrDefault();
                                    if (objTimeKeeperCompleteSamesInfo != null)
                                    {
                                        completeListItemReultItem.SameDateTime = "False";
                                    }
                                }
                                list.AddRange(completeListItemReult);
                            }
                        }
                        from = from.AddDays(1);
                    }
                }
            }
            return list;
        }

        public List<HRTimeKeeperCompletesInfo> ConvertTimeKeeperMultiInOutToComplete3(List<HRTimeKeepersInfo> listTemp
                                                                                    , HREmployeesInfo employeesInfo
                                                                                    , List<HREmployeeOTsInfo> EmployeeOTList
                                                                                    , List<HRTimeKeepersInfo> timeKeeperList
                                                                                    , List<HRBreakTimesInfo> BreakTimeList
                                                                                    , List<ADWorkingShiftsInfo> workingShiftList
                                                                                    , List<HREmployeeOTsInfo> EmployeeOTsListDefult
                                                                                    , string type)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;

            List<HRTimeKeeperCompletesInfo> completeList = new List<HRTimeKeeperCompletesInfo>();
            HROverTimesController objOverTimesController = new HROverTimesController();
            if (workingShiftList.Count > 0)
            {
                workingShiftList.ForEach(o =>
                {
                    completeList = AddTimeKeeperToTimeKeeperComplete2(completeList, EmployeeOTList, employeesInfo, listTemp, o, EmployeeOTsListDefult, type);

                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo3 = (HRTimeKeeperCompletesInfo)completeList.FirstOrDefault();
                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo4 = new HRTimeKeeperCompletesInfo();
                    if (o.ADWorkingShiftFromTime.TimeOfDay > o.ADWorkingShiftToTime.TimeOfDay)
                    {
                        if (objTimeKeeperCompletesInfo3 != null)
                        {
                            if ((objTimeKeeperCompletesInfo3.HRTimeKeeperCompleteTimeCheck.TimeOfDay <= o.ADWorkingShiftTimeKeepOutTo.TimeOfDay) && objTimeKeeperCompletesInfo3.FK_ADWorkingShiftID == o.ADWorkingShiftID)
                            {
                                completeList.RemoveAt(0);
                                completeList.ForEach(x =>
                                {
                                    if (x.HRTimeKeeperCompleteInOutMode == 0)
                                    {
                                        x.HRTimeKeeperCompleteInOutMode = 1;
                                        x.HRTimeKeeperCompleteInOutModeName = "Ra";
                                    }
                                    else
                                    {
                                        x.HRTimeKeeperCompleteInOutMode = 0;
                                        x.HRTimeKeeperCompleteInOutModeName = "Vào";
                                    }
                                });
                            }
                        }
                        //else
                        if (completeList != null && completeList.Count > 0)
                        {
                            objTimeKeeperCompletesInfo4 = GetOutModeTimeList((HRTimeKeeperCompletesInfo)completeList.LastOrDefault()
                                                                            , employeesInfo
                                                                            , o);
                            if (objTimeKeeperCompletesInfo4 != null)
                            {
                                if (objTimeKeeperCompletesInfo4.HRTimeKeeperCompleteTimeCheck.TimeOfDay < o.ADWorkingShiftToTime.TimeOfDay)
                                {
                                    objTimeKeeperCompletesInfo4.GoEarly = "False";
                                }
                                completeList.Add(objTimeKeeperCompletesInfo4);
                            }
                        }
                    }

                    #region Check OT diff date and get time out type  OR Add plus if the End InOutMode = In
                    //Check OT diff date and get time out type 
                    if (completeList != null && completeList.Count > 0 && completeList.Count % 2 == 1)
                    {
                        completeList[completeList.Count - 1].HRTimeKeeperCompleteInOutMode = 0;
                        if (completeList[completeList.Count - 1].HRTimeKeeperCompleteInOutMode == 0)
                        {
                            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
                            // Check OT diff date
                            if (EmployeeOTList != null)
                            {
                                objTimeKeeperCompletesInfo = GetOutModeTimeFromOverTimeList(EmployeeOTList
                                                                                , timeKeeperList
                                                                                , listTemp[0]
                                                                                , employeesInfo);
                                if (objTimeKeeperCompletesInfo != null)
                                {
                                    completeList.Add(objTimeKeeperCompletesInfo);
                                }
                                else // Không tồng tại danh sách OT
                                {
                                    objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                    //Lay ngay cham cong là ngày trước OT: listTemp[0].HRTimeKeeperDate
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = completeList[completeList.Count - 1].HRTimeKeeperCompleteDate;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = completeList[completeList.Count - 1].HRTimeKeeperCompletesEmployeeCardNo;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = completeList[completeList.Count - 1].HRTimeKeeperCompleteTimeCheck;
                                    objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                    objTimeKeeperCompletesInfo.ThName = completeList[completeList.Count - 1].ThName;
                                    objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = completeList[completeList.Count - 1].FK_HRMachineTimeKeeperID;
                                    objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                    objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = completeList[completeList.Count - 1].HRTimeKeeperCompleteDateCheck;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                    objTimeKeeperCompletesInfo.SameDateTime = "False";
                                    objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = o.ADWorkingShiftID;
                                    completeList.Add(objTimeKeeperCompletesInfo);
                                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                    entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                }
                            }
                        }
                    }
                    #endregion
                });
            }

            if (type == EmployeePayrollFormulaHandleTypeCombo.FirstLast.ToString())
            {
                if (EmployeeOTsListDefult != null && EmployeeOTsListDefult.Count > 0)
                {
                    EmployeeOTsListDefult.ForEach(o =>
                    {
                        ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
                        ADWorkingShiftsInfo objWorkingShiftsInfo = new ADWorkingShiftsInfo();
                        if (o.FK_ADWorkingShiftID > 0)
                        {
                            objWorkingShiftsInfo = (ADWorkingShiftsInfo)objWorkingShiftsController.GetObjectByID(o.FK_ADWorkingShiftID);
                            if (objWorkingShiftsInfo != null)
                            {
                                completeList = AddTimeKeeperToTimeKeeperComplete4(completeList, EmployeeOTList, employeesInfo, listTemp, objWorkingShiftsInfo, o, EmployeePayrollFormulaHandleTypeCombo.FirstLast.ToString());

                                #region Check OT diff date and get time out type  OR Add plus if the End InOutMode = In
                                #endregion
                            }
                        }
                    });
                }
            }

            return completeList;
        }

        public List<HRTimeKeeperCompletesInfo> AddTimeKeeperToTimeKeeperComplete2(List<HRTimeKeeperCompletesInfo> completeList,
                                                                                    List<HREmployeeOTsInfo> EmployeeOTList,
                                                                                    HREmployeesInfo employeesInfo,
                                                                                    List<HRTimeKeepersInfo> objTimeKeeperList,
                                                                                    ADWorkingShiftsInfo workingShiftList,
                                                                                    List<HREmployeeOTsInfo> objEmployeeOTs,
                                                                                    string type)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
            List<HRBreakTimesInfo> breakTimeList = new List<HRBreakTimesInfo>();
            if (workingShiftList != null)
            {
                HRBreakTimesInfo objBreakTimesInfo = new HRBreakTimesInfo();
                objBreakTimesInfo.HRBreakTimeTimeSheetType = "In";
                objBreakTimesInfo.HRBreakTimeFromTime = workingShiftList.ADWorkingShiftTimeKeepInFrom;
                objBreakTimesInfo.HRBreakTimeToTime = workingShiftList.ADWorkingShiftTimeKeepInTo;
                objBreakTimesInfo.WorkingTimeIn = workingShiftList.ADWorkingShiftFromTime;
                objBreakTimesInfo.WorkingTimeOut = workingShiftList.ADWorkingShiftToTime;
                objBreakTimesInfo.NghiTruaTimeFrom = workingShiftList.ADWorkingShiftBreakTimeBetweenFrom;
                objBreakTimesInfo.NghiTruaTimeTo = workingShiftList.ADWorkingShiftBreakTimeBetweenTo;

                HRBreakTimesInfo objBreakTimesInfo2 = new HRBreakTimesInfo();
                objBreakTimesInfo2.HRBreakTimeTimeSheetType = "Out";
                objBreakTimesInfo2.HRBreakTimeFromTime = workingShiftList.ADWorkingShiftTimeKeepOutFrom;
                objBreakTimesInfo2.HRBreakTimeToTime = workingShiftList.ADWorkingShiftTimeKeepOutTo;
                objBreakTimesInfo2.WorkingTimeIn = workingShiftList.ADWorkingShiftFromTime;
                objBreakTimesInfo2.WorkingTimeOut = workingShiftList.ADWorkingShiftToTime;
                objBreakTimesInfo2.NghiTruaTimeFrom = workingShiftList.ADWorkingShiftBreakTimeBetweenFrom;
                objBreakTimesInfo2.NghiTruaTimeTo = workingShiftList.ADWorkingShiftBreakTimeBetweenTo;

                breakTimeList.Add(objBreakTimesInfo);
                breakTimeList.Add(objBreakTimesInfo2);
            }

            if (type == EmployeePayrollFormulaHandleTypeCombo.Double.ToString())
            {
                if (breakTimeList != null && breakTimeList.Count > 0)
                {
                    HRBreakTimesInfo timeMin = new HRBreakTimesInfo();
                    HRBreakTimesInfo timeMax = new HRBreakTimesInfo();
                    timeMin = breakTimeList[0];
                    timeMax = breakTimeList[0];
                    breakTimeList.ForEach(o =>
                    {
                        if (timeMin.HRBreakTimeFromTime.TimeOfDay > o.HRBreakTimeFromTime.TimeOfDay)
                        {
                            timeMin = o;
                        }
                        if (timeMax.HRBreakTimeToTime.TimeOfDay < o.HRBreakTimeToTime.TimeOfDay)
                        {
                            timeMax = o;
                        }
                    });
                    int nextMode = 0;
                    int leftTime = 0;
                    int BreakTimeMinRegisterOverTime = 0;
                    List<HRTimeKeeperCompletesInfo> objTimeKeeperCheckComplete = new List<HRTimeKeeperCompletesInfo>();
                    objTimeKeeperList.ForEach(o =>
                    {
                        HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                        if (o.HRTimeKeeperTimeOut.TimeOfDay >= timeMin.HRBreakTimeFromTime.TimeOfDay && o.HRTimeKeeperTimeOut.TimeOfDay <= timeMax.HRBreakTimeToTime.TimeOfDay)
                        {
                            objTimeKeepersInfo = o;
                        }

                        if (objTimeKeepersInfo != null && objTimeKeepersInfo.HRTimeKeeperDate < DateTime.MaxValue)
                        {
                            List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck =
                            completeList.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
                            if (objTimeKeeperCheck == null || objTimeKeeperCheck.Count == 0)
                            {

                                #region Check OT diff date and clear time Out
                                // Check OT diff date
                                HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
                                                                                                            && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
                                                                                                            && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

                                #endregion

                                if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
                                {
                                    objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                    objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                    objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                                    objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                                    objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                    objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                    objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
                                    objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                                    objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                                    objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;
                                    if (workingShiftList != null)
                                    {
                                        objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = workingShiftList.ADWorkingShiftID;
                                    }

                                    if (nextMode == 0)
                                    {
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                        nextMode = 1;
                                        if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.WorkingTimeIn.TimeOfDay
                                            && objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < timeMin.WorkingTimeOut.TimeOfDay
                                            && ((objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay - timeMin.NghiTruaTimeFrom.TimeOfDay).TotalMinutes + 0.05 < 0
                                            || objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.NghiTruaTimeTo.TimeOfDay))
                                        {
                                            objTimeKeeperCompletesInfo.LateForWork = "False";
                                        }
                                    }
                                    else
                                    {
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                        nextMode = 0;
                                        if (completeList.Count < 1)
                                        {
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                        }

                                        if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.WorkingTimeIn.TimeOfDay
                                            && objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < timeMin.WorkingTimeOut.TimeOfDay
                                            && ((objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay - timeMin.NghiTruaTimeFrom.TimeOfDay).TotalMinutes + 0.05 < 0
                                            || objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.NghiTruaTimeTo.TimeOfDay))
                                        {
                                            objTimeKeeperCompletesInfo.GoEarly = "False";
                                        }
                                    }
                                    completeList.Add(objTimeKeeperCompletesInfo);
                                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                    entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                }
                            }
                            else if (workingShiftList != null && workingShiftList.ADWorkingShiftID > 0)
                            {
                                //List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck2 = objTimeKeeperCheckComplete.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
                                List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck2 =
                                completeList.Where(x => (x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay)
                                                    && (x.FK_ADWorkingShiftID == workingShiftList.ADWorkingShiftID)).ToList();
                                if (objTimeKeeperCheck2 == null || objTimeKeeperCheck2.Count == 0)
                                {
                                    if (o.HRTimeKeeperTimeOut.TimeOfDay >= workingShiftList.ADWorkingShiftTimeKeepInFrom.TimeOfDay
                                        && o.HRTimeKeeperTimeOut.TimeOfDay <= workingShiftList.ADWorkingShiftTimeKeepInTo.TimeOfDay)
                                    {
                                        #region Check OT diff date and clear time Out
                                        // Check OT diff date
                                        HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
                                                                                                                    && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
                                                                                                                    && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

                                        #endregion

                                        if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
                                        {
                                            objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                            objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                            objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                                            objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                                            objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                            objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                            //objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
                                            objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                                            objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                                            objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;
                                            if (workingShiftList != null)
                                            {
                                                objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = workingShiftList.ADWorkingShiftID;
                                            }

                                            if (nextMode == 0)
                                            {
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                                nextMode = 1;
                                                if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.WorkingTimeIn.TimeOfDay
                                                    && objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < timeMin.WorkingTimeOut.TimeOfDay
                                                    && ((objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay - timeMin.NghiTruaTimeFrom.TimeOfDay).TotalMinutes + 0.05 < 0
                                                    || objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.NghiTruaTimeTo.TimeOfDay))
                                                {
                                                    objTimeKeeperCompletesInfo.LateForWork = "False";
                                                }
                                            }
                                            else
                                            {
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                                nextMode = 0;
                                                if (completeList.Count < 1)
                                                {
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                                }

                                                if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.WorkingTimeIn.TimeOfDay
                                                    && objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < timeMin.WorkingTimeOut.TimeOfDay
                                                    && ((objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay - timeMin.NghiTruaTimeFrom.TimeOfDay).TotalMinutes + 0.05 < 0
                                                    || objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > timeMin.NghiTruaTimeTo.TimeOfDay))
                                                {
                                                    objTimeKeeperCompletesInfo.GoEarly = "False";
                                                }
                                            }

                                            completeList.Add(objTimeKeeperCompletesInfo);
                                            objTimeKeeperCheckComplete.Add(objTimeKeeperCompletesInfo);
                                            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                            entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                        }
                                    }
                                }
                            }
                        }
                    });
                }
            }
            else
            {
                if (breakTimeList != null && breakTimeList.Count > 0)
                {
                    breakTimeList.ForEach(h =>
                    {
                        int leftTime = 0;
                        int BreakTimeMinRegisterOverTime = 0;
                        DateTime timeIn = DateTime.MinValue;
                        DateTime timeOut = DateTime.MaxValue;
                        String InOut = string.Empty;
                        timeIn = h.HRBreakTimeFromTime;
                        timeOut = h.HRBreakTimeToTime;
                        InOut = h.HRBreakTimeTimeSheetType;
                        //if (type == EmployeePayrollFormulaHandleTypeCombo.FirstLast.ToString())
                        {
                            HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                            if (InOut == "In")
                            {
                                objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.Where(o => (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
                                                                                                 && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)).FirstOrDefault();
                            }
                            else if (InOut == "Out")
                            {
                                objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.Where(o => (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
                                                                                                && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)).LastOrDefault();
                            }

                            if (objTimeKeepersInfo != null && objTimeKeepersInfo.HRTimeKeeperDate < DateTime.MaxValue)
                            {
                                List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck = completeList.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
                                if (objTimeKeeperCheck == null || objTimeKeeperCheck.Count == 0)
                                {

                                    #region Check OT diff date and clear time Out
                                    // Check OT diff date
                                    HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
                                                                                                                && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
                                                                                                                && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

                                    #endregion

                                    if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
                                    {
                                        objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                        objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                        objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                                        objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                                        objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                        objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                        objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
                                        objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                                        objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                                        objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;
                                        if (workingShiftList != null)
                                        {
                                            objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = workingShiftList.ADWorkingShiftID;
                                        }

                                        if (InOut == "In")
                                        {
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                            if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeIn.TimeOfDay)
                                            {
                                                objTimeKeeperCompletesInfo.LateForWork = "False";
                                            }
                                        }
                                        else if (InOut == "Out")
                                        {
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                            if (completeList.Count < 1)
                                            {
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                            }
                                            if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < h.WorkingTimeOut.TimeOfDay)
                                            {
                                                objTimeKeeperCompletesInfo.GoEarly = "False";
                                            }
                                        }
                                        else
                                        {
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                            if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeIn.TimeOfDay)
                                            {
                                                objTimeKeeperCompletesInfo.GoEarly = "False";
                                            }
                                        }
                                        completeList.Add(objTimeKeeperCompletesInfo);
                                        HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                        entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                    }
                                }
                                else if (workingShiftList != null && workingShiftList.ADWorkingShiftID > 0)
                                {
                                    //List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck2 = objTimeKeeperCheckComplete.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
                                    List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck2 =
                                    completeList.Where(x => (x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay)
                                                        && (x.FK_ADWorkingShiftID == workingShiftList.ADWorkingShiftID)).ToList();
                                    if (objTimeKeeperCheck2 == null || objTimeKeeperCheck2.Count == 0)
                                    {
                                        if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay >= workingShiftList.ADWorkingShiftTimeKeepInFrom.TimeOfDay
                                            && objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay <= workingShiftList.ADWorkingShiftTimeKeepInTo.TimeOfDay)
                                        {
                                            #region Check OT diff date and clear time Out
                                            // Check OT diff date
                                            HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
                                                                                                                        && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
                                                                                                                        && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

                                            #endregion

                                            if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
                                            {
                                                objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                                objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                                objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                                                objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                                                objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                                objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                                objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                                                objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                                                objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;
                                                if (workingShiftList != null)
                                                {
                                                    objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = workingShiftList.ADWorkingShiftID;
                                                }

                                                if (InOut == "In")
                                                {
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                                    if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeIn.TimeOfDay)
                                                    {
                                                        objTimeKeeperCompletesInfo.LateForWork = "False";
                                                    }
                                                }
                                                else if (InOut == "Out")
                                                {
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                                    if (completeList.Count < 1)
                                                    {
                                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                                    }
                                                    if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < h.WorkingTimeOut.TimeOfDay)
                                                    {
                                                        objTimeKeeperCompletesInfo.GoEarly = "False";
                                                    }
                                                }
                                                else
                                                {
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                                    if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeIn.TimeOfDay)
                                                    {
                                                        objTimeKeeperCompletesInfo.GoEarly = "False";
                                                    }
                                                }

                                                completeList.Add(objTimeKeeperCompletesInfo);
                                                HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                                entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    });
                }
            }
            return completeList;
        }

        public List<HRTimeKeeperCompletesInfo> ConvertTimeKeeperMultiInOutToComplete2(List<HRTimeKeepersInfo> listTemp
                                                                                    , HREmployeesInfo employeesInfo
                                                                                    , List<HREmployeeOTsInfo> EmployeeOTList
                                                                                    , List<HRTimeKeepersInfo> timeKeeperList
                                                                                    , List<HRBreakTimesInfo> BreakTimeList)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;

            List<HRTimeKeeperCompletesInfo> completeList = new List<HRTimeKeeperCompletesInfo>();

            HRTimesheetEmployeeLatesController objTimesheetEmployeeLatesController = new HRTimesheetEmployeeLatesController();
            HRTimesheetEmployeeLatesInfo objTimesheetEmployeeLatesInfo = objTimesheetEmployeeLatesController.GetHRTimesheetEmployeeMaxLate(employeesInfo.FK_HREmployeePayrollFormulaID);

            if (BreakTimeList.Count > 0)
            {
                List<HRBreakTimesInfo> breakTimes = BreakTimeList.Where(o => o.FK_HREmployeePayrollFormulaID == employeesInfo.FK_HREmployeePayrollFormulaID && !string.IsNullOrEmpty(o.HRBreakTimeTimeSheetType)).ToList();
                breakTimes.ForEach(o =>
                {
                    HRBreakTimesInfo objBreakTimesInfo = new HRBreakTimesInfo();
                    //if (BreakTimeList != null)
                    //objBreakTimesInfo = BreakTimeList.Where(x => x.FK_HREmployeePayrollFormulaID == employeesInfo.FK_HREmployeePayrollFormulaID && x.HRBreakTimeTimeSheetType == "In").FirstOrDefault();
                    objBreakTimesInfo = o;

                    int leftTime = 0;
                    int BreakTimeMinRegisterOverTime = 0;
                    if (objBreakTimesInfo != null)
                    {
                        leftTime = objBreakTimesInfo.HRBreakTimeMaxOutTime;
                        BreakTimeMinRegisterOverTime = objBreakTimesInfo.HRBreakTimeMinRegisterOverTime;
                    }

                    //HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                    //objTimeKeepersInfo = (HRTimeKeepersInfo)listTemp.FirstOrDefault();

                    //completeList = AddTimeKeeperToTimeKeeperComplete(completeList, EmployeeOTList, employeesInfo, objTimeKeepersInfo, objBreakTimesInfo);
                    completeList = AddTimeKeeperToTimeKeeperComplete(completeList, EmployeeOTList, employeesInfo, listTemp, objBreakTimesInfo, objTimesheetEmployeeLatesInfo);

                    //if (BreakTimeList != null)
                    //objBreakTimesInfo = BreakTimeList.Where(x => x.FK_HREmployeePayrollFormulaID == employeesInfo.FK_HREmployeePayrollFormulaID && x.HRBreakTimeTimeSheetType == "Out").FirstOrDefault();

                    //objTimeKeepersInfo = (HRTimeKeepersInfo)listTemp.LastOrDefault();
                    //completeList = AddTimeKeeperToTimeKeeperComplete(completeList, EmployeeOTList, employeesInfo, objTimeKeepersInfo, objBreakTimesInfo);
                    //completeList = AddTimeKeeperToTimeKeeperComplete(completeList, EmployeeOTList, employeesInfo, listTemp, objBreakTimesInfo, objTimesheetEmployeeLatesInfo);

                    #region Check OT diff date and get time out type  OR Add plus if the End InOutMode = In
                    //Check OT diff date and get time out type 
                    if (completeList != null && completeList.Count > 0 && completeList.Count % 2 == 1 && o.HRBreakTimeTimeSheetType == "Out")
                    {
                        completeList[completeList.Count - 1].HRTimeKeeperCompleteInOutMode = 0;
                        if (completeList[completeList.Count - 1].HRTimeKeeperCompleteInOutMode == 0)
                        {
                            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
                            // Check OT diff date
                            if (EmployeeOTList != null)
                            {
                                objTimeKeeperCompletesInfo = GetOutModeTimeFromOverTimeList(EmployeeOTList
                                                                                , timeKeeperList
                                                                                , listTemp[0]
                                                                                , employeesInfo);
                                //objTimeKeeperCompletesInfo = GetOutModeTimeFromOverTimeList2(EmployeeOTList
                                //                                                , timeKeeperList
                                //                                                , listTemp[0]
                                //                                                , employeesInfo);

                                if (objTimeKeeperCompletesInfo != null)
                                {
                                    completeList.Add(objTimeKeeperCompletesInfo);
                                }
                                else // Không tồng tại danh sách OT
                                {
                                    objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                    //Lay ngay cham cong là ngày trước OT: listTemp[0].HRTimeKeeperDate
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = completeList[completeList.Count - 1].HRTimeKeeperCompleteDate;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = completeList[completeList.Count - 1].HRTimeKeeperCompletesEmployeeCardNo;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = completeList[completeList.Count - 1].HRTimeKeeperCompleteTimeCheck;
                                    objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                    objTimeKeeperCompletesInfo.ThName = completeList[completeList.Count - 1].ThName;
                                    objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = completeList[completeList.Count - 1].FK_HRMachineTimeKeeperID;
                                    objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                    objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = completeList[completeList.Count - 1].HRTimeKeeperCompleteDateCheck;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                    objTimeKeeperCompletesInfo.SameDateTime = "False";
                                    if (objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode == 1)
                                    {
                                    }
                                    completeList.Add(objTimeKeeperCompletesInfo);
                                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                    entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                }
                            }
                        }
                    }
                    #endregion
                });
            }

            return completeList;
        }

        public HRTimeKeeperCompletesInfo GetOutModeTimeList(HRTimeKeeperCompletesInfo timeKeepersCompleteInfo
                                                                        , HREmployeesInfo employeesInfo
                                                                        , ADWorkingShiftsInfo workingShiftInfo)
        {
            int nextMode = 0;
            string nextModeS = ManagerTimeKeeperLocalizedResources.In.ToString();
            // Check OT diff date

            nextMode = 1;
            nextModeS = ManagerTimeKeeperLocalizedResources.Out.ToString();
            //Lấy theo ngày kết thúc OT

            List<HRTimeKeepersInfo> timeKeeperListreget = new List<HRTimeKeepersInfo>();
            HRTimeKeepersController objTimeKeepersController = new HRTimeKeepersController();
            DateTime dateFrom = timeKeepersCompleteInfo.HRTimeKeeperCompleteDate.AddDays(1);
            DateTime dateTo = timeKeepersCompleteInfo.HRTimeKeeperCompleteDate.AddDays(1);
            int branchId = 0;
            int machineId = 0;
            int departmentID = 0;
            int departmentRoomID = 0;
            int departmentRoomGroupItemID = 0;
            int employeeID = employeesInfo.HREmployeeID;

            if (machineId != 0)
            {
                timeKeeperListreget = objTimeKeepersController.GetTimeKeeperByConditions(branchId, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, machineId, dateFrom, dateTo);
            }
            else
            {
                timeKeeperListreget = objTimeKeepersController.GetTimeKeeperByConditions(branchId, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, null, dateFrom, dateTo);
            }

            List<HRTimeKeepersInfo> listTempNextDate = timeKeeperListreget.Where(p => p.HRTimeKeeperEmployeeCardNo == timeKeepersCompleteInfo.HRTimeKeeperCompletesEmployeeCardNo).OrderBy(p => p.HRTimeKeeperTimeOut).ToList();

            if (listTempNextDate != null && listTempNextDate.Count >= 0)
            {
                HRTimeKeepersInfo objTimeKeepersInfo =
                    (HRTimeKeepersInfo)listTempNextDate.Where(o => o.HRTimeKeeperTimeOut.TimeOfDay <= workingShiftInfo.ADWorkingShiftTimeKeepOutTo.TimeOfDay).FirstOrDefault();

                if (objTimeKeepersInfo != null)
                {
                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                    //Lay ngay cham cong là ngày trước OT: listTemp[0].HRTimeKeeperDate
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                    objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                    objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                    objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                    objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                    objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                    objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
                    objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                    objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                    objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;
                    objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = workingShiftInfo.ADWorkingShiftID;

                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = nextMode;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = nextModeS;
                    return objTimeKeeperCompletesInfo;
                }
            }
            return null;
        }

        public string GetThName(DateTime date)
        {
            string[] thu = { "Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
            int indexThu = 0;
            indexThu = (int)date.DayOfWeek;
            return thu[indexThu];
        }

        public HRTimeKeeperCompletesInfo GetOutModeTimeFromOverTimeList(List<HREmployeeOTsInfo> EmployeeOTList
                                                                        , List<HRTimeKeepersInfo> timeKeeperList
                                                                        , HRTimeKeepersInfo timeKeepersCompleteDate
                                                                        , HREmployeesInfo employeesInfo)
        {
            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
            int nextMode = 0;
            string nextModeS = ManagerTimeKeeperLocalizedResources.In.ToString();
            // Check OT diff date
            HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == timeKeepersCompleteDate.HRTimeKeeperEmployeeCardNo
                                                                                        && x.HREmployeeOTDate.Date == timeKeepersCompleteDate.HRTimeKeeperTimeOut.Date).FirstOrDefault();
            if (objEmployeeOTDiffDateInsInfo != null)
            {
                nextMode = 1;
                nextModeS = ManagerTimeKeeperLocalizedResources.Out.ToString();
                //Lấy theo ngày kết thúc OT
                List<HRTimeKeepersInfo> listTempNextDate = timeKeeperList.Where(p => (p.HRTimeKeeperEmployeeCardNo == timeKeepersCompleteDate.HRTimeKeeperEmployeeCardNo &&
                        p.HRTimeKeeperDate.Date == objEmployeeOTDiffDateInsInfo.HREmployeeOTDateEnd.Date)).OrderBy(p => p.HRTimeKeeperTimeOut).ToList();

                if (listTempNextDate == null || listTempNextDate.Count == 0)
                {
                    List<HRTimeKeepersInfo> timeKeeperListreget = new List<HRTimeKeepersInfo>();
                    HRTimeKeepersController objTimeKeepersController = new HRTimeKeepersController();
                    DateTime dateFrom = mt100DateFrom;
                    DateTime dateTo = mt100DateTo.AddDays(2);
                    int branchId = mt100BranchID;
                    int departmentID = mt100DepartmentID;
                    int departmentRoomID = mt100DepartmentRoomID;
                    int departmentRoomGroupItemID = mt100DepartmentRoomGroupItemID;
                    int employeeID = employeesInfo.HREmployeeID;
                    timeKeeperListreget = objTimeKeepersController.GetTimeKeeperByConditions(branchId, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, null, dateFrom, dateTo);

                    listTempNextDate = timeKeeperListreget.Where(p => (p.HRTimeKeeperEmployeeCardNo == timeKeepersCompleteDate.HRTimeKeeperEmployeeCardNo &&
                        p.HRTimeKeeperDate.Date == objEmployeeOTDiffDateInsInfo.HREmployeeOTDateEnd.Date)).OrderBy(p => p.HRTimeKeeperTimeOut).ToList();
                }
                else
                {
                    objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                    //Lay ngay cham cong là ngày trước OT: listTemp[0].HRTimeKeeperDate
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = timeKeepersCompleteDate.HRTimeKeeperDate;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = listTempNextDate[0].HRTimeKeeperEmployeeCardNo;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = listTempNextDate[0].HRTimeKeeperTimeOut;
                    objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                    objTimeKeeperCompletesInfo.ThName = GetThName(listTempNextDate[0].HRTimeKeeperDate);
                    objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = listTempNextDate[0].FK_HRMachineTimeKeeperID;
                    objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                    objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = listTempNextDate[0].HRTimeKeeperTimeOut;
                    objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = listTempNextDate[0].HRTimeKeeperID;

                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = nextMode;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = nextModeS;
                    return objTimeKeeperCompletesInfo;
                }

            }
            return null;

        }

        public List<HRTimeKeeperCompletesInfo> AddTimeKeeperToTimeKeeperComplete4(List<HRTimeKeeperCompletesInfo> completeList,
                                                                                    List<HREmployeeOTsInfo> EmployeeOTList,
                                                                                    HREmployeesInfo employeesInfo,
                                                                                    List<HRTimeKeepersInfo> objTimeKeeperList,
                                                                                    ADWorkingShiftsInfo workingShiftList,
                                                                                    HREmployeeOTsInfo objEmployeeOTsInfo,
                                                                                    string type)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
            List<HRBreakTimesInfo> breakTimeList = new List<HRBreakTimesInfo>();

            //03/06/2019
            if (objEmployeeOTsInfo != null)
            {
                HRBreakTimesInfo objBreakTimesInfo3 = new HRBreakTimesInfo();
                objBreakTimesInfo3.HRBreakTimeTimeSheetType = "In";
                objBreakTimesInfo3.HRBreakTimeFromTime = objEmployeeOTsInfo.HROverTimeFromTimeIn;
                objBreakTimesInfo3.HRBreakTimeToTime = objEmployeeOTsInfo.HROverTimeFromTimeOut;
                objBreakTimesInfo3.WorkingTimeOTIn = objEmployeeOTsInfo.HROverTimeFromDate;
                objBreakTimesInfo3.IsOT = true;
                objBreakTimesInfo3.WorkingTimeIn = workingShiftList.ADWorkingShiftFromTime;
                objBreakTimesInfo3.WorkingTimeOut = workingShiftList.ADWorkingShiftToTime;
                objBreakTimesInfo3.NghiTruaTimeFrom = workingShiftList.ADWorkingShiftBreakTimeBetweenFrom;
                objBreakTimesInfo3.NghiTruaTimeTo = workingShiftList.ADWorkingShiftBreakTimeBetweenTo;

                HRBreakTimesInfo objBreakTimesInfo4 = new HRBreakTimesInfo();
                objBreakTimesInfo4.HRBreakTimeTimeSheetType = "Out";
                objBreakTimesInfo4.HRBreakTimeFromTime = objEmployeeOTsInfo.HROverTimeToTimeIn;
                objBreakTimesInfo4.HRBreakTimeToTime = objEmployeeOTsInfo.HROverTimeToTimeOut;
                objBreakTimesInfo4.WorkingTimeOTOut = objEmployeeOTsInfo.HROverTimeToDate;
                objBreakTimesInfo4.IsOT = true;
                objBreakTimesInfo4.WorkingTimeIn = workingShiftList.ADWorkingShiftFromTime;
                objBreakTimesInfo4.WorkingTimeOut = workingShiftList.ADWorkingShiftToTime;
                objBreakTimesInfo4.NghiTruaTimeFrom = workingShiftList.ADWorkingShiftBreakTimeBetweenFrom;
                objBreakTimesInfo4.NghiTruaTimeTo = workingShiftList.ADWorkingShiftBreakTimeBetweenTo;

                if (objBreakTimesInfo3.WorkingTimeOTIn.TimeOfDay < workingShiftList.ADWorkingShiftFromTime.TimeOfDay
                    && objBreakTimesInfo4.WorkingTimeOTOut.TimeOfDay <= workingShiftList.ADWorkingShiftFromTime.TimeOfDay)
                {
                    objBreakTimesInfo3.OTType = "First";
                    objBreakTimesInfo4.OTType = "First";
                }
                else if (objBreakTimesInfo3.WorkingTimeOTIn.TimeOfDay >= workingShiftList.ADWorkingShiftToTime.TimeOfDay
                    && objBreakTimesInfo4.WorkingTimeOTOut.TimeOfDay > workingShiftList.ADWorkingShiftToTime.TimeOfDay)
                {
                    objBreakTimesInfo3.OTType = "Last";
                    objBreakTimesInfo4.OTType = "Last";
                }
                else if (objBreakTimesInfo3.WorkingTimeOTIn.TimeOfDay <= workingShiftList.ADWorkingShiftBreakTimeBetweenFrom.TimeOfDay
                    && objBreakTimesInfo4.WorkingTimeOTOut.TimeOfDay <= workingShiftList.ADWorkingShiftBreakTimeBetweenTo.TimeOfDay)
                {
                    objBreakTimesInfo3.OTType = "Mid";
                    objBreakTimesInfo4.OTType = "Mid";
                }

                breakTimeList.Add(objBreakTimesInfo3);
                breakTimeList.Add(objBreakTimesInfo4);
            }

            if (breakTimeList != null && breakTimeList.Count > 0)
            {
                breakTimeList.ForEach(h =>
                {
                    int leftTime = 0;
                    int BreakTimeMinRegisterOverTime = 0;
                    DateTime timeIn = DateTime.MinValue;
                    DateTime timeOut = DateTime.MaxValue;
                    String InOut = string.Empty;
                    timeIn = h.HRBreakTimeFromTime;
                    timeOut = h.HRBreakTimeToTime;
                    InOut = h.HRBreakTimeTimeSheetType;
                    //if (type == EmployeePayrollFormulaHandleTypeCombo.FirstLast.ToString())
                    {
                        HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                        if (InOut == "In")
                        {
                            objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.Where(o => (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
                                                                                             && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)).FirstOrDefault();
                            if (objTimeKeepersInfo == null)
                            {
                                objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.FirstOrDefault();
                                if (objTimeKeepersInfo != null)
                                {
                                    if (h.OTType == "Mid")
                                    {
                                        //if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < h.NghiTruaTimeFrom.TimeOfDay)
                                        {
                                            objTimeKeepersInfo.HRTimeKeeperDate = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.NghiTruaTimeFrom.TimeOfDay.Hours, h.NghiTruaTimeFrom.TimeOfDay.Minutes, h.NghiTruaTimeFrom.TimeOfDay.Seconds);
                                            objTimeKeepersInfo.HRTimeKeeperTimeOut =
                                                new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.NghiTruaTimeFrom.TimeOfDay.Hours, h.NghiTruaTimeFrom.TimeOfDay.Minutes, h.NghiTruaTimeFrom.TimeOfDay.Seconds);
                                        }
                                    }
                                    else if (h.OTType == "Last")
                                    {
                                        //if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < h.WorkingTimeOut.TimeOfDay)
                                        {
                                            objTimeKeepersInfo.HRTimeKeeperDate = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.WorkingTimeOut.TimeOfDay.Hours, h.WorkingTimeOut.TimeOfDay.Minutes, h.WorkingTimeOut.TimeOfDay.Seconds);
                                            objTimeKeepersInfo.HRTimeKeeperTimeOut = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.WorkingTimeOut.TimeOfDay.Hours, h.WorkingTimeOut.TimeOfDay.Minutes, h.WorkingTimeOut.TimeOfDay.Seconds);
                                        }
                                    }
                                }
                            }
                        }
                        else if (InOut == "Out")
                        {
                            objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.Where(o => (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
                                                                                            && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)).LastOrDefault();

                            if (objTimeKeepersInfo == null)
                            {
                                objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.LastOrDefault();
                                if (objTimeKeepersInfo != null)
                                {
                                    if (h.OTType == "Mid")
                                    {
                                        //if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.NghiTruaTimeTo.TimeOfDay)
                                        {
                                            objTimeKeepersInfo.HRTimeKeeperDate = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.NghiTruaTimeTo.TimeOfDay.Hours, h.NghiTruaTimeTo.TimeOfDay.Minutes, h.NghiTruaTimeTo.TimeOfDay.Seconds);
                                            objTimeKeepersInfo.HRTimeKeeperTimeOut = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.NghiTruaTimeTo.TimeOfDay.Hours, h.NghiTruaTimeTo.TimeOfDay.Minutes, h.NghiTruaTimeTo.TimeOfDay.Seconds);
                                        }
                                    }
                                    else if (h.OTType == "First")
                                    {
                                        //if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeIn.TimeOfDay)
                                        {
                                            objTimeKeepersInfo.HRTimeKeeperDate = objTimeKeepersInfo.HRTimeKeeperTimeOut = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.WorkingTimeIn.TimeOfDay.Hours, h.WorkingTimeIn.TimeOfDay.Minutes, h.WorkingTimeIn.TimeOfDay.Seconds);
                                            objTimeKeepersInfo.HRTimeKeeperTimeOut = objTimeKeepersInfo.HRTimeKeeperTimeOut = new DateTime(objTimeKeepersInfo.HRTimeKeeperTimeOut.Year, objTimeKeepersInfo.HRTimeKeeperTimeOut.Month, objTimeKeepersInfo.HRTimeKeeperTimeOut.Day,
                                                    h.WorkingTimeIn.TimeOfDay.Hours, h.WorkingTimeIn.TimeOfDay.Minutes, h.WorkingTimeIn.TimeOfDay.Seconds);
                                        }
                                    }
                                }
                            }
                        }

                        if (objTimeKeepersInfo != null && objTimeKeepersInfo.HRTimeKeeperDate < DateTime.MaxValue)
                        {
                            List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck = completeList.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay == objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
                            if (objTimeKeeperCheck == null || objTimeKeeperCheck.Count == 0)
                            {

                                #region Check OT diff date and clear time Out
                                // Check OT diff date
                                HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
                                                                                                            && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
                                                                                                            && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

                                #endregion

                                if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
                                {
                                    objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                    objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                                    objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                                    objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                                    objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                                    objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                                    objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
                                    objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                                    objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                                    objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;
                                    if (workingShiftList != null)
                                    {
                                        objTimeKeeperCompletesInfo.FK_ADWorkingShiftID = workingShiftList.ADWorkingShiftID;
                                    }

                                    objTimeKeeperCompletesInfo.FK_HROverTimeID = objEmployeeOTsInfo.FK_HROverTimeID;

                                    if (InOut == "In")
                                    {
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                        if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeOTIn.TimeOfDay)
                                        {
                                            objTimeKeeperCompletesInfo.LateForWork = "False";
                                        }
                                    }
                                    else if (InOut == "Out")
                                    {
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                        if (completeList.Count < 1)
                                        {
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                        }
                                        if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay < h.WorkingTimeOTOut.TimeOfDay)
                                        {
                                            objTimeKeeperCompletesInfo.GoEarly = "False";
                                        }
                                    }
                                    else
                                    {
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                        objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                        if (objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay > h.WorkingTimeOTIn.TimeOfDay)
                                        {
                                            objTimeKeeperCompletesInfo.LateForWork = "False";
                                        }
                                    }
                                    completeList.Add(objTimeKeeperCompletesInfo);
                                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                                    entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                                }
                            }
                        }
                    }
                });
            }
            return completeList;
        }

        public List<HRTimeKeeperCompletesInfo> AddTimeKeeperToTimeKeeperComplete(List<HRTimeKeeperCompletesInfo> completeList,
                                                                                    List<HREmployeeOTsInfo> EmployeeOTList,
                                                                                    HREmployeesInfo employeesInfo,
                                                                                    List<HRTimeKeepersInfo> objTimeKeeperList,
                                                                                    HRBreakTimesInfo objBreakTimesInfo,
                                                                                    HRTimesheetEmployeeLatesInfo objTimesheetEmployeeLatesInfo)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo;
            int leftTime = 0;
            int BreakTimeMinRegisterOverTime = 0;
            DateTime timeIn = DateTime.MinValue;
            DateTime timeOut = DateTime.MaxValue;
            String InOut = string.Empty;
            if (objBreakTimesInfo != null)
            {
                leftTime = objBreakTimesInfo.HRBreakTimeMaxOutTime;
                BreakTimeMinRegisterOverTime = objBreakTimesInfo.HRBreakTimeMinRegisterOverTime;
                timeIn = objBreakTimesInfo.HRBreakTimeFromTime;
                timeOut = objBreakTimesInfo.HRBreakTimeToTime;
                InOut = objBreakTimesInfo.HRBreakTimeTimeSheetType;
            }

            int timeLate = 0;
            //if (objTimesheetEmployeeLatesInfo != null)
            //{
            //    timeLate = objTimesheetEmployeeLatesInfo.HRTimesheetEmployeeLateTimeTo;
            //}

            //24-05-2019
            //HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
            //if (InOut == "In")
            //{
            //    objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.Where(o => (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
            //                                                                     && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)
            //                                                                     || (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
            //                                                                     && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.AddMinutes(timeLate).TimeOfDay)).FirstOrDefault();
            //}
            //else if (InOut == "Out")
            //{
            //    objTimeKeepersInfo = (HRTimeKeepersInfo)objTimeKeeperList.Where(o => (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
            //                                                                    && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)
            //                                                                    || (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay
            //                                                                    && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.AddMinutes(timeLate).TimeOfDay)).LastOrDefault();
            //}

            //if (objTimeKeepersInfo != null && objTimeKeepersInfo.HRTimeKeeperDate < DateTime.MaxValue)
            //{
            //    List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck = completeList.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
            //    if (objTimeKeeperCheck == null || objTimeKeeperCheck.Count == 0)
            //    {

            //        #region Check OT diff date and clear time Out
            //        // Check OT diff date
            //        HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
            //                                                                                    && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
            //                                                                                    && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

            //        #endregion

            //        if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
            //        {
            //            objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
            //            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
            //            objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
            //            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
            //            objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
            //            objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
            //            objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
            //            objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
            //            objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
            //            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
            //            objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
            //            objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
            //            objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
            //            objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;

            //            if (InOut == "In")
            //            {
            //                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
            //                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
            //            }
            //            else if (InOut == "Out")
            //            {
            //                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
            //                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
            //                if (completeList.Count < 1)
            //                {
            //                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
            //                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
            //                }
            //            }
            //            else
            //            {
            //                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
            //                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
            //            }

            //            objTimeKeeperCompletesInfo.NotInWorkingShift = "False";

            //            //Kiểm tra Ko DK tăng ca
            //            //if (objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode == 1)
            //            //{
            //            //    if (CheckNotInOverTime(objTimeKeeperCompletesInfo, BreakTimeMinRegisterOverTime, false))
            //            //    {
            //            //        objTimeKeeperCompletesInfo.NotInOverTime = "False";
            //            //    }
            //            //    if (CheckOverTimeAbsence(objTimeKeeperCompletesInfo, BreakTimeMinRegisterOverTime, false))
            //            //    {
            //            //        objTimeKeeperCompletesInfo.OverTimeAbsence = "False";
            //            //    }
            //            //}
            //            completeList.Add(objTimeKeeperCompletesInfo);
            //            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
            //            entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
            //        }
            //    }
            //}
            objTimeKeeperList.ForEach(o =>
            {
                HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                if (InOut == "In")
                {
                    if ((o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)
                        || (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.AddMinutes(timeLate).TimeOfDay))
                    {
                        objTimeKeepersInfo = o;
                    }
                }
                else if (InOut == "Out")
                {
                    if ((o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.TimeOfDay)
                        || (o.HRTimeKeeperTimeOut.TimeOfDay >= timeIn.TimeOfDay && o.HRTimeKeeperTimeOut.TimeOfDay <= timeOut.AddMinutes(timeLate).TimeOfDay))
                    {
                        objTimeKeepersInfo = o;
                    }
                }

                if (objTimeKeepersInfo != null && objTimeKeepersInfo.HRTimeKeeperDate < DateTime.MaxValue)
                {
                    List<HRTimeKeeperCompletesInfo> objTimeKeeperCheck = completeList.Where(x => x.HRTimeKeeperCompleteDateCheck.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).ToList();
                    if (objTimeKeeperCheck == null || objTimeKeeperCheck.Count == 0)
                    {

                        #region Check OT diff date and clear time Out
                        // Check OT diff date
                        HREmployeeOTsInfo objEmployeeOTDiffDateInsInfo = EmployeeOTList.Where(x => x.HREmployeeCardNumber == objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo
                                                                                                    && x.HREmployeeOTToDate.Date == objTimeKeepersInfo.HRTimeKeeperTimeOut.Date
                                                                                                    && x.HREmployeeOTToDate.AddMinutes(leftTime).TimeOfDay >= objTimeKeepersInfo.HRTimeKeeperTimeOut.TimeOfDay).FirstOrDefault();

                        #endregion

                        if (objEmployeeOTDiffDateInsInfo == null || objEmployeeOTDiffDateInsInfo.HREmployeeOTID == 0)
                        {
                            objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDate = objTimeKeepersInfo.HRTimeKeeperDate;
                            objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo;
                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                            objTimeKeeperCompletesInfo.EmployeeName = employeesInfo.HREmployeeName;
                            objTimeKeeperCompletesInfo.ThName = GetThName(objTimeKeepersInfo.HRTimeKeeperDate);
                            objTimeKeeperCompletesInfo.FK_HRMachineTimeKeeperID = objTimeKeepersInfo.FK_HRMachineTimeKeeperID;
                            objTimeKeeperCompletesInfo.FK_HRDepartmentID = employeesInfo.FK_HRDepartmentID;
                            objTimeKeeperCompletesInfo.FK_HRLevelID = employeesInfo.FK_HRLevelID;
                            objTimeKeeperCompletesInfo.HRTimeKeeperCompleteDateCheck = objTimeKeepersInfo.HRTimeKeeperTimeOut;
                            objTimeKeeperCompletesInfo.FK_HRTimeKeeperID = objTimeKeepersInfo.HRTimeKeeperID;
                            objTimeKeeperCompletesInfo.HRDepartmentRoomName = objTimeKeepersInfo.HRDepartmentRoomName;
                            objTimeKeeperCompletesInfo.HRDepartmentRoomGroupItemName = objTimeKeepersInfo.HRDepartmentRoomGroupItemName;
                            objTimeKeeperCompletesInfo.HREmployeePayrollFormulaName = objTimeKeepersInfo.HREmployeePayrollFormulaName;

                            if (InOut == "In")
                            {
                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                            }
                            else if (InOut == "Out")
                            {
                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 1;
                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.Out.ToString();
                                if (completeList.Count < 1)
                                {
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                                }
                            }
                            else
                            {
                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutMode = 0;
                                objTimeKeeperCompletesInfo.HRTimeKeeperCompleteInOutModeName = ManagerTimeKeeperLocalizedResources.In.ToString();
                            }

                            objTimeKeeperCompletesInfo.NotInWorkingShift = "False";
                            completeList.Add(objTimeKeeperCompletesInfo);
                            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo2 = (HRTimeKeeperCompletesInfo)objTimeKeeperCompletesInfo.Clone();
                            entity.TimeKeeperCompleteBackupList.Add(objTimeKeeperCompletesInfo2);
                        }
                    }
                }
            });
            return completeList;
        }

        public void SaveDataComplete()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            List<HRTimeKeeperCompletesInfo> timeKeeperCompleteList = entity.TimeKeeperCompletesList.ToList();
            HRTimeKeeperCompletesController objTimeKeepersController = new HRTimeKeeperCompletesController();
            List<string> list = new List<string>();
            string str;
            HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
            if (timeKeeperCompleteList != null)
            {
                objTimeKeeperCompletesInfo = timeKeeperCompleteList.Where(x => x.HRTimeKeeperCompleteDateCheck.Hour == 0 && x.HRTimeKeeperCompleteDateCheck.Minute == 0).FirstOrDefault();
            }
            List<HRTimeKeeperCompletesInfo> timeKeeperList2 = new List<HRTimeKeeperCompletesInfo>();
            if (objTimeKeeperCompletesInfo != null && objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo != string.Empty)
            {
                if (MessageBox.Show("Giờ vào/ra đang chứa giá trị 00:00", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            DateTime dateFrom = mt100DateFrom;
            DateTime dateTo = mt100DateTo;
            bool isCancel = false;
            List<HRTimeKeeperCompletesInfo> listDataComplete = entity.TimeKeeperCompletesList.ToList();
            if (listDataComplete != null)
            {
                foreach (HRTimeKeeperCompletesInfo item in timeKeeperCompleteList)
                {
                    bool isSameData = CheckSameTime(item, listDataComplete);
                    if (isSameData)
                    {
                        if (isCancel)
                            continue;
                        DialogResult dlgResult = MessageBox.Show(item.EmployeeName + "-" + item.HRTimeKeeperCompleteDate +
                                           Environment.NewLine + ": Giờ vào/ra trùng nhau, bạn có muốn tiếp tục không?"
                                           + Environment.NewLine + "Cancel: Lưu và không kiểm tra."
                                           + Environment.NewLine + "Yes: Lưu và kiểm tra"
                                           + Environment.NewLine + "No: không lưu và Thoát."
                                           , "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                        {
                            return;
                        }
                        else if (dlgResult == DialogResult.Cancel)
                        {
                            isCancel = true;
                        }
                    }

                    if (!CheckDataComplete(timeKeeperList2, item.FK_HRMachineTimeKeeperID, item.HRTimeKeeperCompleteDate, item.HRTimeKeeperCompletesEmployeeCardNo))
                    {
                        timeKeeperList2.Add(item);
                    }
                }
            }

            //foreach (HRTimeKeeperCompletesInfo item in timeKeeperList2)
            //{
            //    int check = objTimeKeepersController.CheckExistData(item.FK_HRMachineTimeKeeperID, item.HRTimeKeeperCompleteDateCheck, item.HRTimeKeeperCompletesEmployeeCardNo);
            //    if (check > 0)
            //    {
            //        objTimeKeepersController.DeleteData(item.FK_HRMachineTimeKeeperID, item.HRTimeKeeperCompleteDateCheck, item.HRTimeKeeperCompletesEmployeeCardNo);
            //    }
            //}
            entity.TimeKeeperCompletesList.Select(o1 => o1.HRTimeKeeperCompletesEmployeeCardNo)
                                          .Distinct()
                                          .ToList()
                                          .ForEach(o1 =>
                                          {
                                              objTimeKeepersController.DeleteAllByDate(o1, dateFrom, dateTo);
                                          });
            if (timeKeeperCompleteList != null)
            {
                timeKeeperCompleteList = CheckOTTimeKeeper(timeKeeperCompleteList);
                entity.SaveDataComplete(timeKeeperCompleteList);
                MessageBox.Show("SaveSuccess", "Lưu dữ liệu vào hệ thống");
            }
        }

        private bool CheckDataComplete(List<HRTimeKeeperCompletesInfo> timeKeeperCompleteList, int machine, DateTime date, string employeeCardNo)
        {
            foreach (HRTimeKeeperCompletesInfo item in timeKeeperCompleteList)
            {
                if (item.FK_HRMachineTimeKeeperID == machine && item.HRTimeKeeperCompleteDate.Date == date.Date && item.HRTimeKeeperCompletesEmployeeCardNo == employeeCardNo)
                    return true;
            }
            return false;
        }

        public List<HRTimeKeeperCompletesInfo> CheckOTTimeKeeper(List<HRTimeKeeperCompletesInfo> timeKeeperCompleteList)
        {
            if (TimeKeeperCompletesClone != null && TimeKeeperCompletesClone.Count > 0)
            {
                TimeKeeperCompletesClone.ForEach(o =>
                {
                    timeKeeperCompleteList.Add(o);
                });
            }
            return timeKeeperCompleteList;
        }

        #region MT101
        public void GetDataCompleted(int branchId, int departmentID, int departmentRoomID, int departmentRoomGroupItemID, int employeeID, DateTime dateFrom, DateTime dateTo)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HRTimeKeeperCompletesController objTimeKeeperCompletesController = new HRTimeKeeperCompletesController();
            List<HRTimeKeeperCompletesInfo> listDataComplete = new List<HRTimeKeeperCompletesInfo>();
            List<HRTimeKeeperCompletesInfo> listDataCompleteDate = new List<HRTimeKeeperCompletesInfo>();
            List<HRTimeKeeperCompletesInfo> listDataCompleteLN = new List<HRTimeKeeperCompletesInfo>();

            listDataComplete = objTimeKeeperCompletesController.GetDataCompleteByConditions(departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, null, dateFrom, dateTo);
            foreach (HRTimeKeeperCompletesInfo item in listDataComplete)
            {
                item.ThName = GetThName(item.HRTimeKeeperCompleteTimeCheck);
            }

            listDataCompleteDate = objTimeKeeperCompletesController.GetDataCompleteByConditionDates(departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, null, dateFrom, dateTo);
            listDataCompleteLN = objTimeKeeperCompletesController.GetDataCompleteByConditionLNs(departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, null, dateFrom, dateTo);
            //HRTimeKeeperCompletesView.DataSource = listDataComplete;
            listDataCompleteDate.ForEach(o =>
            {
                o.ThName = GetThName(o.HRTimeKeeperCompleteTimeCheck);
            });
            entity.TimeKeeperCompleteListView.Invalidate(listDataCompleteDate);
            entity.TimeKeeperCompleteListView.GridControl.RefreshDataSource();
            GridView view = (GridView)entity.TimeKeeperCompleteListView.GridControl.MainView;
            view.ExpandAllGroups();

            listDataCompleteLN.ForEach(o =>
            {
                o.ThName = GetThName(o.HRTimeKeeperCompleteTimeCheck);
            });
            entity.TimeKeeperCompleteListView2.Invalidate(listDataCompleteLN);
            entity.TimeKeeperCompleteListView2.GridControl.RefreshDataSource();
            GridView view2 = (GridView)entity.TimeKeeperCompleteListView2.GridControl.MainView;
            view2.ExpandAllGroups();
        }

        public void SaveDataCompletedView()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            entity.SaveTimeKeeperCompleteListView();
        }
        #endregion

        #region MT103
        public void ChangeSelectedMachine(int row)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            if (row > 0)
            {
                CurenMachineTimeKeeper = entity.MachineTimeKeepersList[row];
            }
            else
            {
                CurenMachineTimeKeeper = entity.MachineTimeKeepersList.FirstOrDefault();
            }
        }

        public void DownloadAndShowData(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
                int index = entity.MachineTimeKeepersList.CurrentIndex;
                List<HRTimeKeepersInfo> timeKeeperList = DownloadData(index, dateFrom, dateTo);
                VinaProgressBar.Start("Đã lấy dữ liệu máy chấm công thành công! Đang gán công cho nhân viên...");
                foreach (HRTimeKeepersInfo item in timeKeeperList)
                {
                    item.ThName = GetThName(item.HRTimeKeeperDate);
                }
                entity.TimeKeepersList.Invalidate(timeKeeperList);
                SaveData(timeKeeperList, false, dateFrom, dateTo);

                VinaProgressBar.Close();
                MessageBox.Show("SaveSuccess", "Lưu dữ liệu vào hệ thống");
            }
            catch (Exception e)
            {
                DisConnectAll();
            }
        }

        public List<HRTimeKeepersInfo> DownloadData(int typeIndex,DateTime dateFrom, DateTime dateTo)
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            List<HRTimeKeepersInfo> timeKeeperList = new List<HRTimeKeepersInfo>();
            if (typeIndex == 0)
            {
                List<HRMachineTimeKeepersInfo> list = entity.MachineTimeKeepersList.ToList();
                if (list != null)
                {
                    list = list.Where(o => o.AASelected == true).ToList();
                    List<HRTimeKeepersInfo> listTimekeeperClone = new List<HRTimeKeepersInfo>();
                    list.ForEach(o =>
                    {
                        o = Connect(o);
                        VinaProgressBar.Start("Đã kết nối...");
                        listTimekeeperClone = GetGeneralLogData(o.HRMachineTimeKeeperID, o.CZKEMMachine, true, dateFrom, dateTo);
                        if (listTimekeeperClone != null && listTimekeeperClone.Count > 0)
                        {
                            timeKeeperList.AddRange(listTimekeeperClone);
                        }

                        if (CurenMachineTimeKeeper.CZKEMMachine != null)
                            CurenMachineTimeKeeper.CZKEMMachine.Disconnect();
                    });
                }
            }
            else
            {
                HRMachineTimeKeepersController objHRMachineTimeKeepersController = new HRMachineTimeKeepersController();
                List<HRMachineTimeKeepersInfo> list = objHRMachineTimeKeepersController.GetAllObjectList();
                List<HRTimeKeepersInfo> currentTimeKeeperList = new List<HRTimeKeepersInfo>();
                HRMachineTimeKeepersInfo objMachineTimeKeepersInfo;
                foreach (HRMachineTimeKeepersInfo item in list)
                {
                    objMachineTimeKeepersInfo = (HRMachineTimeKeepersInfo)item.Clone();
                    objMachineTimeKeepersInfo = Connect(objMachineTimeKeepersInfo);
                    currentTimeKeeperList = GetGeneralLogData(objMachineTimeKeepersInfo.HRMachineTimeKeeperID, objMachineTimeKeepersInfo.CZKEMMachine, true, dateFrom, dateTo);
                    DisConnect(item);
                    timeKeeperList.AddRange(currentTimeKeeperList);
                }

            }
            //objMachineTimeKeepersInfo = DisConnect(objMachineTimeKeepersInfo);
            return timeKeeperList;
        }
        public HRMachineTimeKeepersInfo Connect(HRMachineTimeKeepersInfo objMachineTimeKeepersInfo)
        {
            objMachineTimeKeepersInfo.CZKEMMachine = new CZKEMClass();
            objMachineTimeKeepersInfo.HRMachineTimeKeeperIsConnected = objMachineTimeKeepersInfo.CZKEMMachine.Connect_Net(objMachineTimeKeepersInfo.HRMachineTimeKeeperIP, Convert.ToInt32(objMachineTimeKeepersInfo.HRMachineTimeKeeperPortID));
            return objMachineTimeKeepersInfo;
        }

        public List<HRTimeKeepersInfo> GetGeneralLogData(int machineTimeKeeperID, CZKEMClass machine, bool FilterByDay, DateTime FromDate, DateTime ToDate)
        {
            List<HRTimeKeepersInfo> timeKeeperList = new List<HRTimeKeepersInfo>();
            HRTimeKeepersInfo objTimeKeeper;
            string str = "";
            int dwVerifyMode = 0;
            int dwInOutMode = 0;
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            int dwWorkCode = 0;
            int num14 = 0;
            int dwEMachineNumber = 0;
            int dwTMachineNumber = 0;
            int dwEnrollNumber = 0;

            DateTime time;
            DateTime time2;
            HRBreakTimesController objBreakTimeController = new HRBreakTimesController();
            List<HRBreakTimesInfo> breakTime = (List<HRBreakTimesInfo>)objBreakTimeController.GetListFromDataSet(objBreakTimeController.GetAllObjects());
            List<HRBreakTimesInfo> breakTimeList = breakTime.Where(o => o.HRBreakTimeType == "OutSiesta" || o.HRBreakTimeTimeSheetType == "Out").ToList();
            if (!machine.IsTFTMachine(machineTimeKeeperID))
            {
                VinaProgressBar.Start("Not TFT machine read...");
                machine.EnableDevice(machineTimeKeeperID, false);
                VinaProgressBar.Start("EnableDevice Not TFT machine...");
                try
                {
                    if (machine.ReadAllGLogData(machineTimeKeeperID) == true)
                    {
                        VinaProgressBar.Start("Đang đọc...");
                        while (machine.GetGeneralLogData(machineTimeKeeperID, ref dwTMachineNumber, ref dwEnrollNumber, ref dwEMachineNumber, ref dwVerifyMode, ref dwInOutMode, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute))
                        {
                            num14++;
                            try
                            {
                                time = Convert.ToDateTime(string.Concat(new object[] { dwYear, "/", dwMonth, "/", dwDay }));
                                time2 = Convert.ToDateTime(string.Concat(new object[] { dwYear, "/", dwMonth, "/", dwDay, " ", dwHour, ":", dwMinute }));
                                str = dwEnrollNumber.ToString();
                                if (FilterByDay)
                                {
                                    if ((time >= FromDate.Date) && (time <= ToDate.Date))
                                    {
                                        objTimeKeeper = new HRTimeKeepersInfo(str, time, time2, dwInOutMode, machineTimeKeeperID);
                                        timeKeeperList.Add(objTimeKeeper);
                                    }
                                }
                            }
                            catch (Exception xe)
                            {
                                MessageBox.Show(xe.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception xe)
                {
                    MessageBox.Show(xe.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                VinaProgressBar.Start("Release Device Not TFT machine...");
            }
            else
            {
                VinaProgressBar.Start("TFT machine read...");
                machine.EnableDevice(machineTimeKeeperID, false);
                VinaProgressBar.Start("EnableDevice TFT...");
                if (machine.ReadAllGLogData(machineTimeKeeperID) == true)
                {
                    VinaProgressBar.Start("Đang đọc...");
                    while (machine.SSR_GetGeneralLogData(machineTimeKeeperID, out str, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))
                    {
                        num14++;
                        time = Convert.ToDateTime(string.Concat(new object[] { dwYear, "/", dwMonth, "/", dwDay }));
                        time2 = Convert.ToDateTime(string.Concat(new object[] { dwYear, "/", dwMonth, "/", dwDay, " ", dwHour, ":", dwMinute }));
                        if (FilterByDay)
                        {
                            if ((time >= FromDate.Date) && (time <= ToDate.Date))
                            {
                                if (CheckInOutBreakTime(time2, breakTimeList, str))
                                    dwInOutMode = 1;
                                else
                                    dwInOutMode = 0;
                                objTimeKeeper = new HRTimeKeepersInfo(str, time, time2, dwInOutMode, machineTimeKeeperID);
                                timeKeeperList.Add(objTimeKeeper);
                            }
                        }
                    }
                }
                VinaProgressBar.Start("Out While...");
            }
            return timeKeeperList;
        }

        public void DisConnectAll()
        {
            HRMachineTimeKeepersController objHRMachineTimeKeepersController = new HRMachineTimeKeepersController();
            List<HRMachineTimeKeepersInfo> list = objHRMachineTimeKeepersController.GetAllObjectList();
            foreach (HRMachineTimeKeepersInfo objMachineTimeKeepersInfo in list)
            {
                DisConnect(objMachineTimeKeepersInfo);
            }
        }

        public HRMachineTimeKeepersInfo DisConnect(HRMachineTimeKeepersInfo objMachineTimeKeepersInfo)
        {
            if (objMachineTimeKeepersInfo.HRMachineTimeKeeperIsConnected)
            {
                if (objMachineTimeKeepersInfo.CZKEMMachine != null)
                    objMachineTimeKeepersInfo.CZKEMMachine.Disconnect();
            }
            objMachineTimeKeepersInfo.HRMachineTimeKeeperIsConnected = false;
            return objMachineTimeKeepersInfo;
        }

        public void SaveData(List<HRTimeKeepersInfo> timeKeeperList, bool import, DateTime dateFrom, DateTime dateTo)
        {
            VinaProgressBar.Start("Đang lưu dữ liệu...");
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            HRTimeKeepersController objTimeKeepersController = new HRTimeKeepersController();
            int index = entity.MachineTimeKeepersList.CurrentIndex;
            List<HRTimeKeepersInfo> timeKeepersListCheck = new List<HRTimeKeepersInfo>();
            HRTimeKeepersInfo objTimeKeepersInfoCheck = new HRTimeKeepersInfo();

            if (!import)
            {
                if (index == 0)
                {
                    List<HRMachineTimeKeepersInfo> list = entity.MachineTimeKeepersList.ToList();
                    if (list != null)
                    {
                        list = list.Where(o => o.AASelected == true).ToList();
                        foreach (HRMachineTimeKeepersInfo item in list)
                        {
                            timeKeepersListCheck = (List<HRTimeKeepersInfo>)objTimeKeepersController.GetTimeKeeperByMachineAndDate(item.HRMachineTimeKeeperID, dateFrom.Date, dateTo.Date);
                            timeKeepersListCheck.ForEach(o =>
                            {
                                timeKeeperList.RemoveAll(x => x.FK_HRMachineTimeKeeperID == o.FK_HRMachineTimeKeeperID
                                                        && x.HRTimeKeeperDate.Date == o.HRTimeKeeperDate.Date
                                                        && x.HRTimeKeeperEmployeeCardNo.Trim() == o.HRTimeKeeperEmployeeCardNo.Trim()
                                                        && x.HRTimeKeeperTimeOut == o.HRTimeKeeperTimeOut);
                            });
                        }
                    }
                }
                else
                {
                    HRMachineTimeKeepersController objHRMachineTimeKeepersController = new HRMachineTimeKeepersController();
                    List<HRMachineTimeKeepersInfo> list = objHRMachineTimeKeepersController.GetAllObjectList();
                    List<HRTimeKeepersInfo> currentTimeKeeperList = new List<HRTimeKeepersInfo>();
                    foreach (HRMachineTimeKeepersInfo item in list)
                    {
                        timeKeepersListCheck = (List<HRTimeKeepersInfo>)objTimeKeepersController.GetTimeKeeperByMachineAndDate(item.HRMachineTimeKeeperID, dateFrom.Date, dateTo.Date);
                        timeKeepersListCheck.ForEach(o =>
                        {
                            timeKeeperList.RemoveAll(x => x.FK_HRMachineTimeKeeperID == o.FK_HRMachineTimeKeeperID
                                                        && x.HRTimeKeeperDate.Date == o.HRTimeKeeperDate.Date
                                                        && x.HRTimeKeeperEmployeeCardNo.Trim() == o.HRTimeKeeperEmployeeCardNo.Trim()
                                                        && x.HRTimeKeeperTimeOut == o.HRTimeKeeperTimeOut);
                        });
                    }
                }
            }
            else
            {
                List<HRTimeKeepersInfo> timeKeeperList2 = new List<HRTimeKeepersInfo>();
                foreach (HRTimeKeepersInfo item in timeKeeperList)
                {
                    if (!Check(timeKeeperList2, item.FK_HRMachineTimeKeeperID, item.HRTimeKeeperDate))
                    {
                        timeKeeperList2.Add(item);
                    }
                }
                foreach (HRTimeKeepersInfo item in timeKeeperList2)
                {
                    objTimeKeepersController = new HRTimeKeepersController();
                    int check = objTimeKeepersController.CheckExistData(item.FK_HRMachineTimeKeeperID, item.HRTimeKeeperDate);
                    if (check > 0)
                    {
                        objTimeKeepersController.DeleteData(item.FK_HRMachineTimeKeeperID, item.HRTimeKeeperDate);
                    }
                }
            }
            entity.SaveData(timeKeeperList);
        }

        public bool CheckInOutBreakTime(DateTime time, List<HRBreakTimesInfo> breakTimeList, string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                HREmployeesController objEmployeesController = new HREmployeesController();
                HREmployeesInfo objEmployeesInfo = objEmployeesController.GetEmployeeByCardNumber(str);
                if (objEmployeesInfo != null && breakTimeList.Count > 0)
                {
                    List<HRBreakTimesInfo> breakTimeList2 = breakTimeList.Where(o => o.FK_HREmployeePayrollFormulaID == objEmployeesInfo.FK_HREmployeePayrollFormulaID).ToList();
                    foreach (HRBreakTimesInfo item in breakTimeList)
                    {
                        if (time.TimeOfDay >= item.HRBreakTimeFromTime.TimeOfDay && time.TimeOfDay <= item.HRBreakTimeToTime.TimeOfDay)
                        {
                            return true;
                            break;
                        }
                    }
                }
            }
            return false;
        }

        private bool Check(List<HRTimeKeepersInfo> timeKeeperList, int machine, DateTime date)
        {
            foreach (HRTimeKeepersInfo item in timeKeeperList)
            {
                if (item.FK_HRMachineTimeKeeperID == machine && item.HRTimeKeeperDate.Date == date.Date)
                    return true;
            }
            return false;
        }

        public void ActionQuickImportTimeSheet()
        {
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)CurrentModuleEntity;
            guiQuickImportTimeSheet guiFind = new guiQuickImportTimeSheet(entity.EmployeesList);
            guiFind.Module = this;
            guiFind.ShowDialog();
            if (guiFind.DialogResult != DialogResult.OK)
                return;

            DateTime timeIn = guiFind.TimeIn;
            DateTime timeOut = guiFind.TimeOut;

            List<HRTimeKeepersInfo> list = new List<HRTimeKeepersInfo>();
            List<HREmployeesInfo> employeeList = (List<HREmployeesInfo>)guiFind.SelectedObjects;
            foreach (HREmployeesInfo objEmployeesInfo in employeeList)
            {
                if (timeIn.TimeOfDay != DateTime.MinValue.TimeOfDay)
                {
                    foreach (HRTimeKeepersInfo item in guiFind.SelectTimeKeepersList)
                    {
                        HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                        if (objEmployeesInfo != null)
                        {
                            objTimeKeepersInfo.HRTimeKeeperEmployeeNo = objEmployeesInfo.HREmployeeNo;
                            objTimeKeepersInfo.EmployeeName = objEmployeesInfo.HREmployeeName;
                            objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo = objEmployeesInfo.HREmployeeCardNumber;
                        }
                        objTimeKeepersInfo.ThName = item.ThName;
                        objTimeKeepersInfo.HRTimeKeeperDate = new DateTime(item.HRTimeKeeperQuickImportDate.Year, item.HRTimeKeeperQuickImportDate.Month, item.HRTimeKeeperQuickImportDate.Day);
                        objTimeKeepersInfo.HRTimeKeeperTimeIn = new DateTime(item.HRTimeKeeperQuickImportDate.Year, item.HRTimeKeeperQuickImportDate.Month, item.HRTimeKeeperQuickImportDate.Day);
                        objTimeKeepersInfo.HRTimeKeeperTimeInOutMode = 0;
                        objTimeKeepersInfo.HRTimeKeeperTimeOut = new DateTime(item.HRTimeKeeperQuickImportDate.Year, item.HRTimeKeeperQuickImportDate.Month, item.HRTimeKeeperQuickImportDate.Day, guiFind.TimeIn.Hour, guiFind.TimeIn.Minute, guiFind.TimeIn.Second);
                        list.Add(objTimeKeepersInfo);
                    }
                }

                if (timeOut.TimeOfDay != DateTime.MinValue.TimeOfDay)
                {
                    foreach (HRTimeKeepersInfo item2 in guiFind.SelectTimeKeepersList)
                    {
                        HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();
                        if (objEmployeesInfo != null)
                        {
                            objTimeKeepersInfo.HRTimeKeeperEmployeeNo = objEmployeesInfo.HREmployeeNo;
                            objTimeKeepersInfo.EmployeeName = objEmployeesInfo.HREmployeeName;
                            objTimeKeepersInfo.HRTimeKeeperEmployeeCardNo = objEmployeesInfo.HREmployeeCardNumber;
                        }
                        objTimeKeepersInfo.ThName = item2.ThName;
                        objTimeKeepersInfo.HRTimeKeeperDate = new DateTime(item2.HRTimeKeeperQuickImportDate.Year, item2.HRTimeKeeperQuickImportDate.Month, item2.HRTimeKeeperQuickImportDate.Day);
                        objTimeKeepersInfo.HRTimeKeeperTimeIn = new DateTime(item2.HRTimeKeeperQuickImportDate.Year, item2.HRTimeKeeperQuickImportDate.Month, item2.HRTimeKeeperQuickImportDate.Day);
                        objTimeKeepersInfo.HRTimeKeeperTimeInOutMode = 1;
                        objTimeKeepersInfo.HRTimeKeeperTimeOut = new DateTime(item2.HRTimeKeeperQuickImportDate.Year, item2.HRTimeKeeperQuickImportDate.Month, item2.HRTimeKeeperQuickImportDate.Day, guiFind.TimeOut.Hour, guiFind.TimeOut.Minute, guiFind.TimeOut.Second);
                        list.Add(objTimeKeepersInfo);
                    }
                }
            }
            if (list != null && list.Count > 0)
            {
                entity.TimeKeepersList.Invalidate(list);
                entity.SaveData(list);
                HRTimeKeeperCompletesInfo objTimeKeeperCompletesBackup = new HRTimeKeeperCompletesInfo();
                list.ForEach(o =>
                {
                    HRTimeKeeperCompletesInfo objTimeKeeperCompletesInfo = new HRTimeKeeperCompletesInfo();
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompletesEmployeeCardNo = o.HRTimeKeeperEmployeeCardNo;
                    objTimeKeeperCompletesInfo.HRTimeKeeperCompleteTimeCheck = o.HRTimeKeeperTimeOut;

                    entity.SaveHistory(TableName.HRTimeKeeperCompletesTableName, objTimeKeeperCompletesBackup, objTimeKeeperCompletesInfo, "Add");
                    objTimeKeeperCompletesBackup.HRTimeKeeperCompletesEmployeeCardNo = o.HRTimeKeeperEmployeeCardNo;
                });
            }
        }
        #endregion
    }
}
