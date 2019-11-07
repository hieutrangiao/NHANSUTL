using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib;

namespace VinaERP.Utilities
{
    public class ItemGridControl : VinaGridControl
    {
        private string SerieColumnName = string.Empty;

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            gridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(GridView_FocusedColumnChanged);
            return gridView;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            ShowInventory();
        }

        protected virtual void GridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (gridView.FocusedColumn.FieldName.EndsWith("StockLotNo"))
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    BusinessObject item = (BusinessObject)gridView.GetRow(gridView.FocusedRowHandle);
                    ((BaseModuleERP)Screen.Module).InvalidateSerieColumn(gridView.FocusedColumn, item, VinaDataSource);
                }
                else
                {
                    GridColumn column = gridView.Columns[SerieColumnName];
                    if (column != null)
                    {
                        column.ColumnEdit = null;
                    }
                }
            }
        }

        protected override void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.GridView_FocusedRowChanged(sender, e);

            GridView gridView = (GridView)sender;
            if (e.FocusedRowHandle < 0)
                return;

            BusinessObject item = (BusinessObject)gridView.GetRow(e.FocusedRowHandle);
            if (gridView.FocusedColumn != null && gridView.FocusedColumn.FieldName.EndsWith("StockLotNo"))
            {
                SerieColumnName = gridView.FocusedColumn.FieldName;
                if (gridView.FocusedRowHandle >= 0)
                {
                    ((BaseModuleERP)Screen.Module).InvalidateSerieColumn(gridView.FocusedColumn, item, VinaDataSource);
                }
                else
                {
                    GridColumn column = gridView.Columns[SerieColumnName];
                    if (column != null)
                    {
                        column.ColumnEdit = null;
                    }
                }
            }
        }

        private void ShowInventory()
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                BusinessObject item = (BusinessObject)gridView.GetRow(gridView.FocusedRowHandle);
                VinaDbUtil dbUtil = new VinaDbUtil();
                string itemTableName = VinaUtil.GetTableNameFromBusinessObject(item);
                String columnName = String.Empty;
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductDesc";
                string desc = dbUtil.GetPropertyStringValue(item, columnName);
                int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");

                ((BaseModuleERP)Screen.Module).ShowInventory(productID, desc);
            }
        }
    }
}
