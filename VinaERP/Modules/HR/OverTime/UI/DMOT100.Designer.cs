using VinaLib.BaseProvider;

namespace VinaERP.Modules.OverTime.UI
{
    partial class DMOT100
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
            this.fld_dgcHREmployeeOTs = new VinaERP.Modules.OverTime.HREmployeeOTsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHROverTimeNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHROverTimeDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHROverTimeName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHROverTimeDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHROverTimeStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_dteHROverTimeDateEnd1 = new VinaLib.BaseProvider.VinaDateEdit();
            this.fld_ceHROverTimeHaveMeal = new VinaLib.BaseProvider.VinaCheckBox();
            this.fld_lkeFK_ADWorkingShiftID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHROverTimeFactor = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHROverTimeFromDate = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_txtHROverTimeToDate = new VinaLib.BaseProvider.VinaTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeOTs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHROverTimeDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHROverTimeStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHROverTimeDateEnd1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHROverTimeDateEnd1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ceHROverTimeHaveMeal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ADWorkingShiftID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeFactor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeToDate.Properties)).BeginInit();
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
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeOTs);
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
            // fld_dgcHREmployeeOTs
            // 
            this.fld_dgcHREmployeeOTs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeOTs.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeOTs.MainView = this.gridView1;
            this.fld_dgcHREmployeeOTs.Name = "fld_dgcHREmployeeOTs";
            this.fld_dgcHREmployeeOTs.Screen = null;
            this.fld_dgcHREmployeeOTs.Size = new System.Drawing.Size(1049, 330);
            this.fld_dgcHREmployeeOTs.TabIndex = 16;
            this.fld_dgcHREmployeeOTs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeOTs.VinaDataMember = null;
            this.fld_dgcHREmployeeOTs.VinaDataSource = "HREmployeeOTs";
            this.fld_dgcHREmployeeOTs.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeOTs;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã danh sách";
            // 
            // fld_txtHROverTimeNo
            // 
            this.fld_txtHROverTimeNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHROverTimeNo.Name = "fld_txtHROverTimeNo";
            this.fld_txtHROverTimeNo.Screen = null;
            this.fld_txtHROverTimeNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHROverTimeNo.TabIndex = 0;
            this.fld_txtHROverTimeNo.Tag = "DC";
            this.fld_txtHROverTimeNo.VinaDataMember = "HROverTimeNo";
            this.fld_txtHROverTimeNo.VinaDataSource = "HROverTimes";
            this.fld_txtHROverTimeNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHROverTimeDesc
            // 
            this.fld_mneHROverTimeDesc.Location = new System.Drawing.Point(442, 89);
            this.fld_mneHROverTimeDesc.Name = "fld_mneHROverTimeDesc";
            this.fld_mneHROverTimeDesc.Screen = null;
            this.fld_mneHROverTimeDesc.Size = new System.Drawing.Size(199, 44);
            this.fld_mneHROverTimeDesc.TabIndex = 3;
            this.fld_mneHROverTimeDesc.Tag = "DC";
            this.fld_mneHROverTimeDesc.VinaDataMember = "HROverTimeDesc";
            this.fld_mneHROverTimeDesc.VinaDataSource = "HROverTimes";
            this.fld_mneHROverTimeDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(345, 90);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Mô tả";
            // 
            // fld_txtHROverTimeName
            // 
            this.fld_txtHROverTimeName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHROverTimeName.Name = "fld_txtHROverTimeName";
            this.fld_txtHROverTimeName.Screen = null;
            this.fld_txtHROverTimeName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHROverTimeName.TabIndex = 63;
            this.fld_txtHROverTimeName.Tag = "DC";
            this.fld_txtHROverTimeName.VinaDataMember = "HROverTimeName";
            this.fld_txtHROverTimeName.VinaDataSource = "HROverTimes";
            this.fld_txtHROverTimeName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên danh sách";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(345, 39);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(47, 13);
            this.labelControl10.TabIndex = 71;
            this.labelControl10.Text = "Đến ngày";
            // 
            // fld_txtHROverTimeDate
            // 
            this.fld_txtHROverTimeDate.EditValue = null;
            this.fld_txtHROverTimeDate.Location = new System.Drawing.Point(116, 36);
            this.fld_txtHROverTimeDate.Name = "fld_txtHROverTimeDate";
            this.fld_txtHROverTimeDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_txtHROverTimeDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_txtHROverTimeDate.Screen = null;
            this.fld_txtHROverTimeDate.Size = new System.Drawing.Size(119, 20);
            this.fld_txtHROverTimeDate.TabIndex = 74;
            this.fld_txtHROverTimeDate.Tag = "DC";
            this.fld_txtHROverTimeDate.VinaDataMember = "HROverTimeDate";
            this.fld_txtHROverTimeDate.VinaDataSource = "HROverTimes";
            this.fld_txtHROverTimeDate.VinaPropertyName = "EditValue";
            this.fld_txtHROverTimeDate.Validated += new System.EventHandler(this.fld_txtHROverTimeFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 39);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Từ ngày";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 116);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "Tình trạng";
            // 
            // fld_lkeHROverTimeStatus
            // 
            this.fld_lkeHROverTimeStatus.Location = new System.Drawing.Point(116, 113);
            this.fld_lkeHROverTimeStatus.Name = "fld_lkeHROverTimeStatus";
            this.fld_lkeHROverTimeStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHROverTimeStatus.Properties.ReadOnly = true;
            this.fld_lkeHROverTimeStatus.Screen = null;
            this.fld_lkeHROverTimeStatus.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHROverTimeStatus.TabIndex = 84;
            this.fld_lkeHROverTimeStatus.Tag = "DC";
            this.fld_lkeHROverTimeStatus.VinaAllowDummy = true;
            this.fld_lkeHROverTimeStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHROverTimeStatus.VinaDataMember = "HROverTimeStatus";
            this.fld_lkeHROverTimeStatus.VinaDataSource = "HROverTimes";
            this.fld_lkeHROverTimeStatus.VinaPropertyName = "EditValue";
            // 
            // fld_dteHROverTimeDateEnd1
            // 
            this.fld_dteHROverTimeDateEnd1.EditValue = null;
            this.fld_dteHROverTimeDateEnd1.Location = new System.Drawing.Point(442, 36);
            this.fld_dteHROverTimeDateEnd1.Name = "fld_dteHROverTimeDateEnd1";
            this.fld_dteHROverTimeDateEnd1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHROverTimeDateEnd1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHROverTimeDateEnd1.Screen = null;
            this.fld_dteHROverTimeDateEnd1.Size = new System.Drawing.Size(119, 20);
            this.fld_dteHROverTimeDateEnd1.TabIndex = 87;
            this.fld_dteHROverTimeDateEnd1.Tag = "DC";
            this.fld_dteHROverTimeDateEnd1.VinaDataMember = "HROverTimeDateEnd";
            this.fld_dteHROverTimeDateEnd1.VinaDataSource = "HROverTimes";
            this.fld_dteHROverTimeDateEnd1.VinaPropertyName = "EditValue";
            this.fld_dteHROverTimeDateEnd1.Validated += new System.EventHandler(this.fld_dteHROverTimeDateEnd_Validated);
            // 
            // fld_ceHROverTimeHaveMeal
            // 
            this.fld_ceHROverTimeHaveMeal.Location = new System.Drawing.Point(442, 64);
            this.fld_ceHROverTimeHaveMeal.Name = "fld_ceHROverTimeHaveMeal";
            this.fld_ceHROverTimeHaveMeal.Properties.Caption = "Có cơm";
            this.fld_ceHROverTimeHaveMeal.Screen = null;
            this.fld_ceHROverTimeHaveMeal.Size = new System.Drawing.Size(124, 19);
            this.fld_ceHROverTimeHaveMeal.TabIndex = 89;
            this.fld_ceHROverTimeHaveMeal.Tag = "DC";
            this.fld_ceHROverTimeHaveMeal.VinaDataMember = "HROverTimeHaveMeal";
            this.fld_ceHROverTimeHaveMeal.VinaDataSource = "HROverTimes";
            this.fld_ceHROverTimeHaveMeal.VinaPropertyName = "EditValue";
            // 
            // fld_lkeFK_ADWorkingShiftID
            // 
            this.fld_lkeFK_ADWorkingShiftID.Location = new System.Drawing.Point(116, 87);
            this.fld_lkeFK_ADWorkingShiftID.Name = "fld_lkeFK_ADWorkingShiftID";
            this.fld_lkeFK_ADWorkingShiftID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_ADWorkingShiftID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADWorkingShiftName", "Ca làm việc")});
            this.fld_lkeFK_ADWorkingShiftID.Properties.DisplayMember = "ADWorkingShiftName";
            this.fld_lkeFK_ADWorkingShiftID.Properties.ValueMember = "ADWorkingShiftID";
            this.fld_lkeFK_ADWorkingShiftID.Screen = null;
            this.fld_lkeFK_ADWorkingShiftID.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeFK_ADWorkingShiftID.TabIndex = 91;
            this.fld_lkeFK_ADWorkingShiftID.Tag = "DC";
            this.fld_lkeFK_ADWorkingShiftID.VinaAllowDummy = true;
            this.fld_lkeFK_ADWorkingShiftID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeFK_ADWorkingShiftID.VinaDataMember = "FK_ADWorkingShiftID";
            this.fld_lkeFK_ADWorkingShiftID.VinaDataSource = "HROverTimes";
            this.fld_lkeFK_ADWorkingShiftID.VinaPropertyName = "EditValue";
            this.fld_lkeFK_ADWorkingShiftID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.fld_lkeFK_ADWorkingShiftID_CloseUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 90;
            this.labelControl2.Text = "Ca làm việc";
            // 
            // fld_txtHROverTimeFactor
            // 
            this.fld_txtHROverTimeFactor.Location = new System.Drawing.Point(116, 62);
            this.fld_txtHROverTimeFactor.Name = "fld_txtHROverTimeFactor";
            this.fld_txtHROverTimeFactor.Screen = null;
            this.fld_txtHROverTimeFactor.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHROverTimeFactor.TabIndex = 92;
            this.fld_txtHROverTimeFactor.Tag = "DC";
            this.fld_txtHROverTimeFactor.VinaDataMember = "HROverTimeFactor";
            this.fld_txtHROverTimeFactor.VinaDataSource = "HROverTimes";
            this.fld_txtHROverTimeFactor.VinaPropertyName = "EditValue";
            this.fld_txtHROverTimeFactor.Validated += new System.EventHandler(this.fld_txtHROverTimeFactor_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 13);
            this.labelControl3.TabIndex = 93;
            this.labelControl3.Text = "Hệ số giờ công";
            // 
            // fld_txtHROverTimeFromDate
            // 
            this.fld_txtHROverTimeFromDate.Location = new System.Drawing.Point(241, 36);
            this.fld_txtHROverTimeFromDate.Name = "fld_txtHROverTimeFromDate";
            this.fld_txtHROverTimeFromDate.Properties.DisplayFormat.FormatString = "HH:mm";
            this.fld_txtHROverTimeFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_txtHROverTimeFromDate.Properties.EditFormat.FormatString = "HH:mm";
            this.fld_txtHROverTimeFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_txtHROverTimeFromDate.Screen = null;
            this.fld_txtHROverTimeFromDate.Size = new System.Drawing.Size(74, 20);
            this.fld_txtHROverTimeFromDate.TabIndex = 94;
            this.fld_txtHROverTimeFromDate.Tag = "DC";
            this.fld_txtHROverTimeFromDate.VinaDataMember = "HROverTimeFromDate";
            this.fld_txtHROverTimeFromDate.VinaDataSource = "HROverTimes";
            this.fld_txtHROverTimeFromDate.VinaPropertyName = "EditValue";
            this.fld_txtHROverTimeFromDate.Validated += new System.EventHandler(this.vinaTextBox2_Validated);
            // 
            // fld_txtHROverTimeToDate
            // 
            this.fld_txtHROverTimeToDate.Location = new System.Drawing.Point(567, 36);
            this.fld_txtHROverTimeToDate.Name = "fld_txtHROverTimeToDate";
            this.fld_txtHROverTimeToDate.Screen = null;
            this.fld_txtHROverTimeToDate.Size = new System.Drawing.Size(74, 20);
            this.fld_txtHROverTimeToDate.TabIndex = 95;
            this.fld_txtHROverTimeToDate.Tag = "DC";
            this.fld_txtHROverTimeToDate.VinaDataMember = "HROverTimeToDate";
            this.fld_txtHROverTimeToDate.VinaDataSource = "HROverTimes";
            this.fld_txtHROverTimeToDate.VinaPropertyName = "EditValue";
            this.fld_txtHROverTimeToDate.Validated += new System.EventHandler(this.fld_txtHROverTimeToDate_Validated);
            // 
            // DMOT100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.fld_txtHROverTimeToDate);
            this.Controls.Add(this.fld_txtHROverTimeFromDate);
            this.Controls.Add(this.fld_txtHROverTimeFactor);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_lkeFK_ADWorkingShiftID);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fld_ceHROverTimeHaveMeal);
            this.Controls.Add(this.fld_dteHROverTimeDateEnd1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_lkeHROverTimeStatus);
            this.Controls.Add(this.fld_txtHROverTimeDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.fld_txtHROverTimeName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHROverTimeDesc);
            this.Controls.Add(this.fld_txtHROverTimeNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMOT100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeOTs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHROverTimeDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHROverTimeStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHROverTimeDateEnd1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHROverTimeDateEnd1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ceHROverTimeHaveMeal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ADWorkingShiftID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeFactor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHROverTimeToDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeOTsGridControl fld_dgcHREmployeeOTs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHROverTimeNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHROverTimeDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHROverTimeName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private VinaDateEdit fld_txtHROverTimeDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaLookupEdit fld_lkeHROverTimeStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private VinaDateEdit fld_dteHROverTimeDateEnd1;
        private VinaCheckBox fld_ceHROverTimeHaveMeal;
        private VinaLookupEdit fld_lkeFK_ADWorkingShiftID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private VinaTextBox fld_txtHROverTimeFactor;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaTextBox fld_txtHROverTimeFromDate;
        private VinaTextBox fld_txtHROverTimeToDate;
    }
}