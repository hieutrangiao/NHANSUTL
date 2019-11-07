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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using VinaERP.Common.Constant;

namespace VinaERP.Modules.CustomerPayment
{
    public class ARCustomerPaymentDetailsGridControl : VinaGridControl
    {
        /// <summary>
        /// Gets or sets the payment details binding to the grid control
        /// </summary>
        public List<ARCustomerPaymentDetailsInfo> CustomerPaymentDetailList { get; set; }

        /// <summary>
        /// Gets or sets the payment amount
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the grid allows multiple-payment
        /// </summary>
        public bool AllowMultiplePayment { get; set; }

        /// <summary>
        /// Gets or sets the required method in case the grid do not allow multiple-payment
        /// </summary>
        public string RequiredMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the gird allows take payment by currencies
        /// </summary>
        public bool AllowPaymentByCurrency { get; set; }


        public override void InitializeControl()
        {
            base.InitializeControl();
            this.Enter += new EventHandler(GridControl_Enter);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();

            GridColumn column = gridView.Columns["ARCustomerPaymentDetailPaymentMethodType"];
            if (column != null)
            {
                column.AppearanceCell.BackColor = Color.WhiteSmoke;
            }

            column = gridView.Columns["ARCustomerPaymentDetailAmount"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                FormatNumbericColumn(column, true, "n2");
                if (AllowPaymentByCurrency)
                {
                    RepositoryItemButtonEdit rep = new RepositoryItemButtonEdit();
                    rep.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(RepositoryItemButtonEditAmount_ButtonClick);
                    column.ColumnEdit = rep;
                    InitColumnRepositoryFromFieldFormatGroup("ARCustomerPaymentDetails", "ARCustomerPaymentDetailAmount");
                }
            }

            gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            return gridView;
        }

        private void RepositoryItemButtonEditAmount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if ((Screen.Module as BaseModuleERP).IsEditable())
            {
                (Screen.Module as BaseModuleERP).ActionEdit();
            }

            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                ARCustomerPaymentDetailsInfo objCustomerPaymentDetailsInfo = (ARCustomerPaymentDetailsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                //guiPaymentCurrency guiPaymentCurrency = new guiPaymentCurrency(objCustomerPaymentDetailsInfo);
                //guiPaymentCurrency.Module = Screen.Module;
                //guiPaymentCurrency.ShowDialog();
            }
        }

        public override void InitGridControlDataSource()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CustomerPaymentDetailList;
            DataSource = bds;
            RefreshDataSource();
        }

        #region GridControl Event Handlers
        private void GridControl_Enter(object sender, EventArgs e)
        {
            ProposeRemainingAmount();
        }

        protected override void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.GridView_FocusedRowChanged(sender, e);

            ProposeRemainingAmount();
        }
        #endregion

        public void ProposeRemainingAmount()
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                ARCustomerPaymentDetailsInfo currentPayment = null;
                if (!AllowMultiplePayment && !string.IsNullOrEmpty(RequiredMethod))
                {
                    currentPayment = CustomerPaymentDetailList.Where(cpd => cpd.ARCustomerPaymentDetailPaymentMethodType == RequiredMethod).FirstOrDefault();
                }
                else
                {
                    currentPayment = (ARCustomerPaymentDetailsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                }

                if (AllowMultiplePayment)
                {
                    decimal amount = 0;
                    foreach (ARCustomerPaymentDetailsInfo objCustomerPaymentDetailsInfo in CustomerPaymentDetailList)
                        if (objCustomerPaymentDetailsInfo.ARCustomerPaymentDetailPaymentMethodType != currentPayment.ARCustomerPaymentDetailPaymentMethodType)
                            amount += objCustomerPaymentDetailsInfo.ARCustomerPaymentDetailAmount;

                    if (PaymentAmount >= amount)
                        currentPayment.ARCustomerPaymentDetailAmount = PaymentAmount - amount;
                }
                else
                {
                    ARCustomerPaymentDetailsInfo previousPayment = CustomerPaymentDetailList.Where(cpd => cpd.ARCustomerPaymentDetailID > 0 &&
                                                                                                   cpd.ARCustomerPaymentDetailAmount > 0).FirstOrDefault();
                    if (previousPayment != null)
                    {
                        currentPayment = previousPayment;
                    }
                    CustomerPaymentDetailList.ForEach(cpd => cpd.ARCustomerPaymentDetailAmount = 0);
                    currentPayment.ARCustomerPaymentDetailAmount = PaymentAmount;
                }
                this.RefreshDataSource();
            }
        }

        protected override void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            base.GridView_ValidatingEditor(sender, e);

            GridView gridView = (GridView)sender;
            if (gridView.FocusedColumn.FieldName == "ARCustomerPaymentDetailAmount")
            {
                if (e.Value != null)
                {
                    ARCustomerPaymentDetailsInfo currentPayment = (ARCustomerPaymentDetailsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                    if (!AllowMultiplePayment)
                    {
                        if (CustomerPaymentDetailList.Exists(cpd => cpd.ARCustomerPaymentDetailAmount > 0 && cpd.ARCustomerPaymentDetailPaymentMethodType != currentPayment.ARCustomerPaymentDetailPaymentMethodType))
                        {
                            e.ErrorText = "Không thể thực hiện đa thanh toán!";
                            e.Valid = false;
                            return;
                        }
                    }
                    decimal amount = 0;
                    foreach (ARCustomerPaymentDetailsInfo objDocumentPaymentDetaisInfo in CustomerPaymentDetailList)
                    {
                        if (objDocumentPaymentDetaisInfo.ARCustomerPaymentDetailPaymentMethodType != currentPayment.ARCustomerPaymentDetailPaymentMethodType)
                        {
                            amount += objDocumentPaymentDetaisInfo.ARCustomerPaymentDetailAmount;
                        }
                    }
                    amount += Convert.ToDecimal(e.Value);
                    if (amount > PaymentAmount)
                    {
                        e.ErrorText = "Tổng tiền không được lớn hơn tiền thanh toán!";
                        e.Valid = false;
                    }
                }
            }
        }
    }
}
