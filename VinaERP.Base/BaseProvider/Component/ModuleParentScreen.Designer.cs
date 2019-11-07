namespace VinaERP
{
    partial class ModuleParentScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleParentScreen));
            this.fld_barMenuModuleManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.fld_dockModuleManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.fld_pnlSearchObject = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.fld_pnlSearchResults = new DevExpress.XtraEditors.PanelControl();
            this.fld_tabcMainViewApplication = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.fld_barMenuModuleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dockModuleManager)).BeginInit();
            this.fld_pnlSearchObject.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pnlSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_tabcMainViewApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_barMenuModuleManager
            // 
            this.fld_barMenuModuleManager.DockControls.Add(this.barDockControlTop);
            this.fld_barMenuModuleManager.DockControls.Add(this.barDockControlBottom);
            this.fld_barMenuModuleManager.DockControls.Add(this.barDockControlLeft);
            this.fld_barMenuModuleManager.DockControls.Add(this.barDockControlRight);
            this.fld_barMenuModuleManager.DockManager = this.fld_dockModuleManager;
            this.fld_barMenuModuleManager.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.fld_barMenuModuleManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1166, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 585);
            this.barDockControlBottom.Manager = this.fld_barMenuModuleManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1166, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.fld_barMenuModuleManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 585);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1166, 0);
            this.barDockControlRight.Manager = this.fld_barMenuModuleManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 585);
            // 
            // fld_dockModuleManager
            // 
            this.fld_dockModuleManager.Form = this;
            this.fld_dockModuleManager.MenuManager = this.fld_barMenuModuleManager;
            this.fld_dockModuleManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.fld_pnlSearchObject});
            this.fld_dockModuleManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"});
            // 
            // fld_pnlSearchObject
            // 
            this.fld_pnlSearchObject.Controls.Add(this.dockPanel1_Container);
            this.fld_pnlSearchObject.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.fld_pnlSearchObject.ID = new System.Guid("44fed023-6da5-4d69-bc94-1db0b05d48e6");
            this.fld_pnlSearchObject.Location = new System.Drawing.Point(0, 0);
            this.fld_pnlSearchObject.Name = "fld_pnlSearchObject";
            this.fld_pnlSearchObject.OriginalSize = new System.Drawing.Size(287, 200);
            this.fld_pnlSearchObject.Size = new System.Drawing.Size(287, 585);
            this.fld_pnlSearchObject.Text = "Danh sách đối tượng";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.fld_pnlSearchResults);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(278, 558);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // fld_pnlSearchResults
            // 
            this.fld_pnlSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_pnlSearchResults.Location = new System.Drawing.Point(0, 0);
            this.fld_pnlSearchResults.Name = "fld_pnlSearchResults";
            this.fld_pnlSearchResults.Size = new System.Drawing.Size(278, 558);
            this.fld_pnlSearchResults.TabIndex = 13;
            // 
            // fld_tabcMainViewApplication
            // 
            this.fld_tabcMainViewApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_tabcMainViewApplication.Location = new System.Drawing.Point(287, 0);
            this.fld_tabcMainViewApplication.Name = "fld_tabcMainViewApplication";
            this.fld_tabcMainViewApplication.Size = new System.Drawing.Size(879, 585);
            this.fld_tabcMainViewApplication.TabIndex = 5;
            // 
            // ModuleParentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1166, 585);
            this.Controls.Add(this.fld_tabcMainViewApplication);
            this.Controls.Add(this.fld_pnlSearchObject);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuleParentScreen";
            this.Text = "ModuleParentScreen";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ModuleParentScreen_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModuleParentScreen_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.fld_barMenuModuleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dockModuleManager)).EndInit();
            this.fld_pnlSearchObject.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_pnlSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_tabcMainViewApplication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager fld_barMenuModuleManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager fld_dockModuleManager;
        private DevExpress.XtraBars.Docking.DockPanel fld_pnlSearchObject;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTab.XtraTabControl fld_tabcMainViewApplication;
        private DevExpress.XtraEditors.PanelControl fld_pnlSearchResults;
    }
}