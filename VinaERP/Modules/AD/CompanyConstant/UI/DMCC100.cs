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
        public DMCC100()
        {
            InitializeComponent();
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
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.RewardTypesList.InitVinaListGridControl(fld_dgcRewardTypes);
            entity.DisciplineTypesList.InitVinaListGridControl(fld_dgcDisciplineTypes);
            entity.WorkingShiftGroupsList.InitVinaListGridControl(fld_dgcADWorkingShiftGroups);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ((CompanyConstantModule)Module).SaveDisciplineTypesList();
        }
    }
}