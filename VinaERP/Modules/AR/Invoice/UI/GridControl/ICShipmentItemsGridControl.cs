using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaERP.Modules.Invoice
{
    public class ICShipmentItemsGridControl : VinaGridControl
    {
        public void InvalidateDataSource(List<ICShipmentItemsInfo> datasource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datasource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = new GridColumn();
            column.Caption = "Mã đơn bán hàng";
            column.FieldName = "ARSaleOrderNo";
            gridView.Columns.Add(column);
            column = gridView.Columns["ARSaleOrderNo"];
            if (column != null)
            {
                column.Group();
            }
            foreach (GridColumn columnedit in gridView.Columns)
            {
                columnedit.OptionsColumn.AllowEdit = false;
            }
            return gridView;
        }
    }
}
