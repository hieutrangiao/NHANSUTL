namespace VinaERP.Modules.Supplier.UI
{
    partial class SMSP100
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
            this.fld_dgcSupplierSearchResultGridControl = new VinaERP.VinaSearchResultsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcSupplierSearchResultGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcSupplierSearchResultGridControl
            // 
            this.fld_dgcSupplierSearchResultGridControl.Location = new System.Drawing.Point(12, 179);
            this.fld_dgcSupplierSearchResultGridControl.MainView = this.gridView1;
            this.fld_dgcSupplierSearchResultGridControl.Name = "fld_dgcSupplierSearchResultGridControl";
            this.fld_dgcSupplierSearchResultGridControl.Screen = null;
            this.fld_dgcSupplierSearchResultGridControl.Size = new System.Drawing.Size(403, 313);
            this.fld_dgcSupplierSearchResultGridControl.TabIndex = 0;
            this.fld_dgcSupplierSearchResultGridControl.Tag = "SR";
            this.fld_dgcSupplierSearchResultGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcSupplierSearchResultGridControl.VinaDataMember = null;
            this.fld_dgcSupplierSearchResultGridControl.VinaDataSource = "APSuppliers";
            this.fld_dgcSupplierSearchResultGridControl.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView1.GridControl = this.fld_dgcSupplierSearchResultGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã hợp đồng";
            this.gridColumn1.FieldName = "ARSaleOrderNo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // SMSP100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.fld_dgcSupplierSearchResultGridControl);
            this.Name = "SMSP100";
            this.Text = "Tìm kiếm";
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcSupplierSearchResultGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VinaSearchResultsGridControl fld_dgcSupplierSearchResultGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}