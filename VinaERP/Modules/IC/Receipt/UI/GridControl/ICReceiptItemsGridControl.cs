using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common.Constant.IC;
using VinaERP.Utilities;

namespace VinaERP.Modules.Receipt
{
    public class ICReceiptItemsGridControl : ItemGridControl
    {
        public override void InitGridControlDataSource()
        {
            ReceiptEntities entity = (ReceiptEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ReceiptItemsList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ICReceiptItemProductUnitPrice"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICReceiptItemDiscountPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ICReceiptItemDiscountAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICReceiptItemTaxPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ICReceiptItemTaxAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICReceiptItemTotalAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ICReceiptItemProductQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
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
            column = gridView.Columns["ICReceiptItemProductFactor"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ICReceiptItemProductExchangeQty"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ICReceiptItemStockLotNo"];
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
                ((ReceiptModule)Screen.Module).DeleteItemFromReceiptItemList();
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            ReceiptEntities entity = (ReceiptEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
            if (entity.ReceiptItemsList.CurrentIndex >= 0)
            {
                GridView gridView = (GridView)sender;
                ICReceiptItemsInfo item = (ICReceiptItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (e.Column.FieldName == "FK_ICMeasureUnitID")
                {
                    ((ReceiptModule)Screen.Module).ChangeItemMeasureUnit();
                }
                else if (e.Column.FieldName == "ICReceiptItemDiscountAmount")
                {
                    ((ReceiptModule)Screen.Module).ChangeItemDiscountAmount();
                }
                else if (e.Column.FieldName == "ICReceiptItemTaxAmount")
                {
                    ((ReceiptModule)Screen.Module).ChangeItemTaxAmount();
                }
                ((ReceiptModule)Screen.Module).ChangeItemFromReceiptItemsList(item);
            }
        }

        protected override void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView gridView = (GridView)sender;
            ICReceiptItemsInfo item = (ICReceiptItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
            if (e.Value != null)
            {
                if (gridView.FocusedColumn.FieldName == "ICReceiptItemProductFactor")
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
                if (gridView.FocusedColumn.FieldName == "ICReceiptItemStockLotNo")
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        ICProductsController objProductsController = new ICProductsController();
                        ICProductsInfo objProductsInfo = new ICProductsInfo();

                        objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(item.FK_ICProductID);
                        if (objProductsInfo == null)
                            return;

                        if (objProductsInfo.ICPriceCalculationMethodType != PriceCalculationMethod.Specific)
                            return;

                        e.ErrorText = "Không được nhập lô cho sản phẩm tính giá trung bình!";
                        e.Valid = false;
                    }
                }
            }
        }

        private void rpMeasureUnitt_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            ICReceiptItemsInfo item = (ICReceiptItemsInfo)gridView.GetRow(gridView.FocusedRowHandle);
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
