using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VinaERP.Common;
using VinaERP.Modules.UserManagement.UI;
using VinaLib;

namespace VinaERP.Modules.UserManagement
{
    public class UserManagementModule : BaseModuleERP
    {
        public UserManagementModule()
        {
            CurrentModuleName = ModuleName.UserManagementModule;
            CurrentModuleEntity = new UserManagementEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override void InitializeScreens()
        {
            this.ParentScreen.LeftPanelContainer.Hide();
            GuiUserManagement guiUserManagement = new GuiUserManagement();
            guiUserManagement.ScreenCode = "DMUM100";
            guiUserManagement.Module = this;
            guiUserManagement.Height -= 100;
            Screens.Add(guiUserManagement);
            InitializeTreeList(guiUserManagement.TreeListUserGroup);
            guiUserManagement.AddControlsToParentScreen();

            guiListUsers guiListUsers = new guiListUsers();
            guiListUsers.ScreenCode = "DMUM101";
            guiListUsers.Module = this;
            guiListUsers.Height -= 100;
            guiListUsers.InitGridControl();
            Screens.Add(guiListUsers);
            guiListUsers.AddControlsToParentScreen();

            InvalidateUserList();
        }

        public void InitializeTreeList(TreeList fld_trlstUserGroup)
        {

            List<ADUserGroupsInfo> lstNode = new List<ADUserGroupsInfo>();
            TreeListNode prevFocusedNode = fld_trlstUserGroup.FocusedNode;
            fld_trlstUserGroup.Nodes.Clear();
            ADUserGroupsController objADUserGroupsController = new ADUserGroupsController();
            DataSet dsADUserGroups = objADUserGroupsController.GetAllObjects();
            if (dsADUserGroups != null)
            {
                foreach (DataRow row in dsADUserGroups.Tables[0].Rows)
                {
                    ADUserGroupsInfo objADUserGroupsInfo = (ADUserGroupsInfo)objADUserGroupsController.GetObjectFromDataRow(row);
                    if (objADUserGroupsInfo != null)
                    {
                        lstNode.Add(objADUserGroupsInfo);
                    }
                }
            }
            CreateTreeView(fld_trlstUserGroup, lstNode, null);
            if (prevFocusedNode != null)
            {
                TreeListNode currentFocusedNode = fld_trlstUserGroup.FindNodeByID(prevFocusedNode.Id);
                while (currentFocusedNode != null)
                {
                    if (currentFocusedNode.Level > 0)
                    {
                        currentFocusedNode.ExpandAll();
                    }
                    else
                    {
                        currentFocusedNode.Expanded = true;
                    }
                    currentFocusedNode = currentFocusedNode.ParentNode;
                }
            }
        }

        private void CreateTreeView(TreeList fld_trlstUserGroup, List<ADUserGroupsInfo> lstNodeName, TreeListNode ParentNode)
        {
            fld_trlstUserGroup.BeginUnboundLoad();
            TreeListNode treeListNode;
            treeListNode = fld_trlstUserGroup.AppendNode(new object[] { "Nhóm người dùng", 0 }, ParentNode);
            for (int i = 0; i < lstNodeName.Count; i++)
            {
                treeListNode = fld_trlstUserGroup.AppendNode(new object[] { lstNodeName[i].ADUserGroupName, 1 }, 0);
                treeListNode.Tag = lstNodeName[i].ADUserGroupID;
                treeListNode.HasChildren = HasChild(lstNodeName[i].ADUserGroupID);

                if (treeListNode.HasChildren)
                {
                    ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                    DataSet dsUserGroupChild = objUserGroupSectionsController.GetUserGroupSectionByUserGroupID(lstNodeName[i].ADUserGroupID);
                    if (dsUserGroupChild != null)
                    {
                        foreach (DataRow row in dsUserGroupChild.Tables[0].Rows)
                        {
                            ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectFromDataRow(row);
                            if (objADUserGroupSectionsInfo != null)
                            {
                                TreeListNode treeListChildNode = fld_trlstUserGroup.AppendNode(new object[] { objADUserGroupSectionsInfo.ADUserGroupSectionName, treeListNode.Level + 1 }, treeListNode);
                                treeListChildNode.Tag = objADUserGroupSectionsInfo.ADUserGroupSectionID;
                                AddModuleNode(fld_trlstUserGroup, objADUserGroupSectionsInfo.ADUserGroupSectionID, treeListChildNode);
                            }
                        }
                    }

                }
            }
            fld_trlstUserGroup.EndUnboundLoad();
        }

        public bool HasChild(int iUserGroupID)
        {
            DataSet ds = new ADUserGroupSectionsController().GetAllDataByForeignColumn("ADUserGroupID", iUserGroupID);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }

        private void AddModuleNode(TreeList fld_trlstUserGroup, int iUserGroupSectionID, TreeListNode parentNode)
        {
            STModuleToUserGroupSectionsController objSTModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
            DataSet dsModuleUserGroupSections = objSTModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID(iUserGroupSectionID);
            if (dsModuleUserGroupSections != null)
            {
                foreach (DataRow row in dsModuleUserGroupSections.Tables[0].Rows)
                {
                    STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objSTModuleToUserGroupSectionsController.GetObjectFromDataRow(row);
                    if (objSTModuleToUserGroupSectionsInfo != null)
                    {
                        STModulesInfo objSTModulesInfo = (STModulesInfo)new STModulesController().GetObjectByID(objSTModuleToUserGroupSectionsInfo.FK_STModuleID);
                        if (objSTModulesInfo != null)
                        {
                            TreeListNode treeListModuleNode = fld_trlstUserGroup.AppendNode(new object[] { objSTModulesInfo.STModuleDesc, parentNode.Level + 1 }, parentNode);
                            treeListModuleNode.Tag = objSTModulesInfo.STModuleID;
                        }
                    }
                }
            }
        }

        public void SaveFieldPermission(TreeListNode treeListNode)
        {

            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            if (treeListNode.Level != 3)
                return;

            TreeListNode userGroupNode = treeListNode.ParentNode.ParentNode;
            ADUserGroupsController objUserGroupsController = new ADUserGroupsController();
            int userGroupID = Convert.ToInt32(userGroupNode.Tag);
            STModulesController objSTModulesController = new STModulesController();
            int moduleID = Convert.ToInt32(treeListNode.Tag);
            string moduleName = objSTModulesController.GetObjectNameByID(moduleID);

            //STFieldPermissionsController objFieldPermissionsController = new STFieldPermissionsController();
            //guiConfigureToolbar guiConfigToolbar = new guiConfigureToolbar();
            //entity.STToolbarsTreeList.InvalidateTreeList(moduleID, true);
            //List<STFieldPermissionsInfo> fieldPermissions = objFieldPermissionsController.GetFieldPermissionList(userGroupID, moduleName, null, null, null);
            //foreach (STFieldPermissionsInfo objFieldPermissionsInfo in fieldPermissions)
            //{
            //    STToolbarsInfo objToolbarsInfo = (STToolbarsInfo)entity.STToolbarsTreeList.GetObjectByPropertyNameAndValue("STToolbarName", objFieldPermissionsInfo.STToolbarName);
            //    if (objToolbarsInfo != null)
            //    {
            //        if (objFieldPermissionsInfo.STFieldPermissionType.Equals((int)FieldPermissionType.None))
            //        {
            //            objToolbarsInfo.Selected = true;
            //        }
            //        else
            //        {
            //            objToolbarsInfo.Selected = false;
            //        }
            //    }
            //}
            //guiConfigToolbar.Module = this;
            //guiConfigToolbar.InitializeControls();
            //if (guiConfigToolbar.ShowDialog() == DialogResult.OK)
            //{
            //    entity.SaveFieldPermission(userGroupID, moduleName);
            //    MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        public void InvalidateUserList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ADUsersController objUsersController = new ADUsersController();
            DataSet ds = objUsersController.GetAllObjects();
            entity.ADUserList.Invalidate(ds);
        }

        public void AddUser()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ADUsersInfo objUsersInfo = new ADUsersInfo();
            guiManageUser guiUser = new guiManageUser(objUsersInfo);
            //guiUser.BringToFront();
            //guiUser.loca
            if (guiUser.ShowDialog() != DialogResult.OK)
                return;
            objUsersInfo = guiUser.ADUsers;
            ADUsersController objUsersController = new ADUsersController();
            objUsersController.CreateObject(objUsersInfo);
            InvalidateUserList();
        }
        public void EditUser()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ADUsersInfo objUsersInfo = entity.ADUserList[entity.ADUserList.CurrentIndex];
            if (objUsersInfo == null)
                return;

            guiManageUser guiUser = new guiManageUser(objUsersInfo);
            if (guiUser.ShowDialog() != DialogResult.OK)
                return;
            objUsersInfo = guiUser.ADUsers;
            ADUsersController objUsersController = new ADUsersController();
            objUsersController.UpdateObject(objUsersInfo);
            InvalidateUserList();
        }

        public void DeleteUser()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ADUsersInfo objUsersInfo = entity.ADUserList[entity.ADUserList.CurrentIndex];
            if (objUsersInfo == null)
                return;

            DialogResult rs =  MessageBox.Show("Bạn có chắn chắn muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
                return;

            ADUsersController objUsersController = new ADUsersController();
            objUsersController.DeleteObject(objUsersInfo.ADUserID);
            InvalidateUserList();
        }
        
    }
}
