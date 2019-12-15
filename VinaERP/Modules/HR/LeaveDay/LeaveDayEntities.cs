using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.Department
{
    public class DepartmentEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HRDepartmentRoomsInfo> DepartmentRoomsList { get; set; }

        #endregion

        #region Constructor
        public DepartmentEntities()
            : base()
        {
            DepartmentRoomsList = new VinaList<HRDepartmentRoomsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRDepartmentsInfo();
            SearchObject = new HRDepartmentsInfo();
        }

        public override void InitModuleObjectList()
        {
            DepartmentRoomsList.InitVinaList(this,
                                             TableName.HRDepartmentsTableName,
                                             TableName.HRDepartmentRoomsTableName,
                                             VinaList<HRDepartmentRoomsInfo>.cstRelationForeign);
            DepartmentRoomsList.ItemTableForeignKey = "FK_HRDepartmentID";
        }

        public override void InitGridControlInVinaList()
        {
            DepartmentRoomsList.InitVinaListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                DepartmentRoomsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            DepartmentRoomsList.Invalidate(iObjectID);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            DepartmentRoomsList.SaveItemObjects();
        }
        #endregion
    }
}
