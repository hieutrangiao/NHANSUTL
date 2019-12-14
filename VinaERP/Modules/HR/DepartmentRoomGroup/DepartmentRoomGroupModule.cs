using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaERP.Modules.DepartmentRoomGroup
{

    public class DepartmentRoomGroupModule : BaseModuleERP
    {

        public DepartmentRoomGroupModule()
        {
            CurrentModuleName = "DepartmentRoomGroup";
            CurrentModuleEntity = new DepartmentRoomGroupEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            DepartmentRoomGroupEntities entity = (DepartmentRoomGroupEntities)CurrentModuleEntity;
            return base.ActionSave();

        }
        public void RemoveSelectedItemFromDepartmentRoomGroupItemList()
        {
            DepartmentRoomGroupEntities entity = (DepartmentRoomGroupEntities)CurrentModuleEntity;
            entity.DepartmentRoomGroupItemsList.RemoveSelectedRowObjectFromList();
        }
    }
}
