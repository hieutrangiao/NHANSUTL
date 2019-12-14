using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.EmployeeWorkSchedule
{

    public class EmployeeWorkScheduleModule : BaseModuleERP
    {
        #region Constant
        public const string EmployeeWorkScheduleTypeLookupEditName = "fld_lkeHREmployeeWorkScheduleType";
        public const string EmployeeWorkScheduleValueTextBoxName = "fld_txtHREmployeeWorkScheduleValue";
        #endregion
        public EmployeeWorkScheduleModule()
        {
            CurrentModuleName = "EmployeeWorkSchedule";
            CurrentModuleEntity = new EmployeeWorkScheduleEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            HREmployeeWorkSchedulesInfo obj = (HREmployeeWorkSchedulesInfo)entity.MainObject;
            DateTime d = obj.HREmployeeWorkScheduleFromDate;
            DateTime dto = obj.HREmployeeWorkScheduleToDate;
            obj.HREmployeeWorkScheduleDateFrom = new DateTime(d.Year, d.Month, d.Day, obj.HREmployeeWorkScheduleDateFrom.Hour, obj.HREmployeeWorkScheduleDateFrom.Minute, 0);
            obj.HREmployeeWorkScheduleDateTo = new DateTime(dto.Year, dto.Month, dto.Day, obj.HREmployeeWorkScheduleDateTo.Hour, obj.HREmployeeWorkScheduleDateTo.Minute, 0);
            return base.ActionSave();
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            HREmployeeWorkSchedulesInfo obj = (HREmployeeWorkSchedulesInfo)entity.MainObject;
            obj.HREmployeeWorkScheduleFromDate = obj.HREmployeeWorkScheduleDateFrom;
            obj.HREmployeeWorkScheduleToDate = obj.HREmployeeWorkScheduleDateTo;
            entity.UpdateMainObjectBindingSource();
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            HREmployeeWorkSchedulesInfo mainObject = (HREmployeeWorkSchedulesInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HREmployeeWorkScheduleID > 0)
            {
                if(mainObject.HREmployeeWorkScheduleStatus == EmployeeWorkScheduleStatus.New.ToString())
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

        public void RemoveSelectedItemFromEmployeeWorkScheduleItemList()
        {
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            entity.EmployeeWorkScheduleItemsList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            HREmployeeWorkSchedulesInfo mainObject = (HREmployeeWorkSchedulesInfo)entity.MainObject;
            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeWorkScheduleItemsList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    HREmployeeWorkScheduleItemsInfo objEmployeeWorkScheduleItemsInfo = new HREmployeeWorkScheduleItemsInfo();
                    entity.SetDefaultValuesFromEmployee(objEmployeeWorkScheduleItemsInfo, objEmployeesInfo);
                    entity.EmployeeWorkScheduleItemsList.Add(objEmployeeWorkScheduleItemsInfo);
                }
                entity.EmployeeWorkScheduleItemsList.GridControl.RefreshDataSource();

                mainObject.HREmployeeCardNumber = string.Join(";", entity.EmployeeWorkScheduleItemsList.Select(o1 => o1.HREmployeeCardNumber).ToArray());
                mainObject.HREmployeeName = string.Join(";", entity.EmployeeWorkScheduleItemsList.Select(o1 => o1.HREmployeeName).ToArray());
            }
        }

        public override void ActionComplete()
        {
            EmployeeWorkScheduleEntities entity = (EmployeeWorkScheduleEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }
    }
}
