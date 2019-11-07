using VinaLib.BaseProvider;

namespace VinaERP.Modules.PaymentTerm.UI
{
    partial class DMPT100
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
            this.fld_dgcGEPaymentTermItems = new VinaERP.Modules.PaymentTerm.GEPaymentTermItemGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtGEPaymentTermName = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_txtGEPaymentTermNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneGEPaymentTermDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteGEPaymentTermDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.fld_ckeGEPaymentTermIsActive = new VinaLib.BaseProvider.VinaCheckBox();
            this.fld_lkeFK_HREmployeeID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_pteGEPaymentTermEmployeePicture = new VinaLib.BaseProvider.VinaPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcGEPaymentTermItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtGEPaymentTermName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtGEPaymentTermNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneGEPaymentTermDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteGEPaymentTermDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteGEPaymentTermDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ckeGEPaymentTermIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pteGEPaymentTermEmployeePicture.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 149);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(810, 409);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcGEPaymentTermItems);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(804, 381);
            this.fld_lkeFK_ICProductID.Text = "Cấu hình điều khoản thanh toán";
            // 
            // fld_dgcGEPaymentTermItems
            // 
            this.fld_dgcGEPaymentTermItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcGEPaymentTermItems.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcGEPaymentTermItems.MainView = this.gridView1;
            this.fld_dgcGEPaymentTermItems.Name = "fld_dgcGEPaymentTermItems";
            this.fld_dgcGEPaymentTermItems.Screen = null;
            this.fld_dgcGEPaymentTermItems.Size = new System.Drawing.Size(804, 381);
            this.fld_dgcGEPaymentTermItems.TabIndex = 16;
            this.fld_dgcGEPaymentTermItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcGEPaymentTermItems.VinaDataMember = null;
            this.fld_dgcGEPaymentTermItems.VinaDataSource = "GEPaymentTermItems";
            this.fld_dgcGEPaymentTermItems.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcGEPaymentTermItems;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(131, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Tên ĐKTT";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(131, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã ĐKTT";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(366, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 52;
            this.labelControl3.Text = "Ngày chứng từ";
            // 
            // fld_txtGEPaymentTermName
            // 
            this.fld_txtGEPaymentTermName.Location = new System.Drawing.Point(210, 36);
            this.fld_txtGEPaymentTermName.Name = "fld_txtGEPaymentTermName";
            this.fld_txtGEPaymentTermName.Screen = null;
            this.fld_txtGEPaymentTermName.Size = new System.Drawing.Size(402, 20);
            this.fld_txtGEPaymentTermName.TabIndex = 2;
            this.fld_txtGEPaymentTermName.Tag = "DC";
            this.fld_txtGEPaymentTermName.VinaDataMember = "GEPaymentTermName";
            this.fld_txtGEPaymentTermName.VinaDataSource = "GEPaymentTerms";
            this.fld_txtGEPaymentTermName.VinaPropertyName = "EditValue";
            // 
            // fld_txtGEPaymentTermNo
            // 
            this.fld_txtGEPaymentTermNo.Location = new System.Drawing.Point(210, 10);
            this.fld_txtGEPaymentTermNo.Name = "fld_txtGEPaymentTermNo";
            this.fld_txtGEPaymentTermNo.Screen = null;
            this.fld_txtGEPaymentTermNo.Size = new System.Drawing.Size(150, 20);
            this.fld_txtGEPaymentTermNo.TabIndex = 0;
            this.fld_txtGEPaymentTermNo.Tag = "DC";
            this.fld_txtGEPaymentTermNo.VinaDataMember = "GEPaymentTermNo";
            this.fld_txtGEPaymentTermNo.VinaDataSource = "GEPaymentTerms";
            this.fld_txtGEPaymentTermNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneGEPaymentTermDesc
            // 
            this.fld_mneGEPaymentTermDesc.Location = new System.Drawing.Point(210, 62);
            this.fld_mneGEPaymentTermDesc.Name = "fld_mneGEPaymentTermDesc";
            this.fld_mneGEPaymentTermDesc.Screen = null;
            this.fld_mneGEPaymentTermDesc.Size = new System.Drawing.Size(402, 45);
            this.fld_mneGEPaymentTermDesc.TabIndex = 3;
            this.fld_mneGEPaymentTermDesc.Tag = "DC";
            this.fld_mneGEPaymentTermDesc.VinaDataMember = "GEPaymentTermDesc";
            this.fld_mneGEPaymentTermDesc.VinaDataSource = "GEPaymentTerms";
            this.fld_mneGEPaymentTermDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(131, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Diễn giải";
            // 
            // fld_dteGEPaymentTermDate
            // 
            this.fld_dteGEPaymentTermDate.EditValue = null;
            this.fld_dteGEPaymentTermDate.Location = new System.Drawing.Point(462, 10);
            this.fld_dteGEPaymentTermDate.Name = "fld_dteGEPaymentTermDate";
            this.fld_dteGEPaymentTermDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteGEPaymentTermDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteGEPaymentTermDate.Screen = null;
            this.fld_dteGEPaymentTermDate.Size = new System.Drawing.Size(150, 20);
            this.fld_dteGEPaymentTermDate.TabIndex = 1;
            this.fld_dteGEPaymentTermDate.Tag = "DC";
            this.fld_dteGEPaymentTermDate.VinaDataMember = "GEPaymentTermDate";
            this.fld_dteGEPaymentTermDate.VinaDataSource = "GEPaymentTerms";
            this.fld_dteGEPaymentTermDate.VinaPropertyName = "EditValue";
            // 
            // fld_ckeGEPaymentTermIsActive
            // 
            this.fld_ckeGEPaymentTermIsActive.Location = new System.Drawing.Point(210, 113);
            this.fld_ckeGEPaymentTermIsActive.Name = "fld_ckeGEPaymentTermIsActive";
            this.fld_ckeGEPaymentTermIsActive.Properties.Caption = "Hoạt động";
            this.fld_ckeGEPaymentTermIsActive.Screen = null;
            this.fld_ckeGEPaymentTermIsActive.Size = new System.Drawing.Size(105, 19);
            this.fld_ckeGEPaymentTermIsActive.TabIndex = 62;
            this.fld_ckeGEPaymentTermIsActive.Tag = "DC";
            this.fld_ckeGEPaymentTermIsActive.VinaDataMember = "GEPaymentTermIsActive";
            this.fld_ckeGEPaymentTermIsActive.VinaDataSource = "GEPaymentTerms";
            this.fld_ckeGEPaymentTermIsActive.VinaPropertyName = "EditValue";
            // 
            // fld_lkeFK_HREmployeeID
            // 
            this.fld_lkeFK_HREmployeeID.Location = new System.Drawing.Point(12, 113);
            this.fld_lkeFK_HREmployeeID.Name = "fld_lkeFK_HREmployeeID";
            this.fld_lkeFK_HREmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên người bán")});
            this.fld_lkeFK_HREmployeeID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeFK_HREmployeeID.Properties.ReadOnly = true;
            this.fld_lkeFK_HREmployeeID.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeFK_HREmployeeID.Screen = null;
            this.fld_lkeFK_HREmployeeID.Size = new System.Drawing.Size(100, 20);
            this.fld_lkeFK_HREmployeeID.TabIndex = 95;
            this.fld_lkeFK_HREmployeeID.Tag = "DC";
            this.fld_lkeFK_HREmployeeID.VinaAllowDummy = true;
            this.fld_lkeFK_HREmployeeID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HREmployeeID.VinaDataMember = "FK_HREmployeeID";
            this.fld_lkeFK_HREmployeeID.VinaDataSource = "GEPaymentTerms";
            this.fld_lkeFK_HREmployeeID.VinaPropertyName = "EditValue";
            // 
            // fld_pteGEPaymentTermEmployeePicture
            // 
            this.fld_pteGEPaymentTermEmployeePicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.fld_pteGEPaymentTermEmployeePicture.Location = new System.Drawing.Point(12, 7);
            this.fld_pteGEPaymentTermEmployeePicture.Name = "fld_pteGEPaymentTermEmployeePicture";
            this.fld_pteGEPaymentTermEmployeePicture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.fld_pteGEPaymentTermEmployeePicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.fld_pteGEPaymentTermEmployeePicture.Screen = null;
            this.fld_pteGEPaymentTermEmployeePicture.Size = new System.Drawing.Size(100, 100);
            this.fld_pteGEPaymentTermEmployeePicture.TabIndex = 94;
            this.fld_pteGEPaymentTermEmployeePicture.Tag = "DC";
            this.fld_pteGEPaymentTermEmployeePicture.VinaDataMember = "GEPaymentTermEmployeePicture";
            this.fld_pteGEPaymentTermEmployeePicture.VinaDataSource = "GEPaymentTerms";
            this.fld_pteGEPaymentTermEmployeePicture.VinaPropertyName = "EditValue";
            // 
            // DMPT100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 563);
            this.Controls.Add(this.fld_lkeFK_HREmployeeID);
            this.Controls.Add(this.fld_pteGEPaymentTermEmployeePicture);
            this.Controls.Add(this.fld_ckeGEPaymentTermIsActive);
            this.Controls.Add(this.fld_dteGEPaymentTermDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneGEPaymentTermDesc);
            this.Controls.Add(this.fld_txtGEPaymentTermNo);
            this.Controls.Add(this.fld_txtGEPaymentTermName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMPT100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcGEPaymentTermItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtGEPaymentTermName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtGEPaymentTermNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneGEPaymentTermDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteGEPaymentTermDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteGEPaymentTermDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ckeGEPaymentTermIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pteGEPaymentTermEmployeePicture.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private GEPaymentTermItemGridControl fld_dgcGEPaymentTermItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaTextBox fld_txtGEPaymentTermName;
        private VinaTextBox fld_txtGEPaymentTermNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneGEPaymentTermDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaDateEdit fld_dteGEPaymentTermDate;
        private VinaCheckBox fld_ckeGEPaymentTermIsActive;
        private VinaLookupEdit fld_lkeFK_HREmployeeID;
        private VinaPictureEdit fld_pteGEPaymentTermEmployeePicture;
    }
}