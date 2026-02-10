using DVLD_Buisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _User = clsUser.Find(UserID);

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_User.UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Fill all fields First ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!_User.CheckPassword(txtCurrentPassword.Text))
            {
                MessageBox.Show("The Password Is incorrect ", "Error", MessageBoxButtons.OK);
                return;
            }
            _User.Password = txtNewPassword.Text;
            if (!_User.Save())
            {
                MessageBox.Show("Didn't save someting off", "Error", MessageBoxButtons.OK);
                return;
            }
            //the password changed successfully
            _User.Password = clsUser.ComputeHash(txtNewPassword.Text);
            MessageBox.Show("Password has changed ", "Saved", MessageBoxButtons.OK);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Please enter a valid Username");
                return;
            }
            errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text.Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password Must Be more then 4 charachers");
                return;
            }
            errorProvider1.SetError(txtNewPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password must same as New Password");
                return;
            }
            errorProvider1.SetError(txtConfirmPassword, null);
        }
    }
}
