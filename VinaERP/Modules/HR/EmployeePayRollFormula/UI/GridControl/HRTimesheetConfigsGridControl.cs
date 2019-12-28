using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaLib;

namespace VinaERP.Modules.EmployeePayRollFormula
{
    public partial class HRTimesheetConfigsGridControl : VinaGridControl
    {

        public override void InitGridControlDataSource()
        {
            EmployeePayRollFormulaEntities entity = (EmployeePayRollFormulaEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.TimesheetConfigsList;
            this.DataSource = bds;
        }


        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            foreach (GridColumn col in gridView.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
            }
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GridColumn column = gridView.Columns["HRTimesheetConfigYear"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "yyyy";
            }
            gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(GridView_CellValueChanging);
            return gridView;
        }

        private void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (e.Column.FieldName != "HRTimesheetConfigYear")
            {
                if (MessageBox.Show("Bạn có muốn áp dụng cho tất cả các tháng khác?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HRTimesheetConfigsInfo obj = (HRTimesheetConfigsInfo)gridView.GetRow(e.RowHandle);
                    obj.HRTimesheetConfigJan = obj.HRTimesheetConfigFeb = obj.HRTimesheetConfigApr = obj.HRTimesheetConfigAug =
                        obj.HRTimesheetConfigDec = obj.HRTimesheetConfigJul = obj.HRTimesheetConfigJun = obj.HRTimesheetConfigMar =
                        obj.HRTimesheetConfigMay = obj.HRTimesheetConfigNov = obj.HRTimesheetConfigOct = obj.HRTimesheetConfigSep = int.Parse(e.Value.ToString());
                }
            }
        }
    }
}
