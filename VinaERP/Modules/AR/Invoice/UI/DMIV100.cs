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
using VinaLib.BaseProvider;


namespace VinaERP.Modules.Invoice.UI
{
    public partial class DMIV100 : VinaERPScreen
    {
        public DMIV100()
        {
            InitializeComponent();
        }

        private void fld_lkeFK_ICProductID_KeyUp(object sender, KeyEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ((InvoiceModule)this.Module).AddItemToInvoiceItemList(Convert.ToInt32(lke.EditValue));
            }
        }

        private void fld_lkeFK_ARCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                ((InvoiceModule)Module).ChangeCustomer(Convert.ToInt32(e.Value));
            }
        }

        private void fld_txtARInvoiceDiscountPercent_Validated(object sender, EventArgs e)
        {
            ((InvoiceModule)this.Module).ChangeDiscountPercent();
        }

        private void fld_txtARInvoiceDiscountAmount_Validated(object sender, EventArgs e)
        {
            ((InvoiceModule)this.Module).ChangeDiscountAmount();
        }

        private void fld_txtARInvoiceTaxPercent_Validated(object sender, EventArgs e)
        {
            ((InvoiceModule)this.Module).ChangeTaxPercent();
        }

        private void fld_txtARInvoiceTaxAmount_Validated(object sender, EventArgs e)
        {
            ((InvoiceModule)this.Module).ChangeTaxAmount();
        }
    }
}