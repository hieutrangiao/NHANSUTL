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
            CurrentModuleName = "Department";
            CurrentModuleEntity = new DepartmentEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override int ActionSave()
        {
            DepartmentEntities entity = (DepartmentEntities)CurrentModuleEntity;
            return base.ActionSave();

        }
        public void RemoveSelectedItemFromDepartmentItemList()
        {
            DepartmentEntities entity = (DepartmentEntities)CurrentModuleEntity;
            entity.DepartmentRoomsList.RemoveSelectedRowObjectFromList();
        }

        public void ChangeDepartmentRoomBoundary()
        {
            DepartmentEntities entity = (DepartmentEntities)CurrentModuleEntity;
            HRDepartmentsInfo mainObject = (HRDepartmentsInfo)entity.MainObject;
            mainObject.HRDepartmentBoundary = (decimal)entity.DepartmentRoomsList.Sum(o => o.HRDepartmentRoomBoundary);
            mainObject.HRDepartmentMenBoundary = (decimal)entity.DepartmentRoomsList.Sum(o => o.HRDepartmentRoomMenBoundary);
            mainObject.HRDepartmentWoMenBoundary = (decimal)entity.DepartmentRoomsList.Sum(o => o.HRDepartmentRoomWoMenBoundary);
            entity.UpdateMainObjectBindingSource();
        }
    }
}
