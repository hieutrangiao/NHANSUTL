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
using VinaLib.BaseProvider;


namespace VinaERP.Modules.ManagerTimeKeeper.UI
{
    public partial class DMMT102 : VinaERPScreen
    {
        public DMMT102()
        {
            InitializeComponent();
        }

        public void InitGridControl()
        {
            fld_dgcHRTimeKeepers.Screen = this;
            fld_dgcHRTimeKeepers.InitializeControl();
            fld_dgcHRMachineTimeKeepers.Screen = this;
            fld_dgcHRMachineTimeKeepers.InitializeControl();
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.TimeKeepersList.InitVinaListGridControl(fld_dgcHRTimeKeepers);
            entity.MachineTimeKeepersList.InitVinaListGridControl(fld_dgcHRMachineTimeKeepers);

            fld_dteDateFrom.DateTime = DateTime.Now.AddDays(-15);
            fld_dteToDate.DateTime = DateTime.Now;
        }

        private void fld_btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = fld_dteDateFrom.DateTime;
            DateTime dateTo = fld_dteToDate.DateTime;

            ((ManagerTimeKeeperModule)this.Module).DownloadAndShowData(dateFrom, dateTo);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ((ManagerTimeKeeperModule)this.Module).ActionQuickImportTimeSheet();
        }

        public void InitializeManagerTimeKeeperFromGridControl()
        {
            //fld_dgcHRDepartmentRooms.FromDate = fld_dteDateFrom.DateTime;
            if (fld_dteDateFrom.DateTime > fld_dteToDate.DateTime)
            {
                fld_dteToDate.DateTime = fld_dteDateFrom.DateTime;
            }
            else if ((fld_dteToDate.DateTime - fld_dteDateFrom.DateTime).TotalDays > 31)
            {
                fld_dteToDate.DateTime = fld_dteDateFrom.DateTime.AddDays(30);
            }
            //fld_dgcHRDepartmentRooms.ToDate = fld_dteToDate.DateTime;
            //fld_dgcHRTimeKeeperCompletes.InitializeControl();
        }

        private void fld_dteDateFrom_Validated(object sender, EventArgs e)
        {
            InitializeManagerTimeKeeperFromGridControl();
        }

        private void fld_dteToDate_Validated(object sender, EventArgs e)
        {
            InitializeManagerTimeKeeperFromGridControl();
        }
    }
}