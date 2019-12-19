using BOSERP.Modules.TimeSheet;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.TimeSheet.UI
{
    partial class DMTS100
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
            this.fld_dgcHREmployeeTimeSheets = new BOSERP.Modules.TimeSheet.HREmployeeTimeSheetsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRTimeSheetNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRTimeSheetDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRTimeSheetName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRTimeSheetDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRTimeSheetType = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRTimeSheetStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_dteHRTimeSheetFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRTimeSheetToDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeTimeSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRTimeSheetNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRTimeSheetDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRTimeSheetName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRTimeSheetType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRTimeSheetStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetToDate.Properties)).BeginInit();
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
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeTimeSheets);
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
            // fld_dgcHREmployeeTimeSheets
            // 
            this.fld_dgcHREmployeeTimeSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeTimeSheets.GridViewMain = null;
            this.fld_dgcHREmployeeTimeSheets.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeTimeSheets.MainView = this.gridView1;
            this.fld_dgcHREmployeeTimeSheets.Name = "fld_dgcHREmployeeTimeSheets";
            this.fld_dgcHREmployeeTimeSheets.RowHandle = 0;
            this.fld_dgcHREmployeeTimeSheets.Screen = null;
            this.fld_dgcHREmployeeTimeSheets.Size = new System.Drawing.Size(1049, 330);
            this.fld_dgcHREmployeeTimeSheets.TabIndex = 16;
            this.fld_dgcHREmployeeTimeSheets.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeTimeSheets.VinaDataMember = null;
            this.fld_dgcHREmployeeTimeSheets.VinaDataSource = "HREmployeeTimeSheets";
            this.fld_dgcHREmployeeTimeSheets.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeTimeSheets;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã bảng công";
            // 
            // fld_txtHRTimeSheetNo
            // 
            this.fld_txtHRTimeSheetNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRTimeSheetNo.Name = "fld_txtHRTimeSheetNo";
            this.fld_txtHRTimeSheetNo.Screen = null;
            this.fld_txtHRTimeSheetNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRTimeSheetNo.TabIndex = 0;
            this.fld_txtHRTimeSheetNo.Tag = "DC";
            this.fld_txtHRTimeSheetNo.VinaDataMember = "HRTimeSheetNo";
            this.fld_txtHRTimeSheetNo.VinaDataSource = "HRTimeSheets";
            this.fld_txtHRTimeSheetNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRTimeSheetDesc
            // 
            this.fld_mneHRTimeSheetDesc.Location = new System.Drawing.Point(116, 116);
            this.fld_mneHRTimeSheetDesc.Name = "fld_mneHRTimeSheetDesc";
            this.fld_mneHRTimeSheetDesc.Screen = null;
            this.fld_mneHRTimeSheetDesc.Size = new System.Drawing.Size(525, 33);
            this.fld_mneHRTimeSheetDesc.TabIndex = 3;
            this.fld_mneHRTimeSheetDesc.Tag = "DC";
            this.fld_mneHRTimeSheetDesc.VinaDataMember = "HRTimeSheetDesc";
            this.fld_mneHRTimeSheetDesc.VinaDataSource = "HRTimeSheets";
            this.fld_mneHRTimeSheetDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 117);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Diễn giải";
            // 
            // fld_txtHRTimeSheetName
            // 
            this.fld_txtHRTimeSheetName.Location = new System.Drawing.Point(116, 36);
            this.fld_txtHRTimeSheetName.Name = "fld_txtHRTimeSheetName";
            this.fld_txtHRTimeSheetName.Screen = null;
            this.fld_txtHRTimeSheetName.Size = new System.Drawing.Size(525, 20);
            this.fld_txtHRTimeSheetName.TabIndex = 63;
            this.fld_txtHRTimeSheetName.Tag = "DC";
            this.fld_txtHRTimeSheetName.VinaDataMember = "HRTimeSheetName";
            this.fld_txtHRTimeSheetName.VinaDataSource = "HRTimeSheets";
            this.fld_txtHRTimeSheetName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên bảng công";
            // 
            // fld_dteHRTimeSheetDate
            // 
            this.fld_dteHRTimeSheetDate.EditValue = null;
            this.fld_dteHRTimeSheetDate.Location = new System.Drawing.Point(116, 62);
            this.fld_dteHRTimeSheetDate.Name = "fld_dteHRTimeSheetDate";
            this.fld_dteHRTimeSheetDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRTimeSheetDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRTimeSheetDate.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.fld_dteHRTimeSheetDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHRTimeSheetDate.Properties.EditFormat.FormatString = "MM/yyyy";
            this.fld_dteHRTimeSheetDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHRTimeSheetDate.Screen = null;
            this.fld_dteHRTimeSheetDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRTimeSheetDate.TabIndex = 74;
            this.fld_dteHRTimeSheetDate.Tag = "DC";
            this.fld_dteHRTimeSheetDate.VinaDataMember = "HRTimeSheetDate";
            this.fld_dteHRTimeSheetDate.VinaDataSource = "HRTimeSheets";
            this.fld_dteHRTimeSheetDate.VinaPropertyName = "EditValue";
            this.fld_dteHRTimeSheetDate.Validated += new System.EventHandler(this.fld_dteHRRewardFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 65);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(30, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Tháng";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(345, 15);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(72, 13);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "Loại bảng công";
            // 
            // fld_lkeHRTimeSheetType
            // 
            this.fld_lkeHRTimeSheetType.Location = new System.Drawing.Point(442, 12);
            this.fld_lkeHRTimeSheetType.Name = "fld_lkeHRTimeSheetType";
            this.fld_lkeHRTimeSheetType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRTimeSheetType.Screen = null;
            this.fld_lkeHRTimeSheetType.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRTimeSheetType.TabIndex = 80;
            this.fld_lkeHRTimeSheetType.Tag = "DC";
            this.fld_lkeHRTimeSheetType.VinaAllowDummy = true;
            this.fld_lkeHRTimeSheetType.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRTimeSheetType.VinaDataMember = "HRTimeSheetType";
            this.fld_lkeHRTimeSheetType.VinaDataSource = "HRTimeSheets";
            this.fld_lkeHRTimeSheetType.VinaPropertyName = "EditValue";
            this.fld_lkeHRTimeSheetType.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.fld_lkeHRTimeSheetType_CloseUp);
            this.fld_lkeHRTimeSheetType.Validated += new System.EventHandler(this.fld_txtHRRewardType_Validated);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(345, 65);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "Tình trạng";
            // 
            // fld_lkeHRTimeSheetStatus
            // 
            this.fld_lkeHRTimeSheetStatus.Location = new System.Drawing.Point(442, 62);
            this.fld_lkeHRTimeSheetStatus.Name = "fld_lkeHRTimeSheetStatus";
            this.fld_lkeHRTimeSheetStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRTimeSheetStatus.Properties.ReadOnly = true;
            this.fld_lkeHRTimeSheetStatus.Screen = null;
            this.fld_lkeHRTimeSheetStatus.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRTimeSheetStatus.TabIndex = 84;
            this.fld_lkeHRTimeSheetStatus.Tag = "DC";
            this.fld_lkeHRTimeSheetStatus.VinaAllowDummy = true;
            this.fld_lkeHRTimeSheetStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRTimeSheetStatus.VinaDataMember = "HRTimeSheetStatus";
            this.fld_lkeHRTimeSheetStatus.VinaDataSource = "HRTimeSheets";
            this.fld_lkeHRTimeSheetStatus.VinaPropertyName = "EditValue";
            // 
            // fld_dteHRTimeSheetFromDate
            // 
            this.fld_dteHRTimeSheetFromDate.EditValue = null;
            this.fld_dteHRTimeSheetFromDate.Location = new System.Drawing.Point(116, 88);
            this.fld_dteHRTimeSheetFromDate.Name = "fld_dteHRTimeSheetFromDate";
            this.fld_dteHRTimeSheetFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRTimeSheetFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRTimeSheetFromDate.Screen = null;
            this.fld_dteHRTimeSheetFromDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRTimeSheetFromDate.TabIndex = 87;
            this.fld_dteHRTimeSheetFromDate.Tag = "DC";
            this.fld_dteHRTimeSheetFromDate.VinaDataMember = "HRTimeSheetFromDate";
            this.fld_dteHRTimeSheetFromDate.VinaDataSource = "HRTimeSheets";
            this.fld_dteHRTimeSheetFromDate.VinaPropertyName = "EditValue";
            this.fld_dteHRTimeSheetFromDate.Validated += new System.EventHandler(this.fld_dteHRTimeSheetFromDate_Validated);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 91);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 86;
            this.labelControl2.Text = "Từ ngày";
            // 
            // fld_dteHRTimeSheetToDate
            // 
            this.fld_dteHRTimeSheetToDate.EditValue = null;
            this.fld_dteHRTimeSheetToDate.Location = new System.Drawing.Point(442, 88);
            this.fld_dteHRTimeSheetToDate.Name = "fld_dteHRTimeSheetToDate";
            this.fld_dteHRTimeSheetToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRTimeSheetToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRTimeSheetToDate.Screen = null;
            this.fld_dteHRTimeSheetToDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRTimeSheetToDate.TabIndex = 89;
            this.fld_dteHRTimeSheetToDate.Tag = "DC";
            this.fld_dteHRTimeSheetToDate.VinaDataMember = "HRTimeSheetToDate";
            this.fld_dteHRTimeSheetToDate.VinaDataSource = "HRTimeSheets";
            this.fld_dteHRTimeSheetToDate.VinaPropertyName = "EditValue";
            this.fld_dteHRTimeSheetToDate.Validated += new System.EventHandler(this.fld_dteHRTimeSheetToDate_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(345, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 88;
            this.labelControl3.Text = "Đến ngày";
            // 
            // DMTS100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.fld_dteHRTimeSheetToDate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_dteHRTimeSheetFromDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_lkeHRTimeSheetStatus);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.fld_lkeHRTimeSheetType);
            this.Controls.Add(this.fld_dteHRTimeSheetDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_txtHRTimeSheetName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRTimeSheetDesc);
            this.Controls.Add(this.fld_txtHRTimeSheetNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMTS100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeTimeSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRTimeSheetNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRTimeSheetDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRTimeSheetName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRTimeSheetType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRTimeSheetStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRTimeSheetToDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeTimeSheetsGridControl fld_dgcHREmployeeTimeSheets;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRTimeSheetNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRTimeSheetDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRTimeSheetName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaDateEdit fld_dteHRTimeSheetDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private VinaLookupEdit fld_lkeHRTimeSheetType;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaLookupEdit fld_lkeHRTimeSheetStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private VinaDateEdit fld_dteHRTimeSheetFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private VinaDateEdit fld_dteHRTimeSheetToDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}