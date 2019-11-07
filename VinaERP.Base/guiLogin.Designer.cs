namespace VinaERP.Base
{
    partial class guiLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.fld_btnLogin = new System.Windows.Forms.Button();
            this.fld_txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.fld_txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fld_btnBarClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUserName.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 300);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(151)))), ((int)(((byte)(181)))));
            this.panel4.Controls.Add(this.linkLabel1);
            this.panel4.Controls.Add(this.fld_btnLogin);
            this.panel4.Controls.Add(this.fld_txtPassword);
            this.panel4.Controls.Add(this.fld_txtUserName);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(184, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(316, 300);
            this.panel4.TabIndex = 2;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.linkLabel1.Location = new System.Drawing.Point(220, 278);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            // 
            // fld_btnLogin
            // 
            this.fld_btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.fld_btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fld_btnLogin.CausesValidation = false;
            this.fld_btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.fld_btnLogin.FlatAppearance.BorderSize = 0;
            this.fld_btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.fld_btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.fld_btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fld_btnLogin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_btnLogin.ForeColor = System.Drawing.Color.White;
            this.fld_btnLogin.Location = new System.Drawing.Point(27, 185);
            this.fld_btnLogin.Name = "fld_btnLogin";
            this.fld_btnLogin.Size = new System.Drawing.Size(264, 31);
            this.fld_btnLogin.TabIndex = 2;
            this.fld_btnLogin.Text = "Đăng nhập";
            this.fld_btnLogin.UseVisualStyleBackColor = false;
            this.fld_btnLogin.Click += new System.EventHandler(this.fld_btnLogin_Click);
            // 
            // fld_txtPassword
            // 
            this.fld_txtPassword.Location = new System.Drawing.Point(27, 141);
            this.fld_txtPassword.Name = "fld_txtPassword";
            this.fld_txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.fld_txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtPassword.Properties.Appearance.Options.UseFont = true;
            this.fld_txtPassword.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.fld_txtPassword.Properties.NullText = "Mật khẩu";
            this.fld_txtPassword.Properties.NullValuePrompt = "Mật khẩu";
            this.fld_txtPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.fld_txtPassword.Properties.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.fld_txtPassword.Properties.Tag = "";
            this.fld_txtPassword.Properties.UseSystemPasswordChar = true;
            this.fld_txtPassword.Size = new System.Drawing.Size(264, 24);
            this.fld_txtPassword.TabIndex = 1;
            this.fld_txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Authentication_KeyDown);
            // 
            // fld_txtUserName
            // 
            this.fld_txtUserName.Location = new System.Drawing.Point(27, 98);
            this.fld_txtUserName.Name = "fld_txtUserName";
            this.fld_txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.fld_txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_txtUserName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtUserName.Properties.Appearance.Options.UseFont = true;
            this.fld_txtUserName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.fld_txtUserName.Properties.NullText = "Tài khoản";
            this.fld_txtUserName.Properties.NullValuePrompt = "Tài khoản";
            this.fld_txtUserName.Properties.NullValuePromptShowForEmptyValue = true;
            this.fld_txtUserName.Properties.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.fld_txtUserName.Properties.ShowNullValuePromptWhenFocused = true;
            this.fld_txtUserName.Properties.Tag = "";
            this.fld_txtUserName.Size = new System.Drawing.Size(264, 24);
            this.fld_txtUserName.TabIndex = 0;
            this.fld_txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Authentication_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(151)))), ((int)(((byte)(181)))));
            this.panel2.Controls.Add(this.fld_btnBarClose);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 30);
            this.panel2.TabIndex = 2;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fld_pnlBarHeader_MouseMove);
            // 
            // fld_btnBarClose
            // 
            this.fld_btnBarClose.CausesValidation = false;
            this.fld_btnBarClose.FlatAppearance.BorderSize = 0;
            this.fld_btnBarClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.fld_btnBarClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.fld_btnBarClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fld_btnBarClose.Image = ((System.Drawing.Image)(resources.GetObject("fld_btnBarClose.Image")));
            this.fld_btnBarClose.Location = new System.Drawing.Point(281, 0);
            this.fld_btnBarClose.Name = "fld_btnBarClose";
            this.fld_btnBarClose.Size = new System.Drawing.Size(35, 30);
            this.fld_btnBarClose.TabIndex = 0;
            this.fld_btnBarClose.TabStop = false;
            this.fld_btnBarClose.UseVisualStyleBackColor = true;
            this.fld_btnBarClose.Click += new System.EventHandler(this.fld_btnBarClose_Click);
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(246, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 30);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.fld_btnBarMinimize_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 300);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(184, 30);
            this.panel5.TabIndex = 1;
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fld_pnlBarHeader_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guiLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiLogin";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Authentication_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUserName.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button fld_btnBarClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button fld_btnLogin;
        private DevExpress.XtraEditors.TextEdit fld_txtPassword;
        private DevExpress.XtraEditors.TextEdit fld_txtUserName;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}