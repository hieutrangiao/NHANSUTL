using VinaLib.BaseProvider;

namespace VinaERP.Modules.DepartmentRoomGroup.UI
{
    partial class DMDG100
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
            this.fld_dgcHRDepartmentRoomGroupItems = new VinaERP.Modules.DepartmentRoomGroup.HRDepartmentRoomGroupItemsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDepartmentNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRDepartmentRoomGroupDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.label11 = new System.Windows.Forms.Label();
            this.fld_lkeFK_BRBranchID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_lkeFK_HRDepartmentID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.fld_lkeFK_HRDepartmentRoomID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRDepartmentRoomGroupItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRDepartmentRoomGroupDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 122);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(639, 201);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHRDepartmentRoomGroupItems);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(633, 173);
            this.fld_lkeFK_ICProductID.Text = "Danh sách tổ";
            // 
            // fld_dgcHRDepartmentRoomGroupItems
            // 
            this.fld_dgcHRDepartmentRoomGroupItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcHRDepartmentRoomGroupItems.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcHRDepartmentRoomGroupItems.MainView = this.gridView1;
            this.fld_dgcHRDepartmentRoomGroupItems.Name = "fld_dgcHRDepartmentRoomGroupItems";
            this.fld_dgcHRDepartmentRoomGroupItems.Screen = null;
            this.fld_dgcHRDepartmentRoomGroupItems.Size = new System.Drawing.Size(633, 173);
            this.fld_dgcHRDepartmentRoomGroupItems.TabIndex = 16;
            this.fld_dgcHRDepartmentRoomGroupItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHRDepartmentRoomGroupItems.VinaDataMember = null;
            this.fld_dgcHRDepartmentRoomGroupItems.VinaDataSource = "HRDepartmentRoomGroupItems";
            this.fld_dgcHRDepartmentRoomGroupItems.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHRDepartmentRoomGroupItems;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Ký hiệu tổ";
            // 
            // fld_txtHRDepartmentNo
            // 
            this.fld_txtHRDepartmentNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRDepartmentNo.Name = "fld_txtHRDepartmentNo";
            this.fld_txtHRDepartmentNo.Screen = null;
            this.fld_txtHRDepartmentNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDepartmentNo.TabIndex = 0;
            this.fld_txtHRDepartmentNo.Tag = "DC";
            this.fld_txtHRDepartmentNo.VinaDataMember = "HRDepartmentRoomGroupNo";
            this.fld_txtHRDepartmentNo.VinaDataSource = "HRDepartmentRoomGroups";
            this.fld_txtHRDepartmentNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRDepartmentRoomGroupDesc
            // 
            this.fld_mneHRDepartmentRoomGroupDesc.Location = new System.Drawing.Point(116, 62);
            this.fld_mneHRDepartmentRoomGroupDesc.Name = "fld_mneHRDepartmentRoomGroupDesc";
            this.fld_mneHRDepartmentRoomGroupDesc.Screen = null;
            this.fld_mneHRDepartmentRoomGroupDesc.Size = new System.Drawing.Size(525, 54);
            this.fld_mneHRDepartmentRoomGroupDesc.TabIndex = 3;
            this.fld_mneHRDepartmentRoomGroupDesc.Tag = "DC";
            this.fld_mneHRDepartmentRoomGroupDesc.VinaDataMember = "HRDepartmentRoomGroupDesc";
            this.fld_mneHRDepartmentRoomGroupDesc.VinaDataSource = "HRDepartmentRoomGroups";
            this.fld_mneHRDepartmentRoomGroupDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(345, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Chi nhánh";
            // 
            // fld_lkeFK_BRBranchID
            // 
            this.fld_lkeFK_BRBranchID.Location = new System.Drawing.Point(442, 10);
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
            this.fld_lkeFK_BRBranchID.VinaDataSource = "HRDepartmentRoomGroups";
            this.fld_lkeFK_BRBranchID.VinaPropertyName = "EditValue";
            // 
            // fld_lkeFK_HRDepartmentID
            // 
            this.fld_lkeFK_HRDepartmentID.Location = new System.Drawing.Point(116, 36);
            this.fld_lkeFK_HRDepartmentID.Name = "fld_lkeFK_HRDepartmentID";
            this.fld_lkeFK_HRDepartmentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã phòng ban"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên phòng ban")});
            this.fld_lkeFK_HRDepartmentID.Properties.DisplayMember = "HRDepartmentName";
            this.fld_lkeFK_HRDepartmentID.Properties.ValueMember = "HRDepartmentID";
            this.fld_lkeFK_HRDepartmentID.Screen = null;
            this.fld_lkeFK_HRDepartmentID.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeFK_HRDepartmentID.TabIndex = 111;
            this.fld_lkeFK_HRDepartmentID.Tag = "DC";
            this.fld_lkeFK_HRDepartmentID.VinaAllowDummy = true;
            this.fld_lkeFK_HRDepartmentID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HRDepartmentID.VinaDataMember = "FK_HRDepartmentID";
            this.fld_lkeFK_HRDepartmentID.VinaDataSource = "HRDepartmentRoomGroups";
            this.fld_lkeFK_HRDepartmentID.VinaPropertyName = "EditValue";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(345, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 110;
            this.label21.Text = "Bộ phận";
            // 
            // fld_lkeFK_HRDepartmentRoomID
            // 
            this.fld_lkeFK_HRDepartmentRoomID.Location = new System.Drawing.Point(442, 36);
            this.fld_lkeFK_HRDepartmentRoomID.Name = "fld_lkeFK_HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentRoomID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentRoomName", "Bộ phận")});
            this.fld_lkeFK_HRDepartmentRoomID.Properties.DisplayMember = "HRDepartmentRoomName";
            this.fld_lkeFK_HRDepartmentRoomID.Properties.ValueMember = "HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.Screen = null;
            this.fld_lkeFK_HRDepartmentRoomID.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeFK_HRDepartmentRoomID.TabIndex = 108;
            this.fld_lkeFK_HRDepartmentRoomID.Tag = "DC";
            this.fld_lkeFK_HRDepartmentRoomID.VinaAllowDummy = false;
            this.fld_lkeFK_HRDepartmentRoomID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HRDepartmentRoomID.VinaDataMember = "FK_HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.VinaDataSource = "HRDepartmentRoomGroups";
            this.fld_lkeFK_HRDepartmentRoomID.VinaPropertyName = "EditValue";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 109;
            this.label20.Text = "Phòng ban";
            // 
            // DMDG100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 335);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentID);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentRoomID);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.fld_lkeFK_BRBranchID);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRDepartmentRoomGroupDesc);
            this.Controls.Add(this.fld_txtHRDepartmentNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMDG100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRDepartmentRoomGroupItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDepartmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRDepartmentRoomGroupDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HRDepartmentRoomGroupItemsGridControl fld_dgcHRDepartmentRoomGroupItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRDepartmentNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRDepartmentRoomGroupDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label label11;
        private VinaLookupEdit fld_lkeFK_BRBranchID;
        private VinaLookupEdit fld_lkeFK_HRDepartmentID;
        private System.Windows.Forms.Label label21;
        private VinaLookupEdit fld_lkeFK_HRDepartmentRoomID;
        private System.Windows.Forms.Label label20;
    }
}