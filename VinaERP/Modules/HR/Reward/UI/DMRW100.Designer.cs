using VinaLib.BaseProvider;

namespace VinaERP.Modules.Reward.UI
{
    partial class DMRW100
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
            this.fld_dgcHREmployeeRewards = new VinaERP.Modules.Reward.HREmployeeRewardsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRRewardNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRRewardDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRRewardName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRRewardValue = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRRewardDecisionNumber = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeFK_HREmployeeRequest = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRRewardFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRRewardType = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRRewardOption = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRRewardStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeRewards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRRewardDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardDecisionNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeRequest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRRewardFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRRewardFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRRewardType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRRewardOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRRewardStatus.Properties)).BeginInit();
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
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeRewards);
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
            // fld_dgcHREmployeeRewards
            // 
            this.fld_dgcHREmployeeRewards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeRewards.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeRewards.MainView = this.gridView1;
            this.fld_dgcHREmployeeRewards.Name = "fld_dgcHREmployeeRewards";
            this.fld_dgcHREmployeeRewards.Screen = null;
            this.fld_dgcHREmployeeRewards.Size = new System.Drawing.Size(1049, 330);
            this.fld_dgcHREmployeeRewards.TabIndex = 16;
            this.fld_dgcHREmployeeRewards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeRewards.VinaDataMember = null;
            this.fld_dgcHREmployeeRewards.VinaDataSource = "HREmployeeRewards";
            this.fld_dgcHREmployeeRewards.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeRewards;
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
            // fld_txtHRRewardNo
            // 
            this.fld_txtHRRewardNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRRewardNo.Name = "fld_txtHRRewardNo";
            this.fld_txtHRRewardNo.Screen = null;
            this.fld_txtHRRewardNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRRewardNo.TabIndex = 0;
            this.fld_txtHRRewardNo.Tag = "DC";
            this.fld_txtHRRewardNo.VinaDataMember = "HRRewardNo";
            this.fld_txtHRRewardNo.VinaDataSource = "HRRewards";
            this.fld_txtHRRewardNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRRewardDesc
            // 
            this.fld_mneHRRewardDesc.Location = new System.Drawing.Point(116, 116);
            this.fld_mneHRRewardDesc.Name = "fld_mneHRRewardDesc";
            this.fld_mneHRRewardDesc.Screen = null;
            this.fld_mneHRRewardDesc.Size = new System.Drawing.Size(199, 33);
            this.fld_mneHRRewardDesc.TabIndex = 3;
            this.fld_mneHRRewardDesc.Tag = "DC";
            this.fld_mneHRRewardDesc.VinaDataMember = "HRRewardDesc";
            this.fld_mneHRRewardDesc.VinaDataSource = "HRRewards";
            this.fld_mneHRRewardDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 117);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // fld_txtHRRewardName
            // 
            this.fld_txtHRRewardName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRRewardName.Name = "fld_txtHRRewardName";
            this.fld_txtHRRewardName.Screen = null;
            this.fld_txtHRRewardName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRRewardName.TabIndex = 63;
            this.fld_txtHRRewardName.Tag = "DC";
            this.fld_txtHRRewardName.VinaDataMember = "HRRewardName";
            this.fld_txtHRRewardName.VinaDataSource = "HRRewards";
            this.fld_txtHRRewardName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(26, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Lý do";
            // 
            // fld_txtHRRewardValue
            // 
            this.fld_txtHRRewardValue.Location = new System.Drawing.Point(442, 88);
            this.fld_txtHRRewardValue.Name = "fld_txtHRRewardValue";
            this.fld_txtHRRewardValue.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRRewardValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRRewardValue.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRRewardValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRRewardValue.Screen = null;
            this.fld_txtHRRewardValue.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRRewardValue.TabIndex = 67;
            this.fld_txtHRRewardValue.Tag = "DC";
            this.fld_txtHRRewardValue.VinaDataMember = "HRRewardValue";
            this.fld_txtHRRewardValue.VinaDataSource = "HRRewards";
            this.fld_txtHRRewardValue.VinaPropertyName = "EditValue";
            this.fld_txtHRRewardValue.Validated += new System.EventHandler(this.fld_txtHRRewardValue_Validated);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(345, 91);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 68;
            this.labelControl6.Text = "Số tiền";
            // 
            // fld_txtHRRewardDecisionNumber
            // 
            this.fld_txtHRRewardDecisionNumber.Location = new System.Drawing.Point(116, 36);
            this.fld_txtHRRewardDecisionNumber.Name = "fld_txtHRRewardDecisionNumber";
            this.fld_txtHRRewardDecisionNumber.Screen = null;
            this.fld_txtHRRewardDecisionNumber.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRRewardDecisionNumber.TabIndex = 69;
            this.fld_txtHRRewardDecisionNumber.Tag = "DC";
            this.fld_txtHRRewardDecisionNumber.VinaDataMember = "HRRewardDecisionNumber";
            this.fld_txtHRRewardDecisionNumber.VinaDataSource = "HRRewards";
            this.fld_txtHRRewardDecisionNumber.VinaPropertyName = "EditValue";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 70;
            this.labelControl2.Text = "Số biên bản";
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
            this.fld_lkeFK_HREmployeeRequest.VinaDataSource = "HRRewards";
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
            // fld_dteHRRewardFromDate
            // 
            this.fld_dteHRRewardFromDate.EditValue = null;
            this.fld_dteHRRewardFromDate.Location = new System.Drawing.Point(116, 62);
            this.fld_dteHRRewardFromDate.Name = "fld_dteHRRewardFromDate";
            this.fld_dteHRRewardFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRRewardFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRRewardFromDate.Screen = null;
            this.fld_dteHRRewardFromDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRRewardFromDate.TabIndex = 74;
            this.fld_dteHRRewardFromDate.Tag = "DC";
            this.fld_dteHRRewardFromDate.VinaDataMember = "HRRewardFromDate";
            this.fld_dteHRRewardFromDate.VinaDataSource = "HRRewards";
            this.fld_dteHRRewardFromDate.VinaPropertyName = "EditValue";
            this.fld_dteHRRewardFromDate.Validated += new System.EventHandler(this.fld_dteHRRewardFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 65);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(67, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Ngày áp dụng";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(345, 65);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(46, 13);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "Hình thức";
            // 
            // fld_lkeHRRewardType
            // 
            this.fld_lkeHRRewardType.Location = new System.Drawing.Point(442, 62);
            this.fld_lkeHRRewardType.Name = "fld_lkeHRRewardType";
            this.fld_lkeHRRewardType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRRewardType.Screen = null;
            this.fld_lkeHRRewardType.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRRewardType.TabIndex = 80;
            this.fld_lkeHRRewardType.Tag = "DC";
            this.fld_lkeHRRewardType.VinaAllowDummy = true;
            this.fld_lkeHRRewardType.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRRewardType.VinaDataMember = "HRRewardType";
            this.fld_lkeHRRewardType.VinaDataSource = "HRRewards";
            this.fld_lkeHRRewardType.VinaPropertyName = "EditValue";
            this.fld_lkeHRRewardType.Validated += new System.EventHandler(this.fld_txtHRRewardType_Validated);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 83;
            this.labelControl3.Text = "Loại chứng từ";
            // 
            // fld_lkeHRRewardOption
            // 
            this.fld_lkeHRRewardOption.Location = new System.Drawing.Point(116, 88);
            this.fld_lkeHRRewardOption.Name = "fld_lkeHRRewardOption";
            this.fld_lkeHRRewardOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRRewardOption.Screen = null;
            this.fld_lkeHRRewardOption.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRRewardOption.TabIndex = 82;
            this.fld_lkeHRRewardOption.Tag = "DC";
            this.fld_lkeHRRewardOption.VinaAllowDummy = true;
            this.fld_lkeHRRewardOption.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRRewardOption.VinaDataMember = "HRRewardOption";
            this.fld_lkeHRRewardOption.VinaDataSource = "HRRewards";
            this.fld_lkeHRRewardOption.VinaPropertyName = "EditValue";
            this.fld_lkeHRRewardOption.Validated += new System.EventHandler(this.fld_lkeHRRewardOption_Validated);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(345, 117);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "Tình trạng";
            // 
            // fld_lkeHRRewardStatus
            // 
            this.fld_lkeHRRewardStatus.Location = new System.Drawing.Point(442, 114);
            this.fld_lkeHRRewardStatus.Name = "fld_lkeHRRewardStatus";
            this.fld_lkeHRRewardStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRRewardStatus.Properties.ReadOnly = true;
            this.fld_lkeHRRewardStatus.Screen = null;
            this.fld_lkeHRRewardStatus.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRRewardStatus.TabIndex = 84;
            this.fld_lkeHRRewardStatus.Tag = "DC";
            this.fld_lkeHRRewardStatus.VinaAllowDummy = true;
            this.fld_lkeHRRewardStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRRewardStatus.VinaDataMember = "HRRewardStatus";
            this.fld_lkeHRRewardStatus.VinaDataSource = "HRRewards";
            this.fld_lkeHRRewardStatus.VinaPropertyName = "EditValue";
            // 
            // DMRW100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_lkeHRRewardStatus);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fld_lkeHRRewardOption);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.fld_lkeHRRewardType);
            this.Controls.Add(this.fld_dteHRRewardFromDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_lkeFK_HREmployeeRequest);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.fld_txtHRRewardDecisionNumber);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fld_txtHRRewardValue);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.fld_txtHRRewardName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRRewardDesc);
            this.Controls.Add(this.fld_txtHRRewardNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMRW100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeRewards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRRewardDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRRewardDecisionNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeRequest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRRewardFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRRewardFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRRewardType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRRewardOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRRewardStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeRewardsGridControl fld_dgcHREmployeeRewards;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRRewardNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRRewardDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRRewardName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaTextBox fld_txtHRRewardValue;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private VinaTextBox fld_txtHRRewardDecisionNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private VinaLookupEdit fld_lkeFK_HREmployeeRequest;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private VinaDateEdit fld_dteHRRewardFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private VinaLookupEdit fld_lkeHRRewardType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private VinaLookupEdit fld_lkeHRRewardOption;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaLookupEdit fld_lkeHRRewardStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
    }
}