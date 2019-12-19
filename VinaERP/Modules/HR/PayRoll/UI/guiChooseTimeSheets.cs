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

namespace VinaERP.Modules.PayRoll.UI
{
    public partial class guiChooseTimeSheets : VinaERPScreen
    {
        private GridControlHelper GridControlHelper;
        private List<HRTimeSheetsInfo> TimeSheetsList { get; set; }
        public IList SelectedObjects { get; set; }
        public guiChooseTimeSheets(List<HRTimeSheetsInfo> timeSheetsList)
        {
            InitializeComponent();
            TimeSheetsList = timeSheetsList;
            
        }

        private void guiChooseSaleOrderItem_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            SelectedObjects = new List<HRTimeSheetsInfo>();
            fld_dgcICShipmentItems.InvalidateDataSource(TimeSheetsList);

            GridView gridView = (GridView)fld_dgcICShipmentItems.MainView;
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
            SelectedObjects = GridControlHelper.Selection.OfType<HRTimeSheetsInfo>().ToList();
            if (SelectedObjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (SelectedObjects.Count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 đối tượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}