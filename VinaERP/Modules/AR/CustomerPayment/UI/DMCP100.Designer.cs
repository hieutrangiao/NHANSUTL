using VinaLib.BaseProvider;

namespace VinaERP.Modules.CustomerPayment.UI
{
    partial class DMCP100
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
            this.fld_lkeFK_ARCustomerID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteARSaleOrderDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.fld_txtARSaleOrderName = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_txtARSaleOrderNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneARSaleOrderDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeARSaleOrderStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtARSaleOrderExchangeRate = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_GECurrencyID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fld_pteARSaleOrderEmployeePicture = new VinaLib.BaseProvider.VinaPictureEdit();
            this.fld_lkeFK_HREmployeeID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcARCustomerPaymentTimePayments = new VinaERP.Modules.CustomerPayment.ARCustomerPaymentTimePaymentsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcARCustomerPaymentDetails = new VinaERP.Modules.CustomerPayment.ARCustomerPaymentDetailsGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_txtARCustomerPaymentSenderName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtARCustomerPaymentTotalAmount = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.vinaTextBox1 = new VinaLib.BaseProvider.VinaTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ARCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteARSaleOrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteARSaleOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARSaleOrderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARSaleOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneARSaleOrderDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeARSaleOrderStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARSaleOrderExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_GECurrencyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pteARSaleOrderEmployeePicture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcARCustomerPaymentTimePayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcARCustomerPaymentDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARCustomerPaymentSenderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARCustomerPaymentTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_lkeFK_ARCustomerID
            // 
            this.fld_lkeFK_ARCustomerID.Location = new System.Drawing.Point(210, 64);
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
            this.fld_lkeFK_ARCustomerID.TabIndex = 6;
            this.fld_lkeFK_ARCustomerID.Tag = "DC";
            this.fld_lkeFK_ARCustomerID.VinaAllowDummy = true;
            this.fld_lkeFK_ARCustomerID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_ARCustomerID.VinaDataMember = "FK_ARCustomerID";
            this.fld_lkeFK_ARCustomerID.VinaDataSource = "ARCustomerPayments";
            this.fld_lkeFK_ARCustomerID.VinaPropertyName = "EditValue";
            this.fld_lkeFK_ARCustomerID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.fld_lkeFK_ARCustomerID_CloseUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(131, 67);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "Khách hàng";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(131, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Tên chứng từ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(131, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã chứng từ";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(380, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 52;
            this.labelControl3.Text = "Ngày chứng từ";
            // 
            // fld_dteARSaleOrderDate
            // 
            this.fld_dteARSaleOrderDate.EditValue = null;
            this.fld_dteARSaleOrderDate.Location = new System.Drawing.Point(469, 12);
            this.fld_dteARSaleOrderDate.Name = "fld_dteARSaleOrderDate";
            this.fld_dteARSaleOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteARSaleOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteARSaleOrderDate.Screen = null;
            this.fld_dteARSaleOrderDate.Size = new System.Drawing.Size(150, 20);
            this.fld_dteARSaleOrderDate.TabIndex = 1;
            this.fld_dteARSaleOrderDate.Tag = "DC";
            this.fld_dteARSaleOrderDate.VinaDataMember = "ARCustomerPaymentDate";
            this.fld_dteARSaleOrderDate.VinaDataSource = "ARCustomerPayments";
            this.fld_dteARSaleOrderDate.VinaPropertyName = "EditValue";
            // 
            // fld_txtARSaleOrderName
            // 
            this.fld_txtARSaleOrderName.Location = new System.Drawing.Point(210, 38);
            this.fld_txtARSaleOrderName.Name = "fld_txtARSaleOrderName";
            this.fld_txtARSaleOrderName.Screen = null;
            this.fld_txtARSaleOrderName.Size = new System.Drawing.Size(150, 20);
            this.fld_txtARSaleOrderName.TabIndex = 3;
            this.fld_txtARSaleOrderName.Tag = "DC";
            this.fld_txtARSaleOrderName.VinaDataMember = "ARCustomerPaymentName";
            this.fld_txtARSaleOrderName.VinaDataSource = "ARCustomerPayments";
            this.fld_txtARSaleOrderName.VinaPropertyName = "EditValue";
            // 
            // fld_txtARSaleOrderNo
            // 
            this.fld_txtARSaleOrderNo.Location = new System.Drawing.Point(210, 12);
            this.fld_txtARSaleOrderNo.Name = "fld_txtARSaleOrderNo";
            this.fld_txtARSaleOrderNo.Screen = null;
            this.fld_txtARSaleOrderNo.Size = new System.Drawing.Size(150, 20);
            this.fld_txtARSaleOrderNo.TabIndex = 0;
            this.fld_txtARSaleOrderNo.Tag = "DC";
            this.fld_txtARSaleOrderNo.VinaDataMember = "ARCustomerPaymentNo";
            this.fld_txtARSaleOrderNo.VinaDataSource = "ARCustomerPayments";
            this.fld_txtARSaleOrderNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneARSaleOrderDesc
            // 
            this.fld_mneARSaleOrderDesc.Location = new System.Drawing.Point(210, 90);
            this.fld_mneARSaleOrderDesc.Name = "fld_mneARSaleOrderDesc";
            this.fld_mneARSaleOrderDesc.Screen = null;
            this.fld_mneARSaleOrderDesc.Size = new System.Drawing.Size(409, 45);
            this.fld_mneARSaleOrderDesc.TabIndex = 9;
            this.fld_mneARSaleOrderDesc.Tag = "DC";
            this.fld_mneARSaleOrderDesc.VinaDataMember = "ARCustomerPaymentDesc";
            this.fld_mneARSaleOrderDesc.VinaDataSource = "ARCustomerPayments";
            this.fld_mneARSaleOrderDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(380, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 58;
            this.labelControl4.Text = "Trạng thái";
            // 
            // fld_lkeARSaleOrderStatus
            // 
            this.fld_lkeARSaleOrderStatus.Location = new System.Drawing.Point(469, 38);
            this.fld_lkeARSaleOrderStatus.Name = "fld_lkeARSaleOrderStatus";
            this.fld_lkeARSaleOrderStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeARSaleOrderStatus.Properties.ReadOnly = true;
            this.fld_lkeARSaleOrderStatus.Screen = null;
            this.fld_lkeARSaleOrderStatus.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeARSaleOrderStatus.TabIndex = 4;
            this.fld_lkeARSaleOrderStatus.Tag = "DC";
            this.fld_lkeARSaleOrderStatus.VinaAllowDummy = true;
            this.fld_lkeARSaleOrderStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeARSaleOrderStatus.VinaDataMember = "ARCustomerPaymentStatus";
            this.fld_lkeARSaleOrderStatus.VinaDataSource = "ARCustomerPayments";
            this.fld_lkeARSaleOrderStatus.VinaPropertyName = "EditValue";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(131, 93);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 62;
            this.labelControl6.Text = "Diễn giải";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(380, 66);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(84, 13);
            this.labelControl10.TabIndex = 67;
            this.labelControl10.Text = "Người thanh toán";
            // 
            // fld_txtARSaleOrderExchangeRate
            // 
            this.fld_txtARSaleOrderExchangeRate.Location = new System.Drawing.Point(728, 38);
            this.fld_txtARSaleOrderExchangeRate.Name = "fld_txtARSaleOrderExchangeRate";
            this.fld_txtARSaleOrderExchangeRate.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtARSaleOrderExchangeRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtARSaleOrderExchangeRate.Properties.EditFormat.FormatString = "n3";
            this.fld_txtARSaleOrderExchangeRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtARSaleOrderExchangeRate.Screen = null;
            this.fld_txtARSaleOrderExchangeRate.Size = new System.Drawing.Size(150, 20);
            this.fld_txtARSaleOrderExchangeRate.TabIndex = 5;
            this.fld_txtARSaleOrderExchangeRate.Tag = "DC";
            this.fld_txtARSaleOrderExchangeRate.VinaDataMember = "ARCustomerPaymentExchangeRate";
            this.fld_txtARSaleOrderExchangeRate.VinaDataSource = "ARCustomerPayments";
            this.fld_txtARSaleOrderExchangeRate.VinaPropertyName = "EditValue";
            this.fld_txtARSaleOrderExchangeRate.Validated += new System.EventHandler(this.Fld_txtARSaleOrderExchangeRate_Validated);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(639, 15);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(53, 13);
            this.labelControl12.TabIndex = 71;
            this.labelControl12.Text = "Loại tiền tệ";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(639, 41);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(29, 13);
            this.labelControl13.TabIndex = 75;
            this.labelControl13.Text = "Tỷ giá";
            // 
            // fld_lkeFK_GECurrencyID
            // 
            this.fld_lkeFK_GECurrencyID.Location = new System.Drawing.Point(728, 12);
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
            this.fld_lkeFK_GECurrencyID.VinaDataSource = "ARCustomerPayments";
            this.fld_lkeFK_GECurrencyID.VinaPropertyName = "EditValue";
            this.fld_lkeFK_GECurrencyID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.Fld_lkeFK_GECurrencyID_CloseUp);
            // 
            // fld_pteARSaleOrderEmployeePicture
            // 
            this.fld_pteARSaleOrderEmployeePicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.fld_pteARSaleOrderEmployeePicture.Location = new System.Drawing.Point(12, 12);
            this.fld_pteARSaleOrderEmployeePicture.Name = "fld_pteARSaleOrderEmployeePicture";
            this.fld_pteARSaleOrderEmployeePicture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.fld_pteARSaleOrderEmployeePicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.fld_pteARSaleOrderEmployeePicture.Screen = null;
            this.fld_pteARSaleOrderEmployeePicture.Size = new System.Drawing.Size(100, 94);
            this.fld_pteARSaleOrderEmployeePicture.TabIndex = 89;
            this.fld_pteARSaleOrderEmployeePicture.Tag = "DC";
            this.fld_pteARSaleOrderEmployeePicture.VinaDataMember = "ARSaleOrderEmployeePicture";
            this.fld_pteARSaleOrderEmployeePicture.VinaDataSource = "ARSaleOrders";
            this.fld_pteARSaleOrderEmployeePicture.VinaPropertyName = "EditValue";
            // 
            // fld_lkeFK_HREmployeeID
            // 
            this.fld_lkeFK_HREmployeeID.Location = new System.Drawing.Point(12, 111);
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
            this.fld_lkeFK_HREmployeeID.TabIndex = 90;
            this.fld_lkeFK_HREmployeeID.Tag = "DC";
            this.fld_lkeFK_HREmployeeID.VinaAllowDummy = true;
            this.fld_lkeFK_HREmployeeID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HREmployeeID.VinaDataMember = "FK_HREmployeeID";
            this.fld_lkeFK_HREmployeeID.VinaDataSource = "ARCustomerPayments";
            this.fld_lkeFK_HREmployeeID.VinaPropertyName = "EditValue";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 141);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(879, 410);
            this.xtraTabControl1.TabIndex = 91;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.fld_dgcARCustomerPaymentTimePayments);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(873, 382);
            this.xtraTabPage1.Text = "Hóa đơn thanh toán";
            // 
            // fld_dgcARCustomerPaymentTimePayments
            // 
            this.fld_dgcARCustomerPaymentTimePayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcARCustomerPaymentTimePayments.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcARCustomerPaymentTimePayments.MainView = this.gridView1;
            this.fld_dgcARCustomerPaymentTimePayments.Name = "fld_dgcARCustomerPaymentTimePayments";
            this.fld_dgcARCustomerPaymentTimePayments.Screen = null;
            this.fld_dgcARCustomerPaymentTimePayments.Size = new System.Drawing.Size(873, 382);
            this.fld_dgcARCustomerPaymentTimePayments.TabIndex = 16;
            this.fld_dgcARCustomerPaymentTimePayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcARCustomerPaymentTimePayments.VinaDataMember = null;
            this.fld_dgcARCustomerPaymentTimePayments.VinaDataSource = "ARCustomerPaymentTimePayments";
            this.fld_dgcARCustomerPaymentTimePayments.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcARCustomerPaymentTimePayments;
            this.gridView1.Name = "gridView1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.fld_dgcARCustomerPaymentDetails);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(873, 382);
            this.xtraTabPage2.Text = "Thông tin thanh toán";
            // 
            // fld_dgcARCustomerPaymentDetails
            // 
            this.fld_dgcARCustomerPaymentDetails.AllowMultiplePayment = false;
            this.fld_dgcARCustomerPaymentDetails.AllowPaymentByCurrency = false;
            this.fld_dgcARCustomerPaymentDetails.CustomerPaymentDetailList = null;
            this.fld_dgcARCustomerPaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcARCustomerPaymentDetails.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcARCustomerPaymentDetails.MainView = this.gridView2;
            this.fld_dgcARCustomerPaymentDetails.Name = "fld_dgcARCustomerPaymentDetails";
            this.fld_dgcARCustomerPaymentDetails.PaymentAmount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fld_dgcARCustomerPaymentDetails.RequiredMethod = null;
            this.fld_dgcARCustomerPaymentDetails.Screen = null;
            this.fld_dgcARCustomerPaymentDetails.Size = new System.Drawing.Size(873, 382);
            this.fld_dgcARCustomerPaymentDetails.TabIndex = 17;
            this.fld_dgcARCustomerPaymentDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.fld_dgcARCustomerPaymentDetails.VinaDataMember = null;
            this.fld_dgcARCustomerPaymentDetails.VinaDataSource = "ARCustomerPaymentDetails";
            this.fld_dgcARCustomerPaymentDetails.VinaPropertyName = null;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcARCustomerPaymentDetails;
            this.gridView2.Name = "gridView2";
            // 
            // fld_txtARCustomerPaymentSenderName
            // 
            this.fld_txtARCustomerPaymentSenderName.Location = new System.Drawing.Point(469, 64);
            this.fld_txtARCustomerPaymentSenderName.Name = "fld_txtARCustomerPaymentSenderName";
            this.fld_txtARCustomerPaymentSenderName.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtARCustomerPaymentSenderName.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtARCustomerPaymentSenderName.Properties.EditFormat.FormatString = "n3";
            this.fld_txtARCustomerPaymentSenderName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtARCustomerPaymentSenderName.Screen = null;
            this.fld_txtARCustomerPaymentSenderName.Size = new System.Drawing.Size(150, 20);
            this.fld_txtARCustomerPaymentSenderName.TabIndex = 7;
            this.fld_txtARCustomerPaymentSenderName.Tag = "DC";
            this.fld_txtARCustomerPaymentSenderName.VinaDataMember = "ARCustomerPaymentSenderName";
            this.fld_txtARCustomerPaymentSenderName.VinaDataSource = "ARCustomerPayments";
            this.fld_txtARCustomerPaymentSenderName.VinaPropertyName = "EditValue";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(639, 93);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(58, 13);
            this.labelControl8.TabIndex = 94;
            this.labelControl8.Text = "Tiền quy đổi";
            // 
            // fld_txtARCustomerPaymentTotalAmount
            // 
            this.fld_txtARCustomerPaymentTotalAmount.Location = new System.Drawing.Point(728, 90);
            this.fld_txtARCustomerPaymentTotalAmount.Name = "fld_txtARCustomerPaymentTotalAmount";
            this.fld_txtARCustomerPaymentTotalAmount.Properties.DisplayFormat.FormatString = "n3";
            this.fld_txtARCustomerPaymentTotalAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtARCustomerPaymentTotalAmount.Properties.EditFormat.FormatString = "n3";
            this.fld_txtARCustomerPaymentTotalAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtARCustomerPaymentTotalAmount.Screen = null;
            this.fld_txtARCustomerPaymentTotalAmount.Size = new System.Drawing.Size(150, 20);
            this.fld_txtARCustomerPaymentTotalAmount.TabIndex = 10;
            this.fld_txtARCustomerPaymentTotalAmount.Tag = "DC";
            this.fld_txtARCustomerPaymentTotalAmount.VinaDataMember = "ARCustomerPaymentExchangeAmount";
            this.fld_txtARCustomerPaymentTotalAmount.VinaDataSource = "ARCustomerPayments";
            this.fld_txtARCustomerPaymentTotalAmount.VinaPropertyName = "EditValue";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(639, 67);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(80, 13);
            this.labelControl9.TabIndex = 96;
            this.labelControl9.Text = "Tổng thanh toán";
            // 
            // vinaTextBox1
            // 
            this.vinaTextBox1.Location = new System.Drawing.Point(728, 64);
            this.vinaTextBox1.Name = "vinaTextBox1";
            this.vinaTextBox1.Properties.DisplayFormat.FormatString = "n3";
            this.vinaTextBox1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.vinaTextBox1.Properties.EditFormat.FormatString = "n3";
            this.vinaTextBox1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.vinaTextBox1.Screen = null;
            this.vinaTextBox1.Size = new System.Drawing.Size(150, 20);
            this.vinaTextBox1.TabIndex = 8;
            this.vinaTextBox1.Tag = "DC";
            this.vinaTextBox1.VinaDataMember = "ARCustomerPaymentTotalAmount";
            this.vinaTextBox1.VinaDataSource = "ARCustomerPayments";
            this.vinaTextBox1.VinaPropertyName = "EditValue";
            // 
            // DMCP100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 563);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.vinaTextBox1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.fld_txtARCustomerPaymentTotalAmount);
            this.Controls.Add(this.fld_txtARCustomerPaymentSenderName);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.fld_lkeFK_HREmployeeID);
            this.Controls.Add(this.fld_pteARSaleOrderEmployeePicture);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.fld_lkeFK_GECurrencyID);
            this.Controls.Add(this.fld_txtARSaleOrderExchangeRate);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.fld_lkeARSaleOrderStatus);
            this.Controls.Add(this.fld_mneARSaleOrderDesc);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_txtARSaleOrderNo);
            this.Controls.Add(this.fld_txtARSaleOrderName);
            this.Controls.Add(this.fld_dteARSaleOrderDate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_lkeFK_ARCustomerID);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMCP100";
            this.Text = "DMSO100";
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ARCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteARSaleOrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteARSaleOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARSaleOrderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARSaleOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneARSaleOrderDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeARSaleOrderStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARSaleOrderExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_GECurrencyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_pteARSaleOrderEmployeePicture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcARCustomerPaymentTimePayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcARCustomerPaymentDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARCustomerPaymentSenderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtARCustomerPaymentTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VinaLookupEdit fld_lkeFK_ARCustomerID;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaDateEdit fld_dteARSaleOrderDate;
        private VinaTextBox fld_txtARSaleOrderName;
        private VinaTextBox fld_txtARSaleOrderNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneARSaleOrderDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaLookupEdit fld_lkeARSaleOrderStatus;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private VinaTextBox fld_txtARSaleOrderExchangeRate;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private VinaLookupEdit fld_lkeFK_GECurrencyID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private VinaPictureEdit fld_pteARSaleOrderEmployeePicture;
        private VinaLookupEdit fld_lkeFK_HREmployeeID;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private CustomerPayment.ARCustomerPaymentTimePaymentsGridControl fld_dgcARCustomerPaymentTimePayments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private CustomerPayment.ARCustomerPaymentDetailsGridControl fld_dgcARCustomerPaymentDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private VinaTextBox fld_txtARCustomerPaymentSenderName;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private VinaTextBox fld_txtARCustomerPaymentTotalAmount;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private VinaTextBox vinaTextBox1;
    }
}