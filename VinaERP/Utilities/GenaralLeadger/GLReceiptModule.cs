using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Common.Constant;
using VinaERP.Common.Constant.IC;
using VinaERP.Common.Constant.ST;

namespace VinaERP.Utilities.GenaralLeadger
{
    public class GLReceiptModule : BaseModuleERP
    {
        public GLReceiptModule()
        {

        }

        public GLReceiptModule(string moduleName, GLReceiptEntities entity)
        {
            CurrentModuleName = moduleName;
            CurrentModuleEntity = entity;
            CurrentModuleEntity.Module = this;
        }

        public override void InvalidateToolbar()
        {
            ICReceiptsInfo receipt = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            if (receipt.ICReceiptID > 0)
            {
                ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.PostedTransactions, false);
                ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.UnPostedTransactions, false);
                if (receipt.ICReceiptStatus == ReceiptStatus.Complete.ToString())
                {
                    ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.PostedTransactions,
                        receipt.ICReceiptPostedStatus != PostedTransactionStatus.Posted.ToString());
                    ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.UnPostedTransactions,
                        receipt.ICReceiptPostedStatus == PostedTransactionStatus.Posted.ToString());
                }
            }

            base.InvalidateToolbar();
        }

        public virtual void ActionPosted()
        {
            GLReceiptEntities entity = (GLReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo objReceiptsInfo = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            objReceiptsInfo.ICReceiptPostedStatus = PostedTransactionStatus.Posted.ToString();
            entity.UpdateMainObject();
            GLHelper.PostedTransactions(this.CurrentModuleName, objReceiptsInfo.ICReceiptID, ModulePostingType.Accounting, ModulePostingType.Stock);
            InvalidateToolbar();
        }

        public virtual void ActionUnPosted()
        {
            GLReceiptEntities entity = (GLReceiptEntities)CurrentModuleEntity;
            ICReceiptsInfo objReceiptsInfo = (ICReceiptsInfo)CurrentModuleEntity.MainObject;
            objReceiptsInfo.ICReceiptPostedStatus = PostedTransactionStatus.UnPosted.ToString();
            entity.UpdateMainObject();
            GLHelper.UnPostedTransactions(this.CurrentModuleName, objReceiptsInfo.ICReceiptID, ModulePostingType.Accounting, ModulePostingType.Stock);
            InvalidateToolbar();
        }
    }
}
