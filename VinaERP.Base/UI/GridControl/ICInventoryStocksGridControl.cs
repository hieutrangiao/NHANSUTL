using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace VinaERP.Base.UI.GridControl
{
    public class ICInventoryStocksGridControl : VinaGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            ICStocksController objStocksController = new ICStocksController();
            GridColumn column = new GridColumn();
            column.Caption = "Kho";
            column.FieldName = "FK_ICStockID";
            column.OptionsColumn.AllowEdit = false;
            RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit.DisplayMember = "ICStockName";
            repositoryItemLookUpEdit.ValueMember = "ICStockID";
            repositoryItemLookUpEdit.DataSource = objStocksController.GetAllStockByStockType(null);
            column.ColumnEdit = repositoryItemLookUpEdit;
            column.Visible = true;
            column.VisibleIndex = 1;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Mã lô hàng";
            column.FieldName = "ICTransactionReceiptSerialNo";
            column.OptionsColumn.AllowEdit = false;
            column.Visible = true;
            column.VisibleIndex = 2;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Số lượng";
            column.FieldName = "ICTransactionExchangeQty";
            column.OptionsColumn.AllowEdit = false;
            FormatNumbericColumn(column, false, "n3");
            column.Visible = true;
            column.VisibleIndex = 3;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "SL đặt bán";
            column.FieldName = "ICTransactionSaleOrderQty";
            column.OptionsColumn.AllowEdit = false;
            FormatNumbericColumn(column, false, "n3");
            column.Visible = true;
            column.VisibleIndex = 4;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "SL có thể sử dụng";
            column.FieldName = "ICTransactionAvailableQty";
            column.OptionsColumn.AllowEdit = false;
            FormatNumbericColumn(column, false, "n3");
            column.Visible = true;
            column.VisibleIndex = 5;
            gridView.Columns.Add(column);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            GridColumn column = gridView.Columns["FK_ICStockID"];
            if (column != null)
            {
                column.Group();
            }
            column = gridView.Columns["ICTransactionExchangeQty"];
            if (column != null)
            { 
                column.SummaryItem.DisplayFormat = "{0:0.####}";
            }
            column = gridView.Columns["ICTransactionSaleOrderQty"];
            if (column != null)
            {
                column.SummaryItem.DisplayFormat = "{0:0.####}";
            }
            column = gridView.Columns["ICTransactionAvailableQty"];
            if (column != null)
            {
                column.SummaryItem.DisplayFormat = "{0:0.####}";
            }
            gridView.EndGrouping += GridView_EndGrouping;
            return gridView;
        }

        private void GridView_EndGrouping(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            gridView.ExpandAllGroups();
        }
    }
}
