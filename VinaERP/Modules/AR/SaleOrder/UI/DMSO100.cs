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


namespace VinaERP.Modules.SaleOrder.UI
{
    public partial class DMSO100 : VinaERPScreen
    {
        public DMSO100()
        {
            InitializeComponent();
        }

        private void fld_lkeFK_ICProductID_KeyUp(object sender, KeyEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ((SaleOrderModule)this.Module).AddItemFromSaleOrderItemsList(Convert.ToInt32(lke.EditValue));
            }
        }

        private void fld_lkeFK_ARCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                ((SaleOrderModule)Module).ChangeCustomer(Convert.ToInt32(e.Value));
            }
        }

        private void fld_lkeARSaleOrderPaymentTerm_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                int paymentTermID = 0;
                if (int.TryParse(e.Value.ToString(), out paymentTermID))
                {
                    ((SaleOrderModule)Module).GeneratePaymentTime(paymentTermID);
                }
            }
        }

        private void fld_lkeARSaleOrderPaymentMethodType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                ((SaleOrderModule)Module).SaleOrderPaymentMethod(e.Value.ToString());
            }
        }

        private void fld_txtARSaleOrderDiscountPercent_Validated(object sender, EventArgs e)
        {
            ((SaleOrderModule)this.Module).ChangeDiscountPercent();
        }

        private void fld_txtARSaleOrderTaxPercent_Validated(object sender, EventArgs e)
        {
            ((SaleOrderModule)this.Module).ChangeTaxPercent();
        }

        private void fld_txtARSaleOrderDiscountAmount_Validated(object sender, EventArgs e)
        {
            ((SaleOrderModule)this.Module).ChangeDiscountAmount();
        }

        private void fld_txtARSaleOrderTaxAmount_Validated(object sender, EventArgs e)
        {
            ((SaleOrderModule)this.Module).ChangeTaxAmount();
        }

        private void Fld_lkeFK_GECurrencyID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                int currencyID = 0;
                Int32.TryParse(e.Value.ToString(), out currencyID);
                ((SaleOrderModule)Module).ChangeCurrency(currencyID);
            }
        }

        private void Fld_txtARSaleOrderExchangeRate_Validated(object sender, EventArgs e)
        {
            ((SaleOrderModule)Module).ChangeExchangeRate();
        }
    }
}