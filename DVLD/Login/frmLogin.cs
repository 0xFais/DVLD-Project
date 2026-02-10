using DVLD.GlobalClasses;
using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
            this.Hide();
            Form frm = new frmMain();
            frm.ShowDialog();
            this.Close();
        }
    }
}
