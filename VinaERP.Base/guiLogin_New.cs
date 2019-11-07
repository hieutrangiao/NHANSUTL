using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace VinaERP
{
    public partial class guiLogin_New : VinaERPScreen
    {
        public guiLogin_New()
        {
            InitializeComponent();
        }

        private void fld_btnLogin_Click(object sender, EventArgs e)
        {
            string strLoginMessage = string.Empty;
            if (fld_txtUserName.EditValue == null || fld_txtPassword.EditValue == null)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được bỏ trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!VinaApp.IsAuthenticated(fld_txtUserName.Text, fld_txtPassword.Text, out strLoginMessage))
            {
                MessageBox.Show(strLoginMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Hide();
            VinaApp.InitApplication();
            this.Show();
            this.fld_txtPassword.Text= string.Empty;
            this.fld_txtUserName.Text = string.Empty;
            this.fld_txtUserName.Focus();
        }

        private void Authentication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.fld_btnLogin_Click(sender, e);
            }
        }

        private void fld_btnExitApplication_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}