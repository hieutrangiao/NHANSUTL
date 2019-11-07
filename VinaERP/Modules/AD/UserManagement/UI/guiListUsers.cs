using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VinaERP.Modules.UserManagement.UI
{
    public partial class guiListUsers : VinaERPScreen
    {
        public guiListUsers()
        {
            InitializeComponent();
        }


        private void Fld_btnAddUser_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).AddUser();
        }

        public void InitGridControl()
        {
            fld_dgcADUsersGridControl.Screen = this;
            fld_dgcADUsersGridControl.InitializeControl();
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ADUserList.InitVinaListGridControl(fld_dgcADUsersGridControl);
        }

        private void Fld_btnEditUser_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).EditUser();
        }

        private void Fld_btnDeleteUser_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).DeleteUser();
        }
    }
}