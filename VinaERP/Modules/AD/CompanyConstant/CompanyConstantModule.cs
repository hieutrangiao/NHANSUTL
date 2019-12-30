using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaERP.Common.Constant.AD;
using VinaERP.Modules.CompanyConstant.UI;
using VinaLib;

namespace VinaERP.Modules.CompanyConstant
{
    public class CompanyConstantModule : BaseModuleERP
    {
        public CompanyConstantModule()
        {
            CurrentModuleName = ModuleName.CompanyConstantModule;
            CurrentModuleEntity = new CompanyConstantEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            InvalidateData();
        }

        public override void InitializeScreens()
        {
            this.ParentScreen.LeftPanelContainer.Hide();
            DMCC100 DMCC100 = new DMCC100();
            DMCC100.ScreenCode = "DMCC100";
            DMCC100.Module = this;
            DMCC100.Height -= 100;
            DMCC100.InitGridControl();
            Screens.Add(DMCC100);
            DMCC100.AddControlsToParentScreen();
        }

        public void InvalidateData()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.InvalidateData();
        }

        #region Remove Items
        public void RemoveSelectedItemFromRewardTypesList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.RewardTypesList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedItemFromDisciplineTypesList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.DisciplineTypesList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedItemFromWorkingShiftGroupList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.WorkingShiftGroupsList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedItemFromFormAllowancesList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.FormAllowancesList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedItemFromOTFactorsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.OTFactorsList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedItemFromTimesheetEmployeeLateConfigsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.TimesheetEmployeeLateConfigsList.RemoveSelectedRowObjectFromList();
        }

        public void RemoveSelectedItemFromTimesheetConfigsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.TimesheetConfigsList.RemoveSelectedRowObjectFromList();
        }
        public void RemoveSelectedItemFromWorkingShiftList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.WorkingShiftsList.RemoveSelectedRowObjectFromList();
        }
        #endregion

        #region Save List
        public void SaveRewardTypesList()
        {
            SaveConfigValues(ConfigValueGroup.RewardType.ToString());
        }

        public void SaveDisciplineTypesList()
        {
            SaveConfigValues(ConfigValueGroup.DisciplineType.ToString());
        }

        public void SaveTimeSheetParam1()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            foreach (HRTimeSheetParamsInfo objTimeSheetParamsInfo in entity.TimeSheetParamsList)
            {
                objTimeSheetParamsInfo.HRTimeSheetParamValue2 = objTimeSheetParamsInfo.HRTimeSheetParamValue2 / 100;
                if (objTimeSheetParamsInfo.HRTimeSheetParamID == 0)
                {
                    objTimeSheetParamsInfo.IsDefault = false;
                }
                objTimeSheetParamsInfo.IsOTCalculated = false;

            }
            entity.TimeSheetParamsList.SaveItemObjects();
            foreach (HRTimeSheetParamsInfo timeSheetParam in entity.TimeSheetParamsList)
            {
                timeSheetParam.HRTimeSheetParamValue2 = timeSheetParam.HRTimeSheetParamValue2 * 100;
            }
        }

        public void SaveTimeSheetParam2()
        {
        CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
        foreach (HRTimeSheetParamsInfo objTimeSheetParamsInfo in entity.TimeSheetParam2sList)
        {
            objTimeSheetParamsInfo.HRTimeSheetParamValue2 = objTimeSheetParamsInfo.HRTimeSheetParamValue2 / 100;
            objTimeSheetParamsInfo.IsOTCalculated = true;
            if (objTimeSheetParamsInfo.HRTimeSheetParamID == 0)
            {
                objTimeSheetParamsInfo.IsDefault = false;
                //objTimeSheetParamsInfo.HRTimeSheetParamValue2 = 1;
            }
            objTimeSheetParamsInfo.HRTimeSheetParamType = "Hour";
        }
        entity.TimeSheetParam2sList.SaveItemObjects();
        foreach (HRTimeSheetParamsInfo timeSheetParam in entity.TimeSheetParam2sList)
        {
            timeSheetParam.HRTimeSheetParamValue2 = timeSheetParam.HRTimeSheetParamValue2 * 100;
        }
    }

        public bool SaveConfigValues(String strGroup)
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            VinaList<ADConfigValuesInfo> configValues = null;
            if (strGroup == ConfigValueGroup.RewardType.ToString())
            {
                configValues = entity.RewardTypesList;
            }
            else if (strGroup == ConfigValueGroup.DisciplineType.ToString())
            {
                configValues = entity.DisciplineTypesList;
            }
            if (configValues != null)
            {
                foreach (ADConfigValuesInfo objConfigValuesInfo in configValues)
                {
                    if (objConfigValuesInfo.ADConfigValueID == 0)
                    {
                        objConfigValuesInfo.ADConfigKeyGroup = strGroup;
                        objConfigValuesInfo.ADConfigKeyValue = VinaApp.ConvertUnicodeStringToUnSign(objConfigValuesInfo.ADConfigText)
                                                                            .Replace(" ", string.Empty);
                        objConfigValuesInfo.ADConfigKey = string.Format("{0}{1}", strGroup, objConfigValuesInfo.ADConfigKeyValue);
                    }
                }
                configValues.SaveItemObjects();
            }

            if (VinaUtil.ADConfigValueUtility.ContainsKey(strGroup))
                VinaUtil.ADConfigValueUtility.Remove(strGroup);

            VinaUtil.ADConfigValueUtility.Add(strGroup, configValues);
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public void SaveWorkingShiftGroupsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.WorkingShiftGroupsList.SaveItemObjects();
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SaveFormAllowancesList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.FormAllowancesList.SaveItemObjects();
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SaveOTFactorsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.OTFactorsList.SaveItemObjects();
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SaveTimesheetEmployeeLateConfigsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.TimesheetEmployeeLateConfigsList.SaveItemObjects();
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SaveTimesheetConfigsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.TimesheetConfigsList.SaveItemObjects();
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void SaveWorkingShiftsList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.WorkingShiftsList.SaveItemObjects();
            XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        public void UpdateIns(decimal result)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật phí công đoàn cho tất cả nhân viên có tham gia BHXH không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                HREmployeesController objEmployeesController = new HREmployeesController();
                objEmployeesController.UpdateInsAllEmployee(result);
            }
        }

        public bool SaveInsurrances(ADInsurrancesInfo objInsurrancesInfo)
        {
            ADInsurrancesController objInsurrancesController = new ADInsurrancesController();
            if (objInsurrancesInfo != null)
            {
                if (objInsurrancesInfo.ADInsurranceID > 0)
                {
                    objInsurrancesController.UpdateObject(objInsurrancesInfo);
                }
                else
                {
                    objInsurrancesController.CreateObject(objInsurrancesInfo);
                }
            }
            return true;
        }
    }
}
