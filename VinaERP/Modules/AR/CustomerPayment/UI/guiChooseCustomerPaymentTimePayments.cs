using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;

namespace VinaERP.Modules.CustomerPayment.UI
{
    public partial class guiChooseCustomerPaymentTimePayments : VinaERPScreen
    {
        private GridControlHelper GridControlHelper;
        private List<ARCustomerPaymentTimePaymentsInfo> CustomerPaymentTimePaymentsList { get; set; }
        public IList SelectedObjects { get; set; }
        public guiChooseCustomerPaymentTimePayments(List<ARCustomerPaymentTimePaymentsInfo> customerPaymentTimePaymentsList)
        {
            InitializeComponent();
            CustomerPaymentTimePaymentsList = customerPaymentTimePaymentsList;
        }

        private void guiChooseSaleOrderItem_Load(object sender, EventArgs e)
        {
            InitializeControls(Controls);
            SelectedObjects = new List<ARCustomerPaymentTimePaymentsInfo>();
            fld_dgcARCustomerPaymentTimePayments.InvalidateDataSource(CustomerPaymentTimePaymentsList);
            //fld_dgcICShipmentItems.InvalidateDataSource(SaleOrderItemList);

            GridView gridView = (GridView)fld_dgcARCustomerPaymentTimePayments.MainView;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsMenu.EnableFooterMenu = false;
            GridControlHelper = new GridControlHelper(gridView);
            gridView.ExpandAllGroups();
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            SelectedObjects = GridControlHelper.Selection.OfType<ARCustomerPaymentTimePaymentsInfo>().ToList();
            if (SelectedObjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chứng từ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((SelectedObjects as List<ARCustomerPaymentTimePaymentsInfo>).Any(o=>o.FK_ARCustomerID != (SelectedObjects[0] as ARCustomerPaymentTimePaymentsInfo).FK_ARCustomerID))
            {
                MessageBox.Show("Vui lòng chọn các chứng từ của cùng khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((SelectedObjects as List<ARCustomerPaymentTimePaymentsInfo>).Any(o => o.FK_GECurrencyID != (SelectedObjects[0] as ARCustomerPaymentTimePaymentsInfo).FK_GECurrencyID))
            {
                MessageBox.Show("Vui lòng chọn các chứng từ có cùng loại tiền tệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}