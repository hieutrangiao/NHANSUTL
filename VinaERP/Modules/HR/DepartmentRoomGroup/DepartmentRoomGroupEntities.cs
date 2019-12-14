using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaERP.Common;
using VinaLib;

namespace VinaERP.Modules.DepartmentRoomGroup
{
    public class DepartmentRoomGroupEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public VinaList<HRDepartmentRoomGroupItemsInfo> DepartmentRoomGroupItemsList { get; set; }

        #endregion

        #region Constructor
        public DepartmentRoomGroupEntities()
            : base()
        {
            DepartmentRoomGroupItemsList = new VinaList<HRDepartmentRoomGroupItemsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRDepartmentRoomGroupsInfo();
            SearchObject = new HRDepartmentRoomGroupsInfo();
        }

        public override void InitModuleObjectList()
        {
            DepartmentRoomGroupItemsList.InitVinaList(this,
                                             TableName.HRDepartmentRoomGroupsTableName,
                                             TableName.HRDepartmentRoomGroupItemsTableName,
                                             VinaList<HRDepartmentRoomGroupItemsInfo>.cstRelationForeign);
            DepartmentRoomGroupItemsList.ItemTableForeignKey = "FK_HRDepartmentRoomGroupID";
        }

        public override void InitGridControlInVinaList()
        {
            DepartmentRoomGroupItemsList.InitVinaListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                DepartmentRoomGroupItemsList.SetDefaultListAndRefreshGridControl();
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
            DepartmentRoomGroupItemsList.Invalidate(iObjectID);
        }

        #endregion

        #region Save Module Objects functions        
        public override void SaveModuleObjects()
        {
            DepartmentRoomGroupItemsList.SaveItemObjects();
        }
        #endregion
    }
}
