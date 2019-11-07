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
    public class ChosseCustomerPaymentTimePaymentsGridControl : ItemGridControl
    {
        public void InvalidateDataSource(List<ARCustomerPaymentTimePaymentsInfo> datasource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = datasource;
            DataSource = bds;
            RefreshDataSource();
        }

        //protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        //{
        //    DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
        //    //GridColumn column = new GridColumn();
        //    //column.Caption = "Mã đơn bán hàng";
        //    //column.FieldName = "ARSaleOrderNo";
        //    //gridView.Columns.Add(column);
        //    //column = gridView.Columns["ARSaleOrderNo"];
        //    //if (column != null)
        //    //{
        //    //    column.Group();
        //    //}
        //    foreach (GridColumn columnedit in gridView.Columns)
        //    {
        //        columnedit.OptionsColumn.AllowEdit = false;
        //    }
        //    return gridView;
        //}

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
                FormatNumbericColumn(column, false, "n3");
            }
            column = gridView.Columns["ARCustomerPaymentTimePaymentPercent"];
            if (column != null)
            {
                FormatNumbericColumn(column, false, "n2");
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
                column.OptionsColumn.AllowEdit = false;
                column.DisplayFormat.FormatType = FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy";
            }
            return gridView;
        }
    }
}
