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
        public VinaList<ADConfigValuesInfo> RewardTypesList { get; set; }
        public VinaList<ADConfigValuesInfo> DisciplineTypesList { get; set; }

        public VinaList<ADWorkingShiftGroupsInfo> WorkingShiftGroupsList { get; set; }
        public CompanyConstantEntities()
            : base()
        {
            RewardTypesList = new VinaList<ADConfigValuesInfo>();
            DisciplineTypesList = new VinaList<ADConfigValuesInfo>();
            WorkingShiftGroupsList = new VinaList<ADWorkingShiftGroupsInfo>();
        }

        public override void InitModuleObjectList()
        {
            RewardTypesList.InitVinaList(this, string.Empty, "ADConfigValues", VinaList<ADConfigValuesInfo>.cstRelationNone);
            DisciplineTypesList.InitVinaList(this, string.Empty, "ADConfigValues", VinaList<ADConfigValuesInfo>.cstRelationNone);
            WorkingShiftGroupsList.InitVinaList(this, string.Empty, "ADWorkingShiftGroupsInfo", VinaList<ADWorkingShiftGroupsInfo>.cstRelationNone);
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                RewardTypesList.SetDefaultListAndRefreshGridControl();
                DisciplineTypesList.SetDefaultListAndRefreshGridControl();
                WorkingShiftGroupsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception) { }
        }

        public void InvalidateData()
        {
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            DataSet ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.RewardType.ToString());
            RewardTypesList.Invalidate(ds);

            ds = objConfigValuesController.GetADConfigValuesByGroup(ConfigValueGroup.DisciplineType.ToString());
            DisciplineTypesList.Invalidate(ds);

            ADWorkingShiftGroupsController objWorkingShiftGroupsController = new ADWorkingShiftGroupsController();
            List<ADWorkingShiftGroupsInfo> list = objWorkingShiftGroupsController.GetAllWorkingShiftGroup();
            WorkingShiftGroupsList.Invalidate(list);
        }
    }
}
