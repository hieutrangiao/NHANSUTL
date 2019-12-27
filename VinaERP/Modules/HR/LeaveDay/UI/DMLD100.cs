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


namespace VinaERP.Modules.LeaveDay.UI
{
    public partial class DMLD100 : VinaERPScreen
    {
        public DMLD100()
        {
            InitializeComponent();
        }

        public void InitGridControl()
        {
            fld_dgcHRDepartmentRooms.Screen = this;
            fld_dgcHRDepartmentRooms.InitializeControl();
            LeaveDayEntities entity = (LeaveDayEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.LeaveDaysList.InitVinaListGridControl(fld_dgcHRDepartmentRooms);
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
            fld_lkeHREmployeeStatusCombo.Screen = this;
            fld_lkeHREmployeeStatusCombo.InitializeControl();

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
            string status = Convert.ToString(fld_lkeHREmployeeStatusCombo.EditValue);

            ((LeaveDayModule)Module).ViewLeaveDays(branchID, departmentID, departmentRoomID, departmentRoomGroupItemID, employeeID, dateFrom, dateTo, status);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ((LeaveDayModule)Module).SaveLeaveDays(fld_dteDateFrom.DateTime, fld_dteToDate.DateTime);
        }

        public void InitializeLeaveDayFromGridControl()
        {
            fld_dgcHRDepartmentRooms.FromDate = fld_dteDateFrom.DateTime;
            if (fld_dteDateFrom.DateTime > fld_dteToDate.DateTime)
            {
                fld_dteToDate.DateTime = fld_dteDateFrom.DateTime;
            }
            else if ((fld_dteToDate.DateTime - fld_dteDateFrom.DateTime).TotalDays > 31)
            {
                fld_dteToDate.DateTime = fld_dteDateFrom.DateTime.AddDays(30);
            }
            fld_dgcHRDepartmentRooms.ToDate = fld_dteToDate.DateTime;
            fld_dgcHRDepartmentRooms.InitializeControl();
        }

        private void fld_dteDateFrom_Validated(object sender, EventArgs e)
        {
            InitializeLeaveDayFromGridControl();
        }

        private void fld_dteToDate_Validated(object sender, EventArgs e)
        {
            InitializeLeaveDayFromGridControl();
        }
    }
}