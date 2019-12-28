namespace VinaERP.Modules.ManagerTimeKeeper
{
    partial class guiQuickImportTimeSheet
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
            this.fld_dgcHREmployees = new VinaERP.Modules.ManagerTimeKeeper.HREmployeesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.fld_lkeFK_BRBranchID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_lkeFK_HRDepartmentID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.fld_lkeFK_HRDepartmentRoomGroupItemID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.fld_lkeFK_HRDepartmentRoomID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.fld_dgcHRTimeKeepers2 = new VinaERP.Modules.ManagerTimeKeeper.HRTimeKeeperGridControl2();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label22 = new System.Windows.Forms.Label();
            this.fld_lkeFK_HREmployeePayrollFormulaID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_txtTimeFromDate = new VinaLib.BaseProvider.VinaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fld_txtTimeToDate = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_dteToDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteDateFrom = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRTimeKeepers2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeePayrollFormulaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtTimeFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtTimeToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcHREmployees
            // 
            this.fld_dgcHREmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployees.Location = new System.Drawing.Point(12, 111);
            this.fld_dgcHREmployees.MainView = this.gridView1;
            this.fld_dgcHREmployees.Name = "fld_dgcHREmployees";
            this.fld_dgcHREmployees.Screen = null;
            this.fld_dgcHREmployees.Size = new System.Drawing.Size(428, 308);
            this.fld_dgcHREmployees.TabIndex = 17;
            this.fld_dgcHREmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployees.VinaDataMember = null;
            this.fld_dgcHREmployees.VinaDataSource = "HREmployees";
            this.fld_dgcHREmployees.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployees;
            this.gridView1.Name = "gridView1";
            // 
            // fld_btnSearch
            // 
            this.fld_btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnSearch.Location = new System.Drawing.Point(312, 64);
            this.fld_btnSearch.Name = "fld_btnSearch";
            this.fld_btnSearch.Size = new System.Drawing.Size(75, 25);
            this.fld_btnSearch.TabIndex = 19;
            this.fld_btnSearch.Text = "Tìm kiếm";
            this.fld_btnSearch.Click += new System.EventHandler(this.fld_btnSearch_Click);
            // 
            // fld_btnCancel
            // 
            this.fld_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnCancel.Location = new System.Drawing.Point(800, 431);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.fld_btnCancel.TabIndex = 19;
            this.fld_btnCancel.Text = "Thoát";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // fld_btnOK
            // 
            this.fld_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnOK.Location = new System.Drawing.Point(704, 431);
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Size = new System.Drawing.Size(75, 25);
            this.fld_btnOK.TabIndex = 19;
            this.fld_btnOK.Text = "Thực hiện";
            this.fld_btnOK.Click += new System.EventHandler(this.fld_btnOK_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Chi nhánh";
            // 
            // fld_lkeFK_BRBranchID
            // 
            this.fld_lkeFK_BRBranchID.Location = new System.Drawing.Point(119, 11);
            this.fld_lkeFK_BRBranchID.Name = "fld_lkeFK_BRBranchID";
            this.fld_lkeFK_BRBranchID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_BRBranchID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BRBranchName", "Chi nhánh")});
            this.fld_lkeFK_BRBranchID.Properties.DisplayMember = "BRBranchName";
            this.fld_lkeFK_BRBranchID.Properties.ValueMember = "BRBranchID";
            this.fld_lkeFK_BRBranchID.Screen = null;
            this.fld_lkeFK_BRBranchID.Size = new System.Drawing.Size(123, 20);
            this.fld_lkeFK_BRBranchID.TabIndex = 24;
            this.fld_lkeFK_BRBranchID.Tag = "DC";
            this.fld_lkeFK_BRBranchID.VinaAllowDummy = true;
            this.fld_lkeFK_BRBranchID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_BRBranchID.VinaDataMember = "FK_BRBranchID";
            this.fld_lkeFK_BRBranchID.VinaDataSource = "HREmployees";
            this.fld_lkeFK_BRBranchID.VinaPropertyName = "EditValue";
            // 
            // fld_lkeFK_HRDepartmentID
            // 
            this.fld_lkeFK_HRDepartmentID.Location = new System.Drawing.Point(312, 12);
            this.fld_lkeFK_HRDepartmentID.Name = "fld_lkeFK_HRDepartmentID";
            this.fld_lkeFK_HRDepartmentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã phòng ban"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên phòng ban")});
            this.fld_lkeFK_HRDepartmentID.Properties.DisplayMember = "HRDepartmentName";
            this.fld_lkeFK_HRDepartmentID.Properties.ValueMember = "HRDepartmentID";
            this.fld_lkeFK_HRDepartmentID.Screen = null;
            this.fld_lkeFK_HRDepartmentID.Size = new System.Drawing.Size(128, 20);
            this.fld_lkeFK_HRDepartmentID.TabIndex = 117;
            this.fld_lkeFK_HRDepartmentID.Tag = "DC";
            this.fld_lkeFK_HRDepartmentID.VinaAllowDummy = true;
            this.fld_lkeFK_HRDepartmentID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HRDepartmentID.VinaDataMember = "FK_HRDepartmentID";
            this.fld_lkeFK_HRDepartmentID.VinaDataSource = "HREmployees";
            this.fld_lkeFK_HRDepartmentID.VinaPropertyName = "EditValue";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(248, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(19, 13);
            this.label28.TabIndex = 116;
            this.label28.Text = "Tổ";
            // 
            // fld_lkeFK_HRDepartmentRoomGroupItemID
            // 
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Location = new System.Drawing.Point(312, 38);
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Name = "fld_lkeFK_HRDepartmentRoomGroupItemID";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentRoomGroupItemName", "Tổ")});
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.DisplayMember = "HRDepartmentRoomGroupItemName";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.ValueMember = "HRDepartmentRoomGroupItemID";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Screen = null;
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Size = new System.Drawing.Size(128, 20);
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.TabIndex = 110;
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Tag = "DC";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.VinaAllowDummy = true;
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.VinaDataMember = "FK_HRDepartmentRoomGroupItemID";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.VinaDataSource = "HREmployees";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.VinaPropertyName = "EditValue";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 113;
            this.label21.Text = "Bộ phận";
            // 
            // fld_lkeFK_HRDepartmentRoomID
            // 
            this.fld_lkeFK_HRDepartmentRoomID.Location = new System.Drawing.Point(119, 37);
            this.fld_lkeFK_HRDepartmentRoomID.Name = "fld_lkeFK_HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentRoomID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentRoomName", "Bộ phận")});
            this.fld_lkeFK_HRDepartmentRoomID.Properties.DisplayMember = "HRDepartmentRoomName";
            this.fld_lkeFK_HRDepartmentRoomID.Properties.ValueMember = "HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.Screen = null;
            this.fld_lkeFK_HRDepartmentRoomID.Size = new System.Drawing.Size(123, 20);
            this.fld_lkeFK_HRDepartmentRoomID.TabIndex = 109;
            this.fld_lkeFK_HRDepartmentRoomID.Tag = "DC";
            this.fld_lkeFK_HRDepartmentRoomID.VinaAllowDummy = true;
            this.fld_lkeFK_HRDepartmentRoomID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HRDepartmentRoomID.VinaDataMember = "FK_HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.VinaDataSource = "HREmployees";
            this.fld_lkeFK_HRDepartmentRoomID.VinaPropertyName = "EditValue";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(248, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 112;
            this.label20.Text = "Phòng ban";
            // 
            // fld_dgcHRTimeKeepers2
            // 
            this.fld_dgcHRTimeKeepers2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHRTimeKeepers2.Location = new System.Drawing.Point(447, 111);
            this.fld_dgcHRTimeKeepers2.MainView = this.gridView2;
            this.fld_dgcHRTimeKeepers2.Name = "fld_dgcHRTimeKeepers2";
            this.fld_dgcHRTimeKeepers2.Screen = null;
            this.fld_dgcHRTimeKeepers2.Size = new System.Drawing.Size(428, 308);
            this.fld_dgcHRTimeKeepers2.TabIndex = 118;
            this.fld_dgcHRTimeKeepers2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.fld_dgcHRTimeKeepers2.VinaDataMember = null;
            this.fld_dgcHRTimeKeepers2.VinaDataSource = "HRTimeKeepers";
            this.fld_dgcHRTimeKeepers2.VinaPropertyName = null;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcHRTimeKeepers2;
            this.gridView2.Name = "gridView2";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 13);
            this.label22.TabIndex = 114;
            this.label22.Text = "Nhóm chấm công";
            // 
            // fld_lkeFK_HREmployeePayrollFormulaID
            // 
            this.fld_lkeFK_HREmployeePayrollFormulaID.Location = new System.Drawing.Point(119, 63);
            this.fld_lkeFK_HREmployeePayrollFormulaID.Name = "fld_lkeFK_HREmployeePayrollFormulaID";
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeePayrollFormulaName", "Nhóm chấm công", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.False)});
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.DisplayMember = "HREmployeePayrollFormulaName";
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.ValueMember = "HREmployeePayrollFormulaID";
            this.fld_lkeFK_HREmployeePayrollFormulaID.Screen = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.Size = new System.Drawing.Size(123, 20);
            this.fld_lkeFK_HREmployeePayrollFormulaID.TabIndex = 111;
            this.fld_lkeFK_HREmployeePayrollFormulaID.Tag = "DC";
            this.fld_lkeFK_HREmployeePayrollFormulaID.VinaAllowDummy = true;
            this.fld_lkeFK_HREmployeePayrollFormulaID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_HREmployeePayrollFormulaID.VinaDataMember = "FK_HREmployeePayrollFormulaID";
            this.fld_lkeFK_HREmployeePayrollFormulaID.VinaDataSource = "HREmployees";
            this.fld_lkeFK_HREmployeePayrollFormulaID.VinaPropertyName = "EditValue";
            // 
            // fld_txtTimeFromDate
            // 
            this.fld_txtTimeFromDate.EditValue = "00:00:00";
            this.fld_txtTimeFromDate.Location = new System.Drawing.Point(535, 34);
            this.fld_txtTimeFromDate.Name = "fld_txtTimeFromDate";
            this.fld_txtTimeFromDate.Properties.DisplayFormat.FormatString = "HH:mm";
            this.fld_txtTimeFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_txtTimeFromDate.Properties.EditFormat.FormatString = "HH:mm";
            this.fld_txtTimeFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_txtTimeFromDate.Screen = null;
            this.fld_txtTimeFromDate.Size = new System.Drawing.Size(96, 20);
            this.fld_txtTimeFromDate.TabIndex = 119;
            this.fld_txtTimeFromDate.Tag = "DC";
            this.fld_txtTimeFromDate.VinaDataMember = "";
            this.fld_txtTimeFromDate.VinaDataSource = "";
            this.fld_txtTimeFromDate.VinaPropertyName = "EditValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "Giờ vào";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "Giờ ra";
            // 
            // fld_txtTimeToDate
            // 
            this.fld_txtTimeToDate.EditValue = "00:00:00";
            this.fld_txtTimeToDate.Location = new System.Drawing.Point(734, 34);
            this.fld_txtTimeToDate.Name = "fld_txtTimeToDate";
            this.fld_txtTimeToDate.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.fld_txtTimeToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_txtTimeToDate.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.fld_txtTimeToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_txtTimeToDate.Screen = null;
            this.fld_txtTimeToDate.Size = new System.Drawing.Size(94, 20);
            this.fld_txtTimeToDate.TabIndex = 121;
            this.fld_txtTimeToDate.Tag = "DC";
            this.fld_txtTimeToDate.VinaDataMember = "";
            this.fld_txtTimeToDate.VinaDataSource = "";
            this.fld_txtTimeToDate.VinaPropertyName = "EditValue";
            // 
            // fld_dteToDate
            // 
            this.fld_dteToDate.EditValue = null;
            this.fld_dteToDate.Location = new System.Drawing.Point(734, 11);
            this.fld_dteToDate.Name = "fld_dteToDate";
            this.fld_dteToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteToDate.Screen = null;
            this.fld_dteToDate.Size = new System.Drawing.Size(94, 20);
            this.fld_dteToDate.TabIndex = 140;
            this.fld_dteToDate.Tag = "DC";
            this.fld_dteToDate.VinaDataMember = "HRDisciplineFromDate";
            this.fld_dteToDate.VinaDataSource = "HRDisciplines";
            this.fld_dteToDate.VinaPropertyName = "EditValue";
            this.fld_dteToDate.EditValueChanged += new System.EventHandler(this.fld_dteToDate_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(674, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 139;
            this.labelControl1.Text = "Đến ngày";
            // 
            // fld_dteDateFrom
            // 
            this.fld_dteDateFrom.EditValue = null;
            this.fld_dteDateFrom.Location = new System.Drawing.Point(535, 12);
            this.fld_dteDateFrom.Name = "fld_dteDateFrom";
            this.fld_dteDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteDateFrom.Screen = null;
            this.fld_dteDateFrom.Size = new System.Drawing.Size(96, 20);
            this.fld_dteDateFrom.TabIndex = 138;
            this.fld_dteDateFrom.Tag = "DC";
            this.fld_dteDateFrom.VinaDataMember = "HRDisciplineFromDate";
            this.fld_dteDateFrom.VinaDataSource = "HRDisciplines";
            this.fld_dteDateFrom.VinaPropertyName = "EditValue";
            this.fld_dteDateFrom.EditValueChanged += new System.EventHandler(this.fld_dteDateFrom_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(465, 14);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 137;
            this.labelControl9.Text = "Từ ngày";
            // 
            // guiQuickImportTimeSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 468);
            this.Controls.Add(this.fld_dteToDate);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_dteDateFrom);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fld_txtTimeToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fld_txtTimeFromDate);
            this.Controls.Add(this.fld_dgcHRTimeKeepers2);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentID);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentRoomGroupItemID);
            this.Controls.Add(this.fld_lkeFK_HREmployeePayrollFormulaID);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentRoomID);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.fld_lkeFK_BRBranchID);
            this.Controls.Add(this.fld_btnOK);
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnSearch);
            this.Controls.Add(this.fld_dgcHREmployees);
            this.Name = "guiQuickImportTimeSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.guiChooseSaleOrderItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRTimeKeepers2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeePayrollFormulaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtTimeFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtTimeToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HREmployeesGridControl fld_dgcHREmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton fld_btnSearch;
        private DevExpress.XtraEditors.SimpleButton fld_btnCancel;
        private DevExpress.XtraEditors.SimpleButton fld_btnOK;
        private System.Windows.Forms.Label label11;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeFK_BRBranchID;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeFK_HRDepartmentID;
        private System.Windows.Forms.Label label28;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeFK_HRDepartmentRoomGroupItemID;
        private System.Windows.Forms.Label label21;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeFK_HRDepartmentRoomID;
        private System.Windows.Forms.Label label20;
        private HRTimeKeeperGridControl2 fld_dgcHRTimeKeepers2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label22;
        private VinaLib.BaseProvider.VinaLookupEdit fld_lkeFK_HREmployeePayrollFormulaID;
        private VinaLib.BaseProvider.VinaTextBox fld_txtTimeFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private VinaLib.BaseProvider.VinaTextBox fld_txtTimeToDate;
        private VinaLib.BaseProvider.VinaDateEdit fld_dteToDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaLib.BaseProvider.VinaDateEdit fld_dteDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}