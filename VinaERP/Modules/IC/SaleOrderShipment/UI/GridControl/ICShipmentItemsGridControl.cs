using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Utilities;

namespace VinaERP.Modules.SaleOrderShipment
{
    public class ICShipmentItemsGridControl : ItemGridControl
    {
        public override void InitGridControlDataSource()
        {
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ShipmentItemsList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ICShipmentItemProductUnitPrice"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICShipmentItemDiscountPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ICShipmentItemDiscountAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICShipmentItemTaxPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ICShipmentItemTaxAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICShipmentItemTotalAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICShipmentItemProductQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["FK_ICStockID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["ICShipmentItemStockLotNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["FK_ICMeasureUnitID"];
            if (column != null)
            {
                ICMeasureUnitsController objMeasureUnitsController = new ICMeasureUnitsController();
                column.OptionsColumn.AllowEdit = true;
                RepositoryItemLookUpEdit rpMeasureUnit = new RepositoryItemLookUpEdit();
                rpMeasureUnit.DisplayMember = "ICMeasureUnitName";
                rpMeasureUnit.ValueMember = "ICMeasureUnitID";
                rpMeasureUnit.NullText = string.Empty;
                rpMeasureUnit.Columns.Add(new LookUpColumnInfo("ICMeasureUnitName", "Đơn vị tính"));
                rpMeasureUnit.DataSource = objMeasureUnitsController.GetAllObjects().Tables[0];
                rpMeasureUnit.QueryPopUp += new System.ComponentModel.CancelEventHandler(rpMeasureUnitt_QueryPopUp);
                column.ColumnEdit = rpMeasureUnit;
            }
            column = gridView.Columns["ICShipmentItemProductFactor"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICShipmentItemProductExchangeQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            return gridView;
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            GridView gridView = (GridView)sender;
            SaleOrderShipmentEntities entity = (SaleOrderShipmentEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
            if (entity.ShipmentItemsList.CurrentIndex >= 0)
            {
                ICShipmentItemsInfo item = (ICShipmentItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (e.Column.FieldName == "FK_ICMeasureUnitID")
                {
                    ((SaleOrderShipmentModule)Screen.Module).ChangeItemMeasureUnit();
                }
                else if (e.Column.FieldName == "ICShipmentItemDiscountAmount")
                {
                    ((SaleOrderShipmentModule)Screen.Module).ChangeItemDiscountAmount();
                }
                else if (e.Column.FieldName == "ICShipmentItemTaxAmount")
                {
                    ((SaleOrderShipmentModule)Screen.Module).ChangeItemTaxAmount();
                }
                ((SaleOrderShipmentModule)Screen.Module).ChangeItemFromShipmentItemsList(item);
            }
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((SaleOrderShipmentModule)Screen.Module).DeleteItemFromShipmentItemsList();
            }
        }

        protected override void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            ICShipmentItemsInfo item = (ICShipmentItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "ICShipmentItemProductFactor")
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        ICProductMeasureUnitsController controller = new ICProductMeasureUnitsController();
                        ICProductMeasureUnitsInfo measureUnit = controller.GetProductMeasureUnitByProductIDAndMeasureUnitID(item.FK_ICProductID, item.FK_ICMeasureUnitID);
                        if (measureUnit != null && measureUnit.ICProductMeasureUnitIsEdit)
                            return;

                        e.ErrorText = "Hệ số không được phép thay đổi.";
                        e.Valid = false;
                    }
                }
            }
        }

        private void rpMeasureUnitt_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            ICShipmentItemsInfo item = (ICShipmentItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
            LookUpEdit lookUpEdit = (LookUpEdit)sender;
            if (item != null)
            {
                ICMeasureUnitsController objMeasureUnitsController = new ICMeasureUnitsController();
                List<ICMeasureUnitsInfo> measureUnits = objMeasureUnitsController.GetMeasureUnitByProductID(item.FK_ICProductID);
                if (measureUnits != null)
                {
                    lookUpEdit.Properties.DataSource = measureUnits;
                    lookUpEdit.Properties.DisplayMember = "ICMeasureUnitName";
                    lookUpEdit.Properties.ValueMember = "ICMeasureUnitID";
                }
            }
        }
    }
}
