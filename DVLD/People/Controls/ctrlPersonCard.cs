using DVLD_Buisness;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public bool LoadPersonInfoByPersonID(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                _ResetValues();
                return false;
            }
            _FillPersonInfo();
            return true;
        }
        public bool LoadPersonInfoByNationalNo(string NationalNumber, ref int PersonID)
        {
            _Person = clsPerson.Find(NationalNumber);
            if (_Person == null)
            {
                _ResetValues();
                return false;
            }
            _FillPersonInfo();
            PersonID = _Person.PersonID;
            return true;
        }

        public void ResetValues()
        {
            _ResetValues();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        private void _ResetValues()
        {
            lblAddress.Text = "??????";
            lblCountry.Text = "??????";
            lblDateOfBIrth.Text = "??????";
            lblEmail.Text = "??????";
            lblGender.Text = "??????";
            lblID.Text = "-1";
            lblName.Text = "??????";
            lblNationalNumber.Text = "???????";
            lblPhone.Text = "??????";
        }
        private void _FillPersonInfo()
        {
            lblID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            _Person.NationalNo.ToString();
            lblPhone.Text = _Person.Phone.ToString();
            lblEmail.Text = _Person.Email.ToString();
            clsCountry country = clsCountry.Find(_Person.NationalityCountryID);
            lblCountry.Text = country.CountryName;
            lblAddress.Text = _Person.Address.ToString();
            lblDateOfBIrth.Text = _Person.DateOfBirth.ToString();
            lblNationalNumber.Text = _Person.NationalNo.ToString();
            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
            {
                pbPersonPicture.Image = Properties.Resources.Male_512;
            }
            else
            {
                pbPersonPicture.Image = Properties.Resources.Female_512;
            }
            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonPicture.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
