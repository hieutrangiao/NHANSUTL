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

namespace VinaERP.Modules.SaleOrderShipment
{
    public class ARSaleOrderItemsGridControl : VinaGridControl
    {
        public void InvalidateDataSource(List<ARSaleOrderItemsInfo> datasource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datasource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsFind.ShowCloseButton = false;
            GridColumn column = gridView.Columns["ARSaleOrderItemProductUnitPrice"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemDiscountPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n2");
            }
            column = gridView.Columns["ARSaleOrderItemDiscountAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemTaxPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n2");
            }
            column = gridView.Columns["ARSaleOrderItemTaxAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemTotalAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemProductQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["FK_ICStockID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["ARSaleOrderItemStockLotNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
            }
            column = gridView.Columns["ARSaleOrderItemGrantedFrom"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
            }
            column = gridView.Columns["FK_ARSaleOrderID"];
            if (column != null)
            {
                column.Group();
            }
            return gridView;
        }
    }
}
