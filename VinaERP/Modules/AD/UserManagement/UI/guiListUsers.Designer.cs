using VinaERP.Modules.UserManagement;

namespace VinaERP.Modules.UserManagement.UI
{
    partial class guiListUsers
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fld_dgcADUsersGridControl = new VinaERP.Modules.UserManagement.ADUsersGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fld_btnDeleteUser = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnEditUser = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnAddUser = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcADUsersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.fld_dgcADUsersGridControl);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(898, 451);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách người dùng";
            // 
            // fld_dgcADUsersGridControl
            // 
            this.fld_dgcADUsersGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcADUsersGridControl.Location = new System.Drawing.Point(2, 20);
            this.fld_dgcADUsersGridControl.MainView = this.gridView1;
            this.fld_dgcADUsersGridControl.Name = "fld_dgcADUsersGridControl";
            this.fld_dgcADUsersGridControl.Screen = null;
            this.fld_dgcADUsersGridControl.Size = new System.Drawing.Size(894, 385);
            this.fld_dgcADUsersGridControl.TabIndex = 17;
            this.fld_dgcADUsersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcADUsersGridControl.VinaDataMember = null;
            this.fld_dgcADUsersGridControl.VinaDataSource = "ADUsers";
            this.fld_dgcADUsersGridControl.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcADUsersGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fld_btnDeleteUser);
            this.panel1.Controls.Add(this.fld_btnEditUser);
            this.panel1.Controls.Add(this.fld_btnAddUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 44);
            this.panel1.TabIndex = 0;
            // 
            // fld_btnDeleteUser
            // 
            this.fld_btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnDeleteUser.Location = new System.Drawing.Point(810, 9);
            this.fld_btnDeleteUser.Name = "fld_btnDeleteUser";
            this.fld_btnDeleteUser.Size = new System.Drawing.Size(75, 27);
            this.fld_btnDeleteUser.TabIndex = 2;
            this.fld_btnDeleteUser.Text = "Xóa";
            this.fld_btnDeleteUser.Click += new System.EventHandler(this.Fld_btnDeleteUser_Click);
            // 
            // fld_btnEditUser
            // 
            this.fld_btnEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnEditUser.Location = new System.Drawing.Point(729, 9);
            this.fld_btnEditUser.Name = "fld_btnEditUser";
            this.fld_btnEditUser.Size = new System.Drawing.Size(75, 27);
            this.fld_btnEditUser.TabIndex = 1;
            this.fld_btnEditUser.Text = "Sửa";
            this.fld_btnEditUser.Click += new System.EventHandler(this.Fld_btnEditUser_Click);
            // 
            // fld_btnAddUser
            // 
            this.fld_btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnAddUser.Location = new System.Drawing.Point(648, 9);
            this.fld_btnAddUser.Name = "fld_btnAddUser";
            this.fld_btnAddUser.Size = new System.Drawing.Size(75, 27);
            this.fld_btnAddUser.TabIndex = 0;
            this.fld_btnAddUser.Text = "Thêm";
            this.fld_btnAddUser.Click += new System.EventHandler(this.Fld_btnAddUser_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(902, 455);
            this.panelControl1.TabIndex = 1;
            // 
            // guiListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 455);
            this.Controls.Add(this.panelControl1);
            this.Name = "guiListUsers";
            this.Text = "Danh sách người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcADUsersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton fld_btnAddUser;
        private ADUsersGridControl fld_dgcADUsersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton fld_btnDeleteUser;
        private DevExpress.XtraEditors.SimpleButton fld_btnEditUser;
    }
}