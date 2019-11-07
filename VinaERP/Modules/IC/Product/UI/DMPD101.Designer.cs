using VinaLib.BaseProvider;

namespace VinaERP.Modules.Product.UI
{
    partial class DMPD101
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
            this.fld_dgcICProductMeasureUnits = new VinaERP.Modules.Product.ICProductMeasureUnitsGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICProductMeasureUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcICProductMeasureUnits
            // 
            this.fld_dgcICProductMeasureUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcICProductMeasureUnits.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcICProductMeasureUnits.MainView = this.gridView2;
            this.fld_dgcICProductMeasureUnits.Name = "fld_dgcICProductMeasureUnits";
            this.fld_dgcICProductMeasureUnits.Screen = null;
            this.fld_dgcICProductMeasureUnits.Size = new System.Drawing.Size(821, 504);
            this.fld_dgcICProductMeasureUnits.TabIndex = 18;
            this.fld_dgcICProductMeasureUnits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.fld_dgcICProductMeasureUnits.VinaDataMember = null;
            this.fld_dgcICProductMeasureUnits.VinaDataSource = "ICProductMeasureUnits";
            this.fld_dgcICProductMeasureUnits.VinaPropertyName = null;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcICProductMeasureUnits;
            this.gridView2.Name = "gridView2";
            // 
            // DMPD101
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 504);
            this.Controls.Add(this.fld_dgcICProductMeasureUnits);
            this.Name = "DMPD101";
            this.Text = "Đơn vị tính";
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICProductMeasureUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ICProductMeasureUnitsGridControl fld_dgcICProductMeasureUnits;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}