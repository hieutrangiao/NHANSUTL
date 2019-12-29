using VinaLib.BaseProvider;

namespace VinaERP.Modules.Calender.UI
{
    partial class DMCL100
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
            this.fld_dgcHRCalendarEntrys = new VinaERP.Modules.Calender.HRCalendarEntrysGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRCalendarNo = new VinaLib.BaseProvider.VinaTextBox();
            this.fld_mneHRCalendarDesc = new VinaLib.BaseProvider.Components.VinaMemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRCalendarName = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.fld_txtHRCalendarYear = new VinaLib.BaseProvider.VinaTextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeHRCalendarType = new VinaLib.BaseProvider.VinaLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_lkeFK_ICProductID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRCalendarEntrys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRCalendarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRCalendarDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRCalendarName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRCalendarYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRCalendarType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 101);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.fld_lkeFK_ICProductID;
            this.xtraTabControl1.Size = new System.Drawing.Size(1055, 457);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.fld_lkeFK_ICProductID});
            // 
            // fld_lkeFK_ICProductID
            // 
            this.fld_lkeFK_ICProductID.Controls.Add(this.fld_dgcHRCalendarEntrys);
            this.fld_lkeFK_ICProductID.Name = "fld_lkeFK_ICProductID";
            this.fld_lkeFK_ICProductID.Size = new System.Drawing.Size(1049, 429);
            this.fld_lkeFK_ICProductID.Text = "Danh sách ngày nghỉ lễ";
            // 
            // fld_dgcHRCalendarEntrys
            // 
            this.fld_dgcHRCalendarEntrys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcHRCalendarEntrys.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcHRCalendarEntrys.MainView = this.gridView1;
            this.fld_dgcHRCalendarEntrys.Name = "fld_dgcHRCalendarEntrys";
            this.fld_dgcHRCalendarEntrys.Screen = null;
            this.fld_dgcHRCalendarEntrys.Size = new System.Drawing.Size(1049, 429);
            this.fld_dgcHRCalendarEntrys.TabIndex = 16;
            this.fld_dgcHRCalendarEntrys.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcHRCalendarEntrys.VinaDataMember = null;
            this.fld_dgcHRCalendarEntrys.VinaDataSource = "HRCalendarEntrys";
            this.fld_dgcHRCalendarEntrys.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcHRCalendarEntrys;
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
            // fld_txtHRCalendarNo
            // 
            this.fld_txtHRCalendarNo.Location = new System.Drawing.Point(116, 10);
            this.fld_txtHRCalendarNo.Name = "fld_txtHRCalendarNo";
            this.fld_txtHRCalendarNo.Screen = null;
            this.fld_txtHRCalendarNo.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRCalendarNo.TabIndex = 0;
            this.fld_txtHRCalendarNo.Tag = "DC";
            this.fld_txtHRCalendarNo.VinaDataMember = "HRCalendarNo";
            this.fld_txtHRCalendarNo.VinaDataSource = "HRCalendars";
            this.fld_txtHRCalendarNo.VinaPropertyName = "EditValue";
            // 
            // fld_mneHRCalendarDesc
            // 
            this.fld_mneHRCalendarDesc.Location = new System.Drawing.Point(116, 62);
            this.fld_mneHRCalendarDesc.Name = "fld_mneHRCalendarDesc";
            this.fld_mneHRCalendarDesc.Screen = null;
            this.fld_mneHRCalendarDesc.Size = new System.Drawing.Size(525, 33);
            this.fld_mneHRCalendarDesc.TabIndex = 3;
            this.fld_mneHRCalendarDesc.Tag = "DC";
            this.fld_mneHRCalendarDesc.VinaDataMember = "HRCalendarDesc";
            this.fld_mneHRCalendarDesc.VinaDataSource = "HRCalendars";
            this.fld_mneHRCalendarDesc.VinaPropertyName = "EditValue";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 61;
            this.labelControl4.Text = "Ghi chú";
            // 
            // fld_txtHRCalendarName
            // 
            this.fld_txtHRCalendarName.Location = new System.Drawing.Point(442, 10);
            this.fld_txtHRCalendarName.Name = "fld_txtHRCalendarName";
            this.fld_txtHRCalendarName.Screen = null;
            this.fld_txtHRCalendarName.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRCalendarName.TabIndex = 63;
            this.fld_txtHRCalendarName.Tag = "DC";
            this.fld_txtHRCalendarName.VinaDataMember = "HRCalendarName";
            this.fld_txtHRCalendarName.VinaDataSource = "HRCalendars";
            this.fld_txtHRCalendarName.VinaPropertyName = "EditValue";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 64;
            this.labelControl5.Text = "Tên danh sách";
            // 
            // fld_txtHRCalendarYear
            // 
            this.fld_txtHRCalendarYear.Location = new System.Drawing.Point(442, 36);
            this.fld_txtHRCalendarYear.Name = "fld_txtHRCalendarYear";
            this.fld_txtHRCalendarYear.Properties.DisplayFormat.FormatString = "n0";
            this.fld_txtHRCalendarYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRCalendarYear.Properties.EditFormat.FormatString = "n0";
            this.fld_txtHRCalendarYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtHRCalendarYear.Screen = null;
            this.fld_txtHRCalendarYear.Size = new System.Drawing.Size(199, 20);
            this.fld_txtHRCalendarYear.TabIndex = 67;
            this.fld_txtHRCalendarYear.Tag = "DC";
            this.fld_txtHRCalendarYear.VinaDataMember = "HRCalendarYear";
            this.fld_txtHRCalendarYear.VinaDataSource = "HRCalendars";
            this.fld_txtHRCalendarYear.VinaPropertyName = "EditValue";
            this.fld_txtHRCalendarYear.Validated += new System.EventHandler(this.fld_txtHRRewardValue_Validated);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(345, 39);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(21, 13);
            this.labelControl6.TabIndex = 68;
            this.labelControl6.Text = "Năm";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 39);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(19, 13);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "Loại";
            // 
            // fld_lkeHRCalendarType
            // 
            this.fld_lkeHRCalendarType.Location = new System.Drawing.Point(116, 36);
            this.fld_lkeHRCalendarType.Name = "fld_lkeHRCalendarType";
            this.fld_lkeHRCalendarType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRCalendarType.Screen = null;
            this.fld_lkeHRCalendarType.Size = new System.Drawing.Size(199, 20);
            this.fld_lkeHRCalendarType.TabIndex = 80;
            this.fld_lkeHRCalendarType.Tag = "DC";
            this.fld_lkeHRCalendarType.VinaAllowDummy = true;
            this.fld_lkeHRCalendarType.VinaAutoGenarateDataSoure = true;
            this.fld_lkeHRCalendarType.VinaDataMember = "HRCalendarType";
            this.fld_lkeHRCalendarType.VinaDataSource = "HRCalendars";
            this.fld_lkeHRCalendarType.VinaPropertyName = "EditValue";
            this.fld_lkeHRCalendarType.Validated += new System.EventHandler(this.fld_txtHRRewardType_Validated);
            // 
            // DMCL100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 563);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.fld_lkeHRCalendarType);
            this.Controls.Add(this.fld_txtHRCalendarYear);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.fld_txtHRCalendarName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.fld_mneHRCalendarDesc);
            this.Controls.Add(this.fld_txtHRCalendarNo);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "DMCL100";
            this.Tag = "DC";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_lkeFK_ICProductID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHRCalendarEntrys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRCalendarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mneHRCalendarDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRCalendarName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHRCalendarYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRCalendarType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage fld_lkeFK_ICProductID;
        private HRCalendarEntrysGridControl fld_dgcHRCalendarEntrys;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaTextBox fld_txtHRCalendarNo;
        private VinaLib.BaseProvider.Components.VinaMemoEdit fld_mneHRCalendarDesc;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private VinaTextBox fld_txtHRCalendarName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VinaTextBox fld_txtHRCalendarYear;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private VinaLookupEdit fld_lkeHRCalendarType;
    }
}