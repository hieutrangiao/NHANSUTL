using BOSERP.Modules.PayRoll;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.PayRoll.UI
{
    partial class DMPR100
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
            this.fld_dgcHREmployeePayRolls = new BOSERP.Modules.PayRoll.HREmployeePayRollsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRPayRollNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRPayRollDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRPayRollName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRPayRollDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRPayRollType = new VinaLib.BaseProvider.VinaLookupEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRPayRollStatus = new VinaLib.BaseProvider.VinaLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeePayRolls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRPayRollNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRPayRollDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRPayRollName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRPayRollDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRPayRollDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRPayRollType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRPayRollStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 112);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(1055, 446);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.simpleButton9);
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeePayRolls);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(1049, 418);
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
            // fld_dgcHREmployeePayRolls
            // 
            this.fld_dgcHREmployeePayRolls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeePayRolls.GridViewMain = null;
            this.fld_dgcHREmployeePayRolls.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeePayRolls.MainView = this.gridView1;
            this.fld_dgcHREmployeePayRolls.Name = "fld_dgcHREmployeePayRolls";
            this.fld_dgcHREmployeePayRolls.Screen = null;
            this.fld_dgcHREmployeePayRolls.Size = new System.Drawing.Size(1049, 373);
            this.fld_dgcHREmployeePayRolls.TabIndex = 16;
            this.fld_dgcHREmployeePayRolls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeePayRolls.VinaDataMember = null;
            this.fld_dgcHREmployeePayRolls.VinaDataSource = "HREmployeePayRolls";
            this.fld_dgcHREmployeePayRolls.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeePayRolls;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Mã bảng lương";
            // 
            // fld_txtHRPayRollNo
            // 
            this.fld_txtHRPayRollNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRPayRollNo.Name = "fld_txtHRPayRollNo";
            this.fld_txtHRPayRollNo.Screen = null;
            this.fld_txtHRPayRollNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRPayRollNo.TabIndex = 0;
            this.fld_txtHRPayRollNo.Tag = "DC";
            this.fld_txtHRPayRollNo.VinaDataMember = "HRPayRollNo";
            this.fld_txtHRPayRollNo.VinaDataSource = "HRPayRolls";
            this.fld_txtHRPayRollNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRPayRollDesc
            // 
            this.fld_mneHRPayRollDesc.Location = new System.Drawing.Point(116, 62);
            this.fld_mneHRPayRollDesc.Name = "fld_mneHRPayRollDesc";
            this.fld_mneHRPayRollDesc.Screen = null;
            this.fld_mneHRPayRollDesc.Size = new System.Drawing.Size(846, 33);
            this.fld_mneHRPayRollDesc.TabIndex = 3;
            this.fld_mneHRPayRollDesc.Tag = "DC";
            this.fld_mneHRPayRollDesc.VinaDataMember = "HRPayRollDesc";
            this.fld_mneHRPayRollDesc.VinaDataSource = "HRPayRolls";
            this.fld_mneHRPayRollDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // fld_txtHRPayRollName
            // 
            this.fld_txtHRPayRollName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRPayRollName.Name = "fld_txtHRPayRollName";
            this.fld_txtHRPayRollName.Screen = null;
            this.fld_txtHRPayRollName.Size = new System.Drawing.Size(520, 20);
            this.fld_txtHRPayRollName.TabIndex = 63;
            this.fld_txtHRPayRollName.Tag = "DC";
            this.fld_txtHRPayRollName.VinaDataMember = "HRPayRollName";
            this.fld_txtHRPayRollName.VinaDataSource = "HRPayRolls";
            this.fld_txtHRPayRollName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên bảng lương";
            // 
            // fld_dteHRPayRollDate
            // 
            this.fld_dteHRPayRollDate.EditValue = null;
            this.fld_dteHRPayRollDate.Location = new System.Drawing.Point(116, 36);
            this.fld_dteHRPayRollDate.Name = "fld_dteHRPayRollDate";
            this.fld_dteHRPayRollDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRPayRollDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRPayRollDate.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.fld_dteHRPayRollDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHRPayRollDate.Properties.EditFormat.FormatString = "MM/yyyy";
            this.fld_dteHRPayRollDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteHRPayRollDate.Screen = null;
            this.fld_dteHRPayRollDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRPayRollDate.TabIndex = 74;
            this.fld_dteHRPayRollDate.Tag = "DC";
            this.fld_dteHRPayRollDate.VinaDataMember = "HRPayRollDate";
            this.fld_dteHRPayRollDate.VinaDataSource = "HRPayRolls";
            this.fld_dteHRPayRollDate.VinaPropertyName = "EditValue";
            this.fld_dteHRPayRollDate.Validated += new System.EventHandler(this.fld_dteHRRewardFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 39);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(30, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Tháng";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(345, 39);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(76, 13);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "Loại bảng lương";
            // 
            // fld_lkeHRPayRollType
            // 
            this.fld_lkeHRPayRollType.Location = new System.Drawing.Point(442, 36);
            this.fld_lkeHRPayRollType.Name = "fld_lkeHRPayRollType";
            this.fld_lkeHRPayRollType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRPayRollType.Screen = null;
            this.fld_lkeHRPayRollType.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRPayRollType.TabIndex = 80;
            this.fld_lkeHRPayRollType.Tag = "DC";
            this.fld_lkeHRPayRollType.VinaAllowDummy = true;
            this.fld_lkeHRPayRollType.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRPayRollType.VinaDataMember = "HRPayRollType";
            this.fld_lkeHRPayRollType.VinaDataSource = "HRPayRolls";
            this.fld_lkeHRPayRollType.VinaPropertyName = "EditValue";
            this.fld_lkeHRPayRollType.Validated += new System.EventHandler(this.fld_txtHRRewardType_Validated);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(666, 39);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "Tình trạng";
            // 
            // fld_lkeHRPayRollStatus
            // 
            this.fld_lkeHRPayRollStatus.Location = new System.Drawing.Point(763, 36);
            this.fld_lkeHRPayRollStatus.Name = "fld_lkeHRPayRollStatus";
            this.fld_lkeHRPayRollStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRPayRollStatus.Properties.ReadOnly = true;
            this.fld_lkeHRPayRollStatus.Screen = null;
            this.fld_lkeHRPayRollStatus.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRPayRollStatus.TabIndex = 84;
            this.fld_lkeHRPayRollStatus.Tag = "DC";
            this.fld_lkeHRPayRollStatus.VinaAllowDummy = true;
            this.fld_lkeHRPayRollStatus.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRPayRollStatus.VinaDataMember = "HRPayRollStatus";
            this.fld_lkeHRPayRollStatus.VinaDataSource = "HRPayRolls";
            this.fld_lkeHRPayRollStatus.VinaPropertyName = "EditValue";
            // 
            // DMPR100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.fld_lkeHRPayRollStatus);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.fld_lkeHRPayRollType);
            this.Controls.Add(this.fld_dteHRPayRollDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_txtHRPayRollName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRPayRollDesc);
            this.Controls.Add(this.fld_txtHRPayRollNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMPR100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeePayRolls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRPayRollNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRPayRollDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRPayRollName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRPayRollDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRPayRollDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRPayRollType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRPayRollStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeePayRollsGridControl fld_dgcHREmployeePayRolls;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRPayRollNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRPayRollDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRPayRollName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaDateEdit fld_dteHRPayRollDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private VinaLookupEdit fld_lkeHRPayRollType;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private VinaLookupEdit fld_lkeHRPayRollStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
    }
}