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
using DevExpress.XtraBars;
using System.Collections;
using DevExpress.LookAndFeel;

namespace VinaERP
{
    public partial class GUIMain : VinaLib.BaseProvider.VinaMainForm
    {

        public GUIMain()
        {
            InitializeComponent();
            VinaApp.MainScreen = this;
            VinaApp.VinaAssembly = Assembly.LoadFrom(Application.StartupPath + "\\VinaERP.exe");
        }

        public ToolStrip OpenModulesToolStrip
        {
            get { return fld_tsOpenedModules; }
            set { fld_tsOpenedModules = value; }
        }

        public Bar MainMenu
        {
            get { return fld_mnMainMenu; }
            set { fld_mnMainMenu = value; }
        }



        private void fld_barbtnToolbar_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem subMenu = e.Item as BarButtonItem;
            if (subMenu == null || (subMenu != null && subMenu.Tag == null))
                return;
            VinaApp.ShowModule(subMenu.Tag.ToString());
        }

        private void GUIMain_Load(object sender, EventArgs e)
        {
            OpenModulesToolStrip.Visible = true;
            VinaApp.LogOn();
        }

        private void fld_skinDevExpressChangeSkins_ItemClick(object sender, ItemClickEventArgs e)
        {
            VinaApp.SetApplicationStyle(UserLookAndFeel.Default.ActiveStyle.ToString(), UserLookAndFeel.Default.ActiveSkinName);
        }

        private void GUIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            VinaApp.SaveUserStyle(UserLookAndFeel.Default.ActiveStyle.ToString(), UserLookAndFeel.Default.ActiveSkinName);
            VinaApp.LogOutAndClearSection();
        }
    }
}