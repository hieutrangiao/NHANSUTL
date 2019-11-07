namespace VinaERP.Modules.UserManagement.UI
{
    partial class GuiUserManagement
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
            this.fld_splitContainnerUserManagement = new DevExpress.XtraEditors.SplitContainerControl();
            this.fld_groupUserGroup = new DevExpress.XtraEditors.GroupControl();
            this.fld_treeUserGroup = new DevExpress.XtraTreeList.TreeList();
            this.fld_tlcUserGroupName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.fld_groupUserGroupSection = new DevExpress.XtraEditors.GroupControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.fld_btnConfigToolbar = new DevExpress.XtraEditors.SimpleButton();
            this.fld_xtraTabPermissions = new DevExpress.XtraTab.XtraTabControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_splitContainnerUserManagement)).BeginInit();
            this.fld_splitContainnerUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_groupUserGroup)).BeginInit();
            this.fld_groupUserGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_treeUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_groupUserGroupSection)).BeginInit();
            this.fld_groupUserGroupSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_xtraTabPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_splitContainnerUserManagement
            // 
            this.fld_splitContainnerUserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_splitContainnerUserManagement.Location = new System.Drawing.Point(0, 0);
            this.fld_splitContainnerUserManagement.Name = "fld_splitContainnerUserManagement";
            this.fld_splitContainnerUserManagement.Panel1.Controls.Add(this.fld_groupUserGroup);
            this.fld_splitContainnerUserManagement.Panel1.Text = "Panel1";
            this.fld_splitContainnerUserManagement.Panel2.Controls.Add(this.fld_groupUserGroupSection);
            this.fld_splitContainnerUserManagement.Panel2.Text = "Panel2";
            this.fld_splitContainnerUserManagement.Size = new System.Drawing.Size(1079, 640);
            this.fld_splitContainnerUserManagement.SplitterPosition = 259;
            this.fld_splitContainnerUserManagement.TabIndex = 0;
            this.fld_splitContainnerUserManagement.Text = "splitContainerControl1";
            // 
            // fld_groupUserGroup
            // 
            this.fld_groupUserGroup.Controls.Add(this.fld_treeUserGroup);
            this.fld_groupUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_groupUserGroup.Location = new System.Drawing.Point(0, 0);
            this.fld_groupUserGroup.Name = "fld_groupUserGroup";
            this.fld_groupUserGroup.Size = new System.Drawing.Size(259, 640);
            this.fld_groupUserGroup.TabIndex = 1;
            this.fld_groupUserGroup.Text = "Nhóm người dùng";
            // 
            // fld_treeUserGroup
            // 
            this.fld_treeUserGroup.AllowDrop = true;
            this.fld_treeUserGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.fld_tlcUserGroupName});
            this.fld_treeUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_treeUserGroup.Location = new System.Drawing.Point(2, 20);
            this.fld_treeUserGroup.Name = "fld_treeUserGroup";
            this.fld_treeUserGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fld_treeUserGroup.OptionsView.ShowColumns = false;
            this.fld_treeUserGroup.OptionsView.ShowIndicator = false;
            this.fld_treeUserGroup.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.fld_treeUserGroup.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.fld_treeUserGroup.Size = new System.Drawing.Size(255, 618);
            this.fld_treeUserGroup.TabIndex = 1;
            this.fld_treeUserGroup.DragDrop += new System.Windows.Forms.DragEventHandler(this.fld_trlstUserGroup_DragDrop);
            this.fld_treeUserGroup.DragOver += new System.Windows.Forms.DragEventHandler(this.fld_trlstUserGroup_DragOver);
            this.fld_treeUserGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fld_trlstUserGroup_MouseClick);
            // 
            // fld_tlcUserGroupName
            // 
            this.fld_tlcUserGroupName.Caption = "User Group";
            this.fld_tlcUserGroupName.FieldName = "UserGroup";
            this.fld_tlcUserGroupName.Name = "fld_tlcUserGroupName";
            this.fld_tlcUserGroupName.OptionsColumn.AllowEdit = false;
            this.fld_tlcUserGroupName.OptionsColumn.ReadOnly = true;
            this.fld_tlcUserGroupName.Visible = true;
            this.fld_tlcUserGroupName.VisibleIndex = 0;
            this.fld_tlcUserGroupName.Width = 380;
            // 
            // fld_groupUserGroupSection
            // 
            this.fld_groupUserGroupSection.Controls.Add(this.panelControl6);
            this.fld_groupUserGroupSection.Controls.Add(this.fld_xtraTabPermissions);
            this.fld_groupUserGroupSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_groupUserGroupSection.Location = new System.Drawing.Point(0, 0);
            this.fld_groupUserGroupSection.Name = "fld_groupUserGroupSection";
            this.fld_groupUserGroupSection.Size = new System.Drawing.Size(815, 640);
            this.fld_groupUserGroupSection.TabIndex = 0;
            this.fld_groupUserGroupSection.Text = "Phân quyền";
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.fld_btnConfigToolbar);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 595);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(811, 43);
            this.panelControl6.TabIndex = 1;
            // 
            // fld_btnConfigToolbar
            // 
            this.fld_btnConfigToolbar.Location = new System.Drawing.Point(11, 8);
            this.fld_btnConfigToolbar.Name = "fld_btnConfigToolbar";
            this.fld_btnConfigToolbar.Size = new System.Drawing.Size(153, 30);
            this.fld_btnConfigToolbar.TabIndex = 0;
            this.fld_btnConfigToolbar.Text = "Cấu hình thanh chức năng";
            this.fld_btnConfigToolbar.Click += new System.EventHandler(this.Fld_btnConfigToolbar_Click);
            // 
            // fld_xtraTabPermissions
            // 
            this.fld_xtraTabPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_xtraTabPermissions.Location = new System.Drawing.Point(2, 20);
            this.fld_xtraTabPermissions.Name = "fld_xtraTabPermissions";
            this.fld_xtraTabPermissions.Size = new System.Drawing.Size(811, 577);
            this.fld_xtraTabPermissions.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(1, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(730, 612);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(1, 571);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(730, 42);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(6, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(130, 28);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Cấu hình thanh công cụ";
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(1, 1);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(730, 612);
            this.panelControl3.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(200, 100);
            this.panelControl4.TabIndex = 0;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.simpleButton2);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl5.Location = new System.Drawing.Point(1, 568);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(730, 45);
            this.panelControl5.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(12, 8);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(138, 30);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "Cấu hình thanh công cụ";
            // 
            // GuiUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 640);
            this.Controls.Add(this.fld_splitContainnerUserManagement);
            this.Name = "GuiUserManagement";
            this.Text = "Quản lý người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.fld_splitContainnerUserManagement)).EndInit();
            this.fld_splitContainnerUserManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_groupUserGroup)).EndInit();
            this.fld_groupUserGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_treeUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_groupUserGroupSection)).EndInit();
            this.fld_groupUserGroupSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_xtraTabPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl fld_splitContainnerUserManagement;
        private DevExpress.XtraEditors.GroupControl fld_groupUserGroup;
        private DevExpress.XtraEditors.GroupControl fld_groupUserGroupSection;
        private DevExpress.XtraTab.XtraTabControl fld_xtraTabPermissions;
        public DevExpress.XtraTreeList.TreeList fld_treeUserGroup;
        public DevExpress.XtraTreeList.Columns.TreeListColumn fld_tlcUserGroupName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton fld_btnConfigToolbar;
    }
}