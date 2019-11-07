using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Common;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Supplier
{
    public class SupplierModule : BaseModuleERP
    {
        public SupplierModule()
        {
            this.CurrentModuleName = "Supplier";
            CurrentModuleEntity = new SupplierEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            return base.ActionSave();
        }

        public override void ActionNew()
        {
            base.ActionNew();
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }
        
    }
}
