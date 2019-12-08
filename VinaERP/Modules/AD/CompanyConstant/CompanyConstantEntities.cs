using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common.Constant.AD;
using VinaLib;

namespace VinaERP.Modules.CompanyConstant
{
    public class CompanyConstantEntities : ERPModuleEntities
    {
        public VinaList<ADUsersInfo> ADUserList { get; set; }
        public VinaList<ADConfigValuesInfo> RewardTypesList { get; set; }
        public CompanyConstantEntities()
            : base()
        {
            ADUserList = new VinaList<ADUsersInfo>();
            RewardTypesList = new VinaList<ADConfigValuesInfo>();
        }

        public override void InitModuleObjectList()
        {
            ADUserList.InitVinaList(this, string.Empty, "ADUsers", VinaList<ADUsersInfo>.cstRelationNone);
            RewardTypesList.InitVinaList(this, string.Empty, "ADConfigValues", VinaList<ADConfigValuesInfo>.cstRelationNone);
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ADUserList.SetDefaultListAndRefreshGridControl();
                RewardTypesList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception) { }
        }

        public void InvalidateData()
        {
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            DataSet ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.RewardType.ToString());
            RewardTypesList.Invalidate(ds);
        }
    }
}
