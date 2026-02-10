using DVLD_Buisness;
using System.Windows.Forms;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();

        }
        public bool LoadUserInfo(int UserID)
        {
            if (!clsUser.DoesUserExistByUserID(UserID))
            {
                MessageBox.Show("Didn't found any User by this " + UserID.ToString() + " ID");
                return false;
            }
            _ResetInfo();
            _SetUserInfo(UserID);
            return true;
        }
        private void _SetUserInfo(int UserID)
        {
            clsUser User = clsUser.Find(UserID);
            if (User.IsActive)
            {
                lblActive.Text = "Yes";
            }
            else
            {
                lblActive.Text = "No";
            }
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = UserID.ToString();
            ctrlPersonCard1.LoadPersonInfoByPersonID(User.PersonID);
        }
        private void _ResetInfo()
        {
            ctrlPersonCard1.ResetValues();
            lblUserID.Text = "????";
            lblUserName.Text = "????";
            lblActive.Text = "????";
        }
    }
}
