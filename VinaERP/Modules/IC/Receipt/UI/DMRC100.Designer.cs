using VinaLib.BaseProvider;

namespace VinaERP.Modules.Receipt.UI
{
    partial class DMRC100
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
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_lkeFK_ICProductID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_ptcICProductPicture = new VinaLib.BaseProvider.VinaPictureEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dgcICReceiptItems = new VinaERP.Modules.Receipt.ICReceiptItemsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fld_txtICReceiptSubTotalAmount = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtICReceiptDiscountPercent = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtICReceiptDiscountAmount = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_txtICReceiptTaxAmount = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_txtICReceiptTaxPercent = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtICReceiptTotalAmount = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.fld_pteICReceiptEmployeePicture = new VinaLib.BaseProvider.VinaPictureEdit();
            this.fld_lkeFK_HREmployeeID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_txtICReceiptNo = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtICReceiptName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteICReceiptDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeICReceiptStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_ARCustomerID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_mneICReceiptDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkdFK_ICStockID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtICReceiptProductLotNo = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_GECurrencyID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_txtICReceiptExchangeRate = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ICProductID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ptcICProductPicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICReceiptItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptSubTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptDiscountPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptDiscountAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptTaxAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptTaxPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pteICReceiptEmployeePicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteICReceiptDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteICReceiptDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeICReceiptStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ARCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneICReceiptDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkdFK_ICStockID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptProductLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_GECurrencyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptExchangeRate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 154);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(881, 293);
            this.xtraTabControl1.TabIndex = 46;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.fld_lkeFK_ICProductID);
            this.xtraTabPage1.Controls.Add(this.fld_ptcICProductPicture);
            this.xtraTabPage1.Controls.Add(this.labelControl8);
            this.xtraTabPage1.Controls.Add(this.fld_dgcICReceiptItems);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(875, 265);
            this.xtraTabPage1.Text = "Danh sách sản phẩm";
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeFK_ICProductID.Location = new System.Drawing.Point(61, 8);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_ICProductID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductNo", "Mã sản phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductName", "Tên sản phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductDesc", "Mô tả"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductPrice", "Đơn giá", 20, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.fld_lkeFK_ICProductID.Properties.DisplayMember = "ICProductDesc";
            this.fld_lkeFK_ICProductID.Properties.ValueMember = "ICProductID";
            this.fld_lkeFK_ICProductID.Screen = null;
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(681, 20);
            this.fld_lkeFK_ICProductID.TabIndex = 0;
            this.fld_lkeFK_ICProductID.Tag = "DC";
            this.fld_lkeFK_ICProductID.VinaAllowDummy = false;
            this.fld_lkeFK_ICProductID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_ICProductID.VinaDataMember = "FK_ICProductID";
            this.fld_lkeFK_ICProductID.VinaDataSource = "ICReceiptItems";
            this.fld_lkeFK_ICProductID.VinaPropertyName = "EditValue";
            this.fld_lkeFK_ICProductID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Fld_lkeFK_ICProductID_KeyUp);
            // 
            // fld_ptcICProductPicture
            // 
            this.fld_ptcICProductPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_ptcICProductPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.fld_ptcICProductPicture.Location = new System.Drawing.Point(748, 7);
            this.fld_ptcICProductPicture.Name = "fld_ptcICProductPicture";
            this.fld_ptcICProductPicture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.fld_ptcICProductPicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.fld_ptcICProductPicture.Screen = null;
            this.fld_ptcICProductPicture.Size = new System.Drawing.Size(120, 120);
            this.fld_ptcICProductPicture.TabIndex = 57;
            this.fld_ptcICProductPicture.Tag = "DC";
            this.fld_ptcICProductPicture.VinaDataMember = "ICProductPicture";
            this.fld_ptcICProductPicture.VinaDataSource = "ICProducts";
            this.fld_ptcICProductPicture.VinaPropertyName = "EditValue";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(6, 11);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(47, 13);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "Sản phẩm";
            // 
            // fld_dgcICReceiptItems
            // 
            this.fld_dgcICReceiptItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcICReceiptItems.Location = new System.Drawing.Point(3, 33);
            this.fld_dgcICReceiptItems.MainView = this.gridView1;
            this.fld_dgcICReceiptItems.Name = "fld_dgcICReceiptItems";
            this.fld_dgcICReceiptItems.Screen = null;
            this.fld_dgcICReceiptItems.Size = new System.Drawing.Size(739, 229);
            this.fld_dgcICReceiptItems.TabIndex = 16;
            this.fld_dgcICReceiptItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcICReceiptItems.VinaDataMember = null;
            this.fld_dgcICReceiptItems.VinaDataSource = "ICReceiptItems";
            this.fld_dgcICReceiptItems.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcICReceiptItems;
            this.gridView1.Name = "gridView1";
            // 
            // fld_txtICReceiptSubTotalAmount
            // 
            this.fld_txtICReceiptSubTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtICReceiptSubTotalAmount.Location = new System.Drawing.Point(727, 453);
            this.fld_txtICReceiptSubTotalAmount.Name = "fld_txtICReceiptSubTotalAmount";
            this.fld_txtICReceiptSubTotalAmount.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtICReceiptSubTotalAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptSubTotalAmount.Properties.Mask.EditMask = "n3";
            this.fld_txtICReceiptSubTotalAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtICReceiptSubTotalAmount.Properties.ReadOnly = true;
            this.fld_txtICReceiptSubTotalAmount.Screen = null;
            this.fld_txtICReceiptSubTotalAmount.Size = new System.Drawing.Size(150, 20);
            this.fld_txtICReceiptSubTotalAmount.TabIndex = 80;
            this.fld_txtICReceiptSubTotalAmount.Tag = "DC";
            this.fld_txtICReceiptSubTotalAmount.VinaDataMember = "ICReceiptSubTotalAmount";
            this.fld_txtICReceiptSubTotalAmount.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptSubTotalAmount.VinaPropertyName = "EditValue";
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl14.Location = new System.Drawing.Point(646, 456);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(50, 13);
            this.labelControl14.TabIndex = 79;
            this.labelControl14.Text = "Tổng cộng";
            // 
            // fld_txtICReceiptDiscountPercent
            // 
            this.fld_txtICReceiptDiscountPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtICReceiptDiscountPercent.Location = new System.Drawing.Point(727, 479);
            this.fld_txtICReceiptDiscountPercent.Name = "fld_txtICReceiptDiscountPercent";
            this.fld_txtICReceiptDiscountPercent.Properties.DisplayFormat.FormatString = "n2";
            this.fld_txtICReceiptDiscountPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptDiscountPercent.Properties.EditFormat.FormatString = "n2";
            this.fld_txtICReceiptDiscountPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptDiscountPercent.Screen = null;
            this.fld_txtICReceiptDiscountPercent.Size = new System.Drawing.Size(48, 20);
            this.fld_txtICReceiptDiscountPercent.TabIndex = 82;
            this.fld_txtICReceiptDiscountPercent.Tag = "DC";
            this.fld_txtICReceiptDiscountPercent.VinaDataMember = "ICReceiptDiscountPercent";
            this.fld_txtICReceiptDiscountPercent.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptDiscountPercent.VinaPropertyName = "EditValue";
            this.fld_txtICReceiptDiscountPercent.Validated += new System.EventHandler(this.Fld_txtICReceiptDiscountPercent_Validated);
            // 
            // labelControl15
            // 
            this.labelControl15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl15.Location = new System.Drawing.Point(646, 482);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(51, 13);
            this.labelControl15.TabIndex = 81;
            this.labelControl15.Text = "Chiết khấu";
            // 
            // fld_txtICReceiptDiscountAmount
            // 
            this.fld_txtICReceiptDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtICReceiptDiscountAmount.Location = new System.Drawing.Point(781, 479);
            this.fld_txtICReceiptDiscountAmount.Name = "fld_txtICReceiptDiscountAmount";
            this.fld_txtICReceiptDiscountAmount.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtICReceiptDiscountAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptDiscountAmount.Properties.EditFormat.FormatString = "n3";
            this.fld_txtICReceiptDiscountAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptDiscountAmount.Properties.Mask.EditMask = "n3";
            this.fld_txtICReceiptDiscountAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtICReceiptDiscountAmount.Screen = null;
            this.fld_txtICReceiptDiscountAmount.Size = new System.Drawing.Size(96, 20);
            this.fld_txtICReceiptDiscountAmount.TabIndex = 83;
            this.fld_txtICReceiptDiscountAmount.Tag = "DC";
            this.fld_txtICReceiptDiscountAmount.VinaDataMember = "ICReceiptDiscountAmount";
            this.fld_txtICReceiptDiscountAmount.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptDiscountAmount.VinaPropertyName = "EditValue";
            this.fld_txtICReceiptDiscountAmount.Validated += new System.EventHandler(this.Fld_txtICReceiptDiscountAmount_Validated);
            // 
            // fld_txtICReceiptTaxAmount
            // 
            this.fld_txtICReceiptTaxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtICReceiptTaxAmount.Location = new System.Drawing.Point(781, 505);
            this.fld_txtICReceiptTaxAmount.Name = "fld_txtICReceiptTaxAmount";
            this.fld_txtICReceiptTaxAmount.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtICReceiptTaxAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptTaxAmount.Properties.EditFormat.FormatString = "n3";
            this.fld_txtICReceiptTaxAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptTaxAmount.Properties.Mask.EditMask = "n3";
            this.fld_txtICReceiptTaxAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtICReceiptTaxAmount.Screen = null;
            this.fld_txtICReceiptTaxAmount.Size = new System.Drawing.Size(96, 20);
            this.fld_txtICReceiptTaxAmount.TabIndex = 86;
            this.fld_txtICReceiptTaxAmount.Tag = "DC";
            this.fld_txtICReceiptTaxAmount.VinaDataMember = "ICReceiptTaxAmount";
            this.fld_txtICReceiptTaxAmount.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptTaxAmount.VinaPropertyName = "EditValue";
            this.fld_txtICReceiptTaxAmount.Validated += new System.EventHandler(this.Fld_txtICReceiptTaxAmount_Validated);
            // 
            // fld_txtICReceiptTaxPercent
            // 
            this.fld_txtICReceiptTaxPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtICReceiptTaxPercent.Location = new System.Drawing.Point(727, 505);
            this.fld_txtICReceiptTaxPercent.Name = "fld_txtICReceiptTaxPercent";
            this.fld_txtICReceiptTaxPercent.Properties.DisplayFormat.FormatString = "n2";
            this.fld_txtICReceiptTaxPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptTaxPercent.Properties.EditFormat.FormatString = "n2";
            this.fld_txtICReceiptTaxPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptTaxPercent.Screen = null;
            this.fld_txtICReceiptTaxPercent.Size = new System.Drawing.Size(48, 20);
            this.fld_txtICReceiptTaxPercent.TabIndex = 85;
            this.fld_txtICReceiptTaxPercent.Tag = "DC";
            this.fld_txtICReceiptTaxPercent.VinaDataMember = "ICReceiptTaxPercent";
            this.fld_txtICReceiptTaxPercent.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptTaxPercent.VinaPropertyName = "EditValue";
            this.fld_txtICReceiptTaxPercent.Validated += new System.EventHandler(this.Fld_txtICReceiptTaxPercent_Validated);
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl16.Location = new System.Drawing.Point(646, 508);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(24, 13);
            this.labelControl16.TabIndex = 84;
            this.labelControl16.Text = "Thuế";
            // 
            // fld_txtICReceiptTotalAmount
            // 
            this.fld_txtICReceiptTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtICReceiptTotalAmount.Location = new System.Drawing.Point(727, 531);
            this.fld_txtICReceiptTotalAmount.Name = "fld_txtICReceiptTotalAmount";
            this.fld_txtICReceiptTotalAmount.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtICReceiptTotalAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptTotalAmount.Properties.Mask.EditMask = "n";
            this.fld_txtICReceiptTotalAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtICReceiptTotalAmount.Properties.ReadOnly = true;
            this.fld_txtICReceiptTotalAmount.Screen = null;
            this.fld_txtICReceiptTotalAmount.Size = new System.Drawing.Size(150, 20);
            this.fld_txtICReceiptTotalAmount.TabIndex = 88;
            this.fld_txtICReceiptTotalAmount.Tag = "DC";
            this.fld_txtICReceiptTotalAmount.VinaDataMember = "ICReceiptTotalAmount";
            this.fld_txtICReceiptTotalAmount.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptTotalAmount.VinaPropertyName = "EditValue";
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl17.Location = new System.Drawing.Point(646, 534);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(51, 13);
            this.labelControl17.TabIndex = 87;
            this.labelControl17.Text = "Thành tiền";
            // 
            // fld_pteICReceiptEmployeePicture
            // 
            this.fld_pteICReceiptEmployeePicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.fld_pteICReceiptEmployeePicture.Location = new System.Drawing.Point(12, 12);
            this.fld_pteICReceiptEmployeePicture.Name = "fld_pteICReceiptEmployeePicture";
            this.fld_pteICReceiptEmployeePicture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.fld_pteICReceiptEmployeePicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.fld_pteICReceiptEmployeePicture.Screen = null;
            this.fld_pteICReceiptEmployeePicture.Size = new System.Drawing.Size(100, 100);
            this.fld_pteICReceiptEmployeePicture.TabIndex = 92;
            this.fld_pteICReceiptEmployeePicture.Tag = "DC";
            this.fld_pteICReceiptEmployeePicture.VinaDataMember = "ICReceiptEmployeePicture";
            this.fld_pteICReceiptEmployeePicture.VinaDataSource = "ICReceipts";
            this.fld_pteICReceiptEmployeePicture.VinaPropertyName = "EditValue";
            // 
            // fld_lkeFK_HREmployeeID
            // 
            this.fld_lkeFK_HREmployeeID.Location = new System.Drawing.Point(12, 118);
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
            this.fld_lkeFK_HREmployeeID.TabIndex = 93;
            this.fld_lkeFK_HREmployeeID.Tag = "DC";
            this.fld_lkeFK_HREmployeeID.VinaAllowDummy = true;
            this.fld_lkeFK_HREmployeeID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HREmployeeID.VinaDataMember = "FK_HREmployeeID";
            this.fld_lkeFK_HREmployeeID.VinaDataSource = "ICReceipts";
            this.fld_lkeFK_HREmployeeID.VinaPropertyName = "EditValue";
            // 
            // fld_txtICReceiptNo
            // 
            this.fld_txtICReceiptNo.Location = new System.Drawing.Point(203, 12);
            this.fld_txtICReceiptNo.Name = "fld_txtICReceiptNo";
            this.fld_txtICReceiptNo.Screen = null;
            this.fld_txtICReceiptNo.Size = new System.Drawing.Size(150, 20);
            this.fld_txtICReceiptNo.TabIndex = 0;
            this.fld_txtICReceiptNo.Tag = "DC";
            this.fld_txtICReceiptNo.VinaDataMember = "ICReceiptNo";
            this.fld_txtICReceiptNo.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptNo.VinaPropertyName = "EditValue";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(128, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 94;
            this.labelControl1.Text = "Mã chứng từ";
            // 
            // fld_txtICReceiptName
            // 
            this.fld_txtICReceiptName.Location = new System.Drawing.Point(203, 38);
            this.fld_txtICReceiptName.Name = "fld_txtICReceiptName";
            this.fld_txtICReceiptName.Screen = null;
            this.fld_txtICReceiptName.Size = new System.Drawing.Size(396, 20);
            this.fld_txtICReceiptName.TabIndex = 3;
            this.fld_txtICReceiptName.Tag = "DC";
            this.fld_txtICReceiptName.VinaDataMember = "ICReceiptName";
            this.fld_txtICReceiptName.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptName.VinaPropertyName = "EditValue";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(128, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 95;
            this.labelControl2.Text = "Tên chứng từ";
            // 
            // fld_dteICReceiptDate
            // 
            this.fld_dteICReceiptDate.EditValue = null;
            this.fld_dteICReceiptDate.Location = new System.Drawing.Point(449, 12);
            this.fld_dteICReceiptDate.Name = "fld_dteICReceiptDate";
            this.fld_dteICReceiptDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteICReceiptDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteICReceiptDate.Screen = null;
            this.fld_dteICReceiptDate.Size = new System.Drawing.Size(150, 20);
            this.fld_dteICReceiptDate.TabIndex = 1;
            this.fld_dteICReceiptDate.Tag = "DC";
            this.fld_dteICReceiptDate.VinaDataMember = "ICReceiptDate";
            this.fld_dteICReceiptDate.VinaDataSource = "ICReceipts";
            this.fld_dteICReceiptDate.VinaPropertyName = "EditValue";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(372, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 98;
            this.labelControl3.Text = "Ngày chứng từ";
            // 
            // fld_lkeICReceiptStatus
            // 
            this.fld_lkeICReceiptStatus.Location = new System.Drawing.Point(449, 66);
            this.fld_lkeICReceiptStatus.Name = "fld_lkeICReceiptStatus";
            this.fld_lkeICReceiptStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeICReceiptStatus.Properties.ReadOnly = true;
            this.fld_lkeICReceiptStatus.Screen = null;
            this.fld_lkeICReceiptStatus.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeICReceiptStatus.TabIndex = 6;
            this.fld_lkeICReceiptStatus.Tag = "DC";
            this.fld_lkeICReceiptStatus.VinaAllowDummy = true;
            this.fld_lkeICReceiptStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeICReceiptStatus.VinaDataMember = "ICReceiptStatus";
            this.fld_lkeICReceiptStatus.VinaDataSource = "ICReceipts";
            this.fld_lkeICReceiptStatus.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(372, 69);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 102;
            this.labelControl4.Text = "Tình trạng";
            // 
            // fld_lkeFK_ARCustomerID
            // 
            this.fld_lkeFK_ARCustomerID.Location = new System.Drawing.Point(203, 66);
            this.fld_lkeFK_ARCustomerID.Name = "fld_lkeFK_ARCustomerID";
            this.fld_lkeFK_ARCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_ARCustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ARCustomerName", "Tên khách hàng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ARCustomerName", "Địa chỉ")});
            this.fld_lkeFK_ARCustomerID.Properties.DisplayMember = "ARCustomerName";
            this.fld_lkeFK_ARCustomerID.Properties.ValueMember = "ARCustomerID";
            this.fld_lkeFK_ARCustomerID.Screen = null;
            this.fld_lkeFK_ARCustomerID.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeFK_ARCustomerID.TabIndex = 5;
            this.fld_lkeFK_ARCustomerID.Tag = "DC";
            this.fld_lkeFK_ARCustomerID.VinaAllowDummy = true;
            this.fld_lkeFK_ARCustomerID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_ARCustomerID.VinaDataMember = "FK_APSupplierID";
            this.fld_lkeFK_ARCustomerID.VinaDataSource = "ICReceipts";
            this.fld_lkeFK_ARCustomerID.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(128, 69);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 13);
            this.labelControl5.TabIndex = 96;
            this.labelControl5.Text = "Nhà cung cấp";
            // 
            // fld_mneICReceiptDesc
            // 
            this.fld_mneICReceiptDesc.Location = new System.Drawing.Point(203, 118);
            this.fld_mneICReceiptDesc.Name = "fld_mneICReceiptDesc";
            this.fld_mneICReceiptDesc.Screen = null;
            this.fld_mneICReceiptDesc.Size = new System.Drawing.Size(396, 45);
            this.fld_mneICReceiptDesc.TabIndex = 9;
            this.fld_mneICReceiptDesc.Tag = "DC";
            this.fld_mneICReceiptDesc.VinaDataMember = "ICReceiptDesc";
            this.fld_mneICReceiptDesc.VinaDataSource = "ICReceipts";
            this.fld_mneICReceiptDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(128, 121);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 105;
            this.labelControl6.Text = "Diễn giải";
            // 
            // fld_lkdFK_ICStockID
            // 
            this.fld_lkdFK_ICStockID.Location = new System.Drawing.Point(203, 92);
            this.fld_lkdFK_ICStockID.Name = "fld_lkdFK_ICStockID";
            this.fld_lkdFK_ICStockID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkdFK_ICStockID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICStockNo", "Mã kho"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICStockName", "Tên kho")});
            this.fld_lkdFK_ICStockID.Properties.DisplayMember = "ICStockName";
            this.fld_lkdFK_ICStockID.Properties.ValueMember = "ICStockID";
            this.fld_lkdFK_ICStockID.Screen = null;
            this.fld_lkdFK_ICStockID.Size = new System.Drawing.Size(150, 20);
            this.fld_lkdFK_ICStockID.TabIndex = 7;
            this.fld_lkdFK_ICStockID.Tag = "DC";
            this.fld_lkdFK_ICStockID.VinaAllowDummy = true;
            this.fld_lkdFK_ICStockID.VinaAutoGenarateDataSoure = true;
            this.fld_lkdFK_ICStockID.VinaDataMember = "FK_ICStockID";
            this.fld_lkdFK_ICStockID.VinaDataSource = "ICReceipts";
            this.fld_lkdFK_ICStockID.VinaPropertyName = "EditValue";
            this.fld_lkdFK_ICStockID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.Fld_lkdFK_ICStockID_CloseUp);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(128, 95);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(18, 13);
            this.labelControl7.TabIndex = 106;
            this.labelControl7.Text = "Kho";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(374, 95);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 13);
            this.labelControl9.TabIndex = 108;
            this.labelControl9.Text = "Mã lô hàng";
            // 
            // fld_txtICReceiptProductLotNo
            // 
            this.fld_txtICReceiptProductLotNo.Location = new System.Drawing.Point(449, 92);
            this.fld_txtICReceiptProductLotNo.Name = "fld_txtICReceiptProductLotNo";
            this.fld_txtICReceiptProductLotNo.Screen = null;
            this.fld_txtICReceiptProductLotNo.Size = new System.Drawing.Size(150, 20);
            this.fld_txtICReceiptProductLotNo.TabIndex = 8;
            this.fld_txtICReceiptProductLotNo.Tag = "DC";
            this.fld_txtICReceiptProductLotNo.VinaDataMember = "ICReceiptProductLotNo";
            this.fld_txtICReceiptProductLotNo.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptProductLotNo.VinaPropertyName = "EditValue";
            this.fld_txtICReceiptProductLotNo.Validated += new System.EventHandler(this.Fld_txtICReceiptProductLotNo_Validated);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(622, 40);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(29, 13);
            this.labelControl13.TabIndex = 112;
            this.labelControl13.Text = "Tỷ giá";
            // 
            // fld_lkeFK_GECurrencyID
            // 
            this.fld_lkeFK_GECurrencyID.Location = new System.Drawing.Point(696, 12);
            this.fld_lkeFK_GECurrencyID.Name = "fld_lkeFK_GECurrencyID";
            this.fld_lkeFK_GECurrencyID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_GECurrencyID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GECurrencyNo", "Loại tiền tệ")});
            this.fld_lkeFK_GECurrencyID.Properties.DisplayMember = "GECurrencyNo";
            this.fld_lkeFK_GECurrencyID.Properties.ValueMember = "GECurrencyID";
            this.fld_lkeFK_GECurrencyID.Screen = null;
            this.fld_lkeFK_GECurrencyID.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeFK_GECurrencyID.TabIndex = 2;
            this.fld_lkeFK_GECurrencyID.Tag = "DC";
            this.fld_lkeFK_GECurrencyID.VinaAllowDummy = true;
            this.fld_lkeFK_GECurrencyID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_GECurrencyID.VinaDataMember = "FK_GECurrencyID";
            this.fld_lkeFK_GECurrencyID.VinaDataSource = "ICReceipts";
            this.fld_lkeFK_GECurrencyID.VinaPropertyName = "EditValue";
            this.fld_lkeFK_GECurrencyID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.Fld_lkeFK_GECurrencyID_CloseUp);
            // 
            // fld_txtICReceiptExchangeRate
            // 
            this.fld_txtICReceiptExchangeRate.Location = new System.Drawing.Point(696, 37);
            this.fld_txtICReceiptExchangeRate.Name = "fld_txtICReceiptExchangeRate";
            this.fld_txtICReceiptExchangeRate.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtICReceiptExchangeRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptExchangeRate.Properties.EditFormat.FormatString = "n3";
            this.fld_txtICReceiptExchangeRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtICReceiptExchangeRate.Screen = null;
            this.fld_txtICReceiptExchangeRate.Size = new System.Drawing.Size(150, 20);
            this.fld_txtICReceiptExchangeRate.TabIndex = 4;
            this.fld_txtICReceiptExchangeRate.Tag = "DC";
            this.fld_txtICReceiptExchangeRate.VinaDataMember = "ICReceiptExchangeRate";
            this.fld_txtICReceiptExchangeRate.VinaDataSource = "ICReceipts";
            this.fld_txtICReceiptExchangeRate.VinaPropertyName = "EditValue";
            this.fld_txtICReceiptExchangeRate.Validated += new System.EventHandler(this.Fld_txtICReceiptExchangeRate_Validated);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(622, 15);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(53, 13);
            this.labelControl12.TabIndex = 109;
            this.labelControl12.Text = "Loại tiền tệ";
            // 
            // DMRC100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 563);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.fld_lkeFK_GECurrencyID);
            this.Controls.Add(this.fld_txtICReceiptExchangeRate);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.fld_txtICReceiptProductLotNo);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_lkdFK_ICStockID);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_txtICReceiptNo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_txtICReceiptName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fld_dteICReceiptDate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_lkeICReceiptStatus);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_lkeFK_ARCustomerID);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.fld_mneICReceiptDesc);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.fld_lkeFK_HREmployeeID);
            this.Controls.Add(this.fld_pteICReceiptEmployeePicture);
            this.Controls.Add(this.fld_txtICReceiptTotalAmount);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.fld_txtICReceiptTaxAmount);
            this.Controls.Add(this.fld_txtICReceiptTaxPercent);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.fld_txtICReceiptDiscountAmount);
            this.Controls.Add(this.fld_txtICReceiptDiscountPercent);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.fld_txtICReceiptSubTotalAmount);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "DMRC100";
            this.Text = "DMRC100";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ICProductID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ptcICProductPicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICReceiptItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptSubTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptDiscountPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptDiscountAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptTaxAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptTaxPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pteICReceiptEmployeePicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteICReceiptDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteICReceiptDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeICReceiptStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ARCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneICReceiptDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkdFK_ICStockID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptProductLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_GECurrencyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICReceiptExchangeRate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private ICReceiptItemsGridControl fld_dgcICReceiptItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private VinaTextBox fld_txtICReceiptSubTotalAmount;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private VinaTextBox fld_txtICReceiptDiscountPercent;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private VinaTextBox fld_txtICReceiptDiscountAmount;
        private VinaTextBox fld_txtICReceiptTaxAmount;
        private VinaTextBox fld_txtICReceiptTaxPercent;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private VinaTextBox fld_txtICReceiptTotalAmount;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private VinaPictureEdit fld_ptcICProductPicture;
        private VinaLookupEdit fld_lkeFK_ICProductID;
        private VinaPictureEdit fld_pteICReceiptEmployeePicture;
        private VinaLookupEdit fld_lkeFK_HREmployeeID;
        private VinaTextBox fld_txtICReceiptNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtICReceiptName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private VinaDateEdit fld_dteICReceiptDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaLookupEdit fld_lkeICReceiptStatus;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaLookupEdit fld_lkeFK_ARCustomerID;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneICReceiptDesc;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private VinaLookupEdit fld_lkdFK_ICStockID;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private VinaTextBox fld_txtICReceiptProductLotNo;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private VinaLookupEdit fld_lkeFK_GECurrencyID;
        private VinaTextBox fld_txtICReceiptExchangeRate;
        private DevExpress.XtraEditors.LabelControl labelControl12;
    }
}