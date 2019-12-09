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
        public VinaList<HRFormAllowancesInfo> FormAllowancesList { get; set; }
        public VinaList<ADOTFactorsInfo> OTFactorsList { get; set; }
        public VinaList<HRTimesheetEmployeeLateConfigsInfo> TimesheetEmployeeLateConfigsList { get; set; }
        public CompanyConstantEntities()
            : base()
        {
            RewardTypesList = new VinaList<ADConfigValuesInfo>();
            DisciplineTypesList = new VinaList<ADConfigValuesInfo>();
            WorkingShiftGroupsList = new VinaList<ADWorkingShiftGroupsInfo>();
            FormAllowancesList = new VinaList<HRFormAllowancesInfo>();
            OTFactorsList = new VinaList<ADOTFactorsInfo>();
            TimesheetEmployeeLateConfigsList = new VinaList<HRTimesheetEmployeeLateConfigsInfo>();
        }

        public override void InitModuleObjectList()
        {
            RewardTypesList.InitVinaList(this, string.Empty, "ADConfigValues", VinaList<ADConfigValuesInfo>.cstRelationNone);
            DisciplineTypesList.InitVinaList(this, string.Empty, "ADConfigValues", VinaList<ADConfigValuesInfo>.cstRelationNone);
            WorkingShiftGroupsList.InitVinaList(this, string.Empty, "ADWorkingShiftGroups", VinaList<ADWorkingShiftGroupsInfo>.cstRelationNone);
            FormAllowancesList.InitVinaList(this, string.Empty, "HRFormAllowances", VinaList<HRFormAllowancesInfo>.cstRelationNone);
            OTFactorsList.InitVinaList(this, string.Empty, "ADOTFactors", VinaList<ADOTFactorsInfo>.cstRelationNone);
            TimesheetEmployeeLateConfigsList.InitVinaList(this, string.Empty, "HRTimesheetEmployeeLateConfigs", VinaList<HRTimesheetEmployeeLateConfigsInfo>.cstRelationNone);
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                RewardTypesList.SetDefaultListAndRefreshGridControl();
                DisciplineTypesList.SetDefaultListAndRefreshGridControl();
                WorkingShiftGroupsList.SetDefaultListAndRefreshGridControl();
                FormAllowancesList.SetDefaultListAndRefreshGridControl();
                OTFactorsList.SetDefaultListAndRefreshGridControl();
                TimesheetEmployeeLateConfigsList.SetDefaultListAndRefreshGridControl();
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
            List<ADWorkingShiftGroupsInfo> wsgList = objWorkingShiftGroupsController.GetAllWorkingShiftGroup();
            WorkingShiftGroupsList.Invalidate(wsgList);

            HRFormAllowancesController objFormAllowancesController = new HRFormAllowancesController();
            List<HRFormAllowancesInfo> faList = objFormAllowancesController.GetAllFormAllowances();
            FormAllowancesList.Invalidate(faList);

            ADOTFactorsController objOTFactorsController = new ADOTFactorsController();
            List<ADOTFactorsInfo> otfList = objOTFactorsController.GetAllOTFactors();
            OTFactorsList.Invalidate(otfList);

            HRTimesheetEmployeeLateConfigsController objTimesheetEmployeeLateConfigsController = new HRTimesheetEmployeeLateConfigsController();
            List<HRTimesheetEmployeeLateConfigsInfo> telcList = objTimesheetEmployeeLateConfigsController.GetAllTimesheetEmployeeLateConfigs();
            TimesheetEmployeeLateConfigsList.Invalidate(telcList);

        }
    }
}
