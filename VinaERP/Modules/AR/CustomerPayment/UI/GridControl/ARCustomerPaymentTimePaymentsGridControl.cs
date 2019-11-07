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

namespace VinaERP.Modules.CustomerPayment
{
    public class ARCustomerPaymentTimePaymentsGridControl : ItemGridControl
    {
        public override void InitGridControlDataSource()
        {
            CustomerPaymentEntities entity = (CustomerPaymentEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.CustomerPaymentTimePaymentsList;
            this.DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ARCustomerPaymentTimePaymentTotalAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentPaidAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentRemainAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentAmount"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n3");
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, true, "n2");
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentEndDate"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
                column.DisplayFormat.FormatType = FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy";
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentDate"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.DisplayFormat.FormatType = FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy";
            }
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((CustomerPaymentModule)Screen.Module).DeleteItemFromCustomerPaymentTimePaymentsList();
            }
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            GridView gridView = (GridView)sender;
            CustomerPaymentEntities entity = (CustomerPaymentEntities)(this.Screen.Module as BaseModuleERP).CurrentModuleEntity;
            if (entity.CustomerPaymentTimePaymentsList.CurrentIndex >= 0)
            {
                ARCustomerPaymentTimePaymentsInfo item = (ARCustomerPaymentTimePaymentsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (e.Column.FieldName == "ARCustomerPaymentTimePaymentPercent")
                {
                    item.ARCustomerPaymentTimePaymentAmount = item.ARCustomerPaymentTimePaymentPercent / 100 * item.ARCustomerPaymentTimePaymentTotalAmount;
                    if(item.ARCustomerPaymentTimePaymentAmount > item.ARCustomerPaymentTimePaymentRemainAmount)
                    {
                        decimal oldValue = Convert.ToDecimal(gridView.ActiveEditor.OldEditValue);
                        MessageBox.Show("Số tiền thanh toán vượt quá số tiền còn lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.ARCustomerPaymentTimePaymentPercent = oldValue;
                        item.ARCustomerPaymentTimePaymentAmount = item.ARCustomerPaymentTimePaymentPercent / 100 * item.ARCustomerPaymentTimePaymentTotalAmount;
                        return;
                    }
                    ((CustomerPaymentModule)Screen.Module).UpdateTotalAmount();
                }
                else if (e.Column.FieldName == "ARCustomerPaymentTimePaymentAmount")
                {
                    ((CustomerPaymentModule)Screen.Module).UpdateTotalAmount();
                }
            }
        }
    }
}
