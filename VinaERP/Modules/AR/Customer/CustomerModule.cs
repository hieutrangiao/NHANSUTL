using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Common;
using VinaERP.Modules.Customer;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.Customer
{
    public class CustomerModule : BaseModuleERP
    {

        public CustomerModule()
        {
            this.CurrentModuleName = "Customer";
            CurrentModuleEntity = new CustomerEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();

        }

        public override int ActionSave()
        {
            //SetProductExtraWoodTypeAndColor();
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
