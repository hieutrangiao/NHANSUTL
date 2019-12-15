using VinaLib.BaseProvider;

namespace VinaERP.Modules.Department.UI
{
    partial class DMDP100
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.fld_lkeFK_ICProductID = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcHRDepartmentRooms = new VinaERP.Modules.Department.HRDepartmentRoomsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDepartmentNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRDepartmentDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDepartmentName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.label11 = new System.Windows.Forms.Label();
            this.fld_lkeFK_BRBranchID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_txtHRDepartmentTotalEmployee = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDepartmentBoundary = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDepartmentMenBoundary = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDepartmentWoMenBoundary = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRDepartmentRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRDepartmentDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentTotalEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentBoundary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentMenBoundary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentWoMenBoundary.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 106);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(1055, 452);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHRDepartmentRooms);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(1049, 424);
            this.fld_lkeFK_ICProductID.Text = "Danh sách bộ phận";
            // 
            // fld_dgcHRDepartmentRooms
            // 
            this.fld_dgcHRDepartmentRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcHRDepartmentRooms.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcHRDepartmentRooms.MainView = this.gridView1;
            this.fld_dgcHRDepartmentRooms.Name = "fld_dgcHRDepartmentRooms";
            this.fld_dgcHRDepartmentRooms.Screen = null;
            this.fld_dgcHRDepartmentRooms.Size = new System.Drawing.Size(1049, 424);
            this.fld_dgcHRDepartmentRooms.TabIndex = 16;
            this.fld_dgcHRDepartmentRooms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHRDepartmentRooms.VinaDataMember = null;
            this.fld_dgcHRDepartmentRooms.VinaDataSource = "HRDepartmentRooms";
            this.fld_dgcHRDepartmentRooms.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHRDepartmentRooms;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã phòng ban";
            // 
            // fld_txtHRDepartmentNo
            // 
            this.fld_txtHRDepartmentNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRDepartmentNo.Name = "fld_txtHRDepartmentNo";
            this.fld_txtHRDepartmentNo.Screen = null;
            this.fld_txtHRDepartmentNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentNo.TabIndex = 0;
            this.fld_txtHRDepartmentNo.Tag = "DC";
            this.fld_txtHRDepartmentNo.VinaDataMember = "HRDepartmentNo";
            this.fld_txtHRDepartmentNo.VinaDataSource = "HRDepartments";
            this.fld_txtHRDepartmentNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRDepartmentDesc
            // 
            this.fld_mneHRDepartmentDesc.Location = new System.Drawing.Point(116, 38);
            this.fld_mneHRDepartmentDesc.Name = "fld_mneHRDepartmentDesc";
            this.fld_mneHRDepartmentDesc.Screen = null;
            this.fld_mneHRDepartmentDesc.Size = new System.Drawing.Size(199, 45);
            this.fld_mneHRDepartmentDesc.TabIndex = 3;
            this.fld_mneHRDepartmentDesc.Tag = "DC";
            this.fld_mneHRDepartmentDesc.VinaDataMember = "HRDepartmentDesc";
            this.fld_mneHRDepartmentDesc.VinaDataSource = "HRDepartments";
            this.fld_mneHRDepartmentDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // fld_txtHRDepartmentName
            // 
            this.fld_txtHRDepartmentName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRDepartmentName.Name = "fld_txtHRDepartmentName";
            this.fld_txtHRDepartmentName.Screen = null;
            this.fld_txtHRDepartmentName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentName.TabIndex = 63;
            this.fld_txtHRDepartmentName.Tag = "DC";
            this.fld_txtHRDepartmentName.VinaDataMember = "HRDepartmentName";
            this.fld_txtHRDepartmentName.VinaDataSource = "HRDepartments";
            this.fld_txtHRDepartmentName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên phòng ban";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(345, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Chi nhánh";
            // 
            // fld_lkeFK_BRBranchID
            // 
            this.fld_lkeFK_BRBranchID.Location = new System.Drawing.Point(442, 37);
            this.fld_lkeFK_BRBranchID.Name = "fld_lkeFK_BRBranchID";
            this.fld_lkeFK_BRBranchID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_BRBranchID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BRBranchName", "Chi nhánh")});
            this.fld_lkeFK_BRBranchID.Properties.DisplayMember = "BRBranchName";
            this.fld_lkeFK_BRBranchID.Properties.ValueMember = "BRBranchID";
            this.fld_lkeFK_BRBranchID.Screen = null;
            this.fld_lkeFK_BRBranchID.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeFK_BRBranchID.TabIndex = 65;
            this.fld_lkeFK_BRBranchID.Tag = "DC";
            this.fld_lkeFK_BRBranchID.VinaAllowDummy = false;
            this.fld_lkeFK_BRBranchID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_BRBranchID.VinaDataMember = "FK_BRBranchID";
            this.fld_lkeFK_BRBranchID.VinaDataSource = "HRDepartments";
            this.fld_lkeFK_BRBranchID.VinaPropertyName = "EditValue";
            // 
            // fld_txtHRDepartmentTotalEmployee
            // 
            this.fld_txtHRDepartmentTotalEmployee.Location = new System.Drawing.Point(442, 63);
            this.fld_txtHRDepartmentTotalEmployee.Name = "fld_txtHRDepartmentTotalEmployee";
            this.fld_txtHRDepartmentTotalEmployee.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRDepartmentTotalEmployee.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentTotalEmployee.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRDepartmentTotalEmployee.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentTotalEmployee.Screen = null;
            this.fld_txtHRDepartmentTotalEmployee.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentTotalEmployee.TabIndex = 67;
            this.fld_txtHRDepartmentTotalEmployee.Tag = "DC";
            this.fld_txtHRDepartmentTotalEmployee.VinaDataMember = "HRDepartmentTotalEmployee";
            this.fld_txtHRDepartmentTotalEmployee.VinaDataSource = "HRDepartments";
            this.fld_txtHRDepartmentTotalEmployee.VinaPropertyName = "EditValue";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(345, 66);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(74, 13);
            this.labelControl6.TabIndex = 68;
            this.labelControl6.Text = "Tổng nhân viên";
            // 
            // fld_txtHRDepartmentBoundary
            // 
            this.fld_txtHRDepartmentBoundary.Location = new System.Drawing.Point(824, 10);
            this.fld_txtHRDepartmentBoundary.Name = "fld_txtHRDepartmentBoundary";
            this.fld_txtHRDepartmentBoundary.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRDepartmentBoundary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentBoundary.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRDepartmentBoundary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentBoundary.Screen = null;
            this.fld_txtHRDepartmentBoundary.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentBoundary.TabIndex = 69;
            this.fld_txtHRDepartmentBoundary.Tag = "DC";
            this.fld_txtHRDepartmentBoundary.VinaDataMember = "HRDepartmentBoundary";
            this.fld_txtHRDepartmentBoundary.VinaDataSource = "HRDepartments";
            this.fld_txtHRDepartmentBoundary.VinaPropertyName = "EditValue";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(683, 15);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(112, 13);
            this.labelControl7.TabIndex = 70;
            this.labelControl7.Text = "Tổng định biên nhân sự";
            // 
            // fld_txtHRDepartmentMenBoundary
            // 
            this.fld_txtHRDepartmentMenBoundary.Location = new System.Drawing.Point(824, 36);
            this.fld_txtHRDepartmentMenBoundary.Name = "fld_txtHRDepartmentMenBoundary";
            this.fld_txtHRDepartmentMenBoundary.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRDepartmentMenBoundary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentMenBoundary.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRDepartmentMenBoundary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentMenBoundary.Screen = null;
            this.fld_txtHRDepartmentMenBoundary.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentMenBoundary.TabIndex = 71;
            this.fld_txtHRDepartmentMenBoundary.Tag = "DC";
            this.fld_txtHRDepartmentMenBoundary.VinaDataMember = "HRDepartmentMenBoundary";
            this.fld_txtHRDepartmentMenBoundary.VinaDataSource = "HRDepartments";
            this.fld_txtHRDepartmentMenBoundary.VinaPropertyName = "EditValue";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(683, 41);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(135, 13);
            this.labelControl8.TabIndex = 72;
            this.labelControl8.Text = "Tổng định biên nhân sự nam";
            // 
            // fld_txtHRDepartmentWoMenBoundary
            // 
            this.fld_txtHRDepartmentWoMenBoundary.Location = new System.Drawing.Point(824, 62);
            this.fld_txtHRDepartmentWoMenBoundary.Name = "fld_txtHRDepartmentWoMenBoundary";
            this.fld_txtHRDepartmentWoMenBoundary.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRDepartmentWoMenBoundary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentWoMenBoundary.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRDepartmentWoMenBoundary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDepartmentWoMenBoundary.Screen = null;
            this.fld_txtHRDepartmentWoMenBoundary.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentWoMenBoundary.TabIndex = 73;
            this.fld_txtHRDepartmentWoMenBoundary.Tag = "DC";
            this.fld_txtHRDepartmentWoMenBoundary.VinaDataMember = "HRDepartmentWoMenBoundary";
            this.fld_txtHRDepartmentWoMenBoundary.VinaDataSource = "HRDepartments";
            this.fld_txtHRDepartmentWoMenBoundary.VinaPropertyName = "EditValue";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(683, 67);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(128, 13);
            this.labelControl9.TabIndex = 74;
            this.labelControl9.Text = "Tổng định biên nhân sự nữ";
            // 
            // DMDP100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.fld_txtHRDepartmentWoMenBoundary);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_txtHRDepartmentMenBoundary);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.fld_txtHRDepartmentBoundary);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_txtHRDepartmentTotalEmployee);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.fld_lkeFK_BRBranchID);
            this.Controls.Add(this.fld_txtHRDepartmentName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRDepartmentDesc);
            this.Controls.Add(this.fld_txtHRDepartmentNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMDP100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRDepartmentRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRDepartmentDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentTotalEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentBoundary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentMenBoundary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentWoMenBoundary.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HRDepartmentRoomsGridControl fld_dgcHRDepartmentRooms;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRDepartmentNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRDepartmentDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRDepartmentName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label label11;
        private VinaLookupEdit fld_lkeFK_BRBranchID;
        private VinaTextBox fld_txtHRDepartmentTotalEmployee;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private VinaTextBox fld_txtHRDepartmentBoundary;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaTextBox fld_txtHRDepartmentMenBoundary;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private VinaTextBox fld_txtHRDepartmentWoMenBoundary;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}