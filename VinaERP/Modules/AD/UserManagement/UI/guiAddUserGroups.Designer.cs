namespace VinaERP.Modules.UserManagement.UI
{
    partial class GuiAddUserGroups
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
            this.fld_btnCloseUserGroup = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnAddUserGroup = new DevExpress.XtraEditors.SimpleButton();
            this.fld_txtUserGroup = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUserGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_btnCloseUserGroup
            // 
            this.fld_btnCloseUserGroup.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCloseUserGroup.Location = new System.Drawing.Point(203, 64);
            this.fld_btnCloseUserGroup.Name = "fld_btnCloseUserGroup";
            this.fld_btnCloseUserGroup.Size = new System.Drawing.Size(75, 23);
            this.fld_btnCloseUserGroup.TabIndex = 7;
            this.fld_btnCloseUserGroup.Text = "Hủy bỏ";
            this.fld_btnCloseUserGroup.Click += new System.EventHandler(this.fld_btnCloseUserGroup_Click);
            // 
            // fld_btnAddUserGroup
            // 
            this.fld_btnAddUserGroup.Location = new System.Drawing.Point(122, 64);
            this.fld_btnAddUserGroup.Name = "fld_btnAddUserGroup";
            this.fld_btnAddUserGroup.Size = new System.Drawing.Size(75, 23);
            this.fld_btnAddUserGroup.TabIndex = 6;
            this.fld_btnAddUserGroup.Text = "Đồng ý";
            this.fld_btnAddUserGroup.Click += new System.EventHandler(this.fld_btnAddUserGroup_Click);
            // 
            // fld_txtUserGroup
            // 
            this.fld_txtUserGroup.Location = new System.Drawing.Point(12, 35);
            this.fld_txtUserGroup.Name = "fld_txtUserGroup";
            this.fld_txtUserGroup.Size = new System.Drawing.Size(266, 20);
            this.fld_txtUserGroup.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(104, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tên nhóm người dùng";
            // 
            // GuiAddUserGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 101);
            this.Controls.Add(this.fld_btnCloseUserGroup);
            this.Controls.Add(this.fld_btnAddUserGroup);
            this.Controls.Add(this.fld_txtUserGroup);
            this.Controls.Add(this.labelControl1);
            this.Name = "GuiAddUserGroups";
            this.Text = "Thêm/ Chỉnh sửa nhóm người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUserGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton fld_btnCloseUserGroup;
        private DevExpress.XtraEditors.SimpleButton fld_btnAddUserGroup;
        public DevExpress.XtraEditors.TextEdit fld_txtUserGroup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}