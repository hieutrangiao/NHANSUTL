using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Common.Constant.ST;

namespace VinaERP.Utilities.GenaralLeadger
{
    public class GLHelper
    {
        #region Constructor
        public GLHelper()
            : base()
        {

        }
        #endregion

        public static void PostedTransactions(string module, int refid, params string[] PostingType)
        {
            STModulePostingsController controller = new STModulePostingsController();
            foreach (string type in PostingType)
            {
                switch (type)
                {
                    case ModulePostingType.Stock:
                        controller.STModulePostingStockFunction(module, refid, true);
                        break;
                    case ModulePostingType.Accounting:
                        controller.STModulePostingAccountingFunction(module, refid, true);
                        break;
                    case ModulePostingType.SaleOrder:
                        controller.STModulePostingSaleOrderFunction(module, refid, true);
                        break;
                    case ModulePostingType.Purchase:
                        controller.STModulePostingPurchaseFunction(module, refid, true);
                        break;
                    default:
                        break;
                }
            }

        }

        public static void UnPostedTransactions(string module, int refid, params string[] PostingType)
        {
            STModulePostingsController controller = new STModulePostingsController();
            foreach (string type in PostingType)
            {
                switch (type)
                {
                    case ModulePostingType.Stock:
                        controller.STModulePostingStockFunction(module, refid, false);
                        break;
                    case ModulePostingType.Accounting:
                        controller.STModulePostingAccountingFunction(module, refid, false);
                        break;
                    case ModulePostingType.SaleOrder:
                        controller.STModulePostingSaleOrderFunction(module, refid, false);
                        break;
                    case ModulePostingType.Purchase:
                        controller.STModulePostingPurchaseFunction(module, refid, false);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
