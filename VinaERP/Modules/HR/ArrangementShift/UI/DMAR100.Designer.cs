using BOSERP.Modules.ArrangementShift;
using VinaLib.BaseProvider;

namespace VinaERP.Modules.ArrangementShift.UI
{
    partial class DMAR100
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
            this.fld_dgcHREmployeeArrangementShifts = new BOSERP.Modules.ArrangementShift.HREmployeeArrangementShiftsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRArrangementShiftNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRArrangementShiftDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRArrangementShiftName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRArrangementShiftFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteHRArrangementShiftToDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeArrangementShifts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRArrangementShiftNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRArrangementShiftDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRArrangementShiftName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftToDate.Properties)).BeginInit();
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
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHREmployeeArrangementShifts);
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
            // fld_dgcHREmployeeArrangementShifts
            // 
            this.fld_dgcHREmployeeArrangementShifts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcHREmployeeArrangementShifts.GridViewMain = null;
            this.fld_dgcHREmployeeArrangementShifts.Location = new System.Drawing.Point(0, 45);
            this.fld_dgcHREmployeeArrangementShifts.MainView = this.gridView1;
            this.fld_dgcHREmployeeArrangementShifts.Name = "fld_dgcHREmployeeArrangementShifts";
            this.fld_dgcHREmployeeArrangementShifts.RowHandle = 0;
            this.fld_dgcHREmployeeArrangementShifts.Screen = null;
            this.fld_dgcHREmployeeArrangementShifts.Size = new System.Drawing.Size(1049, 330);
            this.fld_dgcHREmployeeArrangementShifts.TabIndex = 16;
            this.fld_dgcHREmployeeArrangementShifts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHREmployeeArrangementShifts.VinaDataMember = null;
            this.fld_dgcHREmployeeArrangementShifts.VinaDataSource = "HREmployeeArrangementShifts";
            this.fld_dgcHREmployeeArrangementShifts.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHREmployeeArrangementShifts;
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
            // fld_txtHRArrangementShiftNo
            // 
            this.fld_txtHRArrangementShiftNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRArrangementShiftNo.Name = "fld_txtHRArrangementShiftNo";
            this.fld_txtHRArrangementShiftNo.Screen = null;
            this.fld_txtHRArrangementShiftNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRArrangementShiftNo.TabIndex = 0;
            this.fld_txtHRArrangementShiftNo.Tag = "DC";
            this.fld_txtHRArrangementShiftNo.VinaDataMember = "HRArrangementShiftNo";
            this.fld_txtHRArrangementShiftNo.VinaDataSource = "HRArrangementShifts";
            this.fld_txtHRArrangementShiftNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRArrangementShiftDesc
            // 
            this.fld_mneHRArrangementShiftDesc.Location = new System.Drawing.Point(116, 62);
            this.fld_mneHRArrangementShiftDesc.Name = "fld_mneHRArrangementShiftDesc";
            this.fld_mneHRArrangementShiftDesc.Screen = null;
            this.fld_mneHRArrangementShiftDesc.Size = new System.Drawing.Size(525, 33);
            this.fld_mneHRArrangementShiftDesc.TabIndex = 3;
            this.fld_mneHRArrangementShiftDesc.Tag = "DC";
            this.fld_mneHRArrangementShiftDesc.VinaDataMember = "HRArrangementShiftDesc";
            this.fld_mneHRArrangementShiftDesc.VinaDataSource = "HRArrangementShifts";
            this.fld_mneHRArrangementShiftDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // fld_txtHRArrangementShiftName
            // 
            this.fld_txtHRArrangementShiftName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRArrangementShiftName.Name = "fld_txtHRArrangementShiftName";
            this.fld_txtHRArrangementShiftName.Screen = null;
            this.fld_txtHRArrangementShiftName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRArrangementShiftName.TabIndex = 63;
            this.fld_txtHRArrangementShiftName.Tag = "DC";
            this.fld_txtHRArrangementShiftName.VinaDataMember = "HRArrangementShiftName";
            this.fld_txtHRArrangementShiftName.VinaDataSource = "HRArrangementShifts";
            this.fld_txtHRArrangementShiftName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên chứng từ";
            // 
            // fld_dteHRArrangementShiftFromDate
            // 
            this.fld_dteHRArrangementShiftFromDate.EditValue = null;
            this.fld_dteHRArrangementShiftFromDate.Location = new System.Drawing.Point(116, 36);
            this.fld_dteHRArrangementShiftFromDate.Name = "fld_dteHRArrangementShiftFromDate";
            this.fld_dteHRArrangementShiftFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRArrangementShiftFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRArrangementShiftFromDate.Screen = null;
            this.fld_dteHRArrangementShiftFromDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRArrangementShiftFromDate.TabIndex = 74;
            this.fld_dteHRArrangementShiftFromDate.Tag = "DC";
            this.fld_dteHRArrangementShiftFromDate.VinaDataMember = "HRArrangementShiftFromDate";
            this.fld_dteHRArrangementShiftFromDate.VinaDataSource = "HRArrangementShifts";
            this.fld_dteHRArrangementShiftFromDate.VinaPropertyName = "EditValue";
            this.fld_dteHRArrangementShiftFromDate.Validated += new System.EventHandler(this.fld_dteHRRewardFromDate_Validated);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 39);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 73;
            this.labelControl9.Text = "Từ ngày";
            // 
            // fld_dteHRArrangementShiftToDate
            // 
            this.fld_dteHRArrangementShiftToDate.EditValue = null;
            this.fld_dteHRArrangementShiftToDate.Location = new System.Drawing.Point(442, 36);
            this.fld_dteHRArrangementShiftToDate.Name = "fld_dteHRArrangementShiftToDate";
            this.fld_dteHRArrangementShiftToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRArrangementShiftToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHRArrangementShiftToDate.Screen = null;
            this.fld_dteHRArrangementShiftToDate.Size = new System.Drawing.Size(199, 20);
            this.fld_dteHRArrangementShiftToDate.TabIndex = 76;
            this.fld_dteHRArrangementShiftToDate.Tag = "DC";
            this.fld_dteHRArrangementShiftToDate.VinaDataMember = "HRArrangementShiftToDate";
            this.fld_dteHRArrangementShiftToDate.VinaDataSource = "HRArrangementShifts";
            this.fld_dteHRArrangementShiftToDate.VinaPropertyName = "EditValue";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(345, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 75;
            this.labelControl2.Text = "Đến ngày";
            // 
            // DMAR100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.fld_dteHRArrangementShiftToDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.fld_dteHRArrangementShiftFromDate);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_txtHRArrangementShiftName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRArrangementShiftDesc);
            this.Controls.Add(this.fld_txtHRArrangementShiftNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMAR100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeArrangementShifts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRArrangementShiftNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRArrangementShiftDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRArrangementShiftName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHRArrangementShiftToDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HREmployeeArrangementShiftsGridControl fld_dgcHREmployeeArrangementShifts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRArrangementShiftNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRArrangementShiftDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRArrangementShiftName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaDateEdit fld_dteHRArrangementShiftFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private VinaDateEdit fld_dteHRArrangementShiftToDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}