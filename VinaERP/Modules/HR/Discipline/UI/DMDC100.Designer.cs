using VinaLib.BaseProvider;

namespace VinaERP.Modules.Discipline.UI
{
    partial class DMDC100
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
            this.fld_dgcHREmployeeDisciplines = new VinaERP.Modules.Discipline.HREmployeeDisciplinesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDisciplineNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRDisciplineDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDisciplineName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDisciplineValue = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRDisciplineNumber = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_HREmployeeRequest = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRDisciplineFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRDisciplineType = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRDisciplineOption = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRDisciplineStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.fld_mmeHRDisciplineExplain = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeDisciplines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRDisciplineDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeRequest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRDisciplineFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRDisciplineFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRDisciplineType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRDisciplineOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRDisciplineStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mmeHRDisciplineExplain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 218);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(1055, 340);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.simpleButton9);
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeDisciplines);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(1049, 312);
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
            // fld_dgcHREmployeeDisciplines
            // 
            this.fld_dgcHREmployeeDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeDisciplines.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeDisciplines.MainView = this.gridView1;
            this.fld_dgcHREmployeeDisciplines.Name = "fld_dgcHREmployeeDisciplines";
            this.fld_dgcHREmployeeDisciplines.Screen = null;
            this.fld_dgcHREmployeeDisciplines.Size = new System.Drawing.Size(1049, 267);
            this.fld_dgcHREmployeeDisciplines.TabIndex = 16;
            this.fld_dgcHREmployeeDisciplines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeDisciplines.VinaDataMember = null;
            this.fld_dgcHREmployeeDisciplines.VinaDataSource = "HREmployeeDisciplines";
            this.fld_dgcHREmployeeDisciplines.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeDisciplines;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã chứng từ";
            // 
            // fld_txtHRDisciplineNo
            // 
            this.fld_txtHRDisciplineNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRDisciplineNo.Name = "fld_txtHRDisciplineNo";
            this.fld_txtHRDisciplineNo.Screen = null;
            this.fld_txtHRDisciplineNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDisciplineNo.TabIndex = 0;
            this.fld_txtHRDisciplineNo.Tag = "DC";
            this.fld_txtHRDisciplineNo.VinaDataMember = "HRDisciplineNo";
            this.fld_txtHRDisciplineNo.VinaDataSource = "HRDisciplines";
            this.fld_txtHRDisciplineNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRDisciplineDesc
            // 
            this.fld_mneHRDisciplineDesc.Location = new System.Drawing.Point(116, 36);
            this.fld_mneHRDisciplineDesc.Name = "fld_mneHRDisciplineDesc";
            this.fld_mneHRDisciplineDesc.Screen = null;
            this.fld_mneHRDisciplineDesc.Size = new System.Drawing.Size(525, 33);
            this.fld_mneHRDisciplineDesc.TabIndex = 3;
            this.fld_mneHRDisciplineDesc.Tag = "DC";
            this.fld_mneHRDisciplineDesc.VinaDataMember = "HRDisciplineDesc";
            this.fld_mneHRDisciplineDesc.VinaDataSource = "HRDisciplines";
            this.fld_mneHRDisciplineDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // fld_txtHRDisciplineName
            // 
            this.fld_txtHRDisciplineName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRDisciplineName.Name = "fld_txtHRDisciplineName";
            this.fld_txtHRDisciplineName.Screen = null;
            this.fld_txtHRDisciplineName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDisciplineName.TabIndex = 63;
            this.fld_txtHRDisciplineName.Tag = "DC";
            this.fld_txtHRDisciplineName.VinaDataMember = "HRDisciplineName";
            this.fld_txtHRDisciplineName.VinaDataSource = "HRDisciplines";
            this.fld_txtHRDisciplineName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Nhóm biên bản";
            // 
            // fld_txtHRDisciplineValue
            // 
            this.fld_txtHRDisciplineValue.Location = new System.Drawing.Point(442, 127);
            this.fld_txtHRDisciplineValue.Name = "fld_txtHRDisciplineValue";
            this.fld_txtHRDisciplineValue.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRDisciplineValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDisciplineValue.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRDisciplineValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRDisciplineValue.Screen = null;
            this.fld_txtHRDisciplineValue.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDisciplineValue.TabIndex = 67;
            this.fld_txtHRDisciplineValue.Tag = "DC";
            this.fld_txtHRDisciplineValue.VinaDataMember = "HRDisciplineValue";
            this.fld_txtHRDisciplineValue.VinaDataSource = "HRDisciplines";
            this.fld_txtHRDisciplineValue.VinaPropertyName = "EditValue";
            this.fld_txtHRDisciplineValue.Validated += new System.EventHandler(this.fld_txtHRDisciplineValue_Validated);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(345, 130);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 68;
            this.labelControl6.Text = "Số tiền";
            // 
            // fld_txtHRDisciplineNumber
            // 
            this.fld_txtHRDisciplineNumber.Location = new System.Drawing.Point(116, 127);
            this.fld_txtHRDisciplineNumber.Name = "fld_txtHRDisciplineNumber";
            this.fld_txtHRDisciplineNumber.Screen = null;
            this.fld_txtHRDisciplineNumber.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRDisciplineNumber.TabIndex = 69;
            this.fld_txtHRDisciplineNumber.Tag = "DC";
            this.fld_txtHRDisciplineNumber.VinaDataMember = "HRDisciplineNumber";
            this.fld_txtHRDisciplineNumber.VinaDataSource = "HRDisciplines";
            this.fld_txtHRDisciplineNumber.VinaPropertyName = "EditValue";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 130);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 70;
            this.labelControl2.Text = "Số biên bản";
            // 
            // fld_lkeFK_HREmployeeRequest
            // 
            this.fld_lkeFK_HREmployeeRequest.Location = new System.Drawing.Point(442, 75);
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
            this.fld_lkeFK_HREmployeeRequest.VinaDataSource = "HRDisciplines";
            this.fld_lkeFK_HREmployeeRequest.VinaPropertyName = "EditValue";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(345, 78);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(69, 13);
            this.labelControl10.TabIndex = 71;
            this.labelControl10.Text = "Người yêu cầu";
            // 
            // fld_dteHRDisciplineFromDate
            // 
            this.fld_dteHRDisciplineFromDate.EditValue = null;
            this.fld_dteHRDisciplineFromDate.Location = new System.Drawing.Point(116, 75);
            this.fld_dteHRDisciplineFromDate.Name = "fld_dteHRDisciplineFromDate";
            this.fld_dteHRDisciplineFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRDisciplineFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRDisciplineFromDate.Screen = null;
            this.fld_dteHRDisciplineFromDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRDisciplineFromDate.TabIndex = 74;
            this.fld_dteHRDisciplineFromDate.Tag = "DC";
            this.fld_dteHRDisciplineFromDate.VinaDataMember = "HRDisciplineFromDate";
            this.fld_dteHRDisciplineFromDate.VinaDataSource = "HRDisciplines";
            this.fld_dteHRDisciplineFromDate.VinaPropertyName = "EditValue";
            this.fld_dteHRDisciplineFromDate.Validated += new System.EventHandler(this.fld_dteHRDisciplineFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 78);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(67, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Ngày áp dụng";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 104);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(46, 13);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "Hình thức";
            // 
            // fld_lkeHRDisciplineType
            // 
            this.fld_lkeHRDisciplineType.Location = new System.Drawing.Point(116, 101);
            this.fld_lkeHRDisciplineType.Name = "fld_lkeHRDisciplineType";
            this.fld_lkeHRDisciplineType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRDisciplineType.Screen = null;
            this.fld_lkeHRDisciplineType.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRDisciplineType.TabIndex = 80;
            this.fld_lkeHRDisciplineType.Tag = "DC";
            this.fld_lkeHRDisciplineType.VinaAllowDummy = true;
            this.fld_lkeHRDisciplineType.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRDisciplineType.VinaDataMember = "HRDisciplineType";
            this.fld_lkeHRDisciplineType.VinaDataSource = "HRDisciplines";
            this.fld_lkeHRDisciplineType.VinaPropertyName = "EditValue";
            this.fld_lkeHRDisciplineType.Validated += new System.EventHandler(this.fld_txtHRDisciplineType_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(345, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 83;
            this.labelControl3.Text = "Loại chứng từ";
            // 
            // fld_lkeHRDisciplineOption
            // 
            this.fld_lkeHRDisciplineOption.Location = new System.Drawing.Point(442, 101);
            this.fld_lkeHRDisciplineOption.Name = "fld_lkeHRDisciplineOption";
            this.fld_lkeHRDisciplineOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRDisciplineOption.Screen = null;
            this.fld_lkeHRDisciplineOption.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRDisciplineOption.TabIndex = 82;
            this.fld_lkeHRDisciplineOption.Tag = "DC";
            this.fld_lkeHRDisciplineOption.VinaAllowDummy = true;
            this.fld_lkeHRDisciplineOption.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRDisciplineOption.VinaDataMember = "HRDisciplineOption";
            this.fld_lkeHRDisciplineOption.VinaDataSource = "HRDisciplines";
            this.fld_lkeHRDisciplineOption.VinaPropertyName = "EditValue";
            this.fld_lkeHRDisciplineOption.Validated += new System.EventHandler(this.fld_lkeHRDisciplineOption_Validated);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 156);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "Tình trạng";
            // 
            // fld_lkeHRDisciplineStatus
            // 
            this.fld_lkeHRDisciplineStatus.Location = new System.Drawing.Point(116, 153);
            this.fld_lkeHRDisciplineStatus.Name = "fld_lkeHRDisciplineStatus";
            this.fld_lkeHRDisciplineStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRDisciplineStatus.Properties.ReadOnly = true;
            this.fld_lkeHRDisciplineStatus.Screen = null;
            this.fld_lkeHRDisciplineStatus.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRDisciplineStatus.TabIndex = 84;
            this.fld_lkeHRDisciplineStatus.Tag = "DC";
            this.fld_lkeHRDisciplineStatus.VinaAllowDummy = true;
            this.fld_lkeHRDisciplineStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRDisciplineStatus.VinaDataMember = "HRDisciplineStatus";
            this.fld_lkeHRDisciplineStatus.VinaDataSource = "HRDisciplines";
            this.fld_lkeHRDisciplineStatus.VinaPropertyName = "EditValue";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 181);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(42, 13);
            this.labelControl8.TabIndex = 87;
            this.labelControl8.Text = "Giải trình";
            // 
            // fld_mmeHRDisciplineExplain
            // 
            this.fld_mmeHRDisciplineExplain.Location = new System.Drawing.Point(116, 179);
            this.fld_mmeHRDisciplineExplain.Name = "fld_mmeHRDisciplineExplain";
            this.fld_mmeHRDisciplineExplain.Screen = null;
            this.fld_mmeHRDisciplineExplain.Size = new System.Drawing.Size(525, 33);
            this.fld_mmeHRDisciplineExplain.TabIndex = 86;
            this.fld_mmeHRDisciplineExplain.Tag = "DC";
            this.fld_mmeHRDisciplineExplain.VinaDataMember = "HRDisciplineExplain";
            this.fld_mmeHRDisciplineExplain.VinaDataSource = "HRDisciplines";
            this.fld_mmeHRDisciplineExplain.VinaPropertyName = "EditValue";
            // 
            // DMDC100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.fld_mmeHRDisciplineExplain);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_lkeHRDisciplineStatus);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_lkeHRDisciplineOption);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.fld_lkeHRDisciplineType);
            this.Controls.Add(this.fld_dteHRDisciplineFromDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_lkeFK_HREmployeeRequest);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.fld_txtHRDisciplineNumber);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fld_txtHRDisciplineValue);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.fld_txtHRDisciplineName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRDisciplineDesc);
            this.Controls.Add(this.fld_txtHRDisciplineNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMDC100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeDisciplines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRDisciplineDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRDisciplineNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeRequest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRDisciplineFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRDisciplineFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRDisciplineType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRDisciplineOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRDisciplineStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mmeHRDisciplineExplain.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeDisciplinesGridControl fld_dgcHREmployeeDisciplines;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRDisciplineNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRDisciplineDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRDisciplineName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaTextBox fld_txtHRDisciplineValue;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private VinaTextBox fld_txtHRDisciplineNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private VinaLookupEdit fld_lkeFK_HREmployeeRequest;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private VinaDateEdit fld_dteHRDisciplineFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private VinaLookupEdit fld_lkeHRDisciplineType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaLookupEdit fld_lkeHRDisciplineOption;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaLookupEdit fld_lkeHRDisciplineStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mmeHRDisciplineExplain;
    }
}