using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Utilities;

namespace VinaERP.Modules.SaleOrder
{
    public class ARProposalsGridControl : VinaGridControl
    {
        public void InvalidateDataSource(List<ARProposalsInfo> datasource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datasource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            foreach (GridColumn columnedit in gridView.Columns)
            {
                columnedit.OptionsColumn.AllowEdit = false;
            }
            return gridView;
        }
    }
}
