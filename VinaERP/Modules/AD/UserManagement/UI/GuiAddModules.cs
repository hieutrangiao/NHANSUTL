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
using VinaERP.Base.BaseCommon;
using VinaLib;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Transactions;
using DevExpress.XtraTreeList.Nodes;

namespace VinaERP.Modules.UserManagement.UI
{
    public partial class GuiAddModules : VinaERPScreen
    {
        
        private TreeList treeList = null;
        private VinaList<STModulesInfo> lstModule;
        private GridHitInfo downHitInfo = null;

        public GuiAddModules()
        {
            InitializeComponent();
        }

        public GuiAddModules(TreeList _treeList)
        {
            InitializeComponent();
            this.treeList = _treeList;
            lstModule = new VinaList<STModulesInfo>();
            InitializeModuleNonSection();
            InitializeModuleSection();
        }
        public void InitializeModuleNonSection()
        {
            STModulesController objModulesController = new STModulesController();
            DataSet ds = objModulesController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                List<STModulesInfo> lstModules = new List<STModulesInfo>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STModulesInfo objModulesInfo = (STModulesInfo)objModulesController.GetObjectFromDataRow(row);
                    if(objModulesInfo.AAStatus != "Delete")
                        lstModules.Add(objModulesInfo);
                }
                fld_dgcModuleNoneActiveGridControl.DataSource = lstModules;
                fld_dgcModuleNoneActiveGridControl.RefreshDataSource();
            }
        }

        public void InitializeModuleSection()
        {
            TreeListNode node = treeList.FocusedNode;
            if (node != null)
            {
                ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectByID(Convert.ToInt32(node.Tag));
                if (objADUserGroupSectionsInfo != null)
                {
                    STModuleToUserGroupSectionsController objModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
                    DataSet ds = objModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID(objADUserGroupSectionsInfo.ADUserGroupSectionID);
                    if (ds != null)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)new STModuleToUserGroupSectionsController().GetObjectFromDataRow(row);
                            if (objADUserGroupSectionsInfo != null)
                            {
                                STModulesInfo objSTModulesInfo = (STModulesInfo)new STModulesController().GetObjectByID(objSTModuleToUserGroupSectionsInfo.FK_STModuleID);
                                if (objSTModulesInfo != null)
                                {
                                    lstModule.Add(objSTModulesInfo);
                                }
                            }
                        }
                    }
                }
            }
            fld_dgcModuleActivesGridControl.DataSource = lstModule;
            fld_dgcModuleActivesGridControl.RefreshDataSource();
        }


        private void fld_btnCloseModule_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnSaveMUGSection_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    TreeListNode node = treeList.FocusedNode;
                    if (node != null)
                    {
                        ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)new ADUserGroupSectionsController().GetObjectByID(Convert.ToInt32(node.Tag));
                        if (objADUserGroupSectionsInfo != null)
                        {
                            //delete all 
                            new STModuleToUserGroupSectionsController().DeleteAllModuleToUserGroupSectionByUserGroupSectionID(objADUserGroupSectionsInfo.ADUserGroupSectionID);
                            int iSortOrder = 0;
                            foreach (STModulesInfo objSTModulesInfo in lstModule)
                            {
                                iSortOrder++;
                                STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = new STModuleToUserGroupSectionsInfo();
                                objSTModuleToUserGroupSectionsInfo.FK_STModuleID = objSTModulesInfo.STModuleID;
                                objSTModuleToUserGroupSectionsInfo.STUserGroupSectionID = objADUserGroupSectionsInfo.ADUserGroupSectionID;
                                objSTModuleToUserGroupSectionsInfo.STModuleToUserGroupSectionSortOrder = iSortOrder;
                                new STModuleToUserGroupSectionsController().CreateObject(objSTModuleToUserGroupSectionsInfo);

                            }
                        }
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
            ((UserManagementModule)this.Module).InitializeTreeList(treeList);
            this.Close();
        }

        private void fld_btnForward_Click(object sender, EventArgs e)
        {
            int iRowHandle = fld_dgvCurrentModuleGridView.FocusedRowHandle;
            if (iRowHandle >= 0)
            {
                STModulesInfo objSTModulesInfo = (STModulesInfo)fld_dgvCurrentModuleGridView.GetRow(iRowHandle);
                if (objSTModulesInfo != null)
                {
                    if (lstModule.Exists("STModuleName", objSTModulesInfo.STModuleName))
                    {
                        MessageBox.Show("Module đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lstModule.Add(objSTModulesInfo);
                }
            }
            fld_dgcModuleActivesGridControl.DataSource = lstModule;
            fld_dgcModuleActivesGridControl.RefreshDataSource();
        }

        private void fld_btnBackward_Click(object sender, EventArgs e)
        {
            int iRowHandle = fld_dgvActiveModulesGridView.FocusedRowHandle;
            if (iRowHandle >= 0)
            {
                STModulesInfo objSTModulesInfo = (STModulesInfo)fld_dgvActiveModulesGridView.GetRow(iRowHandle);
                if (objSTModulesInfo != null)
                {
                    int iIndex = lstModule.IndexOf(objSTModulesInfo);
                    lstModule.RemoveAt(iIndex);
                }
            }
            fld_dgcModuleActivesGridControl.DataSource = lstModule;
            fld_dgcModuleActivesGridControl.RefreshDataSource();
        }

    }
}