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
using DevExpress.XtraTreeList;
using VinaLib;
using VinaERP.Modules.UserManagement;

namespace VinaERP.Modules.UserManagement.UI
{
  
    public enum AddUserGroupMode { Add, Edit }

    public partial class GuiAddUserGroups : VinaERPScreen
    {
        private TreeList TreeList = null;
        private AddUserGroupMode Mode;

        public GuiAddUserGroups()
        {
            InitializeComponent();
        }
        public GuiAddUserGroups(TreeList treeList, AddUserGroupMode mode)
        {
            InitializeComponent();
            TreeList = treeList;
            Mode = mode;
        }

        private void fld_btnCloseUserGroup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnAddUserGroup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtUserGroup.Text))
            {
                MessageBox.Show("Tên nhóm không được bỏ trống","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ADUserGroupsController objUserGroupsController = new ADUserGroupsController();
            if (Mode == AddUserGroupMode.Add)
            {
                ADUserGroupsInfo objADUserGroupsInfo = new ADUserGroupsInfo();
                objADUserGroupsInfo.ADUserGroupName = fld_txtUserGroup.Text;
                objADUserGroupsInfo.ADUserGroupDesc = fld_txtUserGroup.Text;
                objUserGroupsController.CreateObject(objADUserGroupsInfo);
            }
            else if (Mode == AddUserGroupMode.Edit)
            {
                ADUserGroupsInfo objADUserGroupsInfo = (ADUserGroupsInfo)objUserGroupsController.GetObjectByID(Convert.ToInt32(TreeList.FocusedNode.Tag));
                objADUserGroupsInfo.ADUserGroupName = fld_txtUserGroup.Text;
                objADUserGroupsInfo.ADUserGroupDesc = fld_txtUserGroup.Text;
                objUserGroupsController.UpdateObject(objADUserGroupsInfo);
            }
            ((UserManagementModule)this.Module).InitializeTreeList(TreeList);
            this.Close();
        }
    }
}