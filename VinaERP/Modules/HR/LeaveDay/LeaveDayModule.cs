using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;
using VinaLib.BaseProvider;
using VinaERP.Modules.LeaveDay.UI;
using VinaCommon;
using System.Windows.Forms;

namespace VinaERP.Modules.LeaveDay
{

    public class LeaveDayModule : BaseModuleERP
    {
        #region Public Properties
        public List<HRTimeSheetParamsInfo> commonParams;
        #endregion
        public LeaveDayModule()
        {
            CurrentModuleName = "LeaveDay";
            CurrentModuleEntity = new LeaveDayEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            commonParams = new List<HRTimeSheetParamsInfo>();
        }

        public override void InitializeScreens()
        {
            this.ParentScreen.LeftPanelContainer.Hide();
            DMLD100 DMLD100 = new DMLD100();
            DMLD100.ScreenCode = "DMLD100";
            DMLD100.Module = this;
            DMLD100.Height -= 100;
            DMLD100.InitGridControl();
            Screens.Add(DMLD100);
            DMLD100.AddControlsToParentScreen();
        }

        public void UpdateTotalLeaveDays(HRLeaveDaysInfo leaveDay)
        {
            HRLeaveDaysController objLeaveDaysController = new HRLeaveDaysController();
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo obj = (HREmployeesInfo)objEmployeesController.GetObjectByID(leaveDay.FK_HREmployeeID);
            double leaveDays = 0;
            if (obj != null)
            {
                List<HRLeaveDaysInfo> LeaveDaysList = new List<HRLeaveDaysInfo>();
                LeaveDaysList = objLeaveDaysController.GetLeaveDayOnYearByHREmployeeID(leaveDay.FK_HREmployeeID);
                foreach (HRLeaveDaysInfo item in LeaveDaysList)
                {
                    if (item.HRTimeSheetParamNo == "Pn")
                    {
                        leaveDays = leaveDays + 1;
                    }
                    else if (item.HRTimeSheetParamNo == "Pn 1/2")
                    {
                        leaveDays = leaveDays + 0.5;
                    }
                }
            }
            VinaDbUtil dbUtil = new VinaDbUtil();
            LeaveDayEntities entity = (LeaveDayEntities)CurrentModuleEntity;
            leaveDay.TotalLeaveDays = 0;

            for (int i = 1; i <= 31; i++)
            {
                string paramNo = dbUtil.GetPropertyStringValue(leaveDay, string.Format("HRLeaveDayDate{0}", i));
                if (!string.IsNullOrEmpty(paramNo))
                {
                    if (paramNo.IndexOf("1/2") > 0)
                    {
                        leaveDay.TotalLeaveDays = leaveDay.TotalLeaveDays + decimal.Parse("0.5");
                    }
                    else
                    {
                        leaveDay.TotalLeaveDays = leaveDay.TotalLeaveDays + 1;
                    }
                }
            }

            //if ((leaveDays + leaveDay.TotalLeaveDays) >= 12)
            //{
            //    MessageBox.Show("Số ngày nghỉ phép không còn!",
            //                CommonLocalizedResources.MessageBoxDefaultCaption,
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);
            //    leaveDay = (HRLeaveDaysInfo)leaveDay.OldObject;
            //    entity.LeaveDaysList.GridControl.RefreshDataSource();
            //}
            //else
            //{
            //    entity.LeaveDaysList.GridControl.RefreshDataSource();
            //}
            entity.LeaveDaysList.GridControl.RefreshDataSource();
        }

        public void SaveLeaveDays(DateTime dateFrom, DateTime dateTo)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            LeaveDayEntities entity = (LeaveDayEntities)CurrentModuleEntity;
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            commonParams = objTimeSheetParamsController.GetTimeSheetParamsByTimeSheetType(TimeSheetParamType.Common.ToString());
            HRLeaveDaysController objLeaveDaysController = new HRLeaveDaysController();
            foreach (HRLeaveDaysInfo employeeLeaveDay in entity.LeaveDaysList)
            {
                //objLeaveDaysController.DeleteByEmployeeIDAndDate(employeeLeaveDay.FK_HREmployeeID, employeeLeaveDay.HRLeaveDayDate);
                for (int i = 1; i <= 31; i++)
                {
                    string[] paramNumbers = dbUtil.GetPropertyStringValue(employeeLeaveDay, string.Format("HRLeaveDayDate{0}", i)).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (dateFrom.Date.AddDays(i - 1) <= dateTo.Date)
                    {
                        objLeaveDaysController.DeleteByEmployeeIDAndDate(employeeLeaveDay.FK_HREmployeeID, dateFrom.Date.AddDays(i - 1));
                    }
                    for (int j = 0; j < paramNumbers.Length; j++)
                    {
                        string paramNo = paramNumbers[j].Trim();
                        //string paramNo = dbUtil.GetPropertyStringValue(employeeLeaveDay, string.Format("HRLeaveDayDate{0}", i));
                        if (!string.IsNullOrEmpty(paramNo))
                        {
                            HRTimeSheetParamsInfo param = commonParams.Where(p => p.HRTimeSheetParamNo == paramNo).FirstOrDefault();
                            if (param != null)
                            {
                                HRLeaveDaysInfo leaveDay = new HRLeaveDaysInfo();
                                leaveDay.FK_HREmployeeID = employeeLeaveDay.FK_HREmployeeID;
                                leaveDay.FK_HRTimeSheetParamID = param.HRTimeSheetParamID;
                                //leaveDay.HRLeaveDayDate = new DateTime(employeeLeaveDay.HRLeaveDayDate.Year, employeeLeaveDay.HRLeaveDayDate.Month, i);
                                leaveDay.HRLeaveDayDate = dateFrom.Date.AddDays(i - 1);
                                //objLeaveDaysController.DeleteByEmployeeIDAndDate(employeeLeaveDay.FK_HREmployeeID, leaveDay.HRLeaveDayDate);
                                objLeaveDaysController.CreateObject(leaveDay);
                            }
                        }
                        //else
                        //{
                        //    objLeaveDaysController.DeleteByEmployeeIDAndDate(employeeLeaveDay.FK_HREmployeeID, dteFrom.DateTime.Date.AddDays(i - 1));
                        //}
                    }
                }
            }

            MessageBox.Show("Lưu thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public void ViewLeaveDays(int branchID, int departmentID, int departmentRoomID, int departmentRoomGroupItemID, int employeeID, DateTime dateFrom, DateTime dateTo, string status)
        {
            VinaDbUtil dbUtil = new VinaDbUtil();
            HRLeaveDaysController objLeaveDaysController = new HRLeaveDaysController();
            HRTimeSheetParamsController objTimeSheetParamsController = new HRTimeSheetParamsController();
            List<HRLeaveDaysInfo> leaveDays = objLeaveDaysController.GetLeaveDaysList(branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, dateFrom, dateTo);
            commonParams = objTimeSheetParamsController.GetTimeSheetParamsByTimeSheetType(TimeSheetParamType.Common.ToString());
            LeaveDayEntities entity = (LeaveDayEntities)CurrentModuleEntity;
            entity.LeaveDaysList.Clear();
            HREmployeesController objEmployeesController = new HREmployeesController();
            List<HREmployeesInfo> employees = new List<HREmployeesInfo>();
            if (employeeID == 0)
            {
                employees = objEmployeesController.GetEmployeeList(branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, status);
            }
            else
            {
                HREmployeesInfo employee = (HREmployeesInfo)objEmployeesController.GetObjectByID(employeeID);
                employees.Add(employee);
            }

            int numDays = (int)(dateTo.Date - dateFrom.Date).TotalDays + 1;
            foreach (HRLeaveDaysInfo leaveDay in leaveDays)
            {
                if (!employees.Exists(p => p.HREmployeeID == leaveDay.FK_HREmployeeID)) continue;
                HRLeaveDaysInfo employeeLeaveDay = entity.LeaveDaysList.Where(ld => ld.FK_HREmployeeID == leaveDay.FK_HREmployeeID).FirstOrDefault();
                if (employeeLeaveDay == null)
                {
                    employeeLeaveDay = new HRLeaveDaysInfo();
                    entity.LeaveDaysList.Add(employeeLeaveDay);
                }
                if (employeeLeaveDay != null)
                {
                    employeeLeaveDay.FK_HREmployeeID = leaveDay.FK_HREmployeeID;
                    employeeLeaveDay.HREmployeeNo = leaveDay.HREmployeeNo;
                    employeeLeaveDay.HREmployeeName = leaveDay.HREmployeeName;
                    employeeLeaveDay.HRLeaveDayDate = dateFrom;
                    employeeLeaveDay.HREmployeeCardNumber = leaveDay.HREmployeeCardNumber;
                    HRTimeSheetParamsInfo param = commonParams.Where(p => p.HRTimeSheetParamID == leaveDay.FK_HRTimeSheetParamID).FirstOrDefault();
                    for (int i = 1; i <= numDays; i++)
                    {
                        if (param != null)
                        {
                            //dbUtil.SetPropertyValue(employeeLeaveDay, string.Format("HRLeaveDayDate{0}", leaveDay.HRLeaveDayDate.Date.Day), param.HRTimeSheetParamNo);
                            if (dateFrom.Date.AddDays(i - 1) == leaveDay.HRLeaveDayDate.Date)
                            {
                                string paramTemp = dbUtil.GetPropertyStringValue(employeeLeaveDay, string.Format("HRLeaveDayDate{0}", leaveDay.HRLeaveDayDate.Date.Day));
                                if (string.IsNullOrEmpty(paramTemp))
                                {
                                    dbUtil.SetPropertyValue(employeeLeaveDay, string.Format("HRLeaveDayDate{0}", i), param.HRTimeSheetParamNo);
                                }
                                else
                                {
                                    dbUtil.SetPropertyValue(employeeLeaveDay, string.Format("HRLeaveDayDate{0}", i), paramTemp + ", " + param.HRTimeSheetParamNo);
                                }
                            }
                        }
                    }
                }
            }

            foreach (HREmployeesInfo employee in employees)
            {
                if (!entity.LeaveDaysList.Exists(ld => ld.FK_HREmployeeID == employee.HREmployeeID))
                {
                    HRLeaveDaysInfo leaveDay = new HRLeaveDaysInfo();
                    leaveDay.FK_HREmployeeID = employee.HREmployeeID;
                    leaveDay.HREmployeeNo = employee.HREmployeeNo;
                    leaveDay.HREmployeeName = employee.HREmployeeName;
                    leaveDay.HRLeaveDayDate = dateFrom;
                    leaveDay.HREmployeeCardNumber = employee.HREmployeeCardNumber;
                    entity.LeaveDaysList.Add(leaveDay);
                }
            }

            foreach (HRLeaveDaysInfo leaveDay in entity.LeaveDaysList)
            {
                UpdateTotalLeaveDays(leaveDay);
                leaveDay.BackupObject = (HRLeaveDaysInfo)leaveDay.Clone();
            }

            HRLeaveDaysGridControl gridControl = entity.LeaveDaysList.GridControl as HRLeaveDaysGridControl;
            gridControl.ViewDate = dateFrom;
            gridControl.FromDate = dateFrom;
            gridControl.ToDate = dateTo;
            //gridControl.InitializeControl();

            foreach (var item in entity.LeaveDaysList)
            {
                HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(item.FK_HREmployeeID);
                if (objEmployeesInfo != null)
                    item.HREmployeeCardNumber = objEmployeesInfo.HREmployeeCardNumber;
            }
            gridControl.RefreshDataSource();
        }
    }
}
