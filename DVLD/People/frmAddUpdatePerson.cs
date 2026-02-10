using DVLD.GlobalClasses;
using DVLD_Buisness;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        enum enGender { enMale = 0, enFemale = 1 };
        enum enMode { enAddNew = 0, enUpdate = 1 };
        private enMode _Mode;
        private int _PersonID = -1;
        private clsPerson _Person;

        public frmAddUpdatePerson()
        {
            _Mode = enMode.enAddNew;
            InitializeComponent();
        }
        public frmAddUpdatePerson(int PersonID)
        {
            _Mode = enMode.enUpdate;
            _PersonID = PersonID;

            InitializeComponent();
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComoboBox();
            if (_Mode == enMode.enAddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update";
            }
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Properties.Resources.Male_512;
            }
            else
            {
                pbPersonImage.Image = Properties.Resources.Female_512;
            }
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-100);

            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");

            tbAddress.Text = "";
            tbEmail.Text = "";
            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNumber.Text = "";
            tbPhone.Text = "";
            rbMale.Checked = true;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.enUpdate)
            {
                _LoadInfo();
            }
        }
        private void _LoadInfo()
        {

            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblID.Text = _Person.PersonID.ToString();
            lblID.Text = _PersonID.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNumber.Text = _Person.NationalNo;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            tbAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gender == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);
        }
        private void _SetPersonInfo()
        {
            _Person.FirstName = tbFirstName.Text;
            _Person.SecondName = tbSecondName.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.NationalNo = tbNationalNumber.Text;
            _Person.Phone = tbPhone.Text;
            _Person.Email = tbEmail.Text;
            _Person.Address = tbAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked == true)
            {
                _Person.Gender = 0;
            }
            else
            {
                _Person.Gender = 1;
            }
            clsCountry country = clsCountry.Find(cbCountries.Text);
            _Person.NationalityCountryID = country.ID;
            _Person.ImagePath = "";
        }
        private void Save()
        {
            _SetPersonInfo();
            if (_Person.Save())
            {
                if (_Mode == enMode.enAddNew)
                {
                    _Mode = enMode.enUpdate;
                    lblTitle.Text = "Update Person";
                    _PersonID = clsPerson.Find(_Person.NationalNo).PersonID;
                }
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Save();
            _LoadInfo();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _PersonID);
            this.Close();
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {

        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (tbEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidate.ValidateEmail(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
            }
            ;

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbNationalNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNumber, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNumber, null);
            }

            //Make sure the national number is not used by another person
            if (tbNationalNumber.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(tbNationalNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNumber, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(tbNationalNumber, null);
            }
        }

    }
}
