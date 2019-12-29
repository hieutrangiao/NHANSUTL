using VinaLib.BaseProvider;

namespace VinaERP.Modules.ManagerTimeKeeper.UI
{
    partial class DMMT100
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
            this.fld_dgcHRTimeKeeperCompletes = new VinaERP.Modules.ManagerTimeKeeper.HRTimeKeeperCompletesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_lkeFK_HRDepartmentID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.fld_lkeFK_HRDepartmentRoomGroupItemID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.fld_lkeFK_HRDepartmentRoomID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.fld_lkeFK_BRBranchID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.fld_lkeHREmployeeID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_dteDateFrom = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteToDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vinaTextBox5 = new VinaLib.BaseProvider.VinaTextBox();
            this.vinaTextBox4 = new VinaLib.BaseProvider.VinaTextBox();
            this.vinaTextBox3 = new VinaLib.BaseProvider.VinaTextBox();
            this.vinaTextBox2 = new VinaLib.BaseProvider.VinaTextBox();
            this.vinaTextBox1 = new VinaLib.BaseProvider.VinaTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRTimeKeeperCompletes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHREmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 116);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(1202, 442);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHRTimeKeeperCompletes);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(1196, 414);
            this.fld_lkeFK_ICProductID.Text = "Thông tin";
            // 
            // fld_dgcHRTimeKeeperCompletes
            // 
            this.fld_dgcHRTimeKeeperCompletes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcHRTimeKeeperCompletes.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcHRTimeKeeperCompletes.MainView = this.gridView1;
            this.fld_dgcHRTimeKeeperCompletes.Name = "fld_dgcHRTimeKeeperCompletes";
            this.fld_dgcHRTimeKeeperCompletes.Screen = null;
            this.fld_dgcHRTimeKeeperCompletes.Size = new System.Drawing.Size(1196, 414);
            this.fld_dgcHRTimeKeeperCompletes.TabIndex = 16;
            this.fld_dgcHRTimeKeeperCompletes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHRTimeKeeperCompletes.VinaDataMember = null;
            this.fld_dgcHRTimeKeeperCompletes.VinaDataSource = "HRTimeKeeperCompletes";
            this.fld_dgcHRTimeKeeperCompletes.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHRTimeKeeperCompletes;
            this.gridView1.Name = "gridView1";
            // 
            // fld_lkeFK_HRDepartmentID
            // 
            this.fld_lkeFK_HRDepartmentID.Location = new System.Drawing.Point(335, 38);
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
            this.fld_lkeFK_HRDepartmentID.TabIndex = 129;
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
            this.label28.Location = new System.Drawing.Point(255, 65);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(19, 13);
            this.label28.TabIndex = 128;
            this.label28.Text = "Tổ";
            // 
            // fld_lkeFK_HRDepartmentRoomGroupItemID
            // 
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Location = new System.Drawing.Point(335, 64);
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Name = "fld_lkeFK_HRDepartmentRoomGroupItemID";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentRoomGroupItemName", "Tổ")});
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.DisplayMember = "HRDepartmentRoomGroupItemName";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties.ValueMember = "HRDepartmentRoomGroupItemID";
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Screen = null;
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.Size = new System.Drawing.Size(128, 20);
            this.fld_lkeFK_HRDepartmentRoomGroupItemID.TabIndex = 122;
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
            this.label21.Location = new System.Drawing.Point(32, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 125;
            this.label21.Text = "Bộ phận";
            // 
            // fld_lkeFK_HRDepartmentRoomID
            // 
            this.fld_lkeFK_HRDepartmentRoomID.Location = new System.Drawing.Point(99, 64);
            this.fld_lkeFK_HRDepartmentRoomID.Name = "fld_lkeFK_HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentRoomID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentRoomName", "Bộ phận")});
            this.fld_lkeFK_HRDepartmentRoomID.Properties.DisplayMember = "HRDepartmentRoomName";
            this.fld_lkeFK_HRDepartmentRoomID.Properties.ValueMember = "HRDepartmentRoomID";
            this.fld_lkeFK_HRDepartmentRoomID.Screen = null;
            this.fld_lkeFK_HRDepartmentRoomID.Size = new System.Drawing.Size(123, 20);
            this.fld_lkeFK_HRDepartmentRoomID.TabIndex = 121;
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
            this.label20.Location = new System.Drawing.Point(255, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 124;
            this.label20.Text = "Phòng ban";
            // 
            // fld_lkeFK_BRBranchID
            // 
            this.fld_lkeFK_BRBranchID.Location = new System.Drawing.Point(99, 38);
            this.fld_lkeFK_BRBranchID.Name = "fld_lkeFK_BRBranchID";
            this.fld_lkeFK_BRBranchID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_BRBranchID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BRBranchName", "Chi nhánh")});
            this.fld_lkeFK_BRBranchID.Properties.DisplayMember = "BRBranchName";
            this.fld_lkeFK_BRBranchID.Properties.ValueMember = "BRBranchID";
            this.fld_lkeFK_BRBranchID.Screen = null;
            this.fld_lkeFK_BRBranchID.Size = new System.Drawing.Size(123, 20);
            this.fld_lkeFK_BRBranchID.TabIndex = 118;
            this.fld_lkeFK_BRBranchID.Tag = "DC";
            this.fld_lkeFK_BRBranchID.VinaAllowDummy = true;
            this.fld_lkeFK_BRBranchID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_BRBranchID.VinaDataMember = "FK_BRBranchID";
            this.fld_lkeFK_BRBranchID.VinaDataSource = "HREmployees";
            this.fld_lkeFK_BRBranchID.VinaPropertyName = "EditValue";
            // 
            // fld_btnSearch
            // 
            this.fld_btnSearch.Location = new System.Drawing.Point(504, 15);
            this.fld_btnSearch.Name = "fld_btnSearch";
            this.fld_btnSearch.Size = new System.Drawing.Size(146, 25);
            this.fld_btnSearch.TabIndex = 130;
            this.fld_btnSearch.Text = "Xem chấm công gốc";
            this.fld_btnSearch.Click += new System.EventHandler(this.fld_btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Nhân viên";
            // 
            // fld_lkeHREmployeeID
            // 
            this.fld_lkeHREmployeeID.Location = new System.Drawing.Point(99, 90);
            this.fld_lkeHREmployeeID.Name = "fld_lkeHREmployeeID";
            this.fld_lkeHREmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHREmployeeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên")});
            this.fld_lkeHREmployeeID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeHREmployeeID.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeHREmployeeID.Screen = null;
            this.fld_lkeHREmployeeID.Size = new System.Drawing.Size(123, 20);
            this.fld_lkeHREmployeeID.TabIndex = 131;
            this.fld_lkeHREmployeeID.Tag = "DC";
            this.fld_lkeHREmployeeID.VinaAllowDummy = true;
            this.fld_lkeHREmployeeID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHREmployeeID.VinaDataMember = "HREmployeeID";
            this.fld_lkeHREmployeeID.VinaDataSource = "HREmployees";
            this.fld_lkeHREmployeeID.VinaPropertyName = "EditValue";
            // 
            // fld_dteDateFrom
            // 
            this.fld_dteDateFrom.EditValue = null;
            this.fld_dteDateFrom.Location = new System.Drawing.Point(99, 12);
            this.fld_dteDateFrom.Name = "fld_dteDateFrom";
            this.fld_dteDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteDateFrom.Screen = null;
            this.fld_dteDateFrom.Size = new System.Drawing.Size(123, 20);
            this.fld_dteDateFrom.TabIndex = 134;
            this.fld_dteDateFrom.Tag = "DC";
            this.fld_dteDateFrom.VinaDataMember = "HRDisciplineFromDate";
            this.fld_dteDateFrom.VinaDataSource = "HRDisciplines";
            this.fld_dteDateFrom.VinaPropertyName = "EditValue";
            this.fld_dteDateFrom.Validated += new System.EventHandler(this.fld_dteDateFrom_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(32, 15);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 133;
            this.labelControl9.Text = "Từ ngày";
            // 
            // fld_dteToDate
            // 
            this.fld_dteToDate.EditValue = null;
            this.fld_dteToDate.Location = new System.Drawing.Point(335, 12);
            this.fld_dteToDate.Name = "fld_dteToDate";
            this.fld_dteToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteToDate.Screen = null;
            this.fld_dteToDate.Size = new System.Drawing.Size(128, 20);
            this.fld_dteToDate.TabIndex = 136;
            this.fld_dteToDate.Tag = "DC";
            this.fld_dteToDate.VinaDataMember = "HRDisciplineFromDate";
            this.fld_dteToDate.VinaDataSource = "HRDisciplines";
            this.fld_dteToDate.VinaPropertyName = "EditValue";
            this.fld_dteToDate.Validated += new System.EventHandler(this.fld_dteToDate_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(255, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 135;
            this.labelControl1.Text = "Đến ngày";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(504, 46);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(146, 25);
            this.simpleButton1.TabIndex = 137;
            this.simpleButton1.Text = "Lưu giờ công";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 138;
            this.labelControl2.Text = "Chi nhánh";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.vinaTextBox5);
            this.groupBox1.Controls.Add(this.vinaTextBox4);
            this.groupBox1.Controls.Add(this.vinaTextBox3);
            this.groupBox1.Controls.Add(this.vinaTextBox2);
            this.groupBox1.Controls.Add(this.vinaTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(684, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 101);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ghi chú";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Về sớm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 132;
            this.label5.Text = "Chấm công không khai báo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Thiếu giờ ra hoặc giờ vào";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Đi trễ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 129;
            this.label2.Text = "Giờ ra trùng giờ vào";
            // 
            // vinaTextBox5
            // 
            this.vinaTextBox5.Location = new System.Drawing.Point(205, 47);
            this.vinaTextBox5.Name = "vinaTextBox5";
            this.vinaTextBox5.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.vinaTextBox5.Properties.Appearance.Options.UseBackColor = true;
            this.vinaTextBox5.Properties.ReadOnly = true;
            this.vinaTextBox5.Screen = null;
            this.vinaTextBox5.Size = new System.Drawing.Size(66, 20);
            this.vinaTextBox5.TabIndex = 4;
            this.vinaTextBox5.VinaDataMember = null;
            this.vinaTextBox5.VinaDataSource = null;
            this.vinaTextBox5.VinaPropertyName = null;
            // 
            // vinaTextBox4
            // 
            this.vinaTextBox4.Location = new System.Drawing.Point(205, 23);
            this.vinaTextBox4.Name = "vinaTextBox4";
            this.vinaTextBox4.Properties.Appearance.BackColor = System.Drawing.Color.Blue;
            this.vinaTextBox4.Properties.Appearance.Options.UseBackColor = true;
            this.vinaTextBox4.Properties.ReadOnly = true;
            this.vinaTextBox4.Screen = null;
            this.vinaTextBox4.Size = new System.Drawing.Size(66, 20);
            this.vinaTextBox4.TabIndex = 3;
            this.vinaTextBox4.VinaDataMember = null;
            this.vinaTextBox4.VinaDataSource = null;
            this.vinaTextBox4.VinaPropertyName = null;
            // 
            // vinaTextBox3
            // 
            this.vinaTextBox3.Location = new System.Drawing.Point(7, 71);
            this.vinaTextBox3.Name = "vinaTextBox3";
            this.vinaTextBox3.Properties.Appearance.BackColor = System.Drawing.Color.Pink;
            this.vinaTextBox3.Properties.Appearance.Options.UseBackColor = true;
            this.vinaTextBox3.Properties.ReadOnly = true;
            this.vinaTextBox3.Screen = null;
            this.vinaTextBox3.Size = new System.Drawing.Size(66, 20);
            this.vinaTextBox3.TabIndex = 2;
            this.vinaTextBox3.VinaDataMember = null;
            this.vinaTextBox3.VinaDataSource = null;
            this.vinaTextBox3.VinaPropertyName = null;
            // 
            // vinaTextBox2
            // 
            this.vinaTextBox2.Location = new System.Drawing.Point(7, 47);
            this.vinaTextBox2.Name = "vinaTextBox2";
            this.vinaTextBox2.Properties.Appearance.BackColor = System.Drawing.Color.Orange;
            this.vinaTextBox2.Properties.Appearance.Options.UseBackColor = true;
            this.vinaTextBox2.Properties.ReadOnly = true;
            this.vinaTextBox2.Screen = null;
            this.vinaTextBox2.Size = new System.Drawing.Size(66, 20);
            this.vinaTextBox2.TabIndex = 1;
            this.vinaTextBox2.VinaDataMember = null;
            this.vinaTextBox2.VinaDataSource = null;
            this.vinaTextBox2.VinaPropertyName = null;
            // 
            // vinaTextBox1
            // 
            this.vinaTextBox1.Location = new System.Drawing.Point(7, 21);
            this.vinaTextBox1.Name = "vinaTextBox1";
            this.vinaTextBox1.Properties.Appearance.BackColor = System.Drawing.Color.Violet;
            this.vinaTextBox1.Properties.Appearance.Options.UseBackColor = true;
            this.vinaTextBox1.Properties.ReadOnly = true;
            this.vinaTextBox1.Screen = null;
            this.vinaTextBox1.Size = new System.Drawing.Size(66, 20);
            this.vinaTextBox1.TabIndex = 0;
            this.vinaTextBox1.VinaDataMember = null;
            this.vinaTextBox1.VinaDataSource = null;
            this.vinaTextBox1.VinaPropertyName = null;
            // 
            // DMMT100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.fld_dteToDate);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_dteDateFrom);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fld_lkeHREmployeeID);
            this.Controls.Add(this.fld_btnSearch);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentID);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentRoomGroupItemID);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentRoomID);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.fld_lkeFK_BRBranchID);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "DMMT100";
            this.Tag = "DC";
            this.Text = "Xác định giờ công";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRTimeKeeperCompletes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomGroupItemID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentRoomID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_BRBranchID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHREmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinaTextBox1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HRTimeKeeperCompletesGridControl fld_dgcHRTimeKeeperCompletes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private VinaLookupEdit fld_lkeFK_HRDepartmentID;
        private System.Windows.Forms.Label label28;
        private VinaLookupEdit fld_lkeFK_HRDepartmentRoomGroupItemID;
        private System.Windows.Forms.Label label21;
        private VinaLookupEdit fld_lkeFK_HRDepartmentRoomID;
        private System.Windows.Forms.Label label20;
        private VinaLookupEdit fld_lkeFK_BRBranchID;
        private DevExpress.XtraEditors.SimpleButton fld_btnSearch;
        private System.Windows.Forms.Label label1;
        private VinaLookupEdit fld_lkeHREmployeeID;
        private VinaDateEdit fld_dteDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private VinaDateEdit fld_dteToDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private VinaTextBox vinaTextBox5;
        private VinaTextBox vinaTextBox4;
        private VinaTextBox vinaTextBox3;
        private VinaTextBox vinaTextBox2;
        private VinaTextBox vinaTextBox1;
    }
}