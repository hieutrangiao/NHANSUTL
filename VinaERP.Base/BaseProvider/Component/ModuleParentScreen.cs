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
using System.Reflection;
using VinaLib;
using System.Windows.Forms.Layout;
using DevExpress.XtraBars.Docking;

namespace VinaERP
{
    public partial class ModuleParentScreen : DevExpress.XtraEditors.XtraForm
    {
        #region Properties Controls
        public DevExpress.XtraBars.BarManager ToolbarManager
        {
            get { return fld_barMenuModuleManager; }
            set { fld_barMenuModuleManager = value; }
        }

        public DevExpress.XtraEditors.PanelControl SearchResultsContainer
        {
            get { return fld_pnlSearchResults; }
            set { fld_pnlSearchResults = value; }
        }

        public DevExpress.XtraTab.XtraTabControl ScreenContainer
        {
            get { return fld_tabcMainViewApplication; }
            set { fld_tabcMainViewApplication = value; }
        }

        public DockPanel LeftPanelContainer
        {
            get { return fld_pnlSearchObject; }
        }

        public BaseModuleERP Module { get; set; }
        #endregion

        public ModuleParentScreen()
        {
            InitializeComponent();
        }

        public void ModuleParentScreen_Init()
        {
            STModulesController objModulesController = new STModulesController();
            STModulesInfo objModulesInfo = objModulesController.GetObjectByID(Module.CurrentModuleID) as STModulesInfo;
            if (objModulesInfo != null)
                this.Text = objModulesInfo.STModuleDesc;
            else
                this.Text = Module.CurrentModuleName;
            InitDisplayToolbar();
        }

        public void InitDisplayToolbar()
        {
            STToolbarsController objToolbarsController = new STToolbarsController();
            List<STToolbarsInfo> toolbarList = objToolbarsController.GetAllToolbarByModuleID(Module.CurrentModuleID, VinaApp.CurrentUserInfo.FK_ADUserGroupID);

            InitDisplayToolbarGroup(toolbarList.Where(o => o.STToolbarGroup == BaseToolbar.ToolbarAction).ToList()
                                    , BaseToolbar.ToolbarAction);

            InitDisplayToolbarGroup(toolbarList.Where(o => o.STToolbarGroup == BaseToolbar.ToolbarExtra).ToList()
                                    , BaseToolbar.ToolbarExtra);

            InitDisplayToolbarGroup(toolbarList.Where(o => o.STToolbarGroup == BaseToolbar.ToolbarUtility).ToList()
                                    , BaseToolbar.ToolbarUtility);

            InitDisplayToolbarGroup(toolbarList.Where(o => o.STToolbarGroup == BaseToolbar.ToolbarInfo).ToList()
                                    , BaseToolbar.ToolbarInfo);

            ToolbarManager.AllowCustomization = false;
            ToolbarManager.AllowMoveBarOnToolbar = false;
            ToolbarManager.AllowShowToolbarsPopup = true;
        }

        public void InitDisplayToolbarGroup(List<STToolbarsInfo> toolbarList, string strToolbarGroup)
        {
            if (toolbarList.Count() == 0)
                return;

            DevExpress.XtraBars.Bar fld_toolbarGroup = new DevExpress.XtraBars.Bar(ToolbarManager);
            fld_toolbarGroup.BarName = strToolbarGroup;
            fld_toolbarGroup.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            fld_toolbarGroup.Text = strToolbarGroup;
            fld_toolbarGroup.OptionsBar.AllowQuickCustomization = false;
            fld_toolbarGroup.OptionsBar.UseWholeRow = false;

            SetPropertiesOfToolbarGroup(ref fld_toolbarGroup, strToolbarGroup);

            DevExpress.XtraBars.BarItem[] btnButtons = InitToolbarButtonsForToolbar(toolbarList, strToolbarGroup);
            fld_toolbarGroup.AddItems(btnButtons);

            if (strToolbarGroup.Equals(BaseToolbar.ToolbarAction))
            {
                InitStatusForToolbarAction();
            }
        }

        private void SetPropertiesOfToolbarGroup(ref DevExpress.XtraBars.Bar fld_toolbarGroup, string strToolbarGroup)
        {
            switch (strToolbarGroup)
            {
                case BaseToolbar.ToolbarAction:
                    {
                        fld_toolbarGroup.DockCol = 0;
                        fld_toolbarGroup.DockRow = 0;
                        break;
                    }
                case BaseToolbar.ToolbarUtility:
                    {
                        fld_toolbarGroup.DockCol = 1;
                        fld_toolbarGroup.DockRow = 0;
                        break;
                    }
                case BaseToolbar.ToolbarInfo:
                    {
                        fld_toolbarGroup.DockCol = 2;
                        fld_toolbarGroup.DockRow = 0;
                        break;
                    }
                case BaseToolbar.ToolbarExtra:
                    {
                        fld_toolbarGroup.DockCol = 3;
                        fld_toolbarGroup.DockRow = 0;
                        break;
                    }
            }
        }

        public virtual DevExpress.XtraBars.BarItem[] InitToolbarButtonsForToolbar(List<STToolbarsInfo> toolbarList, string strToolbarGroup)
        {
            Dictionary<int, DevExpress.XtraBars.BarItem> lstParentToolbar = new Dictionary<int, DevExpress.XtraBars.BarItem>();
            List<DevExpress.XtraBars.BarItem> btnToolbarList = new List<DevExpress.XtraBars.BarItem>();

            STToolbarsController objSTToolbarsController = new STToolbarsController();
            if (toolbarList.Count() == 0)
                return btnToolbarList.ToArray();

            DevExpress.XtraBars.BarItem objBarItem = null;

            toolbarList.ForEach(o =>
            {
                objBarItem = null;
                if (toolbarList.Any(o1 => o1.STToolbarParentID == o.STToolbarID))
                {
                    objBarItem = new DevExpress.XtraBars.BarSubItem();
                    lstParentToolbar.Add(o.STToolbarID, objBarItem);
                }
                else
                {
                    objBarItem = new DevExpress.XtraBars.BarButtonItem();
                }
                objBarItem.Id = ToolbarManager.GetNewItemId();
                objBarItem.Name = o.STToolbarName;
                objBarItem.Tag = o.STToolbarTag;
                objBarItem.Caption = o.STToolbarCaption;
                objBarItem.Description = o.STToolbarDesc;
                objBarItem.Hint = strToolbarGroup;
                objBarItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;

                if (o.STToolbarParentID == 0)
                    btnToolbarList.Add(objBarItem);

                if (VinaApp.ToolbarImageList.Images.IndexOfKey(objBarItem.Tag.ToString()) >= 0)
                {
                    objBarItem.LargeImageIndex = VinaApp.ToolbarImageList.Images.IndexOfKey(objBarItem.Tag.ToString());
                    objBarItem.ImageIndex = VinaApp.ToolbarImageList.Images.IndexOfKey(objBarItem.Tag.ToString());
                    objBarItem.Glyph = VinaApp.ToolbarImageList.Images[objBarItem.Tag.ToString()];
                }

                if(objBarItem is DevExpress.XtraBars.BarButtonItem)
                {
                    objBarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ToolbarButton_ItemClick);
                    //InitHotKeyForToolbarButton(barButton);
                }

                if (lstParentToolbar.ContainsKey(o.STToolbarParentID))
                {
                    (lstParentToolbar[o.STToolbarParentID] as DevExpress.XtraBars.BarSubItem).AddItem(objBarItem);
                }

                ToolbarManager.Items.Add(objBarItem);
            });
            return btnToolbarList.ToArray();
        }

        public void ToolbarButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraBars.BarItem btn = sender as DevExpress.XtraBars.BarItem;
                String strToolbarTag = e.Item.Tag.ToString();
                String strToolbarGroup = e.Item.Hint;

                STToolbarFunctionsController objSTToolbarFunctionsController = new STToolbarFunctionsController();
                STToolbarFunctionsInfo objToolbarFunctionsInfo = objSTToolbarFunctionsController.GetLastToolbarFunctionByModuleIDAndToolbarTagAndGroup(Module.CurrentModuleID
                                                                                                                                                       , strToolbarTag
                                                                                                                                                       , strToolbarGroup);

                if (objToolbarFunctionsInfo != null)
                {
                    MethodInfo method = Module.GetMethodInfoByMethodFullNameAndMethodClass(objToolbarFunctionsInfo.STToolbarFunctionName,
                                                                                           objToolbarFunctionsInfo.STToolbarFunctionFullName,
                                                                                           objToolbarFunctionsInfo.STToolbarFunctionClass);

                    method.Invoke(Module, Module.GetMethodParameterValues(method.GetParameters(), sender, "ItemClick"));
                }
                else
                {
                    if (!(e.Item is DevExpress.XtraBars.BarSubItem))
                    {
                        switch (strToolbarTag)
                        {
                            case BaseToolbar.ToolbarButtonNew:
                                {
                                    Module.ActionNew();
                                    break;
                                }
                            case BaseToolbar.ToolbarButtonEdit:
                                {
                                    Module.ActionEdit();
                                    break;
                                }
                            case BaseToolbar.ToolbarButtonCancel:
                                {
                                    Module.ActionCancel();
                                    break;
                                }

                            case BaseToolbar.ToolbarButtonSave:
                                {
                                    Module.ActionSave();
                                    break;
                                }
                            case BaseToolbar.ToolbarButtonComplete:
                                {
                                    Module.ActionComplete();
                                    break;
                                }
                            case BaseToolbar.ToolbarButtonPrint:
                                {
                                    Module.ActionPrint();
                                    break;
                                }
                            case BaseToolbar.ToolbarButtonApproved:
                                {
                                    Module.ActionApproved();
                                    break;
                                }
                            default:
                                return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ModuleParentScreen_Activated(object sender, EventArgs e)
        {
            if (VinaApp.OpenModules.ContainsKey(VinaApp.CurrentModuleName))
                ((BaseModuleERP)VinaApp.OpenModules[VinaApp.CurrentModuleName]).ParentScreen.WindowState = FormWindowState.Minimized;

            base.Activate();

            CheckOpenModulesToolStripButton(Module.CurrentModuleName);

            this.WindowState = FormWindowState.Maximized;

            VinaApp.CurrentModuleName = Module.CurrentModuleName;
        }

        private void CheckOpenModulesToolStripButton(String strModuleName)
        {
            foreach (ToolStripButton tsbtnOpenedModule in VinaApp.MainScreen.OpenModulesToolStrip.Items)
            {
                if (tsbtnOpenedModule.Name != strModuleName)
                    tsbtnOpenedModule.Checked = false;
                else
                    tsbtnOpenedModule.Checked = true;
            }
        }

        private void ModuleParentScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Module.Close();
        }

        public virtual void InitStatusForToolbarAction()
        {
            try
            {
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonNew, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonCancel, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonSave, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
            }
            catch (Exception e)
            {
                MessageBox.Show("InitToolbarAction:" + e.Message);
            }
        }

        public virtual void InvalidateToolbarAfterActionNew()
        {
            try
            {

                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonNew, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonCancel, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonSave, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                this.fld_pnlSearchResults.Enabled = false;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("InvalidateToolbarAfterActionNew:" + ex.Message);
            }
        }

        public void SetEnableOfToolbarButton(String strToolbarGroup, String strButtonTag, bool isEnable)
        {
            DevExpress.XtraBars.BarItem barbtn = GetToolbarButton(strButtonTag);
            if (barbtn != null)
                barbtn.Enabled = isEnable;
        }

        public void SetEnableOfToolbarButton(String strButtonTag, bool isEnable)
        {
            DevExpress.XtraBars.BarItem barbtn = GetToolbarButton(strButtonTag);
            if (barbtn != null)
                barbtn.Enabled = isEnable;
        }

        public DevExpress.XtraBars.BarItem GetToolbarButton(String strToolbarTag)
        {
            String strToolbarName = "fld_barbtn" + strToolbarTag;
            if (ToolbarManager.Items[strToolbarName] != null)
                return (DevExpress.XtraBars.BarItem)ToolbarManager.Items[strToolbarName];
            else
                return null;
        }

        public virtual void InvalidateToolbarAfterActionCancel()
        {
            try
            {
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonNew, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonCancel, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonSave, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
                this.fld_pnlSearchResults.Enabled = true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("InvalidateToolbarAfterActionCancel:" + ex.Message);
            }
        }

        public virtual void InvalidateToolbarAfterActionSave()
        {
            try
            {
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonNew, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonCancel, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonSave, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
                this.fld_pnlSearchResults.Enabled = true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("InvalidateToolbarAfterActionSave:" + ex.Message);
            }
        }

        public virtual void InvalidateToolbarAfterActionEdit()
        {
            try
            {
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonNew, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonCancel, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonSave, true);
                SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                this.fld_pnlSearchResults.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("InvalidateToolbarAfterActionEdit:" + e.Message);
            }

        }

        public bool IsExistsGridSearchResult()
        {
            foreach (Control control in (ArrangedElementCollection)this.SearchResultsContainer.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "SR")
                    return true;
            }
            return false;
        }

        private void fld_btnSetFullSizeDockObject_Click(object sender, EventArgs e)
        {

        }
    }
}