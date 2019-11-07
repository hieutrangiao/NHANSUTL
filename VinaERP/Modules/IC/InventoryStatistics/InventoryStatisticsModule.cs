using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.InventoryStatistics
{
    public class InventoryStatisticsModule : BaseModuleERP
    {
        public const string FromDateDateEditControlName = "fld_dteFromDate";

        public const string ToDateDateEditControlName = "fld_dteToDate";

        public const string StockLookupControlName = "fld_lkeICStockID";

        public const string ProductLookupControlName = "fld_lkeICProductID";

        public const string IsGroupByStockControlName = "fld_chkIsGroupByStock";

        public const string InventoryStatisticsGridControlName = "fld_dgcICTransactions";

        public VinaDateEdit FromDateDateEdit;

        public VinaDateEdit ToDateDateEdit;

        public VinaLookupEdit StockLookup;

        public VinaLookupEdit ProductLookup;

        public VinaCheckBox IsGroupByStock;

        public InventoryStatisticsModule()
        {
            this.CurrentModuleName = "InventoryStatistics";
            CurrentModuleEntity = new InventoryStatisticsEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();

            FromDateDateEdit = (VinaDateEdit)Controls[InventoryStatisticsModule.FromDateDateEditControlName];
            ToDateDateEdit = (VinaDateEdit)Controls[InventoryStatisticsModule.ToDateDateEditControlName];
            StockLookup = (VinaLookupEdit)Controls[InventoryStatisticsModule.StockLookupControlName];
            ProductLookup = (VinaLookupEdit)Controls[InventoryStatisticsModule.ProductLookupControlName];
            IsGroupByStock = (VinaCheckBox)Controls[InventoryStatisticsModule.IsGroupByStockControlName];
            FromDateDateEdit.EditValue = DateTime.Now;
            ToDateDateEdit.EditValue = DateTime.Now.AddDays(7);
        }

        public void InventoryStatistics()
        {
            int? stockID = StockLookup.EditValue == null ? (int?)null : Convert.ToInt32(StockLookup.EditValue);
            int? productID = ProductLookup.EditValue == null ? (int?)null : Convert.ToInt32(ProductLookup.EditValue);
            bool isGroupByStock = IsGroupByStock.Checked;
            DateTime fromDate = Convert.ToDateTime(FromDateDateEdit.EditValue);
            DateTime toDate = Convert.ToDateTime(ToDateDateEdit.EditValue);

            ICTransactionsController controller = new ICTransactionsController();
            List<ICTransactionsInfo> inventoryStatistics = controller.GetInventoryStatistics(fromDate, toDate, productID, stockID, isGroupByStock);

            InventoryStatisticsEntities entity = (InventoryStatisticsEntities)CurrentModuleEntity;
            entity.ICTransactionStatisticsList.Invalidate(inventoryStatistics);
        }

        //public void ShowInventoryLeadgerModule()
        //{
        //    InventoryStatisticsEntities entity = (InventoryStatisticsEntities)CurrentModuleEntity;
        //    if (entity.ICTransactionStatisticsList.CurrentIndex < 0)
        //        return;
        //    ICTransactionsInfo item = entity.ICTransactionStatisticsList[entity.ICTransactionStatisticsList.CurrentIndex];
        //    if (item == null)
        //        return;

        //    InventoryLeadger.InventoryLeadgerModule inventoryLeadgerModule = VinaApp.IsOpenedModule("InventoryLeadger")
        //                                                                     ? ((Modules.InventoryLeadger.InventoryLeadgerModule)VinaApp.OpenModules["InventoryLeadger"])
        //                                                                     : (Modules.InventoryLeadger.InventoryLeadgerModule)VinaApp.ShowModule("InventoryLeadger");
        //    if (inventoryLeadgerModule == null)
        //        return;

        //    DateTime fromDate = Convert.ToDateTime(FromDateDateEdit.EditValue);
        //    DateTime toDate = Convert.ToDateTime(ToDateDateEdit.EditValue);

        //    inventoryLeadgerModule.FromDateDateEdit.EditValue = fromDate;
        //    inventoryLeadgerModule.ToDateDateEdit.EditValue = toDate;
        //    inventoryLeadgerModule.StockLookup.EditValue = item.FK_ICStockID;
        //    inventoryLeadgerModule.ProductLookup.EditValue = item.FK_ICProductID;
        //    inventoryLeadgerModule.StockLookup.Refresh();
        //    inventoryLeadgerModule.ProductLookup.Refresh();
        //    inventoryLeadgerModule.InventoryLeadger();

        //    inventoryLeadgerModule.ParentScreen.Activate();
        //}
    }
}
