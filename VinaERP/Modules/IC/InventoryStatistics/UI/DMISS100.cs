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
using VinaERP.Common;
using VinaLib.BaseProvider;
using VinaERP.Modules.InventoryStatistics;

namespace VinaERP.Modules.InventoryStatistics.UI
{
    public partial class DMISS100 : VinaERPScreen
    {
        public DMISS100()
        {
            InitializeComponent();
        }

        private void Fld_btnOK_Click(object sender, EventArgs e)
        {
            ((InventoryStatisticsModule)Module).InventoryStatistics();
        }

        private void Fld_lkeICStockID_QueryPopUp(object sender, CancelEventArgs e)
        {
            VinaLookupEdit lke = (VinaLookupEdit)sender;
            if(lke != null)
            {
                ICStocksController objStocksController = new ICStocksController();
                List<ICStocksInfo> stockList = new List<ICStocksInfo>();
                stockList.Insert(0, new ICStocksInfo());
                stockList.AddRange(objStocksController.GetAllStockByStockType("Sale"));
                lke.Properties.DataSource = stockList;
            }
        }

        private void Fld_lkeICProductID_QueryPopUp(object sender, CancelEventArgs e)
        {
            LookUpEdit lke = (LookUpEdit)sender;
            if (lke != null)
            {
                ICProductsController objProductsController = new ICProductsController();
                List<ICProductsInfo> productList = new List<ICProductsInfo>();
                productList.Insert(0, new ICProductsInfo());
                productList.AddRange((List<ICProductsInfo>)objProductsController.GetListFromDataSet(objProductsController.GetAllObjects()));
                lke.Properties.DataSource = productList;
            }
        }
    }
}