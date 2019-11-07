using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;

namespace VinaERP.Modules.InventoryStatistics
{
    public class InventoryStatisticsEntities : ERPModuleEntities
    {
        public VinaList<ICTransactionsInfo> ICTransactionStatisticsList { get; set; }

        #region Constructor
        public InventoryStatisticsEntities()
            : base()
        {
            ICTransactionStatisticsList = new VinaList<ICTransactionsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitModuleObjectList()
        {
            ICTransactionStatisticsList.InitVinaList(this, String.Empty, "ICTransactions", VinaList<ICTransactionsInfo>.cstRelationNone);
        }

        public override void InitGridControlInVinaList()
        {
            ICTransactionStatisticsList.InitVinaListGridControl(InventoryStatisticsModule.InventoryStatisticsGridControlName);
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ICTransactionStatisticsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion
    }
}
