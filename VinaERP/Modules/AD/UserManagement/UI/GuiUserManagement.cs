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
using DevExpress.XtraTreeList.Nodes;
using VinaLib;

namespace VinaERP.Modules.UserManagement.UI
{
    public partial class GuiUserManagement : VinaERPScreen
    {

        private TreeListHitInfo downHitInfo;

        public GuiUserManagement()
        {
            InitializeComponent();
        }

        public TreeList TreeListUserGroup
        {
            get { return fld_treeUserGroup; }
            set { fld_treeUserGroup = value; }
        }

        private void fld_trlstUserGroup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeListNode node = fld_treeUserGroup.FocusedNode;
                if (node != null)
                {
                    if (node.Level == 0)
                    {
                        ContextMenu popupMenu = new ContextMenu();
                        popupMenu.MenuItems.Add("Thêm nhóm người dùng", new EventHandler(AddUserGroup_Clicked));
                        popupMenu.Show(fld_treeUserGroup, new Point(e.X, e.Y));

                    }
                    else if (node.Level == 1)
                    {
                        ContextMenu popupMenu = new ContextMenu();
                        popupMenu.MenuItems.Add("Thêm nhóm module", new EventHandler(AddSection_Clicked));
                        popupMenu.MenuItems.Add("Chỉnh sửa nhóm người dùng", new EventHandler(EditUserGroup_Clicked));
                        popupMenu.MenuItems.Add("Xóa nhóm người dùng", new EventHandler(DeleteUserGroup_Clicked));
                        popupMenu.Show(fld_treeUserGroup, new Point(e.X, e.Y));
                    }
                    else if (node.Level == 2)
                    {
                        ContextMenu popupMenu = new ContextMenu();
                        popupMenu.MenuItems.Add("Thêm/Xóa module", new EventHandler(AddModule_Clicked));
                        popupMenu.MenuItems.Add("Chỉnh sửa nhóm module", new EventHandler(EditSection_Clicked));
                        popupMenu.MenuItems.Add("Xóa nhóm module", new EventHandler(DeleteSection_Clicked));
                        popupMenu.Show(fld_treeUserGroup, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void AddUserGroup_Clicked(object sender, EventArgs e)
        {
            GuiAddUserGroups guiAddUserGroups = new GuiAddUserGroups(fld_treeUserGroup, AddUserGroupMode.Add);
            guiAddUserGroups.Module = this.Module;
            guiAddUserGroups.ShowDialog();
        }

        private void EditUserGroup_Clicked(object sender, EventArgs e)
        {
            GuiAddUserGroups guiAddUserGroups = new GuiAddUserGroups(fld_treeUserGroup, AddUserGroupMode.Edit);
            guiAddUserGroups.Module = this.Module;
            guiAddUserGroups.fld_txtUserGroup.Text = fld_treeUserGroup.FocusedNode.GetDisplayText(fld_treeUserGroup.Columns[0]);
            guiAddUserGroups.ShowDialog();
        }

        private void DeleteUserGroup_Clicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhóm người dùng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TreeListNode node = fld_treeUserGroup.FocusedNode;
                ADUserGroupsController objUserGroupsController = new ADUserGroupsController();
                ADUserGroupsInfo objUserGroupsInfo = (ADUserGroupsInfo)objUserGroupsController.GetObjectByID((int)node.Tag);
                objUserGroupsController.DeleteObject(objUserGroupsInfo.ADUserGroupID);
                ((UserManagementModule)Module).InitializeTreeList(fld_treeUserGroup);
            }
        }

        private void AddSection_Clicked(object sender, EventArgs e)
        {
            GuiAddSections guiAddSections = new GuiAddSections(fld_treeUserGroup, AddSectionMode.Add);
            guiAddSections.Module = this.Module;
            guiAddSections.ShowDialog();
        }

        private void AddModule_Clicked(object sender, EventArgs e)
        {
            GuiAddModules guiAddModules = new GuiAddModules(fld_treeUserGroup);
            guiAddModules.Module = this.Module;
            guiAddModules.ShowDialog();
        }

       
        private void EditSection_Clicked(object sender, EventArgs e)
        {
            GuiAddSections guiAddSections = new GuiAddSections(fld_treeUserGroup, AddSectionMode.Edit);
            guiAddSections.Module = this.Module;
            guiAddSections.fld_txtSection.Text = fld_treeUserGroup.FocusedNode.GetDisplayText(fld_treeUserGroup.Columns[0]);
            guiAddSections.ShowDialog();
        }

        private void DeleteSection_Clicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhóm module này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TreeListNode node = fld_treeUserGroup.FocusedNode;
                ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                STModuleToUserGroupSectionsController objModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();

                DataSet ds = objModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID((int)node.Tag);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STModuleToUserGroupSectionsInfo objModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objModuleToUserGroupSectionsController.GetObjectFromDataRow(row);
                    objModuleToUserGroupSectionsController.DeleteObject(objModuleToUserGroupSectionsInfo.STModuleToUserGroupSectionID);
                }

                objUserGroupSectionsController.DeleteObject((int)node.Tag);
                ((UserManagementModule)Module).InitializeTreeList(fld_treeUserGroup);
            }
        }

        private void fld_trlstUserGroup_DragDrop(object sender, DragEventArgs e)
        {
            TreeListHitInfo hitInfo = fld_treeUserGroup.CalcHitInfo(fld_treeUserGroup.PointToClient(new Point(e.X, e.Y)));
            TreeListNode targetNode = hitInfo.Node;
            TreeListNode sourceNode = downHitInfo.Node;
            if (targetNode != null)
            {
                if (targetNode.Level == 3 && sourceNode.Level == 3 && targetNode.ParentNode == sourceNode.ParentNode)
                {
                    STModuleToUserGroupSectionsController objSTModuleToUserGroupSectionController = new STModuleToUserGroupSectionsController();
                    STModuleToUserGroupSectionsInfo objModuleToUserGroupSectionsInfoSource = (STModuleToUserGroupSectionsInfo)objSTModuleToUserGroupSectionController.GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleID((int)sourceNode.ParentNode.Tag, (int)sourceNode.Tag);
                    STModuleToUserGroupSectionsInfo objModuleToUserGroupSectionsInfoTarget = (STModuleToUserGroupSectionsInfo)objSTModuleToUserGroupSectionController.GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleID((int)targetNode.ParentNode.Tag, (int)targetNode.Tag);

                    int sortOrderSrc = objModuleToUserGroupSectionsInfoSource.STModuleToUserGroupSectionSortOrder;
                    objModuleToUserGroupSectionsInfoSource.STModuleToUserGroupSectionSortOrder = objModuleToUserGroupSectionsInfoTarget.STModuleToUserGroupSectionSortOrder;
                    objModuleToUserGroupSectionsInfoTarget.STModuleToUserGroupSectionSortOrder = sortOrderSrc;

                    //Update
                    objSTModuleToUserGroupSectionController.UpdateObject(objModuleToUserGroupSectionsInfoSource);
                    objSTModuleToUserGroupSectionController.UpdateObject(objModuleToUserGroupSectionsInfoTarget);
                    ((UserManagementModule)Module).InitializeTreeList(fld_treeUserGroup);
                }
                else if (targetNode.Level == 2 && sourceNode.Level == 2 && targetNode.ParentNode == sourceNode.ParentNode)
                {
                    ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                    ADUserGroupSectionsInfo objUserGroupSectionsInfoSource = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectByID((int)sourceNode.Tag);
                    ADUserGroupSectionsInfo objUserGroupSectionsInfoTarget = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectByID((int)targetNode.Tag);

                    int sortOrderSrc = objUserGroupSectionsInfoSource.ADUserGroupSectionSortOrder;
                    objUserGroupSectionsInfoSource.ADUserGroupSectionSortOrder = objUserGroupSectionsInfoTarget.ADUserGroupSectionSortOrder;
                    objUserGroupSectionsInfoTarget.ADUserGroupSectionSortOrder = sortOrderSrc;

                    //Update
                    objUserGroupSectionsController.UpdateObject(objUserGroupSectionsInfoSource);
                    objUserGroupSectionsController.UpdateObject(objUserGroupSectionsInfoTarget);
                    ((UserManagementModule)Module).InitializeTreeList(fld_treeUserGroup);
                }
                else
                    return;
            }
        }

        private void fld_trlstUserGroup_DragOver(object sender, DragEventArgs e)
        {
            TreeListHitInfo hi = fld_treeUserGroup.CalcHitInfo(fld_treeUserGroup.PointToClient(new Point(e.X, e.Y)));
            TreeListNode node = GetDragNode(e.Data);
            if (node == null)
            {
                if (hi.HitInfoType == HitInfoType.Empty || hi.Node != null)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private TreeListNode GetDragNode(IDataObject data)
        {
            return data.GetData(typeof(TreeListNode)) as TreeListNode;
        }

        private void Fld_btnConfigToolbar_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).SaveFieldPermission(fld_treeUserGroup.FocusedNode);
        }
    }
}