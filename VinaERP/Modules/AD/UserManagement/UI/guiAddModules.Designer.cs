namespace VinaERP.Modules.UserManagement.UI
{
    partial class GuiAddModules
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fld_dgcModuleNoneActiveGridControl = new DevExpress.XtraGrid.GridControl();
            this.fld_dgvCurrentModuleGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fld_dgcModuleActivesGridControl = new DevExpress.XtraGrid.GridControl();
            this.fld_dgvActiveModulesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fld_btnBackward = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnForward = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnSaveMUGSection = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnCloseModule = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleNoneActiveGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvCurrentModuleGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleActivesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvActiveModulesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fld_dgcModuleNoneActiveGridControl);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách module";
            // 
            // fld_dgcModuleNoneActiveGridControl
            // 
            this.fld_dgcModuleNoneActiveGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcModuleNoneActiveGridControl.Location = new System.Drawing.Point(3, 17);
            this.fld_dgcModuleNoneActiveGridControl.MainView = this.fld_dgvCurrentModuleGridView;
            this.fld_dgcModuleNoneActiveGridControl.Name = "fld_dgcModuleNoneActiveGridControl";
            this.fld_dgcModuleNoneActiveGridControl.Size = new System.Drawing.Size(241, 367);
            this.fld_dgcModuleNoneActiveGridControl.TabIndex = 0;
            this.fld_dgcModuleNoneActiveGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvCurrentModuleGridView});
            // 
            // fld_dgvCurrentModuleGridView
            // 
            this.fld_dgvCurrentModuleGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.fld_dgvCurrentModuleGridView.GridControl = this.fld_dgcModuleNoneActiveGridControl;
            this.fld_dgvCurrentModuleGridView.Name = "fld_dgvCurrentModuleGridView";
            this.fld_dgvCurrentModuleGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên module";
            this.gridColumn2.FieldName = "STModuleDesc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fld_dgcModuleActivesGridControl);
            this.groupBox2.Location = new System.Drawing.Point(320, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 387);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhóm module hiện hành";
            // 
            // fld_dgcModuleActivesGridControl
            // 
            this.fld_dgcModuleActivesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcModuleActivesGridControl.Location = new System.Drawing.Point(3, 17);
            this.fld_dgcModuleActivesGridControl.MainView = this.fld_dgvActiveModulesGridView;
            this.fld_dgcModuleActivesGridControl.Name = "fld_dgcModuleActivesGridControl";
            this.fld_dgcModuleActivesGridControl.Size = new System.Drawing.Size(241, 367);
            this.fld_dgcModuleActivesGridControl.TabIndex = 1;
            this.fld_dgcModuleActivesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvActiveModulesGridView});
            // 
            // fld_dgvActiveModulesGridView
            // 
            this.fld_dgvActiveModulesGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.fld_dgvActiveModulesGridView.GridControl = this.fld_dgcModuleActivesGridControl;
            this.fld_dgvActiveModulesGridView.Name = "fld_dgvActiveModulesGridView";
            this.fld_dgvActiveModulesGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên module";
            this.gridColumn1.FieldName = "STModuleDesc";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // fld_btnBackward
            // 
            this.fld_btnBackward.Location = new System.Drawing.Point(260, 200);
            this.fld_btnBackward.Name = "fld_btnBackward";
            this.fld_btnBackward.Size = new System.Drawing.Size(54, 23);
            this.fld_btnBackward.TabIndex = 5;
            this.fld_btnBackward.Text = "<<";
            this.fld_btnBackward.Click += new System.EventHandler(this.fld_btnBackward_Click);
            // 
            // fld_btnForward
            // 
            this.fld_btnForward.Location = new System.Drawing.Point(260, 171);
            this.fld_btnForward.Name = "fld_btnForward";
            this.fld_btnForward.Size = new System.Drawing.Size(54, 23);
            this.fld_btnForward.TabIndex = 4;
            this.fld_btnForward.Text = ">>";
            this.fld_btnForward.Click += new System.EventHandler(this.fld_btnForward_Click);
            // 
            // fld_btnSaveMUGSection
            // 
            this.fld_btnSaveMUGSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_btnSaveMUGSection.Location = new System.Drawing.Point(411, 406);
            this.fld_btnSaveMUGSection.Name = "fld_btnSaveMUGSection";
            this.fld_btnSaveMUGSection.Size = new System.Drawing.Size(75, 25);
            this.fld_btnSaveMUGSection.TabIndex = 3;
            this.fld_btnSaveMUGSection.Text = "Đồng ý";
            this.fld_btnSaveMUGSection.Click += new System.EventHandler(this.fld_btnSaveMUGSection_Click);
            // 
            // fld_btnCloseModule
            // 
            this.fld_btnCloseModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_btnCloseModule.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCloseModule.Location = new System.Drawing.Point(492, 406);
            this.fld_btnCloseModule.Name = "fld_btnCloseModule";
            this.fld_btnCloseModule.Size = new System.Drawing.Size(75, 25);
            this.fld_btnCloseModule.TabIndex = 4;
            this.fld_btnCloseModule.Text = "Hủy bỏ";
            this.fld_btnCloseModule.Click += new System.EventHandler(this.fld_btnCloseModule_Click);
            // 
            // GuiAddModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 443);
            this.Controls.Add(this.fld_btnSaveMUGSection);
            this.Controls.Add(this.fld_btnBackward);
            this.Controls.Add(this.fld_btnCloseModule);
            this.Controls.Add(this.fld_btnForward);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GuiAddModules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/ Xóa module";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleNoneActiveGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvCurrentModuleGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleActivesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvActiveModulesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton fld_btnBackward;
        private DevExpress.XtraEditors.SimpleButton fld_btnForward;
        private DevExpress.XtraEditors.SimpleButton fld_btnSaveMUGSection;
        private DevExpress.XtraEditors.SimpleButton fld_btnCloseModule;
        private DevExpress.XtraGrid.GridControl fld_dgcModuleNoneActiveGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvCurrentModuleGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl fld_dgcModuleActivesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvActiveModulesGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}