using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmShowUserInfo : Form
    {
        private clsUser _User;
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            _User = clsUser.Find(UserID);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadInfo()
        {
            ctrlPersonCard1.LoadPersonInfoByPersonID(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            if (_User.IsActive)
            {
                lblIsActive.Text = "Active";
            }
            else
            {
                lblIsActive.Text = "Not Active";
            }
        }
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }
    }
}
