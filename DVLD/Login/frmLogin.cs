using DVLD.GlobalClasses;
using DVLD_Buisness;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            LoadRememberMe();
        }

        private void RememberMe()
        {
            if (File.Exists(clsGlobal.RememberMeFilePath) && !cBoxRememberMe.Checked)
            {
                File.Delete(clsGlobal.RememberMeFilePath);
                return;
            }
            if (cBoxRememberMe.Checked)
            {
                string content = txtUserName.Text + "\n" + txtPassword.Text;
                File.WriteAllText(clsGlobal.RememberMeFilePath, content);
            }
        }

        private void LoadRememberMe()
        {
            if (!File.Exists(clsGlobal.RememberMeFilePath))
            {
                return;
            }
            string[] UserPassword = File.ReadAllLines(clsGlobal.RememberMeFilePath);
            txtUserName.Text = UserPassword[0];
            txtPassword.Text =  UserPassword[1];
            cBoxRememberMe.Checked = true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobal.User = clsUser.FindByUserNameAndPassword(txtUserName.Text, txtPassword.Text);
            if (clsGlobal.User == null)
            {
                MessageBox.Show("The Password or the UserName is incorrect", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!clsGlobal.User.IsActive)
            {
                MessageBox.Show("This User is not active ", "Error", MessageBoxButtons.OK);
                return;
            }

            RememberMe();
            this.Hide();
            Form frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }
    }
}
