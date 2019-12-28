using VinaLib.BaseProvider;

namespace VinaERP.Modules.ManagerTimeKeeper.UI
{
    partial class DMMT102
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
            this.fld_dgcHRTimeKeepers = new VinaERP.Modules.ManagerTimeKeeper.HRTimeKeeperGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dteDateFrom = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteToDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.fld_dgcHRMachineTimeKeepers = new VinaERP.Modules.ManagerTimeKeeper.HRMachineTimeKeepersGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRTimeKeepers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRMachineTimeKeepers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(370, 116);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(836, 442);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHRTimeKeepers);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(830, 414);
            this.fld_lkeFK_ICProductID.Text = "Thông tin";
            // 
            // fld_dgcHRTimeKeepers
            // 
            this.fld_dgcHRTimeKeepers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcHRTimeKeepers.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcHRTimeKeepers.MainView = this.gridView1;
            this.fld_dgcHRTimeKeepers.Name = "fld_dgcHRTimeKeepers";
            this.fld_dgcHRTimeKeepers.Screen = null;
            this.fld_dgcHRTimeKeepers.Size = new System.Drawing.Size(830, 414);
            this.fld_dgcHRTimeKeepers.TabIndex = 16;
            this.fld_dgcHRTimeKeepers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHRTimeKeepers.VinaDataMember = null;
            this.fld_dgcHRTimeKeepers.VinaDataSource = "HRTimeKeepers";
            this.fld_dgcHRTimeKeepers.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHRTimeKeepers;
            this.gridView1.Name = "gridView1";
            // 
            // fld_btnSearch
            // 
            this.fld_btnSearch.Location = new System.Drawing.Point(673, 38);
            this.fld_btnSearch.Name = "fld_btnSearch";
            this.fld_btnSearch.Size = new System.Drawing.Size(128, 25);
            this.fld_btnSearch.TabIndex = 130;
            this.fld_btnSearch.Text = "Tải dữ liệu";
            this.fld_btnSearch.Click += new System.EventHandler(this.fld_btnSearch_Click);
            // 
            // fld_dteDateFrom
            // 
            this.fld_dteDateFrom.EditValue = null;
            this.fld_dteDateFrom.Location = new System.Drawing.Point(437, 12);
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
            this.labelControl9.Location = new System.Drawing.Point(370, 15);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 133;
            this.labelControl9.Text = "Từ ngày";
            // 
            // fld_dteToDate
            // 
            this.fld_dteToDate.EditValue = null;
            this.fld_dteToDate.Location = new System.Drawing.Point(673, 12);
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
            this.labelControl1.Location = new System.Drawing.Point(593, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 135;
            this.labelControl1.Text = "Đến ngày";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(673, 69);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(128, 25);
            this.simpleButton1.TabIndex = 137;
            this.simpleButton1.Text = "Nhập công nhanh";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(370, 38);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Theo máy được chọn"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tất cả máy")});
            this.radioGroup1.Size = new System.Drawing.Size(270, 56);
            this.radioGroup1.TabIndex = 138;
            // 
            // fld_dgcHRMachineTimeKeepers
            // 
            this.fld_dgcHRMachineTimeKeepers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_dgcHRMachineTimeKeepers.Location = new System.Drawing.Point(8, 8);
            this.fld_dgcHRMachineTimeKeepers.MainView = this.gridView2;
            this.fld_dgcHRMachineTimeKeepers.Name = "fld_dgcHRMachineTimeKeepers";
            this.fld_dgcHRMachineTimeKeepers.Screen = null;
            this.fld_dgcHRMachineTimeKeepers.Size = new System.Drawing.Size(356, 545);
            this.fld_dgcHRMachineTimeKeepers.TabIndex = 139;
            this.fld_dgcHRMachineTimeKeepers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.fld_dgcHRMachineTimeKeepers.VinaDataMember = null;
            this.fld_dgcHRMachineTimeKeepers.VinaDataSource = "HRMachineTimeKeepers";
            this.fld_dgcHRMachineTimeKeepers.VinaPropertyName = null;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcHRMachineTimeKeepers;
            this.gridView2.Name = "gridView2";
            // 
            // DMMT102
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 563);
            this.Controls.Add(this.fld_dgcHRMachineTimeKeepers);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.fld_dteToDate);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_dteDateFrom);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.fld_btnSearch);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "DMMT102";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRTimeKeepers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRMachineTimeKeepers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HRTimeKeeperGridControl fld_dgcHRTimeKeepers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton fld_btnSearch;
        private VinaDateEdit fld_dteDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private VinaDateEdit fld_dteToDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private HRMachineTimeKeepersGridControl fld_dgcHRMachineTimeKeepers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}