using DVLD_Buisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { AddNewUser = 0, UpdateUser = 1 }
        private enMode _Mode;
        private int _UserID = -1;
        private clsUser _User;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNewUser;
            _UserID = -1;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateUser;
            _UserID = UserID;
        }
        private void UpdateMode()
        {
            //checking if the userID exists
            _User = clsUser.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("The UserID wans't Found, you'll be transfer to the Add New User Form");
                NewMode();
                return;
            }
            ctrlPersonCardFilter1.Enabled = false;
            // Load the user data
            _UserID = _User.UserID;
            ctrlPersonCardFilter1.LoadPersonValuesByID(_User.PersonID);
            txtUserName.Text = _User.UserName;
            //txtPassword.Text = _User.Password;
            //txtRepeatPassword.Text = _User.Password;
            lblUserID.Text = _User.UserID.ToString();
            chbActive.Checked = _User.IsActive;
            lblTitle.Text = "Update User";
        }
        private void NewMode()
        {
            _User = new clsUser();
            txtPassword.Text = "";
            txtRepeatPassword.Text = "";
            txtUserName.Text = "";
            chbActive.Checked = false;
            //Reset Default values of person info
            ctrlPersonCardFilter1.LoadPersonValuesByID(-1);
            lblTitle.Text = "Add New User";
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            NewMode();
            if (_Mode == enMode.UpdateUser)
            {
                UpdateMode();
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidatePersonID())
            {
                btnSave.Enabled = true;
                tpUserInfo.Enabled = true;
                tcAddUpdateUser.SelectedTab = tcAddUpdateUser.TabPages["tpUserInfo"];
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate all fileds
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // validate Person ID
            if (!ValidatePersonID())
            {
                MessageBox.Show("Person ID is not valid!, please choose another person",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //set user info
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.PersonID = ctrlPersonCardFilter1._PersonID;
            _User.IsActive = chbActive.Checked;
            //save
            if (!_User.Save())
            {
                MessageBox.Show("The user didnt' saved Succesfullly", "not Save", MessageBoxButtons.OK);
                return;
            }
            _Mode = enMode.UpdateUser;
            lblUserID.Text = _User.UserID.ToString();
            lblTitle.Text = "Update User";
            ctrlPersonCardFilter1.Enabled = false;
            MessageBox.Show("THe user Saved Succesfully", "Saved", MessageBoxButtons.OK);
            return;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Please enter a valid Username");
                return;
            }
            if (_Mode == enMode.UpdateUser)
            {
                if (clsUser.DoesUserExistByUserName(txtUserName.Text.Trim()) && (_User.UserName != txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "this Username already used Exist, please use another user name");
                    return;
                }
            }
            else
            {
                if (clsUser.DoesUserExistByUserName(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "this Username already used, please use another one");
                    return;
                }
            }
            errorProvider1.SetError(txtUserName, null);
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Cannot be blank");
                return;
            }
            if (txtPassword.Text.Trim().Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "the Password must at least be 4 charachters");
                return;
            }
            errorProvider1.SetError(txtPassword, null);
        }
        private void txtRepeatPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRepeatPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRepeatPassword, "Cannot be blank");
                return;
            }
            if (txtRepeatPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtRepeatPassword, "Confirm Password must be the same as password");
                return;
            }
            errorProvider1.SetError(txtRepeatPassword, null);
        }
        private bool ValidatePersonID()
        {
            if (ctrlPersonCardFilter1._PersonID == -1)
            {
                MessageBox.Show("Please Choose a person to sign him as user ");
                return false;
            }
            if (_Mode == enMode.UpdateUser)
            {
                if (clsUser.DoesUserExistByPersonID(ctrlPersonCardFilter1._PersonID) && ctrlPersonCardFilter1._PersonID != _User.PersonID)
                {
                    MessageBox.Show("This Person is Already a User, Please choose another Person");
                    return false;
                }
            }
            else
            {
                if (clsUser.DoesUserExistByPersonID(ctrlPersonCardFilter1._PersonID))
                {
                    MessageBox.Show("This Person is Already a User, Please choose another Person");
                    return false;
                }
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
