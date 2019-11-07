namespace VinaERP
{
    partial class GuiErrorMessage
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
            this.fld_dgcErrorMessages = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_clmMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fld_btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcErrorMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcErrorMessages
            // 
            this.fld_dgcErrorMessages.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.fld_dgcErrorMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcErrorMessages.Location = new System.Drawing.Point(-1, -2);
            this.fld_dgcErrorMessages.MainView = this.gridView1;
            this.fld_dgcErrorMessages.Name = "fld_dgcErrorMessages";
            this.fld_dgcErrorMessages.Size = new System.Drawing.Size(621, 320);
            this.fld_dgcErrorMessages.TabIndex = 0;
            this.fld_dgcErrorMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.fld_clmMessage});
            this.gridView1.GridControl = this.fld_dgcErrorMessages;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // fld_clmMessage
            // 
            this.fld_clmMessage.Caption = "Mô tả";
            this.fld_clmMessage.FieldName = "Message";
            this.fld_clmMessage.Name = "fld_clmMessage";
            this.fld_clmMessage.Visible = true;
            this.fld_clmMessage.VisibleIndex = 0;
            // 
            // fld_btnOK
            // 
            this.fld_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnOK.Location = new System.Drawing.Point(534, 326);
            this.fld_btnOK.LookAndFeel.SkinName = "Office 2007 Blue";
            this.fld_btnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Size = new System.Drawing.Size(75, 27);
            this.fld_btnOK.TabIndex = 8;
            this.fld_btnOK.Text = "Đồng ý";
            this.fld_btnOK.Click += new System.EventHandler(this.fld_btnOK_Click);
            // 
            // GuiErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 363);
            this.Controls.Add(this.fld_btnOK);
            this.Controls.Add(this.fld_dgcErrorMessages);
            this.Name = "GuiErrorMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo lỗi";
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcErrorMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl fld_dgcErrorMessages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton fld_btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn fld_clmMessage;
    }
}