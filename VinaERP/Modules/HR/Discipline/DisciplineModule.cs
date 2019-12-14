using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Discipline
{

    public class DisciplineModule : BaseModuleERP
    {
        #region Constant
        public const string DisciplineTypeLookupEditName = "fld_lkeHRDisciplineType";
        public const string DisciplineValueTextBoxName = "fld_txtHRDisciplineValue";
        #endregion
        public DisciplineModule()
        {
            CurrentModuleName = "Discipline";
            CurrentModuleEntity = new DisciplineEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            return base.ActionSave();

        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            SetMaskForTextBox();
        }

        public override void InvalidateToolbar()
        {
            base.InvalidateToolbar();
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            HRDisciplinesInfo mainObject = (HRDisciplinesInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HRDisciplineID > 0)
            {
                if(mainObject.HRDisciplineStatus == DisciplineStatus.New.ToString())
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

        public void RemoveSelectedItemFromDisciplineItemList()
        {
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            entity.EmployeeDisciplinesList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;

            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeDisciplinesList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    HREmployeeDisciplinesInfo objEmployeeDisciplinesInfo = new HREmployeeDisciplinesInfo();
                    entity.SetDefaultValuesFromEmployee(objEmployeeDisciplinesInfo, objEmployeesInfo);
                    entity.EmployeeDisciplinesList.Add(objEmployeeDisciplinesInfo);
                }
                entity.EmployeeDisciplinesList.GridControl.RefreshDataSource();
            }
        }

        public void UpdateValue()
        {
            decimal result = 0;
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            HRDisciplinesInfo mainObject = (HRDisciplinesInfo)entity.MainObject;
            decimal DisciplineValue = 0;
            decimal.TryParse(mainObject.HRDisciplineValue, out DisciplineValue);
            entity.EmployeeDisciplinesList.ForEach(o1 =>
            {
                o1.HREmployeeDisciplineValue = mainObject.HRDisciplineValue;
                o1.HREmployeeDisciplineValueAmount = DisciplineValue;
            });
            entity.EmployeeDisciplinesList.GridControl.RefreshDataSource();
        }

        public void UpdateItemDate()
        {
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            HRDisciplinesInfo mainObject = (HRDisciplinesInfo)entity.MainObject;
            entity.EmployeeDisciplinesList.ForEach(o1 => o1.HREmployeeDisciplineDate = mainObject.HRDisciplineFromDate);
            entity.EmployeeDisciplinesList.GridControl.RefreshDataSource();
        }

        public void SetMaskForTextBox()
        {
            VinaLookupEdit DisciplineTypeLookupEdit = (VinaLookupEdit)Controls[DisciplineModule.DisciplineTypeLookupEditName];
            VinaTextBox DisciplineValueTextBox = (VinaTextBox)Controls[DisciplineModule.DisciplineValueTextBoxName];

            if (DisciplineTypeLookupEdit.EditValue.ToString() == DisciplineType.Percent.ToString())
            {
                DisciplineValueTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                DisciplineValueTextBox.Properties.Mask.EditMask = "n";
                DisciplineValueTextBox.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            if (DisciplineTypeLookupEdit.EditValue.ToString() == DisciplineType.Amount.ToString())
            {
                DisciplineValueTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                DisciplineValueTextBox.Properties.Mask.EditMask = "n";
                DisciplineValueTextBox.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            if (DisciplineTypeLookupEdit.EditValue.ToString() == DisciplineType.Other.ToString())
            {
                DisciplineValueTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                DisciplineValueTextBox.Properties.Mask.UseMaskAsDisplayFormat = false;
            }

        }

        public override void ActionComplete()
        {
            DisciplineEntities entity = (DisciplineEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }
    }
}
