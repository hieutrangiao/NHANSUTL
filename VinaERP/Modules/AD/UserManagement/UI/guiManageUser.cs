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
using VinaLib;

namespace VinaERP.Modules.UserManagement.UI
{
    public partial class guiManageUser : XtraForm
    {
        public ADUsersInfo ADUsers { get; set; }
        public guiManageUser(ADUsersInfo objUsersInfo)
        {
            InitializeComponent();
            ADUsers = objUsersInfo;
            fld_txtUsername.Enabled = true;
            if (ADUsers.ADUserID > 0)
            {
                fld_txtUsername.Enabled = false;
            }
        }

        private void GuiManageUser_Load(object sender, EventArgs e)
        {
            InitControlDataSource();
            UpdateUI();
        }

        public void InitControlDataSource()
        {
            ADUserGroupsController objUsersController = new ADUserGroupsController();
            DataSet userList = objUsersController.GetAllObjects();
            fld_lkeUserGroup.Properties.DataSource = userList.Tables[0];

            HREmployeesController objEmployeesController = new HREmployeesController();
            DataSet employeeList = objEmployeesController.GetAllObjects();
            fld_lkeHREmployeeID.Properties.DataSource = employeeList.Tables[0];
        }

        private void Fld_btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Fld_btnSave_Click(object sender, EventArgs e)
        {

            UpdateUser();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsValid()
        {
            string username = Convert.ToString(fld_txtUsername.EditValue);
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo existingUser = (ADUsersInfo)objUsersController.GetObjectByName(username);
            if (existingUser != null && existingUser.ADUserID != ADUsers.ADUserID)
            {
                MessageBox.Show("Tên đăng nhập đã được sử dụng. Vui lòng chọn tên đăng nhập khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (ADUsers.ADUserID == 0)
            {
                if (String.IsNullOrEmpty(ADUsers.ADPassword))
                {
                    MessageBox.Show("Mật khẩu không đc để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //if (!string.IsNullOrEmpty(objUsersInfo.ADPassword) && objUsersInfo.ADPassword != fld_txtConfirmPassword.Text)
            //{
            //    MessageBox.Show(UserManagementLocalizedResources.PasswordNotMatchMessage, "Thông báo" MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            return false;
        }

        private void UpdateUser()
        {
            ADUsers.ADUserName = Convert.ToString(fld_txtUsername.EditValue);
            ADUsers.ADPassword = VinaUtil.EncryptMD5Hash(Convert.ToString(fld_txtPassword.EditValue));
            ADUsers.FK_HREmployeeID = Convert.ToInt32(fld_lkeHREmployeeID.EditValue);
            ADUsers.FK_ADUserGroupID = Convert.ToInt32(fld_lkeUserGroup.EditValue);
            ADUsers.ADUserActiveCheck = Convert.ToBoolean(fld_chkIsActive.EditValue);
        }

        private void UpdateUI()
        {
            fld_txtUsername.EditValue = ADUsers.ADUserName;
            fld_txtPassword.EditValue = string.Empty;
            fld_txtRePassword.EditValue = string.Empty;
            fld_lkeHREmployeeID.EditValue = ADUsers.FK_HREmployeeID;
            fld_lkeUserGroup.EditValue = ADUsers.FK_ADUserGroupID;
            fld_chkIsActive.EditValue = ADUsers.ADUserActiveCheck;
        }
    }
}