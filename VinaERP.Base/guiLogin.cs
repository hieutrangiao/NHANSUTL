using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VinaERP.Base
{
    public partial class guiLogin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public guiLogin()
        {
            InitializeComponent();
        }

        private void fld_btnBarClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fld_btnBarMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void fld_pnlBarHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void fld_btnLogin_Click(object sender, EventArgs e)
        {
            string strLoginMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(fld_txtUserName.Text) || string.IsNullOrWhiteSpace(fld_txtPassword.Text))
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
            this.fld_txtPassword.Text = string.Empty;
            this.fld_txtUserName.Text = string.Empty;
            this.fld_txtUserName.Focus();
        }

        private void Authentication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            this.fld_btnLogin_Click(sender, e);
        }
    }
}
