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
    public class ARSaleOrderItemsGridControl : ItemGridControl
    {
        public override void InitGridControlDataSource()
        {
            SaleOrderEntities entity = (SaleOrderEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.SaleOrderItemsList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ARSaleOrderItemProductUnitPrice"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemDiscountPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ARSaleOrderItemDiscountAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemTaxPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ARSaleOrderItemTaxAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemTotalAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARSaleOrderItemProductQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["FK_ICStockID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["ARSaleOrderItemStockLotNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["ARSaleOrderItemGrantedFrom"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((SaleOrderModule)Screen.Module).DeleteItemFromSaleOrderItemsList();
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            GridView gridView = (GridView)sender;
            SaleOrderEntities entity = (SaleOrderEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
            if (entity.SaleOrderItemsList.CurrentIndex >= 0)
            {
                ARSaleOrderItemsInfo item = (ARSaleOrderItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (e.Column.FieldName == "ARSaleOrderItemDiscountAmount")
                {
                    ((SaleOrderModule)Screen.Module).ChangeItemDiscountAmount();
                }
                else if (e.Column.FieldName == "ARSaleOrderItemTaxAmount")
                {
                    ((SaleOrderModule)Screen.Module).ChangeItemTaxAmount();
                }
                ((SaleOrderModule)Screen.Module).ChangeItemFromSaleOrderItemsList(item);
            }
        }
    }
}
