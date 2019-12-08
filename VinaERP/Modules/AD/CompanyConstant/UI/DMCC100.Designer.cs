using VinaLib.BaseProvider;

namespace VinaERP.Modules.CompanyConstant.UI
{
    partial class DMCC100
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
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_tpgReward = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcRewardTypes = new VinaERP.Modules.CompanyConstant.RewardTypesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnSaveRewardType = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_tpgReward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcRewardTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1165, 687);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.fld_tpgReward});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1158, 652);
            this.xtraTabPage1.Text = "Thời gian làm việc";
            // 
            // fld_tpgReward
            // 
            this.fld_tpgReward.Controls.Add(this.fld_btnSaveRewardType);
            this.fld_tpgReward.Controls.Add(this.fld_dgcRewardTypes);
            this.fld_tpgReward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fld_tpgReward.Name = "fld_tpgReward";
            this.fld_tpgReward.Size = new System.Drawing.Size(1158, 652);
            this.fld_tpgReward.Text = "Cấu hình khen thưởng";
            // 
            // fld_dgcRewardTypes
            // 
            this.fld_dgcRewardTypes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fld_dgcRewardTypes.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcRewardTypes.MainView = this.gridView1;
            this.fld_dgcRewardTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fld_dgcRewardTypes.Name = "fld_dgcRewardTypes";
            this.fld_dgcRewardTypes.Screen = null;
            this.fld_dgcRewardTypes.Size = new System.Drawing.Size(1158, 609);
            this.fld_dgcRewardTypes.TabIndex = 17;
            this.fld_dgcRewardTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcRewardTypes.VinaDataMember = null;
            this.fld_dgcRewardTypes.VinaDataSource = "";
            this.fld_dgcRewardTypes.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.fld_dgcRewardTypes;
            this.gridView1.Name = "gridView1";
            // 
            // fld_btnSaveRewardType
            // 
            this.fld_btnSaveRewardType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_btnSaveRewardType.Location = new System.Drawing.Point(1065, 617);
            this.fld_btnSaveRewardType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fld_btnSaveRewardType.Name = "fld_btnSaveRewardType";
            this.fld_btnSaveRewardType.Size = new System.Drawing.Size(87, 31);
            this.fld_btnSaveRewardType.TabIndex = 18;
            this.fld_btnSaveRewardType.Text = "Lưu";
            this.fld_btnSaveRewardType.Click += new System.EventHandler(this.fld_btnSaveRewardType_Click);
            // 
            // DMCC100
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 687);
            this.Controls.Add(this.xtraTabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DMCC100";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_tpgReward.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcRewardTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage fld_tpgReward;
        private RewardTypesGridControl fld_dgcRewardTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton fld_btnSaveRewardType;
    }
}