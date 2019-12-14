using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaCommon;
using VinaLib;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Reward
{

    public class RewardModule : BaseModuleERP
    {
        #region Constant
        public const string RewardTypeLookupEditName = "fld_lkeHRRewardType";
        public const string RewardValueTextBoxName = "fld_txtHRRewardValue";
        #endregion
        public RewardModule()
        {
            CurrentModuleName = "Reward";
            CurrentModuleEntity = new RewardEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            GetEmployeesList();
        }

        public void GetEmployeesList()
        {
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
            HREmployeesController objEmployeesController = new HREmployeesController();
            entity.EmployeesList = objEmployeesController.GetAllEmployees();
        }

        public override int ActionSave()
        {
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
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
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
            HRRewardsInfo mainObject = (HRRewardsInfo)entity.MainObject;

            ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
            if (mainObject.HRRewardID > 0)
            {
                if(mainObject.HRRewardStatus == RewardStatus.New.ToString())
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

        public void RemoveSelectedItemFromRewardItemList()
        {
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
            entity.EmployeeRewardsList.RemoveSelectedRowObjectFromList();
        }

        public void AddEmployee()
        {
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;

            List<HREmployeesInfo> employeesList = entity.EmployeesList.Where(o1 => entity.EmployeeRewardsList.FirstOrDefault(o2 => o2.FK_HREmployeeID == o1.HREmployeeID) == null).ToList();

            guiSearchEmployee guiSearchEmployee = new guiSearchEmployee(employeesList);
            guiSearchEmployee.Module = this;
            if (guiSearchEmployee.ShowDialog() == DialogResult.OK)
            {
                List<HREmployeesInfo> result = (List<HREmployeesInfo>)guiSearchEmployee.SelectedObjects;
                foreach (HREmployeesInfo objEmployeesInfo in result)
                {
                    HREmployeeRewardsInfo objEmployeeRewardsInfo = new HREmployeeRewardsInfo();
                    entity.SetDefaultValuesFromEmployee(objEmployeeRewardsInfo, objEmployeesInfo);
                    entity.EmployeeRewardsList.Add(objEmployeeRewardsInfo);
                }
                entity.EmployeeRewardsList.GridControl.RefreshDataSource();
            }
        }

        public void UpdateValue()
        {
            decimal result = 0;
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
            HRRewardsInfo mainObject = (HRRewardsInfo)entity.MainObject;
            decimal rewardValue = 0;
            decimal.TryParse(mainObject.HRRewardValue, out rewardValue);
            entity.EmployeeRewardsList.ForEach(o1 =>
            {
                o1.HREmployeeRewardValue = mainObject.HRRewardValue;
                o1.HREmployeeRewardValueAmount = rewardValue;
            });
            entity.EmployeeRewardsList.GridControl.RefreshDataSource();
        }

        public void UpdateItemDate()
        {
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
            HRRewardsInfo mainObject = (HRRewardsInfo)entity.MainObject;
            entity.EmployeeRewardsList.ForEach(o1 => o1.HREmployeeRewardDate = mainObject.HRRewardFromDate);
            entity.EmployeeRewardsList.GridControl.RefreshDataSource();
        }

        public void SetMaskForTextBox()
        {
            VinaLookupEdit rewardTypeLookupEdit = (VinaLookupEdit)Controls[RewardModule.RewardTypeLookupEditName];
            VinaTextBox rewardValueTextBox = (VinaTextBox)Controls[RewardModule.RewardValueTextBoxName];

            if (rewardTypeLookupEdit.EditValue.ToString() == RewardType.Percent.ToString())
            {
                rewardValueTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                rewardValueTextBox.Properties.Mask.EditMask = "n";
                rewardValueTextBox.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            if (rewardTypeLookupEdit.EditValue.ToString() == RewardType.Amount.ToString())
            {
                rewardValueTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                rewardValueTextBox.Properties.Mask.EditMask = "n";
                rewardValueTextBox.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            if (rewardTypeLookupEdit.EditValue.ToString() == RewardType.Other.ToString())
            {
                rewardValueTextBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                rewardValueTextBox.Properties.Mask.UseMaskAsDisplayFormat = false;
            }

        }

        public override void ActionComplete()
        {
            RewardEntities entity = (RewardEntities)CurrentModuleEntity;
            entity.CompleteTransaction();
            InvalidateToolbar();
        }
    }
}
