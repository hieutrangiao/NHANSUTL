namespace VinaERP.Modules.UserManagement.UI
{
    partial class GuiAddSections
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
            this.fld_txtSection = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_btnAddSection = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnCloseSection = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSection.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_txtSection
            // 
            this.fld_txtSection.Location = new System.Drawing.Point(11, 30);
            this.fld_txtSection.Name = "fld_txtSection";
            this.fld_txtSection.Size = new System.Drawing.Size(266, 20);
            this.fld_txtSection.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tên nhóm module";
            // 
            // fld_btnAddSection
            // 
            this.fld_btnAddSection.Location = new System.Drawing.Point(121, 58);
            this.fld_btnAddSection.Name = "fld_btnAddSection";
            this.fld_btnAddSection.Size = new System.Drawing.Size(75, 23);
            this.fld_btnAddSection.TabIndex = 6;
            this.fld_btnAddSection.Text = "Đồng ý";
            this.fld_btnAddSection.Click += new System.EventHandler(this.fld_btnAddSection_Click);
            // 
            // fld_btnCloseSection
            // 
            this.fld_btnCloseSection.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCloseSection.Location = new System.Drawing.Point(202, 58);
            this.fld_btnCloseSection.Name = "fld_btnCloseSection";
            this.fld_btnCloseSection.Size = new System.Drawing.Size(75, 23);
            this.fld_btnCloseSection.TabIndex = 7;
            this.fld_btnCloseSection.Text = "Hủy bỏ";
            this.fld_btnCloseSection.Click += new System.EventHandler(this.fld_btnCloseSection_Click);
            // 
            // GuiAddSections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 95);
            this.Controls.Add(this.fld_txtSection);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_btnAddSection);
            this.Controls.Add(this.fld_btnCloseSection);
            this.Name = "GuiAddSections";
            this.Text = "Thêm/Chỉnh sửa nhóm module";
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtSection.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit fld_txtSection;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton fld_btnAddSection;
        private DevExpress.XtraEditors.SimpleButton fld_btnCloseSection;
    }
}