using System;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD.Licenses.InternationalLicenses.Controls
{
    public partial class ctrlShowInternationalLicenseInfo : UserControl
    {
        private clsInternationalLicense ILicense {get; set;}
        public ctrlShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            this.ILicense = clsInternationalLicense.Find(InternationalLicenseID);
        }

        private void _LoadLicenseInfo()
        {
            clsPerson person = clsPerson.Find(ILicense.ApplicationInfo.ApplicantPersonID);
            lblName.Text = person.FullName;
            lblNationalNo.Text =  person.NationalNo;
            lblAppID.Text = ILicense.ApplicationID.ToString();
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = ILicense.DriverID.ToString();
            lblExpDate.Text = ILicense.ExpirationDate.ToShortDateString();
            lblGender.Text = person.Gender == 0 ? "Male" : "Female";
            lblIntLicenseID.Text = ILicense.InternationalLicenseID.ToString();
            lblIsActive.Text = ILicense.IsActive ? "Yes" : "No";
            lblissueDate.Text = ILicense.IssueDate.ToShortDateString();
            lblLicenseID.Text = ILicense.IssueUsingLocalLicenseID.ToString();
        }
        private void ctrlShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }
    }
}