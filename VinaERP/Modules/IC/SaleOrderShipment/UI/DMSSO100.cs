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


namespace VinaERP.Modules.SaleOrderShipment.UI
{
    public partial class DMSSO100 : VinaERPScreen
    {
        public DMSSO100()
        {
            InitializeComponent();
        }

        private void fld_lkeFK_ICProductID_KeyUp(object sender, KeyEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                ((SaleOrderShipmentModule)this.Module).AddItemFromSaleOrderShipmentItemsList(Convert.ToInt32(lke.EditValue));
            }
        }

        private void Fld_lkeFK_GECurrencyID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                int currencyID = 0;
                Int32.TryParse(e.Value.ToString(), out currencyID);
                ((SaleOrderShipmentModule)Module).ChangeCurrency(currencyID);
            }
        }

        private void Fld_txtICReceiptDiscountPercent_Validated(object sender, EventArgs e)
        {
            ((SaleOrderShipmentModule)Module).ChangeDiscountPercent();
        }

        private void Fld_txtICReceiptDiscountAmount_Validated(object sender, EventArgs e)
        {
            ((SaleOrderShipmentModule)Module).ChangeDiscountAmount();
        }

        private void Fld_txtICReceiptTaxPercent_Validated(object sender, EventArgs e)
        {
            ((SaleOrderShipmentModule)Module).ChangeTaxPercent();
        }

        private void Fld_txtICReceiptTaxAmount_Validated(object sender, EventArgs e)
        {
            ((SaleOrderShipmentModule)Module).ChangeTaxAmount();
        }

        private void Fld_txtICReceiptExchangeRate_Validated(object sender, EventArgs e)
        {
            ((SaleOrderShipmentModule)Module).ChangeExchangeRate();
        }

        private void Fld_lkdFK_ICStockID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                int stockID = Convert.ToInt32(e.Value);
                ((SaleOrderShipmentModule)Module).ChangeStock(stockID);
            }
        }
    }
}