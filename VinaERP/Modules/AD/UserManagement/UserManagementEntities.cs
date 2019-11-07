using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaERP.Base.BaseCommon;
using VinaLib;

namespace VinaERP.Modules.UserManagement
{
    public class UserManagementEntities : ERPModuleEntities
    {
        public VinaList<ADUsersInfo> ADUserList { get; set; }

        public UserManagementEntities()
            : base()
        {
            ADUserList = new VinaList<ADUsersInfo>();
        }

        public override void InitModuleObjectList()
        {
            ADUserList.InitVinaList(this, string.Empty, "ADUsers", VinaList<ADUsersInfo>.cstRelationNone);
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ADUserList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception) { }
        }
    }
}
