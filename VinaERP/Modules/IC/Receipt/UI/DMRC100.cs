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


namespace VinaERP.Modules.Receipt.UI
{
    public partial class DMRC100 : VinaERPScreen
    {
        public DMRC100()
        {
            InitializeComponent();
        }

        private void Fld_lkeFK_ICProductID_KeyUp(object sender, KeyEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                int productID = Convert.ToInt32(lke.EditValue);
                ((ReceiptModule)this.Module).AddItemToReceiptItemsList(productID);
            }
        }

        private void Fld_lkdFK_ICStockID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                int stockID = Convert.ToInt32(e.Value);
                ((ReceiptModule)Module).ChangeStock(stockID);
            }
        }

        private void Fld_txtICReceiptProductLotNo_Validated(object sender, EventArgs e)
        {
            ((ReceiptModule)Module).ChangeReceiptProductLotNo();
        }

        private void Fld_lkeFK_GECurrencyID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (e.Value != null && lke.OldEditValue != e.Value)
            {
                int currencyID = 0;
                Int32.TryParse(e.Value.ToString(), out currencyID);
                ((ReceiptModule)Module).ChangeCurrency(currencyID);
            }
        }

        private void Fld_txtICReceiptDiscountPercent_Validated(object sender, EventArgs e)
        {
            ((ReceiptModule)Module).ChangeDiscountPercent();
        }

        private void Fld_txtICReceiptTaxPercent_Validated(object sender, EventArgs e)
        {
            ((ReceiptModule)Module).ChangeTaxPercent();
        }

        private void Fld_txtICReceiptDiscountAmount_Validated(object sender, EventArgs e)
        {
            ((ReceiptModule)Module).ChangeDiscountAmount();
        }

        private void Fld_txtICReceiptTaxAmount_Validated(object sender, EventArgs e)
        {
            ((ReceiptModule)Module).ChangeTaxAmount();
        }

        private void Fld_txtICReceiptExchangeRate_Validated(object sender, EventArgs e)
        {
            ((ReceiptModule)Module).ChangeExchangeRate();
        }
    }
}