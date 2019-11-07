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
using DevExpress.XtraGrid.Views.Grid;
using VinaERP.Common.Constant.IC;
using VinaLib;

namespace VinaERP.Base.UI
{
    public partial class guiShowInventoryStock : VinaERPScreen
    {
        private int ICProductID { get; set; }

        private string ICProductDesc { get; set; }

        public guiShowInventoryStock()
        {
            InitializeComponent();
        }

        public guiShowInventoryStock(int productID , string productDesc)
        {
            InitializeComponent();
            ICProductID = productID;
            ICProductDesc = productDesc;
        }

        private void GuiShowInventoryStock_Load(object sender, EventArgs e)
        {
            fld_dgcInventoryStocks.Screen = this;
            fld_dgcInventoryStocks.InitializeControl();
            (fld_dgcInventoryStocks.MainView as GridView).ExpandAllGroups();
            ICTransactionsController objTransactionsController = new ICTransactionsController();
            List<ICTransactionsInfo> inventoryStockList = objTransactionsController.GetInventoryStockByProductID(ICProductID, ICProductDesc, DateTime.Now);
            decimal onHandQty = inventoryStockList.Where(o=>o.ICStockType == StockType.Sale).Sum(o=>o.ICTransactionExchangeQty);
            decimal saleOrderQty = inventoryStockList.Where(o => o.ICStockType == StockType.SaleOrder).Sum(o => o.ICTransactionExchangeQty);
            decimal purchaseOrderQty = inventoryStockList.Where(o => o.ICStockType == StockType.Purchasre).Sum(o => o.ICTransactionExchangeQty);
            decimal availableQty = (purchaseOrderQty + onHandQty) - saleOrderQty;
           
            fld_lblOnHandQty.Text = onHandQty.ToString("n3");
            fld_lblSOQty.Text = saleOrderQty.ToString("n3");
            fld_lblPOQty.Text = purchaseOrderQty.ToString("n3");
            fld_lblAvailableQty.Text = availableQty.ToString("n3");

            fld_dgcInventoryStocks.DataSource = inventoryStockList.Where(o=>o.ICStockType == StockType.Sale).ToList();
            fld_dgcInventoryStocks.RefreshDataSource();
        }
    }
}