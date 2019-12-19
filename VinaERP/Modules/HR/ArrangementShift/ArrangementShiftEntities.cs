using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.ArrangementShift
{
    public class ArrangementShiftEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HREmployeeArrangementShiftsInfo> EmployeeArrangementShiftsList { get; set; }
        public List<HREmployeesInfo> EmployeesList { get; set; }
        public List<ADWorkingShiftsInfo> WorkingShifts { get; set; }
        #endregion

        #region Constructor
        public ArrangementShiftEntities()
            : base()
        {
            EmployeeArrangementShiftsList = new VinaList<HREmployeeArrangementShiftsInfo>();
            EmployeesList = new List<HREmployeesInfo>();

            ADWorkingShiftsController objWorkingShiftsController = new ADWorkingShiftsController();
            WorkingShifts = (List<ADWorkingShiftsInfo>)objWorkingShiftsController.GetListFromDataSet(objWorkingShiftsController.GetAllObjects());
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRArrangementShiftsInfo();
            SearchObject = new HRArrangementShiftsInfo();
        }

        public override void InitModuleObjectList()
        {
            EmployeeArrangementShiftsList.InitVinaList(this,
                                             TableName.HRArrangementShiftsTableName,
                                             TableName.HREmployeeArrangementShiftsTableName,
                                             VinaList<HREmployeeArrangementShiftsInfo>.cstRelationForeign);
            EmployeeArrangementShiftsList.ItemTableForeignKey = "FK_HRArrangementShiftID";
        }

        public override void InitGridControlInVinaList()
        {
            EmployeeArrangementShiftsList.InitVinaListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRArrangementShiftsInfo objArrangementShiftsInfo = (HRArrangementShiftsInfo)MainObject;
            objArrangementShiftsInfo.HRArrangementShiftFromDate = DateTime.Now;
            objArrangementShiftsInfo.HRArrangementShiftToDate = DateTime.Now;
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                EmployeeArrangementShiftsList.SetDefaultListAndRefreshGridControl();
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
            HRArrangementShiftEntrysController objArrangementShiftEntrysController = new HRArrangementShiftEntrysController();
            HREmployeeArrangementShiftsController objEmployeeArrangementShiftsController = new HREmployeeArrangementShiftsController();
            List<HREmployeeArrangementShiftsInfo> employeeArrangementShiftsList = objEmployeeArrangementShiftsController.GetEmployeeArrangementShiftByArrangementShiftIDAndUserGroup(iObjectID, VinaApp.CurrentUserInfo.FK_ADUserGroupID);
            EmployeeArrangementShiftsList.Invalidate(employeeArrangementShiftsList);
            foreach (HREmployeeArrangementShiftsInfo employeeArrangementShift in EmployeeArrangementShiftsList)
            {
                employeeArrangementShift.HRArrangementShiftEntrysList = objArrangementShiftEntrysController.GetArrangementShiftEntrysByArrangementShiftIDAndEmployeeArrangementShiftID(
                                                                               employeeArrangementShift.FK_HRArrangementShiftID,
                                                                               employeeArrangementShift.HREmployeeArrangementShiftID);

                SetEmployeeArrangementShiftValue(employeeArrangementShift);
            }
        }

        public void SetEmployeeArrangementShiftValue(HREmployeeArrangementShiftsInfo objEmployeeArrangementShiftsInfo)
        {
            HRArrangementShiftsInfo arrangementShift = (HRArrangementShiftsInfo)MainObject;
            List<string> employeeArrangementShiftValueList = new List<string> {   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                                                                   string.Empty
                                                                         };

            foreach (HRArrangementShiftEntrysInfo arrangementShiftEntry in objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList)
            {
                if (arrangementShiftEntry.HRArrangementShiftEntryDate.Date >= arrangementShift.HRArrangementShiftFromDate.Date &&
                    arrangementShiftEntry.HRArrangementShiftEntryDate.Date <= arrangementShift.HRArrangementShiftToDate.Date)
                {
                    int index = (int)(arrangementShiftEntry.HRArrangementShiftEntryDate.Date - arrangementShift.HRArrangementShiftFromDate.Date).TotalDays + 1;
                    if (index > 31)
                    {
                        MessageBox.Show("Bạn không thể chọn thời gian xếp ca quá 31 ngày!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string workingShifId = string.Empty;
                    ADWorkingShiftsInfo objWorkingShiftsInfo = WorkingShifts.Where(o => o.ADWorkingShiftID == arrangementShiftEntry.FK_ADWorkingShiftID).FirstOrDefault();
                    if (objWorkingShiftsInfo != null)
                    {
                        workingShifId = objWorkingShiftsInfo.ADWorkingShiftName;
                    }
                    if (!string.IsNullOrEmpty(workingShifId))
                    {
                        if (string.IsNullOrEmpty(employeeArrangementShiftValueList[index - 1].Trim()))
                        {
                            employeeArrangementShiftValueList[index - 1] = workingShifId;
                        }
                        else
                        {
                            employeeArrangementShiftValueList[index - 1] += String.Format(", {0}", workingShifId);
                        }
                    }
                }
            }

            VinaDbUtil dbUtil = new VinaDbUtil();
            int numDays = ((ArrangementShiftModule)Module).NumOfDayInMonth();
            if (numDays > 31)
            {
                numDays = 31;
            }
            for (int i = 1; i <= numDays; i++)
            {
                String propertyName = String.Format("{0}{1}", "HREmployeeArrangementShiftDate", i.ToString());
                dbUtil.SetPropertyValue(objEmployeeArrangementShiftsInfo, propertyName, employeeArrangementShiftValueList[i - 1]);
            }
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            HRArrangementShiftsInfo arrangementShift = (HRArrangementShiftsInfo)MainObject;
            //Save employee time sheet list
            EmployeeArrangementShiftsList.SaveItemObjects();
            //Create entry for time sheet
            HRArrangementShiftEntrysController objArrangementShiftEntrysController = new HRArrangementShiftEntrysController();
            foreach (HREmployeeArrangementShiftsInfo objEmployeeArrangementShiftsInfo in EmployeeArrangementShiftsList)
            {
                objArrangementShiftEntrysController.DeleteByForeignColumn("FK_HREmployeeArrangementShiftID", objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftID);
                foreach (HRArrangementShiftEntrysInfo entry in objEmployeeArrangementShiftsInfo.HRArrangementShiftEntrysList)
                {
                    if (entry.FK_ADWorkingShiftID == 0) continue;
                    entry.FK_HRArrangementShiftID = arrangementShift.HRArrangementShiftID;
                    entry.FK_HREmployeeArrangementShiftID = objEmployeeArrangementShiftsInfo.HREmployeeArrangementShiftID;
                    objArrangementShiftEntrysController.CreateObject(entry);
                }
            }
        }
        #endregion
    }
}
