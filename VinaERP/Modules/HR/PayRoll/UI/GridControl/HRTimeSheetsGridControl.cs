using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP.Modules.PayRoll
{
    public class HRTimeSheetsGridControl : VinaGridControl
    {
        public void InvalidateDataSource(List<HRTimeSheetsInfo> datasource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datasource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            return gridView;
        }
    }
}
