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
    public class GLShipmentModule : BaseModuleERP
    {
        public GLShipmentModule()
        {

        }

        public GLShipmentModule(string moduleName, GLShipmentEntities entity)
        {
            CurrentModuleName = moduleName;
            CurrentModuleEntity = entity;
            CurrentModuleEntity.Module = this;
        }

        public override void InvalidateToolbar()
        {
            ICShipmentsInfo Shipment = (ICShipmentsInfo)CurrentModuleEntity.MainObject;
            if (Shipment.ICShipmentID > 0)
            {
                ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.PostedTransactions, false);
                ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.UnPostedTransactions, false);
                if (Shipment.ICShipmentStatus == ShipmentStatus.Complete.ToString())
                {
                    ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.PostedTransactions,
                        Shipment.ICShipmentPostedStatus != PostedTransactionStatus.Posted.ToString());
                    ParentScreen.SetEnableOfToolbarButton(ToolbarButtons.UnPostedTransactions,
                        Shipment.ICShipmentPostedStatus == PostedTransactionStatus.Posted.ToString());
                }
            }

            base.InvalidateToolbar();
        }

        public virtual void ActionPosted()
        {
            GLShipmentEntities entity = (GLShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo objShipmentsInfo = (ICShipmentsInfo)CurrentModuleEntity.MainObject;
            objShipmentsInfo.ICShipmentPostedStatus = PostedTransactionStatus.Posted.ToString();
            entity.UpdateMainObject();
            GLHelper.PostedTransactions(this.CurrentModuleName, objShipmentsInfo.ICShipmentID, ModulePostingType.Accounting, ModulePostingType.Stock, ModulePostingType.SaleOrder);
            InvalidateToolbar();
        }

        public virtual void ActionUnPosted()
        {
            GLShipmentEntities entity = (GLShipmentEntities)CurrentModuleEntity;
            ICShipmentsInfo objShipmentsInfo = (ICShipmentsInfo)CurrentModuleEntity.MainObject;
            objShipmentsInfo.ICShipmentPostedStatus = PostedTransactionStatus.UnPosted.ToString();
            entity.UpdateMainObject();
            GLHelper.UnPostedTransactions(this.CurrentModuleName, objShipmentsInfo.ICShipmentID, ModulePostingType.Accounting, ModulePostingType.Stock, ModulePostingType.SaleOrder);
            InvalidateToolbar();
        }
    }
}
