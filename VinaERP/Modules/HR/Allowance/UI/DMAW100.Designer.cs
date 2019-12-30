using VinaLib.BaseProvider;

namespace VinaERP.Modules.Allowance.UI
{
    partial class DMAW100
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
            this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcHREmployeeAllowances = new VinaERP.Modules.Allowance.HREmployeeAllowancesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRAllowanceNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRAllowanceDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRAllowanceName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRAllowanceConfigValue = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRAllowanceNumber = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_HREmployeeRequest = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRAllowanceFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_HRFormAllowanceID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRAllowanceOption = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_ceHRAllowanceByWorkDay = new VinaLib.BaseProvider.VinaCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeAllowances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRAllowanceDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceConfigValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeRequest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRAllowanceFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRAllowanceFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRFormAllowanceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRAllowanceOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ceHRAllowanceByWorkDay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 155);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(1055, 403);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.simpleButton9);
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeAllowances);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(1049, 375);
            this.fld_lkeFK_ICProductID.Text = "Danh sách nhân viên";
            // 
            // simpleButton9
            // 
            this.simpleButton9.Location = new System.Drawing.Point(7, 14);
            this.simpleButton9.Name = "simpleButton9";
            this.simpleButton9.Size = new System.Drawing.Size(113, 25);
            this.simpleButton9.TabIndex = 131;
            this.simpleButton9.Text = "Thêm nhân viên";
            this.simpleButton9.Click += new System.EventHandler(this.simpleButton9_Click);
            // 
            // fld_dgcHREmployeeAllowances
            // 
            this.fld_dgcHREmployeeAllowances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeAllowances.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeAllowances.MainView = this.gridView1;
            this.fld_dgcHREmployeeAllowances.Name = "fld_dgcHREmployeeAllowances";
            this.fld_dgcHREmployeeAllowances.Screen = null;
            this.fld_dgcHREmployeeAllowances.Size = new System.Drawing.Size(1049, 330);
            this.fld_dgcHREmployeeAllowances.TabIndex = 16;
            this.fld_dgcHREmployeeAllowances.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeAllowances.VinaDataMember = null;
            this.fld_dgcHREmployeeAllowances.VinaDataSource = "HREmployeeAllowances";
            this.fld_dgcHREmployeeAllowances.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeAllowances;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã phụ cấp";
            // 
            // fld_txtHRAllowanceNo
            // 
            this.fld_txtHRAllowanceNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRAllowanceNo.Name = "fld_txtHRAllowanceNo";
            this.fld_txtHRAllowanceNo.Screen = null;
            this.fld_txtHRAllowanceNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRAllowanceNo.TabIndex = 0;
            this.fld_txtHRAllowanceNo.Tag = "DC";
            this.fld_txtHRAllowanceNo.VinaDataMember = "HRAllowanceNo";
            this.fld_txtHRAllowanceNo.VinaDataSource = "HRAllowances";
            this.fld_txtHRAllowanceNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRAllowanceDesc
            // 
            this.fld_mneHRAllowanceDesc.Location = new System.Drawing.Point(116, 116);
            this.fld_mneHRAllowanceDesc.Name = "fld_mneHRAllowanceDesc";
            this.fld_mneHRAllowanceDesc.Screen = null;
            this.fld_mneHRAllowanceDesc.Size = new System.Drawing.Size(199, 33);
            this.fld_mneHRAllowanceDesc.TabIndex = 3;
            this.fld_mneHRAllowanceDesc.Tag = "DC";
            this.fld_mneHRAllowanceDesc.VinaDataMember = "HRAllowanceDesc";
            this.fld_mneHRAllowanceDesc.VinaDataSource = "HRAllowances";
            this.fld_mneHRAllowanceDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 117);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Diễn giải";
            // 
            // fld_txtHRAllowanceName
            // 
            this.fld_txtHRAllowanceName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRAllowanceName.Name = "fld_txtHRAllowanceName";
            this.fld_txtHRAllowanceName.Screen = null;
            this.fld_txtHRAllowanceName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRAllowanceName.TabIndex = 63;
            this.fld_txtHRAllowanceName.Tag = "DC";
            this.fld_txtHRAllowanceName.VinaDataMember = "HRAllowanceName";
            this.fld_txtHRAllowanceName.VinaDataSource = "HRAllowances";
            this.fld_txtHRAllowanceName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên phụ cấp";
            // 
            // fld_txtHRAllowanceConfigValue
            // 
            this.fld_txtHRAllowanceConfigValue.Location = new System.Drawing.Point(442, 88);
            this.fld_txtHRAllowanceConfigValue.Name = "fld_txtHRAllowanceConfigValue";
            this.fld_txtHRAllowanceConfigValue.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRAllowanceConfigValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRAllowanceConfigValue.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRAllowanceConfigValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRAllowanceConfigValue.Screen = null;
            this.fld_txtHRAllowanceConfigValue.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRAllowanceConfigValue.TabIndex = 67;
            this.fld_txtHRAllowanceConfigValue.Tag = "DC";
            this.fld_txtHRAllowanceConfigValue.VinaDataMember = "HRAllowanceConfigValue";
            this.fld_txtHRAllowanceConfigValue.VinaDataSource = "HRAllowances";
            this.fld_txtHRAllowanceConfigValue.VinaPropertyName = "EditValue";
            this.fld_txtHRAllowanceConfigValue.Validated += new System.EventHandler(this.fld_txtHRAllowanceValue_Validated);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(345, 91);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 68;
            this.labelControl6.Text = "Số tiền";
            // 
            // fld_txtHRAllowanceNumber
            // 
            this.fld_txtHRAllowanceNumber.Location = new System.Drawing.Point(116, 36);
            this.fld_txtHRAllowanceNumber.Name = "fld_txtHRAllowanceNumber";
            this.fld_txtHRAllowanceNumber.Screen = null;
            this.fld_txtHRAllowanceNumber.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRAllowanceNumber.TabIndex = 69;
            this.fld_txtHRAllowanceNumber.Tag = "DC";
            this.fld_txtHRAllowanceNumber.VinaDataMember = "HRAllowanceNumber";
            this.fld_txtHRAllowanceNumber.VinaDataSource = "HRAllowances";
            this.fld_txtHRAllowanceNumber.VinaPropertyName = "EditValue";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 70;
            this.labelControl2.Text = "Số quyết định";
            // 
            // fld_lkeFK_HREmployeeRequest
            // 
            this.fld_lkeFK_HREmployeeRequest.Location = new System.Drawing.Point(442, 36);
            this.fld_lkeFK_HREmployeeRequest.Name = "fld_lkeFK_HREmployeeRequest";
            this.fld_lkeFK_HREmployeeRequest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeeRequest.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Họ tên")});
            this.fld_lkeFK_HREmployeeRequest.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeFK_HREmployeeRequest.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeFK_HREmployeeRequest.Screen = null;
            this.fld_lkeFK_HREmployeeRequest.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeFK_HREmployeeRequest.TabIndex = 72;
            this.fld_lkeFK_HREmployeeRequest.Tag = "DC";
            this.fld_lkeFK_HREmployeeRequest.VinaAllowDummy = true;
            this.fld_lkeFK_HREmployeeRequest.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HREmployeeRequest.VinaDataMember = "FK_HREmployeeRequest";
            this.fld_lkeFK_HREmployeeRequest.VinaDataSource = "HRAllowances";
            this.fld_lkeFK_HREmployeeRequest.VinaPropertyName = "EditValue";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(345, 39);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(42, 13);
            this.labelControl10.TabIndex = 71;
            this.labelControl10.Text = "Người ký";
            // 
            // fld_dteHRAllowanceFromDate
            // 
            this.fld_dteHRAllowanceFromDate.EditValue = null;
            this.fld_dteHRAllowanceFromDate.Location = new System.Drawing.Point(116, 62);
            this.fld_dteHRAllowanceFromDate.Name = "fld_dteHRAllowanceFromDate";
            this.fld_dteHRAllowanceFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRAllowanceFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRAllowanceFromDate.Screen = null;
            this.fld_dteHRAllowanceFromDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRAllowanceFromDate.TabIndex = 74;
            this.fld_dteHRAllowanceFromDate.Tag = "DC";
            this.fld_dteHRAllowanceFromDate.VinaDataMember = "HRAllowanceFromDate";
            this.fld_dteHRAllowanceFromDate.VinaDataSource = "HRAllowances";
            this.fld_dteHRAllowanceFromDate.VinaPropertyName = "EditValue";
            this.fld_dteHRAllowanceFromDate.Validated += new System.EventHandler(this.fld_dteHRAllowanceFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 65);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(79, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Ngày quyết định";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(345, 65);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(46, 13);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "Hình thức";
            // 
            // fld_lkeFK_HRFormAllowanceID
            // 
            this.fld_lkeFK_HRFormAllowanceID.Location = new System.Drawing.Point(442, 62);
            this.fld_lkeFK_HRFormAllowanceID.Name = "fld_lkeFK_HRFormAllowanceID";
            this.fld_lkeFK_HRFormAllowanceID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRFormAllowanceID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRFormAllowanceName", "Hình thức")});
            this.fld_lkeFK_HRFormAllowanceID.Properties.DisplayMember = "HRFormAllowanceName";
            this.fld_lkeFK_HRFormAllowanceID.Properties.ValueMember = "HRFormAllowanceID";
            this.fld_lkeFK_HRFormAllowanceID.Screen = null;
            this.fld_lkeFK_HRFormAllowanceID.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeFK_HRFormAllowanceID.TabIndex = 80;
            this.fld_lkeFK_HRFormAllowanceID.Tag = "DC";
            this.fld_lkeFK_HRFormAllowanceID.VinaAllowDummy = true;
            this.fld_lkeFK_HRFormAllowanceID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HRFormAllowanceID.VinaDataMember = "FK_HRFormAllowanceID";
            this.fld_lkeFK_HRFormAllowanceID.VinaDataSource = "HRAllowances";
            this.fld_lkeFK_HRFormAllowanceID.VinaPropertyName = "EditValue";
            this.fld_lkeFK_HRFormAllowanceID.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.fld_lkeFK_HRFormAllowanceID_QueryPopUp);
            this.fld_lkeFK_HRFormAllowanceID.Validated += new System.EventHandler(this.fld_txtHRAllowanceType_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 83;
            this.labelControl3.Text = "Loại phụ cấp";
            // 
            // fld_lkeHRAllowanceOption
            // 
            this.fld_lkeHRAllowanceOption.Location = new System.Drawing.Point(116, 88);
            this.fld_lkeHRAllowanceOption.Name = "fld_lkeHRAllowanceOption";
            this.fld_lkeHRAllowanceOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRAllowanceOption.Screen = null;
            this.fld_lkeHRAllowanceOption.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRAllowanceOption.TabIndex = 82;
            this.fld_lkeHRAllowanceOption.Tag = "DC";
            this.fld_lkeHRAllowanceOption.VinaAllowDummy = true;
            this.fld_lkeHRAllowanceOption.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRAllowanceOption.VinaDataMember = "HRAllowanceOption";
            this.fld_lkeHRAllowanceOption.VinaDataSource = "HRAllowances";
            this.fld_lkeHRAllowanceOption.VinaPropertyName = "EditValue";
            this.fld_lkeHRAllowanceOption.Validated += new System.EventHandler(this.fld_lkeHRAllowanceOption_Validated);
            // 
            // fld_ceHRAllowanceByWorkDay
            // 
            this.fld_ceHRAllowanceByWorkDay.Location = new System.Drawing.Point(442, 114);
            this.fld_ceHRAllowanceByWorkDay.Name = "fld_ceHRAllowanceByWorkDay";
            this.fld_ceHRAllowanceByWorkDay.Properties.Caption = "Theo ngày công";
            this.fld_ceHRAllowanceByWorkDay.Screen = null;
            this.fld_ceHRAllowanceByWorkDay.Size = new System.Drawing.Size(124, 19);
            this.fld_ceHRAllowanceByWorkDay.TabIndex = 86;
            this.fld_ceHRAllowanceByWorkDay.Tag = "DC";
            this.fld_ceHRAllowanceByWorkDay.VinaDataMember = "HRAllowanceByWorkDay";
            this.fld_ceHRAllowanceByWorkDay.VinaDataSource = "HRAllowances";
            this.fld_ceHRAllowanceByWorkDay.VinaPropertyName = "EditValue";
            // 
            // DMAW100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.fld_ceHRAllowanceByWorkDay);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_lkeHRAllowanceOption);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.fld_lkeFK_HRFormAllowanceID);
            this.Controls.Add(this.fld_dteHRAllowanceFromDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_lkeFK_HREmployeeRequest);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.fld_txtHRAllowanceNumber);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fld_txtHRAllowanceConfigValue);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.fld_txtHRAllowanceName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRAllowanceDesc);
            this.Controls.Add(this.fld_txtHRAllowanceNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMAW100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeAllowances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRAllowanceDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceConfigValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRAllowanceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeRequest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRAllowanceFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRAllowanceFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRFormAllowanceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRAllowanceOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ceHRAllowanceByWorkDay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeAllowancesGridControl fld_dgcHREmployeeAllowances;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRAllowanceNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRAllowanceDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRAllowanceName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaTextBox fld_txtHRAllowanceConfigValue;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private VinaTextBox fld_txtHRAllowanceNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private VinaLookupEdit fld_lkeFK_HREmployeeRequest;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private VinaDateEdit fld_dteHRAllowanceFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private VinaLookupEdit fld_lkeFK_HRFormAllowanceID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaLookupEdit fld_lkeHRAllowanceOption;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private VinaCheckBox fld_ceHRAllowanceByWorkDay;
    }
}