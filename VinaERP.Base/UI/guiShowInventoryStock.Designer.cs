using VinaERP.Base.UI.GridControl;

namespace VinaERP.Base.UI
{
    partial class guiShowInventoryStock
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lblPOQty = new DevExpress.XtraEditors.LabelControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lblAvailableQty = new DevExpress.XtraEditors.LabelControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lblSOQty = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_lblOnHandQty = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fld_dgcInventoryStocks = new VinaERP.Base.UI.GridControl.ICInventoryStocksGridControl();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcInventoryStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 403);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelControl13);
            this.panel6.Controls.Add(this.fld_lblPOQty);
            this.panel6.Location = new System.Drawing.Point(10, 105);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(237, 25);
            this.panel6.TabIndex = 8;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(3, 6);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(113, 16);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Số lượng đặt mua";
            // 
            // fld_lblPOQty
            // 
            this.fld_lblPOQty.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_lblPOQty.Appearance.Options.UseFont = true;
            this.fld_lblPOQty.Location = new System.Drawing.Point(172, 8);
            this.fld_lblPOQty.Name = "fld_lblPOQty";
            this.fld_lblPOQty.Size = new System.Drawing.Size(8, 14);
            this.fld_lblPOQty.TabIndex = 3;
            this.fld_lblPOQty.Text = "0";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelControl11);
            this.panel5.Controls.Add(this.fld_lblAvailableQty);
            this.panel5.Location = new System.Drawing.Point(10, 74);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(237, 25);
            this.panel5.TabIndex = 8;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(3, 6);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(157, 16);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Số lượng có thể sử dụng";
            // 
            // fld_lblAvailableQty
            // 
            this.fld_lblAvailableQty.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_lblAvailableQty.Appearance.Options.UseFont = true;
            this.fld_lblAvailableQty.Location = new System.Drawing.Point(172, 6);
            this.fld_lblAvailableQty.Name = "fld_lblAvailableQty";
            this.fld_lblAvailableQty.Size = new System.Drawing.Size(8, 14);
            this.fld_lblAvailableQty.TabIndex = 3;
            this.fld_lblAvailableQty.Text = "0";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelControl9);
            this.panel4.Controls.Add(this.fld_lblSOQty);
            this.panel4.Location = new System.Drawing.Point(10, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 25);
            this.panel4.TabIndex = 8;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(3, 6);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(110, 16);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Số lượng đặt bán";
            // 
            // fld_lblSOQty
            // 
            this.fld_lblSOQty.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_lblSOQty.Appearance.Options.UseFont = true;
            this.fld_lblSOQty.Location = new System.Drawing.Point(172, 6);
            this.fld_lblSOQty.Name = "fld_lblSOQty";
            this.fld_lblSOQty.Size = new System.Drawing.Size(8, 14);
            this.fld_lblSOQty.TabIndex = 3;
            this.fld_lblSOQty.Text = "0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelControl1);
            this.panel3.Controls.Add(this.fld_lblOnHandQty);
            this.panel3.Location = new System.Drawing.Point(10, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 25);
            this.panel3.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số lượng tồn kho";
            // 
            // fld_lblOnHandQty
            // 
            this.fld_lblOnHandQty.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_lblOnHandQty.Appearance.Options.UseFont = true;
            this.fld_lblOnHandQty.Location = new System.Drawing.Point(172, 6);
            this.fld_lblOnHandQty.Name = "fld_lblOnHandQty";
            this.fld_lblOnHandQty.Size = new System.Drawing.Size(8, 14);
            this.fld_lblOnHandQty.TabIndex = 3;
            this.fld_lblOnHandQty.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fld_dgcInventoryStocks);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(257, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 403);
            this.panel2.TabIndex = 1;
            // 
            // fld_dgcInventoryStocks
            // 
            this.fld_dgcInventoryStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcInventoryStocks.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcInventoryStocks.Name = "fld_dgcInventoryStocks";
            this.fld_dgcInventoryStocks.Screen = null;
            this.fld_dgcInventoryStocks.Size = new System.Drawing.Size(514, 403);
            this.fld_dgcInventoryStocks.TabIndex = 0;
            this.fld_dgcInventoryStocks.VinaDataMember = null;
            this.fld_dgcInventoryStocks.VinaDataSource = "ICTransactions";
            this.fld_dgcInventoryStocks.VinaPropertyName = null;
            // 
            // guiShowInventoryStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 403);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "guiShowInventoryStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết tồn kho sản phẩm";
            this.Load += new System.EventHandler(this.GuiShowInventoryStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcInventoryStocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl fld_lblOnHandQty;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl fld_lblSOQty;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl fld_lblAvailableQty;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl fld_lblPOQty;
        private ICInventoryStocksGridControl fld_dgcInventoryStocks;
    }
}