using VinaLib.BaseProvider;

namespace VinaERP.Modules.Department.UI
{
    partial class DMDPT100
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
            this.vinaMemoEdit1 = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.vinaTextBox2 = new VinaLib.BaseProvider.VinaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vinaTextBox1 = new VinaLib.BaseProvider.VinaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vinaCheckBox1 = new VinaLib.BaseProvider.VinaCheckBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.vinaTextBox3 = new VinaLib.BaseProvider.VinaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vinaTextBox4 = new VinaLib.BaseProvider.VinaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vinaMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaCheckBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.vinaCheckBox1);
            this.groupControl1.Controls.Add(this.vinaMemoEdit1);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.vinaTextBox2);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.vinaTextBox1);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(807, 143);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin chung";
            // 
            // vinaMemoEdit1
            // 
            this.vinaMemoEdit1.Location = new System.Drawing.Point(87, 55);
            this.vinaMemoEdit1.Name = "vinaMemoEdit1";
            this.vinaMemoEdit1.Screen = null;
            this.vinaMemoEdit1.Size = new System.Drawing.Size(480, 51);
            this.vinaMemoEdit1.TabIndex = 17;
            this.vinaMemoEdit1.Tag = "DC";
            this.vinaMemoEdit1.VinaDataMember = "ICDepartmentDesc";
            this.vinaMemoEdit1.VinaDataSource = "ICDepartments";
            this.vinaMemoEdit1.VinaPropertyName = "EditValue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mô tả";
            // 
            // vinaTextBox2
            // 
            this.vinaTextBox2.Location = new System.Drawing.Point(392, 29);
            this.vinaTextBox2.Name = "vinaTextBox2";
            this.vinaTextBox2.Screen = null;
            this.vinaTextBox2.Size = new System.Drawing.Size(175, 20);
            this.vinaTextBox2.TabIndex = 3;
            this.vinaTextBox2.Tag = "DC";
            this.vinaTextBox2.VinaDataMember = "ICDepartmentName";
            this.vinaTextBox2.VinaDataSource = "ICDepartments";
            this.vinaTextBox2.VinaPropertyName = "EditValue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên ngành";
            // 
            // vinaTextBox1
            // 
            this.vinaTextBox1.Location = new System.Drawing.Point(87, 29);
            this.vinaTextBox1.Name = "vinaTextBox1";
            this.vinaTextBox1.Screen = null;
            this.vinaTextBox1.Size = new System.Drawing.Size(175, 20);
            this.vinaTextBox1.TabIndex = 1;
            this.vinaTextBox1.Tag = "DC";
            this.vinaTextBox1.VinaDataMember = "ICDepartmentNo";
            this.vinaTextBox1.VinaDataSource = "ICDepartments";
            this.vinaTextBox1.VinaPropertyName = "EditValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã ngành";
            // 
            // vinaCheckBox1
            // 
            this.vinaCheckBox1.Location = new System.Drawing.Point(87, 112);
            this.vinaCheckBox1.Name = "vinaCheckBox1";
            this.vinaCheckBox1.Properties.Caption = "Hoạt động";
            this.vinaCheckBox1.Screen = null;
            this.vinaCheckBox1.Size = new System.Drawing.Size(75, 19);
            this.vinaCheckBox1.TabIndex = 18;
            this.vinaCheckBox1.VinaDataMember = "ICDepartmentActiveCheck";
            this.vinaCheckBox1.VinaDataSource = "ICDepartments";
            this.vinaCheckBox1.VinaPropertyName = "EditValue";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButton3);
            this.groupControl2.Controls.Add(this.simpleButton2);
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Controls.Add(this.vinaTextBox3);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.vinaTextBox4);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Location = new System.Drawing.Point(7, 156);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(374, 344);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Danh sách nhóm hàng";
            // 
            // vinaTextBox3
            // 
            this.vinaTextBox3.Location = new System.Drawing.Point(87, 52);
            this.vinaTextBox3.Name = "vinaTextBox3";
            this.vinaTextBox3.Screen = null;
            this.vinaTextBox3.Size = new System.Drawing.Size(267, 20);
            this.vinaTextBox3.TabIndex = 7;
            this.vinaTextBox3.Tag = "DC";
            this.vinaTextBox3.VinaDataMember = "ICDepartmentName";
            this.vinaTextBox3.VinaDataSource = "ICDepartments";
            this.vinaTextBox3.VinaPropertyName = "EditValue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên nhóm";
            // 
            // vinaTextBox4
            // 
            this.vinaTextBox4.Location = new System.Drawing.Point(87, 26);
            this.vinaTextBox4.Name = "vinaTextBox4";
            this.vinaTextBox4.Screen = null;
            this.vinaTextBox4.Size = new System.Drawing.Size(267, 20);
            this.vinaTextBox4.TabIndex = 5;
            this.vinaTextBox4.Tag = "DC";
            this.vinaTextBox4.VinaDataMember = "ICDepartmentNo";
            this.vinaTextBox4.VinaDataSource = "ICDepartments";
            this.vinaTextBox4.VinaPropertyName = "EditValue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã nhóm";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(117, 78);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Thêm";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(198, 78);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "Sửa";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(279, 78);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 10;
            this.simpleButton3.Text = "Xóa";
            // 
            // groupControl3
            // 
            this.groupControl3.Location = new System.Drawing.Point(387, 157);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(427, 343);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Danh sách thuộc tính";
            // 
            // DMDPT100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 504);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "DMDPT100";
            this.Text = "DMSO100";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vinaMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaCheckBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private VinaTextBox vinaTextBox1;
        private System.Windows.Forms.Label label3;
        private VinaTextBox vinaTextBox2;
        private System.Windows.Forms.Label label2;
        private VinaLib.BaseProvider.Components.VinaMemoEdit vinaMemoEdit1;
        private VinaCheckBox vinaCheckBox1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private VinaTextBox vinaTextBox3;
        private System.Windows.Forms.Label label4;
        private VinaTextBox vinaTextBox4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}