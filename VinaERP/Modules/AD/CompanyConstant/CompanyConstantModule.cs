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

        public void RemoveSelectedItemFromRewardTypesList()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            entity.RewardTypesList.RemoveSelectedRowObjectFromList();
        }

        public void SaveRewardTypesList()
        {
            SaveConfigValues(ConfigValueGroup.RewardType.ToString());
        }

        public bool SaveConfigValues(String strGroup)
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)CurrentModuleEntity;
            VinaList<ADConfigValuesInfo> configValues = null;
            if (strGroup == ConfigValueGroup.RewardType.ToString())
            {
                configValues = entity.RewardTypesList;
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
            return true;
        }
    }
}
