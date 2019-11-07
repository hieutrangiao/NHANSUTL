using VinaLib.BaseProvider;

namespace VinaERP.Modules.InventoryStatistics.UI
{
    partial class DMISS100
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fld_btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.fld_chkIsGroupByStock = new VinaLib.BaseProvider.VinaCheckBox();
            this.fld_dteToDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_dteFromDate = new VinaLib.BaseProvider.VinaDateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lkeICStockID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.fld_lkeICProductID = new VinaLib.BaseProvider.VinaLookupEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcICTransactions = new VinaERP.Modules.InventoryStatistics.ICTransactionsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkIsGroupByStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeICStockID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeICProductID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.fld_btnOK);
            this.groupControl1.Controls.Add(this.fld_chkIsGroupByStock);
            this.groupControl1.Controls.Add(this.fld_dteToDate);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.fld_dteFromDate);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.fld_lkeICStockID);
            this.groupControl1.Controls.Add(this.label16);
            this.groupControl1.Controls.Add(this.fld_lkeICProductID);
            this.groupControl1.Controls.Add(this.label15);
            this.groupControl1.Location = new System.Drawing.Point(9, 9);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(796, 90);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Thông tin tìm kiếm";
            // 
            // fld_btnOK
            // 
            this.fld_btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnOK.Location = new System.Drawing.Point(703, 53);
            this.fld_btnOK.LookAndFeel.SkinName = "Office 2007 Blue";
            this.fld_btnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Size = new System.Drawing.Size(75, 27);
            this.fld_btnOK.TabIndex = 72;
            this.fld_btnOK.Text = "Xem";
            this.fld_btnOK.Click += new System.EventHandler(this.Fld_btnOK_Click);
            // 
            // fld_chkIsGroupByStock
            // 
            this.fld_chkIsGroupByStock.Location = new System.Drawing.Point(559, 28);
            this.fld_chkIsGroupByStock.Name = "fld_chkIsGroupByStock";
            this.fld_chkIsGroupByStock.Properties.Caption = "Nhóm theo kho";
            this.fld_chkIsGroupByStock.Screen = null;
            this.fld_chkIsGroupByStock.Size = new System.Drawing.Size(105, 19);
            this.fld_chkIsGroupByStock.TabIndex = 71;
            this.fld_chkIsGroupByStock.Tag = "DC";
            this.fld_chkIsGroupByStock.VinaDataMember = "ICProductActiveCheck";
            this.fld_chkIsGroupByStock.VinaDataSource = "ICProducts";
            this.fld_chkIsGroupByStock.VinaPropertyName = "EditValue";
            // 
            // fld_dteToDate
            // 
            this.fld_dteToDate.EditValue = null;
            this.fld_dteToDate.Location = new System.Drawing.Point(354, 28);
            this.fld_dteToDate.Name = "fld_dteToDate";
            this.fld_dteToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteToDate.Screen = null;
            this.fld_dteToDate.Size = new System.Drawing.Size(150, 20);
            this.fld_dteToDate.TabIndex = 70;
            this.fld_dteToDate.Tag = "DC";
            this.fld_dteToDate.VinaDataMember = "";
            this.fld_dteToDate.VinaDataSource = "";
            this.fld_dteToDate.VinaPropertyName = "EditValue";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(289, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 69;
            this.labelControl1.Text = "Đến ngày";
            // 
            // fld_dteFromDate
            // 
            this.fld_dteFromDate.EditValue = null;
            this.fld_dteFromDate.Location = new System.Drawing.Point(74, 28);
            this.fld_dteFromDate.Name = "fld_dteFromDate";
            this.fld_dteFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteFromDate.Screen = null;
            this.fld_dteFromDate.Size = new System.Drawing.Size(150, 20);
            this.fld_dteFromDate.TabIndex = 68;
            this.fld_dteFromDate.Tag = "DC";
            this.fld_dteFromDate.VinaDataMember = "";
            this.fld_dteFromDate.VinaDataSource = "";
            this.fld_dteFromDate.VinaPropertyName = "EditValue";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(16, 31);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(40, 13);
            this.labelControl9.TabIndex = 67;
            this.labelControl9.Text = "Từ ngày";
            // 
            // fld_lkeICStockID
            // 
            this.fld_lkeICStockID.Location = new System.Drawing.Point(74, 57);
            this.fld_lkeICStockID.Name = "fld_lkeICStockID";
            this.fld_lkeICStockID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeICStockID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICStockName", "Kho")});
            this.fld_lkeICStockID.Properties.DisplayMember = "ICStockName";
            this.fld_lkeICStockID.Properties.ValueMember = "ICStockID";
            this.fld_lkeICStockID.Screen = null;
            this.fld_lkeICStockID.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeICStockID.TabIndex = 8;
            this.fld_lkeICStockID.Tag = "DC";
            this.fld_lkeICStockID.VinaAllowDummy = false;
            this.fld_lkeICStockID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeICStockID.VinaDataMember = "ICStockID";
            this.fld_lkeICStockID.VinaDataSource = "ICStocks";
            this.fld_lkeICStockID.VinaPropertyName = "EditValue";
            this.fld_lkeICStockID.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.Fld_lkeICStockID_QueryPopUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Kho";
            // 
            // fld_lkeICProductID
            // 
            this.fld_lkeICProductID.Location = new System.Drawing.Point(354, 57);
            this.fld_lkeICProductID.Name = "fld_lkeICProductID";
            this.fld_lkeICProductID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeICProductID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductNo", "Mã SP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductName", "Tên SP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICProductDesc", "Mô tả SP")});
            this.fld_lkeICProductID.Properties.DisplayMember = "ICProductDesc";
            this.fld_lkeICProductID.Properties.ValueMember = "ICProductID";
            this.fld_lkeICProductID.Screen = null;
            this.fld_lkeICProductID.Size = new System.Drawing.Size(310, 20);
            this.fld_lkeICProductID.TabIndex = 7;
            this.fld_lkeICProductID.Tag = "DC";
            this.fld_lkeICProductID.VinaAllowDummy = false;
            this.fld_lkeICProductID.VinaAutoGenarateDataSoure = true;
            this.fld_lkeICProductID.VinaDataMember = "ICProductID";
            this.fld_lkeICProductID.VinaDataSource = "ICProducts";
            this.fld_lkeICProductID.VinaPropertyName = "EditValue";
            this.fld_lkeICProductID.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.Fld_lkeICProductID_QueryPopUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(286, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Sản phẩm";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(8, 105);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(802, 455);
            this.xtraTabControl1.TabIndex = 47;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.fld_dgcICTransactions);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(796, 427);
            this.xtraTabPage1.Text = "Tổng hợp nhập xuất tồn";
            // 
            // fld_dgcICTransactions
            // 
            this.fld_dgcICTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcICTransactions.Location = new System.Drawing.Point(3, 3);
            this.fld_dgcICTransactions.MainView = this.gridView1;
            this.fld_dgcICTransactions.Name = "fld_dgcICTransactions";
            this.fld_dgcICTransactions.Screen = null;
            this.fld_dgcICTransactions.Size = new System.Drawing.Size(790, 421);
            this.fld_dgcICTransactions.TabIndex = 16;
            this.fld_dgcICTransactions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcICTransactions.VinaDataMember = null;
            this.fld_dgcICTransactions.VinaDataSource = "ICTransactions";
            this.fld_dgcICTransactions.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcICTransactions;
            this.gridView1.Name = "gridView1";
            // 
            // DMISS100
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 565);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "DMISS100";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkIsGroupByStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeICStockID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeICProductID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private VinaLookupEdit fld_lkeICStockID;
        private System.Windows.Forms.Label label16;
        private VinaLookupEdit fld_lkeICProductID;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private InventoryStatistics.ICTransactionsGridControl fld_dgcICTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private VinaDateEdit fld_dteToDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private VinaDateEdit fld_dteFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private VinaCheckBox fld_chkIsGroupByStock;
        private DevExpress.XtraEditors.SimpleButton fld_btnOK;
    }
}