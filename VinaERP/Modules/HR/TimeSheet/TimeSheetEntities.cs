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

namespace VinaERP.Modules.TimeSheet
{
    public class TimeSheetEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeTimeSheetsInfo> EmployeeTimeSheetsList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }

        public List<HRTimeSheetParamsInfo> TimeSheetParams { get; set; }
        public List<HROTFactorsInfo> OTFactors { get; set; }
        #endregion

        #region Constructor
        public TimeSheetEntities()
            : base()
        {
            EmployeeTimeSheetsList = new VinaList<HREmployeeTimeSheetsInfo>();
            EmployeesList = new List<HREmployeesInfo>();

            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            TimeSheetParams = objTimeSheetParamsController.GetTimeSheetParamsList(string.Empty);

            HROTFactorsController otFactorController = new HROTFactorsController();
            OTFactors = otFactorController.GetAllEmployeeFactors();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRTimeSheetsInfo();
            SearchObject = new HRTimeSheetsInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeTimeSheetsList.InitVinaList(this,
                                             TableName.HRTimeSheetsTableName,
                                             TableName.HREmployeeTimeSheetsTableName,
                                             VinaList<HREmployeeTimeSheetsInfo>.cstRelationForeign);
            EmployeeTimeSheetsList.ItemTableForeignKey = "FK_HRTimeSheetID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeTimeSheetsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)MainObject;
            objTimeSheetsInfo.HRTimeSheetDate = DateTime.Now;
            objTimeSheetsInfo.HRTimeSheetFromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            objTimeSheetsInfo.HRTimeSheetToDate = VinaUtil.GetMonthEndDate(DateTime.Now);
            objTimeSheetsInfo.HRTimeSheetType = TimeSheetType.Day.ToString();
            objTimeSheetsInfo.HRTimeSheetStatus = TimeSheetStatus.New.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeTimeSheetsList.SetDefaultListAndRefreshGridControl();
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
            HRTimeSheetEntrysController objTimeSheetEntrysController = new HRTimeSheetEntrysController();
            HREmployeeTimeSheetsController objEmployeeTimeSheetsController = new HREmployeeTimeSheetsController();
            HREmployeeTimeSheetOTDetailsController objEmployeeTimeSheetOTDetailsController = new HREmployeeTimeSheetOTDetailsController();
            List<HREmployeeTimeSheetsInfo> employeeTimeSheetsList = objEmployeeTimeSheetsController.GetEmployeeTimeSheetByTimeSheetIDAndUserGroup(iObjectID, VinaApp.CurrentUserInfo.FK_ADUserGroupID);
            EmployeeTimeSheetsList.Invalidate(employeeTimeSheetsList);
            foreach (HREmployeeTimeSheetsInfo employeeTimeSheet in EmployeeTimeSheetsList)
            {
                employeeTimeSheet.HRTimeSheetEntrysList = objTimeSheetEntrysController.GetTimeSheetEntryByTimeSheetIDAndEmployeeTimeSheetID(
                                                                               employeeTimeSheet.FK_HRTimeSheetID,
                                                                               employeeTimeSheet.HREmployeeTimeSheetID);

                employeeTimeSheet.HREmployeeTimeSheetOTDetailsList = objEmployeeTimeSheetOTDetailsController.GetListTimeSheetOTDetailByEmployeeTimeSheet(employeeTimeSheet.HREmployeeTimeSheetID);
                SetEmployeeTimeSheetValue(employeeTimeSheet);
            }
        }

        public void SetEmployeeTimeSheetValue(HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo)
        {
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)MainObject;
            List<string> employeeTimeSheetValueList = new List<string> {   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty
                                                                            };

            foreach (HRTimeSheetEntrysInfo timeSheetEntry in objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList)
            {
                if (timeSheetEntry.HRTimeSheetEntryDate.Date >= timeSheet.HRTimeSheetFromDate.Date &&
                    timeSheetEntry.HRTimeSheetEntryDate.Date <= timeSheet.HRTimeSheetToDate.Date)
                {
                    int index = (int)(timeSheetEntry.HRTimeSheetEntryDate.Date - timeSheet.HRTimeSheetFromDate.Date).TotalDays + 1;
                    string timeSheetParamNo = string.Empty;
                    HRTimeSheetParamsInfo objTimeSheetParamsInfo = TimeSheetParams.Where(t => t.HRTimeSheetParamID == timeSheetEntry.FK_HRTimeSheetParamID).FirstOrDefault();
                    if (objTimeSheetParamsInfo != null)
                    {
                        timeSheetParamNo = objTimeSheetParamsInfo.HRTimeSheetParamNo;
                    }
                    if (!string.IsNullOrEmpty(timeSheetParamNo))
                    {
                        if (string.IsNullOrEmpty(employeeTimeSheetValueList[index - 1].Trim()))
                        {
                            employeeTimeSheetValueList[index - 1] = timeSheetParamNo;
                        }
                        else
                        {
                            employeeTimeSheetValueList[index - 1] += String.Format(", {0}", timeSheetParamNo);
                        }
                    }
                }
            }

            VinaDbUtil dbUtil = new VinaDbUtil();
            int numDays = ((TimeSheetModule)Module).NumOfDayInMonth();
            if (numDays > 31)
            {
                numDays = 31;
            }
            for (int i = 1; i <= numDays; i++)
            {
                String propertyName = String.Format("{0}{1}", "HREmployeeTimeSheetDate", i.ToString());
                dbUtil.SetPropertyValue(objEmployeeTimeSheetsInfo, propertyName, employeeTimeSheetValueList[i - 1]);
            }
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            HRTimeSheetsInfo timeSheet = (HRTimeSheetsInfo)MainObject;
            //Save employee time sheet list
            EmployeeTimeSheetsList.SaveItemObjects();
            //Create entry for time sheet
            HRTimeSheetEntrysController objTimeSheetEntrysController = new HRTimeSheetEntrysController();
            HREmployeeTimeSheetOTDetailsController objEmployeeTimeSheetOTDetailsController = new HREmployeeTimeSheetOTDetailsController();
            foreach (HREmployeeTimeSheetsInfo objEmployeeTimeSheetsInfo in EmployeeTimeSheetsList)
            {
                objTimeSheetEntrysController.DeleteByForeignColumn("FK_HREmployeeTimeSheetID", objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID);
                foreach (HRTimeSheetEntrysInfo entry in objEmployeeTimeSheetsInfo.HRTimeSheetEntrysList)
                {
                    if (entry.FK_HRTimeSheetParamID == 0) continue;
                    entry.FK_HRTimeSheetID = timeSheet.HRTimeSheetID;
                    entry.FK_HREmployeeTimeSheetID = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID;
                    objTimeSheetEntrysController.CreateObject(entry);
                }
                objEmployeeTimeSheetOTDetailsController.DeleteByForeignColumn("FK_HREmployeeTimeSheetID", objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID);
                foreach (HREmployeeTimeSheetOTDetailsInfo obj in objEmployeeTimeSheetsInfo.HREmployeeTimeSheetOTDetailsList)
                {
                    obj.FK_HREmployeeTimeSheetID = objEmployeeTimeSheetsInfo.HREmployeeTimeSheetID;
                    objEmployeeTimeSheetOTDetailsController.CreateObject(obj);
                }
            }
        }
        #endregion

        public void CompleteTransaction()
        {
            HRTimeSheetsInfo objTimeSheetsInfo = (HRTimeSheetsInfo)MainObject;
            HRTimeSheetsController objTimeSheetsController = new HRTimeSheetsController();
            HRTimeSheetsInfo objReferrenceTimeSheetsInfo = (HRTimeSheetsInfo)objTimeSheetsController.GetObjectByID(objTimeSheetsInfo.HRTimeSheetID);
            if(objReferrenceTimeSheetsInfo != null)
            {
                objReferrenceTimeSheetsInfo.HRTimeSheetStatus = TimeSheetStatus.Approved.ToString();
                objTimeSheetsController.UpdateObject(objReferrenceTimeSheetsInfo);

                objTimeSheetsInfo.HRTimeSheetStatus = TimeSheetStatus.Approved.ToString();
                UpdateMainObjectBindingSource();
            }
        }
    }
}
