using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP
{
    public class HREmployeesGridControl : VinaGridControl
    {
        public void InvalidateDataSource(List<HREmployeesInfo> datasource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datasource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            //GridColumn column = new GridColumn();
            //column.Caption = "Chọn";
            //column.FieldName = "Selected";
            //gridView.Columns.Add(column);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["HREmployeeName"];
            if (column != null)
            {
                column.Caption = "Tên nhân viên";
            }
            return gridView;
        }
    }
}
