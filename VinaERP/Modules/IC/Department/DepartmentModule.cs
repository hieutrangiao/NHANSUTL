using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP.Modules.Department
{
    public class DepartmentModule : BaseModuleERP
    {
        public DepartmentModule()
        {
            this.CurrentModuleName = "Department";
            CurrentModuleEntity = new DepartmentEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }
    }
}
