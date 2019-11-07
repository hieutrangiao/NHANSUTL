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
    public enum AddSectionMode { Add, Edit }

    public partial class GuiAddSections : VinaERPScreen
    {

        private TreeList TreeList = null;

        private AddSectionMode Mode;

        public GuiAddSections()
        {
            InitializeComponent();
        }

        public GuiAddSections(TreeList treeList, AddSectionMode mode)
        {
            InitializeComponent();
            TreeList = treeList;
            Mode = mode;
        }

        private void fld_btnCloseSection_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnAddSection_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtSection.Text))
            {
                MessageBox.Show("Tên nhóm module không được để trống", "Thông báo" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
            if (Mode == AddSectionMode.Add)
            {
                ADUserGroupSectionsInfo objADUserGroupSectionsInfo = new ADUserGroupSectionsInfo();
                objADUserGroupSectionsInfo.FK_ADUserGroupID = Convert.ToInt32(TreeList.FocusedNode.Tag);
                objADUserGroupSectionsInfo.ADUserGroupSectionName = fld_txtSection.Text;
                objADUserGroupSectionsInfo.ADUserGroupSectionDesc = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                int maxOrder = objUserGroupSectionsController.GetMaxSortOrderSectionByUserGroupID(objADUserGroupSectionsInfo.FK_ADUserGroupID);
                objADUserGroupSectionsInfo.ADUserGroupSectionSortOrder = maxOrder + 1;
                objUserGroupSectionsController.CreateObject(objADUserGroupSectionsInfo);
            }
            else if (Mode == AddSectionMode.Edit)
            {
                ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectByID(Convert.ToInt32(TreeList.FocusedNode.Tag));
                objADUserGroupSectionsInfo.ADUserGroupSectionName = fld_txtSection.Text;
                objADUserGroupSectionsInfo.ADUserGroupSectionDesc = fld_txtSection.Text;
                objUserGroupSectionsController.UpdateObject(objADUserGroupSectionsInfo);
            }
            ((UserManagementModule)this.Module).InitializeTreeList(TreeList);
            this.Close();
        }
    }
}