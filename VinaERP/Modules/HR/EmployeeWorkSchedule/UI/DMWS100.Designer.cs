using VinaLib.BaseProvider;

namespace VinaERP.Modules.EmployeeWorkSchedule.UI
{
    partial class DMWS100
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
            this.fld_dgcHREmployeeWorkScheduleItems = new VinaERP.Modules.EmployeeWorkSchedule.HREmployeeWorkScheduleItemsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHREmployeeWorkScheduleNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHREmployeeWorkScheduleDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHREmployeeWorkScheduleName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHREmployeeWorkScheduleFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHREmployeeWorkScheduleStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            this.fld_dteHREmployeeWorkScheduleDateFrom = new VinaLib.BaseProvider.VinaDateEdit();
            this.fld_dteHREmployeeWorkScheduleDateTo = new VinaLib.BaseProvider.VinaDateEdit();
            this.fld_dteHREmployeeWorkScheduleToDate = new VinaLib.BaseProvider.VinaDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeWorkScheduleItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeWorkScheduleNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHREmployeeWorkScheduleDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeWorkScheduleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHREmployeeWorkScheduleStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleToDate.Properties)).BeginInit();
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
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeWorkScheduleItems);
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
            // fld_dgcHREmployeeWorkScheduleItems
            // 
            this.fld_dgcHREmployeeWorkScheduleItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeWorkScheduleItems.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeWorkScheduleItems.MainView = this.gridView1;
            this.fld_dgcHREmployeeWorkScheduleItems.Name = "fld_dgcHREmployeeWorkScheduleItems";
            this.fld_dgcHREmployeeWorkScheduleItems.Screen = null;
            this.fld_dgcHREmployeeWorkScheduleItems.Size = new System.Drawing.Size(1049, 330);
            this.fld_dgcHREmployeeWorkScheduleItems.TabIndex = 16;
            this.fld_dgcHREmployeeWorkScheduleItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeWorkScheduleItems.VinaDataMember = null;
            this.fld_dgcHREmployeeWorkScheduleItems.VinaDataSource = "HREmployeeWorkScheduleItems";
            this.fld_dgcHREmployeeWorkScheduleItems.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeWorkScheduleItems;
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
            // fld_txtHREmployeeWorkScheduleNo
            // 
            this.fld_txtHREmployeeWorkScheduleNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHREmployeeWorkScheduleNo.Name = "fld_txtHREmployeeWorkScheduleNo";
            this.fld_txtHREmployeeWorkScheduleNo.Screen = null;
            this.fld_txtHREmployeeWorkScheduleNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHREmployeeWorkScheduleNo.TabIndex = 0;
            this.fld_txtHREmployeeWorkScheduleNo.Tag = "DC";
            this.fld_txtHREmployeeWorkScheduleNo.VinaDataMember = "HREmployeeWorkScheduleNo";
            this.fld_txtHREmployeeWorkScheduleNo.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_txtHREmployeeWorkScheduleNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHREmployeeWorkScheduleDesc
            // 
            this.fld_mneHREmployeeWorkScheduleDesc.Location = new System.Drawing.Point(116, 88);
            this.fld_mneHREmployeeWorkScheduleDesc.Name = "fld_mneHREmployeeWorkScheduleDesc";
            this.fld_mneHREmployeeWorkScheduleDesc.Screen = null;
            this.fld_mneHREmployeeWorkScheduleDesc.Size = new System.Drawing.Size(525, 33);
            this.fld_mneHREmployeeWorkScheduleDesc.TabIndex = 3;
            this.fld_mneHREmployeeWorkScheduleDesc.Tag = "DC";
            this.fld_mneHREmployeeWorkScheduleDesc.VinaDataMember = "HREmployeeWorkScheduleDesc";
            this.fld_mneHREmployeeWorkScheduleDesc.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_mneHREmployeeWorkScheduleDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 90);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Mô tả";
            // 
            // fld_txtHREmployeeWorkScheduleName
            // 
            this.fld_txtHREmployeeWorkScheduleName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHREmployeeWorkScheduleName.Name = "fld_txtHREmployeeWorkScheduleName";
            this.fld_txtHREmployeeWorkScheduleName.Screen = null;
            this.fld_txtHREmployeeWorkScheduleName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHREmployeeWorkScheduleName.TabIndex = 63;
            this.fld_txtHREmployeeWorkScheduleName.Tag = "DC";
            this.fld_txtHREmployeeWorkScheduleName.VinaDataMember = "HREmployeeWorkScheduleName";
            this.fld_txtHREmployeeWorkScheduleName.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_txtHREmployeeWorkScheduleName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên lịch công tác";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(345, 39);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(20, 13);
            this.labelControl10.TabIndex = 71;
            this.labelControl10.Text = "Đến";
            // 
            // fld_dteHREmployeeWorkScheduleFromDate
            // 
            this.fld_dteHREmployeeWorkScheduleFromDate.EditValue = null;
            this.fld_dteHREmployeeWorkScheduleFromDate.Location = new System.Drawing.Point(116, 36);
            this.fld_dteHREmployeeWorkScheduleFromDate.Name = "fld_dteHREmployeeWorkScheduleFromDate";
            this.fld_dteHREmployeeWorkScheduleFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleFromDate.Screen = null;
            this.fld_dteHREmployeeWorkScheduleFromDate.Size = new System.Drawing.Size(119, 20);
            this.fld_dteHREmployeeWorkScheduleFromDate.TabIndex = 74;
            this.fld_dteHREmployeeWorkScheduleFromDate.Tag = "DC";
            this.fld_dteHREmployeeWorkScheduleFromDate.VinaDataMember = "HREmployeeWorkScheduleFromDate";
            this.fld_dteHREmployeeWorkScheduleFromDate.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_dteHREmployeeWorkScheduleFromDate.VinaPropertyName = "EditValue";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 39);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(83, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Ngày công tác từ";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 65);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "Tình trạng";
            // 
            // fld_lkeHREmployeeWorkScheduleStatus
            // 
            this.fld_lkeHREmployeeWorkScheduleStatus.Location = new System.Drawing.Point(116, 62);
            this.fld_lkeHREmployeeWorkScheduleStatus.Name = "fld_lkeHREmployeeWorkScheduleStatus";
            this.fld_lkeHREmployeeWorkScheduleStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHREmployeeWorkScheduleStatus.Properties.ReadOnly = true;
            this.fld_lkeHREmployeeWorkScheduleStatus.Screen = null;
            this.fld_lkeHREmployeeWorkScheduleStatus.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHREmployeeWorkScheduleStatus.TabIndex = 84;
            this.fld_lkeHREmployeeWorkScheduleStatus.Tag = "DC";
            this.fld_lkeHREmployeeWorkScheduleStatus.VinaAllowDummy = true;
            this.fld_lkeHREmployeeWorkScheduleStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHREmployeeWorkScheduleStatus.VinaDataMember = "HREmployeeWorkScheduleStatus";
            this.fld_lkeHREmployeeWorkScheduleStatus.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_lkeHREmployeeWorkScheduleStatus.VinaPropertyName = "EditValue";
            // 
            // fld_dteHREmployeeWorkScheduleDateFrom
            // 
            this.fld_dteHREmployeeWorkScheduleDateFrom.EditValue = null;
            this.fld_dteHREmployeeWorkScheduleDateFrom.Location = new System.Drawing.Point(241, 36);
            this.fld_dteHREmployeeWorkScheduleDateFrom.Name = "fld_dteHREmployeeWorkScheduleDateFrom";
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.DisplayFormat.FormatString = "HH:mm";
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.EditFormat.FormatString = "HH:mm";
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.Mask.EditMask = "HH:mm";
            this.fld_dteHREmployeeWorkScheduleDateFrom.Screen = null;
            this.fld_dteHREmployeeWorkScheduleDateFrom.Size = new System.Drawing.Size(74, 20);
            this.fld_dteHREmployeeWorkScheduleDateFrom.TabIndex = 86;
            this.fld_dteHREmployeeWorkScheduleDateFrom.Tag = "DC";
            this.fld_dteHREmployeeWorkScheduleDateFrom.VinaDataMember = "HREmployeeWorkScheduleDateFrom";
            this.fld_dteHREmployeeWorkScheduleDateFrom.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_dteHREmployeeWorkScheduleDateFrom.VinaPropertyName = "EditValue";
            // 
            // fld_dteHREmployeeWorkScheduleDateTo
            // 
            this.fld_dteHREmployeeWorkScheduleDateTo.EditValue = null;
            this.fld_dteHREmployeeWorkScheduleDateTo.Location = new System.Drawing.Point(567, 36);
            this.fld_dteHREmployeeWorkScheduleDateTo.Name = "fld_dteHREmployeeWorkScheduleDateTo";
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.DisplayFormat.FormatString = "HH:mm";
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.EditFormat.FormatString = "HH:mm";
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHREmployeeWorkScheduleDateTo.Properties.Mask.EditMask = "HH:mm";
            this.fld_dteHREmployeeWorkScheduleDateTo.Screen = null;
            this.fld_dteHREmployeeWorkScheduleDateTo.Size = new System.Drawing.Size(74, 20);
            this.fld_dteHREmployeeWorkScheduleDateTo.TabIndex = 88;
            this.fld_dteHREmployeeWorkScheduleDateTo.Tag = "DC";
            this.fld_dteHREmployeeWorkScheduleDateTo.VinaDataMember = "HREmployeeWorkScheduleDateTo";
            this.fld_dteHREmployeeWorkScheduleDateTo.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_dteHREmployeeWorkScheduleDateTo.VinaPropertyName = "EditValue";
            // 
            // fld_dteHREmployeeWorkScheduleToDate
            // 
            this.fld_dteHREmployeeWorkScheduleToDate.EditValue = null;
            this.fld_dteHREmployeeWorkScheduleToDate.Location = new System.Drawing.Point(442, 36);
            this.fld_dteHREmployeeWorkScheduleToDate.Name = "fld_dteHREmployeeWorkScheduleToDate";
            this.fld_dteHREmployeeWorkScheduleToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeWorkScheduleToDate.Screen = null;
            this.fld_dteHREmployeeWorkScheduleToDate.Size = new System.Drawing.Size(119, 20);
            this.fld_dteHREmployeeWorkScheduleToDate.TabIndex = 87;
            this.fld_dteHREmployeeWorkScheduleToDate.Tag = "DC";
            this.fld_dteHREmployeeWorkScheduleToDate.VinaDataMember = "HREmployeeWorkScheduleToDate";
            this.fld_dteHREmployeeWorkScheduleToDate.VinaDataSource = "HREmployeeWorkSchedules";
            this.fld_dteHREmployeeWorkScheduleToDate.VinaPropertyName = "EditValue";
            // 
            // DMWS100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.fld_dteHREmployeeWorkScheduleDateTo);
            this.Controls.Add(this.fld_dteHREmployeeWorkScheduleToDate);
            this.Controls.Add(this.fld_dteHREmployeeWorkScheduleDateFrom);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_lkeHREmployeeWorkScheduleStatus);
            this.Controls.Add(this.fld_dteHREmployeeWorkScheduleFromDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.fld_txtHREmployeeWorkScheduleName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHREmployeeWorkScheduleDesc);
            this.Controls.Add(this.fld_txtHREmployeeWorkScheduleNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMWS100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeWorkScheduleItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeWorkScheduleNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHREmployeeWorkScheduleDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeWorkScheduleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHREmployeeWorkScheduleStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeWorkScheduleToDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeWorkScheduleItemsGridControl fld_dgcHREmployeeWorkScheduleItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHREmployeeWorkScheduleNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHREmployeeWorkScheduleDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHREmployeeWorkScheduleName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private VinaDateEdit fld_dteHREmployeeWorkScheduleFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaLookupEdit fld_lkeHREmployeeWorkScheduleStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private VinaDateEdit fld_dteHREmployeeWorkScheduleDateFrom;
        private VinaDateEdit fld_dteHREmployeeWorkScheduleDateTo;
        private VinaDateEdit fld_dteHREmployeeWorkScheduleToDate;
    }
}