using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Allowance
{

    public class AllowanceModule : BaseModuleERP
    {
        #region Constant
        public const string AllowanceTypeLookupEditName = "fld_lkeHRAllowanceType";
        public const string AllowanceValueTextBoxName = "fld_txtHRAllowanceValue";
        #endregion
        public AllowanceModule()
        {
            CurrentModuleName = "Allowance";
            CurrentModuleEntity = new AllowanceEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            HRAllowancesInfo mainObject = (HRAllowancesInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HRAllowanceID > 0)
            {
                //if(mainObject.HRAllowanceStatus == AllowanceStatus.New.ToString())
                //{
                //    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                //    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
                //}
                //else
                //{
                //    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                //    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                //}
            }
            
        }

        public void RemoveSelectedItemFromAllowanceItemList()
        {
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            entity.EmployeeAllowancesList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;

            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeAllowancesList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    HREmployeeAllowancesInfo objEmployeeAllowancesInfo = new HREmployeeAllowancesInfo();
                    entity.SetDefaultValuesFromEmployee(objEmployeeAllowancesInfo, objEmployeesInfo);
                    entity.EmployeeAllowancesList.Add(objEmployeeAllowancesInfo);
                }
                entity.EmployeeAllowancesList.GridControl.RefreshDataSource();
            }
        }

        public void UpdateValue()
        {
            decimal result = 0;
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            HRAllowancesInfo mainObject = (HRAllowancesInfo)entity.MainObject;
            decimal AllowanceValue = 0;
            decimal.TryParse(mainObject.HRAllowanceValue, out AllowanceValue);
            entity.EmployeeAllowancesList.ForEach(o1 =>
            {
                o1.HREmployeeAllowanceValueAmount = mainObject.HRAllowanceConfigValue;
            });
            entity.EmployeeAllowancesList.GridControl.RefreshDataSource();
        }

        public void UpdateItemDate()
        {
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            HRAllowancesInfo mainObject = (HRAllowancesInfo)entity.MainObject;
            entity.EmployeeAllowancesList.ForEach(o1 => o1.HREmployeeAllowanceDate = mainObject.HRAllowanceFromDate);
            entity.EmployeeAllowancesList.GridControl.RefreshDataSource();
        }

        public override void ActionComplete()
        {
            AllowanceEntities entity = (AllowanceEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }
    }
}
