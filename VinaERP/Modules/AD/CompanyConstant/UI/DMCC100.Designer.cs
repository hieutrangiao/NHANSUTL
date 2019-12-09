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
            this.fld_btnSaveRewardType = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcRewardTypes = new VinaERP.Modules.CompanyConstant.RewardTypesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_tpgDiscipline = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcDisciplineTypes = new VinaERP.Modules.CompanyConstant.DisciplineTypesGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcADWorkingShiftGroups = new VinaERP.Modules.CompanyConstant.HRWorkingShiftGroupsGridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage9 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage10 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage11 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage12 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage13 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.fld_tpgReward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcRewardTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.fld_tpgDiscipline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcDisciplineTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcADWorkingShiftGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(999, 558);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.fld_tpgReward,
            this.fld_tpgDiscipline,
            this.xtraTabPage2,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7,
            this.xtraTabPage8,
            this.xtraTabPage9,
            this.xtraTabPage10,
            this.xtraTabPage11,
            this.xtraTabPage12,
            this.xtraTabPage13});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage1.Text = "Thời gian làm việc";
            // 
            // fld_tpgReward
            // 
            this.fld_tpgReward.Controls.Add(this.fld_btnSaveRewardType);
            this.fld_tpgReward.Controls.Add(this.fld_dgcRewardTypes);
            this.fld_tpgReward.Name = "fld_tpgReward";
            this.fld_tpgReward.Size = new System.Drawing.Size(993, 530);
            this.fld_tpgReward.Text = "Cấu hình khen thưởng";
            // 
            // fld_btnSaveRewardType
            // 
            this.fld_btnSaveRewardType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnSaveRewardType.Location = new System.Drawing.Point(913, 501);
            this.fld_btnSaveRewardType.Name = "fld_btnSaveRewardType";
            this.fld_btnSaveRewardType.Size = new System.Drawing.Size(75, 25);
            this.fld_btnSaveRewardType.TabIndex = 18;
            this.fld_btnSaveRewardType.Text = "Lưu";
            this.fld_btnSaveRewardType.Click += new System.EventHandler(this.fld_btnSaveRewardType_Click);
            // 
            // fld_dgcRewardTypes
            // 
            this.fld_dgcRewardTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcRewardTypes.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcRewardTypes.MainView = this.gridView1;
            this.fld_dgcRewardTypes.Name = "fld_dgcRewardTypes";
            this.fld_dgcRewardTypes.Screen = null;
            this.fld_dgcRewardTypes.Size = new System.Drawing.Size(993, 495);
            this.fld_dgcRewardTypes.TabIndex = 17;
            this.fld_dgcRewardTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.fld_dgcRewardTypes.VinaDataMember = null;
            this.fld_dgcRewardTypes.VinaDataSource = "";
            this.fld_dgcRewardTypes.VinaPropertyName = null;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcRewardTypes;
            this.gridView1.Name = "gridView1";
            // 
            // fld_tpgDiscipline
            // 
            this.fld_tpgDiscipline.Controls.Add(this.fld_dgcDisciplineTypes);
            this.fld_tpgDiscipline.Controls.Add(this.simpleButton1);
            this.fld_tpgDiscipline.Name = "fld_tpgDiscipline";
            this.fld_tpgDiscipline.Size = new System.Drawing.Size(993, 530);
            this.fld_tpgDiscipline.Text = "Cấu hình loại kỷ luật";
            // 
            // fld_dgcDisciplineTypes
            // 
            this.fld_dgcDisciplineTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcDisciplineTypes.Location = new System.Drawing.Point(3, 3);
            this.fld_dgcDisciplineTypes.MainView = this.gridView2;
            this.fld_dgcDisciplineTypes.Name = "fld_dgcDisciplineTypes";
            this.fld_dgcDisciplineTypes.Screen = null;
            this.fld_dgcDisciplineTypes.Size = new System.Drawing.Size(987, 486);
            this.fld_dgcDisciplineTypes.TabIndex = 20;
            this.fld_dgcDisciplineTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.fld_dgcDisciplineTypes.VinaDataMember = null;
            this.fld_dgcDisciplineTypes.VinaDataSource = "";
            this.fld_dgcDisciplineTypes.VinaPropertyName = null;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcDisciplineTypes;
            this.gridView2.Name = "gridView2";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(911, 495);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 25);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "Lưu";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.xtraTabControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage2.Text = "Cấu hình hệ số";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage3;
            this.xtraTabControl2.Size = new System.Drawing.Size(993, 530);
            this.xtraTabControl2.TabIndex = 0;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(987, 502);
            this.xtraTabPage3.Text = "Cấu hình hệ số công";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(987, 502);
            this.xtraTabPage4.Text = "Cấu hình hệ số tăng ca";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.fld_dgcADWorkingShiftGroups);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage5.Text = "Cấu hình nhóm ca";
            // 
            // fld_dgcADWorkingShiftGroups
            // 
            this.fld_dgcADWorkingShiftGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcADWorkingShiftGroups.Location = new System.Drawing.Point(3, 3);
            this.fld_dgcADWorkingShiftGroups.MainView = this.gridView3;
            this.fld_dgcADWorkingShiftGroups.Name = "fld_dgcADWorkingShiftGroups";
            this.fld_dgcADWorkingShiftGroups.Screen = null;
            this.fld_dgcADWorkingShiftGroups.Size = new System.Drawing.Size(993, 473);
            this.fld_dgcADWorkingShiftGroups.TabIndex = 18;
            this.fld_dgcADWorkingShiftGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.fld_dgcADWorkingShiftGroups.VinaDataMember = null;
            this.fld_dgcADWorkingShiftGroups.VinaDataSource = "ADWorkingShiftGroups";
            this.fld_dgcADWorkingShiftGroups.VinaPropertyName = null;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.fld_dgcADWorkingShiftGroups;
            this.gridView3.Name = "gridView3";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage6.Text = "Danh mục công thức tính lương";
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage7.Text = "Cấu hình phụ cấp";
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage8.Text = "Cấu hình tăng ca";
            // 
            // xtraTabPage9
            // 
            this.xtraTabPage9.Name = "xtraTabPage9";
            this.xtraTabPage9.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage9.Text = "Cấu hình đi trễ/về sớm";
            // 
            // xtraTabPage10
            // 
            this.xtraTabPage10.Name = "xtraTabPage10";
            this.xtraTabPage10.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage10.Text = "Cấu hình công tháng";
            // 
            // xtraTabPage11
            // 
            this.xtraTabPage11.Name = "xtraTabPage11";
            this.xtraTabPage11.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage11.Text = "Cấu hình mức lương tối thiểu/tối đa";
            // 
            // xtraTabPage12
            // 
            this.xtraTabPage12.Name = "xtraTabPage12";
            this.xtraTabPage12.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage12.Text = "Bảo hiểm và thuế thu nhập cá nhân";
            // 
            // xtraTabPage13
            // 
            this.xtraTabPage13.Name = "xtraTabPage13";
            this.xtraTabPage13.Size = new System.Drawing.Size(993, 530);
            this.xtraTabPage13.Text = "xtraTabPage13";
            // 
            // DMCC100
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 558);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "DMCC100";
            this.Text = "Thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.fld_tpgReward.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcRewardTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.fld_tpgDiscipline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcDisciplineTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcADWorkingShiftGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage fld_tpgReward;
        private RewardTypesGridControl fld_dgcRewardTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton fld_btnSaveRewardType;
        private DevExpress.XtraTab.XtraTabPage fld_tpgDiscipline;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private HRWorkingShiftGroupsGridControl fld_dgcADWorkingShiftGroups;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage8;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage9;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage10;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage11;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage12;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage13;
        private DisciplineTypesGridControl fld_dgcDisciplineTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}