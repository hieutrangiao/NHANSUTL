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

namespace VinaERP.Modules.ManagerTimeKeeper
{
    public partial class guiQuickImportTimeSheet : VinaERPScreen
    {
        private GridControlHelper GridControlHelper;
        private GridControlHelper GridControlHelper2;
        private List<HREmployeesInfo> EmployeesList { get; set; }
        public List<HRTimeKeepersInfo> SelectTimeKeepersList{ get; set; }

        public List<HRTimeKeepersInfo> TimeKeepersList { get; set; }
        public IList SelectedObjects { get; set; }
        public DateTime EmployeeOTDate { get; set; }
        public DateTime EmployeeOTDateEnd { get; set; }
        public DateTime EmployeeOTFromDate { get; set; }
        public DateTime EmployeeOTToDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public guiQuickImportTimeSheet(List<HREmployeesInfo> employeesList)
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

            GridView gridView2 = (GridView)fld_dgcHRTimeKeepers2.MainView;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsMenu.EnableFooterMenu = false;
            GridControlHelper2 = new GridControlHelper(gridView2);
            gridView.ExpandAllGroups();

            fld_dteDateFrom.DateTime = DateTime.Now;
            fld_dteToDate.DateTime = DateTime.Now;
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
            SelectTimeKeepersList = GridControlHelper2.Selection.OfType<HRTimeKeepersInfo>().ToList();
            TimeIn = DateTime.Parse(fld_txtTimeFromDate.EditValue.ToString());
            TimeOut = DateTime.Parse(fld_txtTimeToDate.EditValue.ToString());
            if (SelectedObjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (SelectTimeKeepersList.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ngày nhập công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            string status = string.Empty;
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

        private void fld_dteDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_dteDateFrom.DateTime.Date > fld_dteToDate.DateTime.Date)
            {
                fld_dteDateFrom.DateTime = fld_dteToDate.DateTime;
            }
            FromDate = fld_dteDateFrom.DateTime;
            ToDate = fld_dteToDate.DateTime;
            DateTime date;
            if (FromDate != DateTime.MaxValue)
                date = DateTime.Now;
            else
                date = FromDate;
            if (ToDate == DateTime.MaxValue)
                ToDate = DateTime.Now;
            List<HRTimeKeepersInfo> list = new List<HRTimeKeepersInfo>();
            HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();

            while (date.Date <= ToDate.Date)
            {
                objTimeKeepersInfo = new HRTimeKeepersInfo();
                objTimeKeepersInfo.HRTimeKeeperQuickImportDate = date;
                objTimeKeepersInfo.ThName = ((ManagerTimeKeeperModule)this.Module).GetThName(date);
                list.Add(objTimeKeepersInfo);
                date = date.AddDays(1);
            }

            if (list != null && list.Count > 0)
            {
                TimeKeepersList = list;
            }

            fld_dgcHRTimeKeepers2.InvalidateDataSource(list);
            GridView gridView = (GridView)fld_dgcHRTimeKeepers2.MainView;
            gridView.ExpandAllGroups();
        }

        private void fld_dteToDate_EditValueChanged(object sender, EventArgs e)
        {
            if (fld_dteDateFrom.DateTime.Date > fld_dteToDate.DateTime.Date)
            {
                fld_dteDateFrom.DateTime = fld_dteToDate.DateTime;
            }
            FromDate = fld_dteDateFrom.DateTime;
            ToDate = fld_dteToDate.DateTime;
            DateTime date;
            if (FromDate != DateTime.MaxValue)
                date = DateTime.Now;
            else
                date = FromDate;
            if (ToDate == DateTime.MaxValue)
                ToDate = DateTime.Now;
            List<HRTimeKeepersInfo> list = new List<HRTimeKeepersInfo>();
            HRTimeKeepersInfo objTimeKeepersInfo = new HRTimeKeepersInfo();

            while (date.Date <= ToDate.Date)
            {
                objTimeKeepersInfo = new HRTimeKeepersInfo();
                objTimeKeepersInfo.HRTimeKeeperQuickImportDate = date;
                objTimeKeepersInfo.ThName = ((ManagerTimeKeeperModule)this.Module).GetThName(date);
                list.Add(objTimeKeepersInfo);
                date = date.AddDays(1);
            }

            if (list != null && list.Count > 0)
            {
                TimeKeepersList = list;
            }

            fld_dgcHRTimeKeepers2.InvalidateDataSource(list);
            GridView gridView = (GridView)fld_dgcHRTimeKeepers2.MainView;
            gridView.ExpandAllGroups();
        }
    }
}