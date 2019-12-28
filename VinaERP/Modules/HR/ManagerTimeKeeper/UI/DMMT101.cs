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
    public partial class DMMT101 : VinaERPScreen
    {
        public DMMT101()
        {
            InitializeComponent();
        }

        public void InitGridControl()
        {
            fld_dgcHRTimeKeeperCompletesView.Screen = this;
            fld_dgcHRTimeKeeperCompletesView.InitializeControl();
            fld_dgcHRTimeKeeperCompletesView2.Screen = this;
            fld_dgcHRTimeKeeperCompletesView2.InitializeControl();
            ManagerTimeKeeperEntities entity = (ManagerTimeKeeperEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.TimeKeeperCompleteListView.InitVinaListGridControl(fld_dgcHRTimeKeeperCompletesView);
            entity.TimeKeeperCompleteListView2.InitVinaListGridControl(fld_dgcHRTimeKeeperCompletesView2);
            fld_lkeHREmployeeID.Screen = this;
            fld_lkeHREmployeeID.InitializeControl();

            fld_lkeFK_BRBranchID.Screen = this;
            fld_lkeFK_BRBranchID.InitializeControl();
            fld_lkeFK_HRDepartmentID.Screen = this;
            fld_lkeFK_HRDepartmentID.InitializeControl();
            fld_lkeFK_HRDepartmentRoomID.Screen = this;
            fld_lkeFK_HRDepartmentRoomID.InitializeControl();
            fld_lkeFK_HRDepartmentRoomGroupItemID.Screen = this;
            fld_lkeFK_HRDepartmentRoomGroupItemID.InitializeControl();

            fld_dteDateFrom.DateTime = DateTime.Now.AddDays(-15);
            fld_dteToDate.DateTime = DateTime.Now;

            HREmployeesController objEmployeesController = new HREmployeesController();
            fld_lkeHREmployeeID.Properties.DataSource = objEmployeesController.GetAllEmployees();
        }

        private void fld_btnSearch_Click(object sender, EventArgs e)
        {
            int branchID = Convert.ToInt32(fld_lkeFK_BRBranchID.EditValue);
            int departmentID = Convert.ToInt32(fld_lkeFK_HRDepartmentID.EditValue);
            int departmentRoomID = Convert.ToInt32(fld_lkeFK_HRDepartmentRoomID.EditValue);
            int employeeID = Convert.ToInt32(fld_lkeHREmployeeID.EditValue);
            int departmentRoomGroupItemID = Convert.ToInt32(fld_lkeFK_HRDepartmentRoomGroupItemID.EditValue);

            DateTime dateFrom = fld_dteDateFrom.DateTime;
            DateTime dateTo = fld_dteToDate.DateTime;
            ((ManagerTimeKeeperModule)this.Module).GetDataCompleted(branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, dateFrom, dateTo);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ((ManagerTimeKeeperModule)this.Module).SaveDataCompletedView();
        }

        public void InitializeManagerTimeKeeperFromGridControl()
        {
            if (fld_dteDateFrom.DateTime > fld_dteToDate.DateTime)
            {
                fld_dteToDate.DateTime = fld_dteDateFrom.DateTime;
            }
            else if ((fld_dteToDate.DateTime - fld_dteDateFrom.DateTime).TotalDays > 31)
            {
                fld_dteToDate.DateTime = fld_dteDateFrom.DateTime.AddDays(30);
            }
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