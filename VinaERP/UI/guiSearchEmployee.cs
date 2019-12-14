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
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;

namespace VinaERP
{
    public partial class guiSearchEmployee : VinaERPScreen
    {
        private GridControlHelper GridControlHelper;
        private List<HREmployeesInfo> EmployeesList { get; set; }
        public IList SelectedObjects { get; set; }
        public DateTime EmployeeOTDate { get; set; }
        public DateTime EmployeeOTDateEnd { get; set; }
        public DateTime EmployeeOTFromDate { get; set; }
        public DateTime EmployeeOTToDate { get; set; }
        public guiSearchEmployee(List<HREmployeesInfo> employeesList)
        {
            InitializeComponent();
            EmployeesList = employeesList;
        }

        private void guiChooseSaleOrderItem_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            SelectedObjects = new List<HREmployeesInfo>();

            GridView gridView = (GridView)fld_dgcHREmployees.MainView;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsMenu.EnableFooterMenu = false;
            GridControlHelper = new GridControlHelper(gridView);
            gridView.ExpandAllGroups();
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            SelectedObjects = GridControlHelper.Selection.OfType<HREmployeesInfo>().ToList();
            if (SelectedObjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_btnSearch_Click(object sender, EventArgs e)
        {
            GetDataSource();
        }

        public void GetDataSource()
        {
            HREmployeesController objEmployeesController = new HREmployeesController();
            int branchID = Convert.ToInt32(fld_lkeFK_BRBranchID.EditValue);
            int departmentID = Convert.ToInt32(fld_lkeFK_HRDepartmentID.EditValue);
            int departmentRoomID = Convert.ToInt32(fld_lkeFK_HRDepartmentRoomID.EditValue);
            int departmentRoomGroupItemID = Convert.ToInt32(fld_lkeFK_HRDepartmentRoomGroupItemID.EditValue);
            int employeePayrollFormulaID = Convert.ToInt32(fld_lkeFK_HREmployeePayrollFormulaID.EditValue);
            string status = Convert.ToString(fld_lkeHREmployeeStatusCombo.EditValue);
            List<HREmployeesInfo> employeesList = EmployeesList.Where(o1 => (o1.FK_BRBranchID == branchID || branchID == 0)
                                                                            && (o1.FK_HRDepartmentID == departmentID || departmentID == 0)
                                                                            && (o1.FK_HRDepartmentRoomID == departmentRoomID || departmentRoomID == 0)
                                                                            && (o1.FK_HRDepartmentRoomGroupItemID == departmentRoomGroupItemID || departmentRoomGroupItemID == 0)
                                                                            && (o1.FK_HREmployeePayrollFormulaID == employeePayrollFormulaID || employeePayrollFormulaID == 0)
                                                                            && (o1.HREmployeeStatusCombo == status || string.IsNullOrEmpty(status)))
                                                               .ToList();
            employeesList.ForEach(o1 =>
            {
                o1.HREmployeeOTDate = EmployeeOTDate;
                o1.HREmployeeOTDateEnd = EmployeeOTDateEnd;
                o1.HREmployeeOTFromDate = EmployeeOTFromDate;
                o1.HREmployeeOTToDate = EmployeeOTToDate;
            });
            
            fld_dgcHREmployees.DataSource = employeesList;
        }
    }
}