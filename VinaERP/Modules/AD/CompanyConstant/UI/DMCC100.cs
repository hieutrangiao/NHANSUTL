using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VinaERP.Common;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.CompanyConstant.UI
{
    public partial class DMCC100 : VinaERPScreen
    {
        public ADInsurrancesInfo objInsurrancesInfo = new ADInsurrancesInfo();
        public DMCC100()
        {
            InitializeComponent();
            ADInsurrancesController objInsurrancesController = new ADInsurrancesController();
            List<ADInsurrancesInfo> list = (List<ADInsurrancesInfo>)objInsurrancesController.GetListFromDataSet(objInsurrancesController.GetAllObjects());
            if (list != null && list.Count() > 0)
            {
                objInsurrancesInfo = (ADInsurrancesInfo)list.LastOrDefault();
                fld_txtHRInsurranceHealthInsPercent.EditValue = objInsurrancesInfo.HRInsurranceHealthInsPercent.ToString(); ;
                fld_txtHRInsurranceHealthInsPercentDN.EditValue = objInsurrancesInfo.HRInsurranceHealthInsPercentDN.ToString();
                fld_txtHRInsurranceOutOfWorkInsPercent.EditValue = objInsurrancesInfo.HRInsurranceOutOfWorkInsPercent.ToString();
                fld_txtHRInsurranceOutOfWorkInsPercentDN.EditValue = objInsurrancesInfo.HRInsurranceOutOfWorkInsPercentDN.ToString();
                fld_txtHRInsurranceSocialInsPercent.EditValue = objInsurrancesInfo.HRInsurranceSocialInsPercent.ToString();
                fld_txtHRInsurranceSocialInsPercentDN.EditValue = objInsurrancesInfo.HRInsurranceSocialInsPercentDN.ToString();
                fld_txtADInsurranceDependencyLevel.EditValue = objInsurrancesInfo.ADInsurranceDependencyLevel.ToString();
                fld_txtADInsurranceLevelNotTaxable.EditValue = objInsurrancesInfo.ADInsurranceLevelNotTaxable.ToString();
                fld_txtADInsurranceSyndicatePaymentPercent.EditValue = objInsurrancesInfo.ADInsurranceSyndicatePaymentPercent.ToString();
            }
        }

        private void fld_btnSaveRewardType_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveRewardTypesList();
        }

        public void InitGridControl()
        {
            fld_dgcRewardTypes.Screen = this;
            fld_dgcRewardTypes.InitializeControl();
            fld_dgcDisciplineTypes.Screen = this;
            fld_dgcDisciplineTypes.InitializeControl();
            fld_dgcADWorkingShiftGroups.Screen = this;
            fld_dgcADWorkingShiftGroups.InitializeControl();
            fld_dgcFormAllowances.Screen = this;
            fld_dgcFormAllowances.InitializeControl();
            fld_dgcOTFactors.Screen = this;
            fld_dgcOTFactors.InitializeControl();
            fld_dgcTimesheetEmployeeLateConfigs.Screen = this;
            fld_dgcTimesheetEmployeeLateConfigs.InitializeControl();
            fld_dgcADTimesheetConfigs.Screen = this;
            fld_dgcADTimesheetConfigs.InitializeControl();
            fld_dgcWorkingShifts.Screen = this;
            fld_dgcWorkingShifts.InitializeControl();
            fld_dgcTimeSheetParams.Screen = this;
            fld_dgcTimeSheetParams.InitializeControl();
            fld_dgcTimeSheetParams2.Screen = this;
            fld_dgcTimeSheetParams2.InitializeControl();
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.RewardTypesList.InitVinaListGridControl(fld_dgcRewardTypes);
            entity.DisciplineTypesList.InitVinaListGridControl(fld_dgcDisciplineTypes);
            entity.WorkingShiftGroupsList.InitVinaListGridControl(fld_dgcADWorkingShiftGroups);
            entity.FormAllowancesList.InitVinaListGridControl(fld_dgcFormAllowances);
            entity.OTFactorsList.InitVinaListGridControl(fld_dgcOTFactors);
            entity.TimesheetEmployeeLateConfigsList.InitVinaListGridControl(fld_dgcTimesheetEmployeeLateConfigs);
            entity.TimesheetConfigsList.InitVinaListGridControl(fld_dgcADTimesheetConfigs);
            entity.WorkingShiftsList.InitVinaListGridControl(fld_dgcWorkingShifts);
            entity.TimeSheetParamsList.InitVinaListGridControl(fld_dgcTimeSheetParams);
            entity.TimeSheetParam2sList.InitVinaListGridControl(fld_dgcTimeSheetParams2);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveDisciplineTypesList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveWorkingShiftGroupsList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveFormAllowancesList();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveOTFactorsList();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveTimesheetEmployeeLateConfigsList();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveTimesheetConfigsList();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            decimal ADInsurranceSyndicatePaymentPercent = 0;
            decimal.TryParse(fld_txtADInsurranceSyndicatePaymentPercent.EditValue.ToString(), out ADInsurranceSyndicatePaymentPercent);
            ((CompanyConstantModule)this.Module).UpdateIns(ADInsurranceSyndicatePaymentPercent);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            decimal HRInsurranceHealthInsPercent = 0;
            decimal HRInsurranceHealthInsPercentDN = 0;
            decimal HRInsurranceOutOfWorkInsPercent = 0;
            decimal HRInsurranceOutOfWorkInsPercentDN = 0;
            decimal HRInsurranceSocialInsPercent = 0;
            decimal HRInsurranceSocialInsPercentDN = 0;
            decimal ADInsurranceLevelNotTaxable = 0;
            decimal ADInsurranceDependencyLevel = 0;
            decimal ADInsurranceSyndicatePaymentPercent = 0;

            decimal.TryParse(fld_txtHRInsurranceHealthInsPercent.EditValue.ToString(), out HRInsurranceHealthInsPercent);
            decimal.TryParse(fld_txtHRInsurranceHealthInsPercentDN.EditValue.ToString(), out HRInsurranceHealthInsPercentDN);
            decimal.TryParse(fld_txtHRInsurranceOutOfWorkInsPercent.EditValue.ToString(), out HRInsurranceOutOfWorkInsPercent);
            decimal.TryParse(fld_txtHRInsurranceOutOfWorkInsPercentDN.EditValue.ToString(), out HRInsurranceOutOfWorkInsPercentDN);
            decimal.TryParse(fld_txtHRInsurranceSocialInsPercent.EditValue.ToString(), out HRInsurranceSocialInsPercent);
            decimal.TryParse(fld_txtHRInsurranceSocialInsPercentDN.EditValue.ToString(), out HRInsurranceSocialInsPercentDN);
            decimal.TryParse(fld_txtADInsurranceDependencyLevel.EditValue.ToString(), out ADInsurranceDependencyLevel);
            decimal.TryParse(fld_txtADInsurranceLevelNotTaxable.EditValue.ToString(), out ADInsurranceLevelNotTaxable);
            decimal.TryParse(fld_txtADInsurranceSyndicatePaymentPercent.EditValue.ToString(), out ADInsurranceSyndicatePaymentPercent);

            objInsurrancesInfo.HRInsurranceHealthInsPercent = HRInsurranceHealthInsPercent;
            objInsurrancesInfo.HRInsurranceHealthInsPercentDN = HRInsurranceHealthInsPercentDN;
            objInsurrancesInfo.HRInsurranceOutOfWorkInsPercent = HRInsurranceOutOfWorkInsPercent;
            objInsurrancesInfo.HRInsurranceOutOfWorkInsPercentDN = HRInsurranceOutOfWorkInsPercentDN;
            objInsurrancesInfo.HRInsurranceSocialInsPercent = HRInsurranceSocialInsPercent;
            objInsurrancesInfo.HRInsurranceSocialInsPercentDN = HRInsurranceSocialInsPercentDN;
            objInsurrancesInfo.ADInsurranceLevelNotTaxable = ADInsurranceLevelNotTaxable;
            objInsurrancesInfo.ADInsurranceDependencyLevel = ADInsurranceDependencyLevel;
            objInsurrancesInfo.ADInsurranceSyndicatePaymentPercent = ADInsurranceSyndicatePaymentPercent;

            bool check = ((Modules.CompanyConstant.CompanyConstantModule)this.Module).SaveInsurrances(objInsurrancesInfo);
            if (check)
            {
                XtraMessageBox.Show("Luu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveWorkingShiftsList();
        }
    }
}