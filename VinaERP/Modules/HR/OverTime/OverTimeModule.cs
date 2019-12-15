using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.OverTime
{

    public class OverTimeModule : BaseModuleERP
    {
        #region Constant
        public const string OverTimeTypeLookupEditName = "fld_lkeHROverTimeType";
        public const string OverTimeValueTextBoxName = "fld_txtHROverTimeValue";
        #endregion
        public OverTimeModule()
        {
            CurrentModuleName = "OverTime";
            CurrentModuleEntity = new OverTimeEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo obj = (HROverTimesInfo)entity.MainObject;
            DateTime d = obj.HROverTimeDate;
            DateTime dto = obj.HROverTimeDateEnd;
            obj.HROverTimeFromDate = new DateTime(d.Year, d.Month, d.Day, obj.HROverTimeFromDate.Hour, obj.HROverTimeFromDate.Minute, 0);
            obj.HROverTimeToDate = new DateTime(dto.Year, dto.Month, dto.Day, obj.HROverTimeToDate.Hour, obj.HROverTimeToDate.Minute, 0);
            Check();
            return base.ActionSave();

        }

        public void Check()
        {
            if (!Toolbar.IsNullOrNoneAction())
            {
                OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
                HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
                DateTime from = objOverTimesInfo.HROverTimeDate.Date.AddHours(objOverTimesInfo.HROverTimeFromDate.Hour).AddMinutes(objOverTimesInfo.HROverTimeFromDate.Minute);
                DateTime to = objOverTimesInfo.HROverTimeDateEnd.Date.AddHours(objOverTimesInfo.HROverTimeToDate.Hour).AddMinutes(objOverTimesInfo.HROverTimeToDate.Minute);
                double n = (to - from).TotalHours;
            }
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            VinaTextBox t1 = (VinaTextBox)this.Controls["fld_txtHROverTimeFromDate"];
            VinaTextBox t2 = (VinaTextBox)this.Controls["fld_txtHROverTimeToDate"];
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            t1.Text = objOverTimesInfo.HROverTimeFromDate.ToString("HH:mm");
            t2.Text = objOverTimesInfo.HROverTimeToDate.ToString("HH:mm");
        }

        public override void ActionNew()
        {
            base.ActionNew();
            ((VinaTextBox)this.Controls["fld_txtHROverTimeFromDate"]).Text = "00:00";
            ((VinaTextBox)this.Controls["fld_txtHROverTimeToDate"]).Text = "00:00";
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo mainObject = (HROverTimesInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HROverTimeID > 0)
            {
                if (mainObject.HROverTimeStatus == OverTimeStatus.New.ToString())
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

        public void RemoveSelectedItemFromOverTimeItemList()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            entity.EmployeeOTsList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo mainObject = (HROverTimesInfo)entity.MainObject;
            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeOTsList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    HREmployeeOTsInfo objEmployeeOTsInfo = new HREmployeeOTsInfo();
                    entity.SetDefaultValuesFromEmployee(objEmployeeOTsInfo, objEmployeesInfo);
                    entity.EmployeeOTsList.Add(objEmployeeOTsInfo);
                }
                entity.EmployeeOTsList.GridControl.RefreshDataSource();
            }
            mainObject.HREmployeeCardNumber = string.Join(";", entity.EmployeeOTsList.Select(o1 => o1.HREmployeeCardNumber).ToArray());
            mainObject.HREmployeeName = string.Join(";", entity.EmployeeOTsList.Select(o1 => o1.HREmployeeName).ToArray());
        }

        public override void ActionComplete()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }

        public void UpdateDateEnd()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            objOverTimesInfo.HROverTimeDateEnd = objOverTimesInfo.HROverTimeDate;
            objOverTimesInfo.HROverTimeFromDate = objOverTimesInfo.HROverTimeDate;
            objOverTimesInfo.HROverTimeToDate = objOverTimesInfo.HROverTimeDate;
        }
        public void UpdateDateTo()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            objOverTimesInfo.HROverTimeToDate = objOverTimesInfo.HROverTimeDateEnd;
        }

        public bool ChangeFromTimeOT()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            if (entity.EmployeeOTsList == null || entity.EmployeeOTsList.Count == 0)
                return true;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            DateTime d = objOverTimesInfo.HROverTimeDate;
            foreach (HREmployeeOTsInfo item in entity.EmployeeOTsList)
            {
                item.HREmployeeOTFromDate = new DateTime(d.Year, d.Month, d.Day, objOverTimesInfo.HROverTimeFromDate.Hour, objOverTimesInfo.HROverTimeFromDate.Minute, 0);
                item.HREmployeeOTDate = objOverTimesInfo.HROverTimeDate;
            }
            return true;
        }

        public bool ChangeToTimeOT()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            if (entity.EmployeeOTsList == null || entity.EmployeeOTsList.Count == 0)
                return true;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            DateTime d = objOverTimesInfo.HROverTimeDateEnd;
            foreach (HREmployeeOTsInfo item in entity.EmployeeOTsList)
            {
                item.HREmployeeOTToDate = new DateTime(d.Year, d.Month, d.Day, objOverTimesInfo.HROverTimeToDate.Hour, objOverTimesInfo.HROverTimeToDate.Minute, 0);
                item.HREmployeeOTDateEnd = objOverTimesInfo.HROverTimeDateEnd;
            }
            return true;
        }

        public void UpdateHREmployeeOTByOTFactor()
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            if (!Toolbar.IsNullOrNoneAction() && objOverTimesInfo.HROverTimeFactor >= 0)
            {
                if (entity.EmployeeOTsList.Count > 0)
                {
                    VinaDbUtil dbUtil = new VinaDbUtil();
                    foreach (HREmployeeOTsInfo employeeOT in entity.EmployeeOTsList)
                    {
                        dbUtil.SetPropertyValue(employeeOT, "HREmployeeOTFactor", objOverTimesInfo.HROverTimeFactor);
                    }
                    entity.EmployeeOTsList.GridControl.RefreshDataSource();
                }
            }
            else
            {
                objOverTimesInfo.HROverTimeFactor = entity.EmployeeOTsList.Count > 0 ? entity.EmployeeOTsList[0].HREmployeeOTFactor : 0;
                entity.UpdateMainObjectBindingSource();
            }
        }

        public void UpdateHREmployeeOTByWorkingShift(int workingShiftID)
        {
            OverTimeEntities entity = (OverTimeEntities)CurrentModuleEntity;
            HROverTimesInfo objOverTimesInfo = (HROverTimesInfo)entity.MainObject;
            if (!Toolbar.IsNullOrNoneAction())
            {
                if (entity.EmployeeOTsList.Count > 0)
                {
                    entity.EmployeeOTsList.ForEach(o =>
                    {
                        o.FK_ADWorkingShiftID = workingShiftID;
                    });

                    entity.EmployeeOTsList.GridControl.RefreshDataSource();
                }
                objOverTimesInfo.FK_ADWorkingShiftID = workingShiftID;
                entity.UpdateMainObjectBindingSource();
            }
        }
    }
}
