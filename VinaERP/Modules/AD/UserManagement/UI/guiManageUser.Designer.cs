namespace VinaERP.Modules.UserManagement.UI
{
    partial class guiManageUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fld_btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.fld_txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.fld_txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.fld_txtRePassword = new DevExpress.XtraEditors.TextEdit();
            this.fld_lkeUserGroup = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_lkeHREmployeeID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_chkIsActive = new VinaLib.BaseProvider.VinaCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtRePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeUserGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHREmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhóm";
            // 
            // fld_btnSave
            // 
            this.fld_btnSave.Location = new System.Drawing.Point(168, 176);
            this.fld_btnSave.Name = "fld_btnSave";
            this.fld_btnSave.Size = new System.Drawing.Size(75, 27);
            this.fld_btnSave.TabIndex = 6;
            this.fld_btnSave.Text = "Lưu";
            this.fld_btnSave.Click += new System.EventHandler(this.Fld_btnSave_Click);
            // 
            // fld_btnClose
            // 
            this.fld_btnClose.Location = new System.Drawing.Point(249, 176);
            this.fld_btnClose.Name = "fld_btnClose";
            this.fld_btnClose.Size = new System.Drawing.Size(75, 27);
            this.fld_btnClose.TabIndex = 7;
            this.fld_btnClose.Text = "Hủy bỏ";
            this.fld_btnClose.Click += new System.EventHandler(this.Fld_btnClose_Click);
            // 
            // fld_txtUsername
            // 
            this.fld_txtUsername.Location = new System.Drawing.Point(135, 17);
            this.fld_txtUsername.Name = "fld_txtUsername";
            this.fld_txtUsername.Size = new System.Drawing.Size(189, 20);
            this.fld_txtUsername.TabIndex = 0;
            // 
            // fld_txtPassword
            // 
            this.fld_txtPassword.Location = new System.Drawing.Point(135, 43);
            this.fld_txtPassword.Name = "fld_txtPassword";
            this.fld_txtPassword.Properties.UseSystemPasswordChar = true;
            this.fld_txtPassword.Size = new System.Drawing.Size(189, 20);
            this.fld_txtPassword.TabIndex = 1;
            // 
            // fld_txtRePassword
            // 
            this.fld_txtRePassword.Location = new System.Drawing.Point(135, 69);
            this.fld_txtRePassword.Name = "fld_txtRePassword";
            this.fld_txtRePassword.Properties.UseSystemPasswordChar = true;
            this.fld_txtRePassword.Size = new System.Drawing.Size(189, 20);
            this.fld_txtRePassword.TabIndex = 2;
            // 
            // fld_lkeUserGroup
            // 
            this.fld_lkeUserGroup.Location = new System.Drawing.Point(135, 121);
            this.fld_lkeUserGroup.Name = "fld_lkeUserGroup";
            this.fld_lkeUserGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeUserGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADUserGroupName", "Nhóm người dùng")});
            this.fld_lkeUserGroup.Properties.DisplayMember = "ADUserGroupName";
            this.fld_lkeUserGroup.Properties.NullText = "";
            this.fld_lkeUserGroup.Properties.ValueMember = "ADUserGroupID";
            this.fld_lkeUserGroup.Screen = null;
            this.fld_lkeUserGroup.Size = new System.Drawing.Size(189, 20);
            this.fld_lkeUserGroup.TabIndex = 4;
            this.fld_lkeUserGroup.VinaAllowDummy = true;
            this.fld_lkeUserGroup.VinaAutoGenarateDataSoure = true;
            this.fld_lkeUserGroup.VinaDataMember = "FK_ADUserGroupID";
            this.fld_lkeUserGroup.VinaDataSource = "ADUsers";
            this.fld_lkeUserGroup.VinaPropertyName = null;
            // 
            // fld_lkeHREmployeeID
            // 
            this.fld_lkeHREmployeeID.Location = new System.Drawing.Point(135, 95);
            this.fld_lkeHREmployeeID.Name = "fld_lkeHREmployeeID";
            this.fld_lkeHREmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHREmployeeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên nhân viên")});
            this.fld_lkeHREmployeeID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeHREmployeeID.Properties.NullText = "";
            this.fld_lkeHREmployeeID.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeHREmployeeID.Screen = null;
            this.fld_lkeHREmployeeID.Size = new System.Drawing.Size(189, 20);
            this.fld_lkeHREmployeeID.TabIndex = 3;
            this.fld_lkeHREmployeeID.VinaAllowDummy = true;
            this.fld_lkeHREmployeeID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHREmployeeID.VinaDataMember = "FK_HREmployeeID";
            this.fld_lkeHREmployeeID.VinaDataSource = "ADUsers";
            this.fld_lkeHREmployeeID.VinaPropertyName = null;
            // 
            // fld_chkIsActive
            // 
            this.fld_chkIsActive.Location = new System.Drawing.Point(135, 147);
            this.fld_chkIsActive.Name = "fld_chkIsActive";
            this.fld_chkIsActive.Properties.Caption = "Hoạt động";
            this.fld_chkIsActive.Screen = null;
            this.fld_chkIsActive.Size = new System.Drawing.Size(75, 19);
            this.fld_chkIsActive.TabIndex = 5;
            this.fld_chkIsActive.VinaDataMember = "ADUserActiveCheck";
            this.fld_chkIsActive.VinaDataSource = "ADUsers";
            this.fld_chkIsActive.VinaPropertyName = "EditValue";
            // 
            // guiManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 217);
            this.Controls.Add(this.fld_txtRePassword);
            this.Controls.Add(this.fld_txtPassword);
            this.Controls.Add(this.fld_txtUsername);
            this.Controls.Add(this.fld_btnClose);
            this.Controls.Add(this.fld_btnSave);
            this.Controls.Add(this.fld_lkeUserGroup);
            this.Controls.Add(this.fld_lkeHREmployeeID);
            this.Controls.Add(this.fld_chkIsActive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "guiManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.GuiManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtRePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeUserGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHREmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkIsActive.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private VinaLib.BaseProvider.VinaCheckBox fld_chkIsActive;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeHREmployeeID;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeUserGroup;
        private DevExpress.XtraEditors.SimpleButton fld_btnSave;
        private DevExpress.XtraEditors.SimpleButton fld_btnClose;
        private DevExpress.XtraEditors.TextEdit fld_txtUsername;
        private DevExpress.XtraEditors.TextEdit fld_txtPassword;
        private DevExpress.XtraEditors.TextEdit fld_txtRePassword;
    }
}