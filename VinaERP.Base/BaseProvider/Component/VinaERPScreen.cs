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
using VinaLib;
using DevExpress.XtraGrid;
using System.Reflection;
using System.Collections;
using VinaLib.BaseProvider;

namespace VinaERP
{
    public partial class VinaERPScreen : VinaScreen
    {
        #region Properties

        public STScreensInfo ScreenInfo { get; set; }

        #endregion

        public VinaERPScreen()
        {
            InitializeComponent();
        }

        public void InitializeScreen(STScreensInfo objScreensInfo)
        {
            this.SuspendLayout();

            if (objScreensInfo != null)
            {
                ScreenInfo = objScreensInfo;
                ScreenID = objScreensInfo.STScreenID;
                ScreenCode = objScreensInfo.STScreenCode;
                ScreenID = objScreensInfo.STScreenID;
                ScreenName = objScreensInfo.STScreenName;
                ScreenCode = objScreensInfo.STScreenCode;
                Text = objScreensInfo.STScreenDesc;

                InitializeControls(this.Controls);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }

        public virtual void InitializeControls(Control.ControlCollection controls)
        {
            try
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    Control ctrl = controls[i];
                    ctrl = InitializeControl(ctrl);
                    if (!Module.Contains(ctrl.Name))
                        this.Module.Controls.Add(ctrl.Name, ctrl);
                    else
                        this.Module.Controls[ctrl.Name] = ctrl;

                    if (ctrl.Controls.Count > 0)
                        InitializeControls(ctrl.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual Control InitializeControl(Control ctrl)
        {
            if (ctrl is IVinaControl)
            {
                IVinaControl control = (IVinaControl)ctrl;
                control.Screen = this;
                control.InitializeControl();
            }
            return ctrl;
        }

        public override void BindingDataControl(Control ctrl)
        {
            try
            {
                VinaDbUtil dbUtil = new VinaDbUtil();
                String strDataSource = dbUtil.GetPropertyStringValue(ctrl, cstDataSourcePropertyName);
                String strDataMember = dbUtil.GetPropertyStringValue(ctrl, cstDataMemberPropertyName);
                String strPropertyName = dbUtil.GetPropertyStringValue(ctrl, "VinaPropertyName");
                ERPModuleEntities entity = ((BaseModuleERP)Module).CurrentModuleEntity;
                if (ctrl.Tag != null)
                {
                    if (ctrl.Tag.Equals(DataControl))
                    {
                        String strMainModuleTable = VinaUtil.GetTableNameFromBusinessObject(entity.MainObject);
                        if (strDataSource.Equals(strMainModuleTable))
                        {
                            if (((BaseModuleERP)Module).CurrentModuleEntity.MainObject != null)
                            {
                                ctrl.DataBindings.Add(
                                                new Binding(strPropertyName,
                                                entity.MainObjectBindingSource,
                                                strDataMember,
                                                true,
                                                DataSourceUpdateMode.OnPropertyChanged));
                            }
                        }
                    }
                    else if (ctrl.Tag.Equals(SearchControl))
                    {
                        if (entity.SearchObjectBindingSource != null)
                        {
                            ctrl.DataBindings.Add(new Binding(strPropertyName,
                                                  entity.SearchObjectBindingSource,
                                                  strDataMember,
                                                  true,
                                                  DataSourceUpdateMode.OnPropertyChanged));
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public virtual void AddControlsToParentScreen()
        {
            if (IsDataMainScreen())
            {
                DevExpress.XtraTab.XtraTabPage tpScreen = new DevExpress.XtraTab.XtraTabPage();
                tpScreen.Text = this.Text;
                tpScreen.Name = this.ScreenCode;
                tpScreen.AutoScroll = true;
                tpScreen.AutoScrollMinSize = new Size(Width, Height - 30);
                ((BaseModuleERP)Module).ParentScreen.ScreenContainer.TabPages.Add(tpScreen);
            }

            ModuleParentScreen parentScreen = ((BaseModuleERP)Module).ParentScreen;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control ctrl = this.Controls[i];

                bool flag = false;
                if (ctrl.Tag != null)
                {
                    switch (ctrl.Tag.ToString())
                    {
                        case VinaERPScreen.SearchResultControl:
                            Size controlSize = parentScreen.SearchResultsContainer.Size;
                            ctrl.Size = controlSize;
                            parentScreen.SearchResultsContainer.Controls.Add(ctrl);
                            parentScreen.SearchResultsContainer.Controls[ctrl.Name].Dock = DockStyle.Fill;
                            i--;
                            flag = true;
                            break;
                        case VinaERPScreen.SearchInfo:
                        case VinaERPScreen.SearchControl:
                            //if (IsSearchMainScreen())
                            //{
                            //    ((BaseModuleERP)Module).SearchScreen.CriteriaSection.Controls.Add(ctrl);
                            //    i--;
                            //    flag = true;
                            //}
                            break;
                    }
                }
                if (flag == false)
                {
                    if (parentScreen.ScreenContainer.TabPages.Count > 0)
                    {
                        parentScreen.ScreenContainer.TabPages[parentScreen.ScreenContainer.TabPages.Count - 1].Controls.Add(ctrl);
                        i--;
                    }
                }
            }
        }
    }
}