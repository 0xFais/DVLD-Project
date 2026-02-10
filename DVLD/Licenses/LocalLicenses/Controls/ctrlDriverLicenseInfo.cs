using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using System.Runtime.InteropServices;

namespace DVLD.Licenses.LocalLicenses.Controls
{
    public partial class ctrlDriverLicenseInfo: UserControl
    {
        public int LicenseID { get; private set; }
        private clsLicense _LicenseInfo { get; set; }
        private clsDriver _DriverInfo { get; set; }
        private clsPerson _PersonInfo { get; set; }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _ReSetInfo()
        {
            lblClassName.Text = "";
            lblFullName.Text = "";
            lblLicenseID.Text = "";
            lblNationalNo.Text = "";
            lblGender.Text = "";
            lblIssueDate.Text = "";
            lblIssueReason.Text = "";
            lblNotes.Text = "";
            lblActive.Text = "";
            lblDateOfBirth.Text = "";
            lblDriverID.Text = "";
            lblExpirationDate.Text = "";
            lblIsDetained.Text = "";
        }
        private void _SetInfo()
        {
            lblClassName.Text = _LicenseInfo.LicenseClassInfo.ClassName;
            lblFullName.Text = _PersonInfo.FullName;
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblGender.Text = _PersonInfo.Gender == 1 ? "Male" : "Female";
            lblIssueDate.Text = _LicenseInfo.IssueDate.ToShortDateString();
            lblIssueReason.Text = _LicenseInfo.IssueReasonText;
            lblNotes.Text = _LicenseInfo.Notes;
            lblActive.Text = _LicenseInfo.IsActive ? "Active" : "Not Active";
            lblDateOfBirth.Text = _PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = "";
        }
        public bool LoadDriverLicense(int LicenseID)
        {
            _ReSetInfo();
            this.LicenseID = LicenseID;
            _LicenseInfo = clsLicense.Find(LicenseID);
            if (_LicenseInfo == null)
            {
                return false;
            }
            _DriverInfo = clsDriver.FindByDriverID(_LicenseInfo.DriverID);
            if (_DriverInfo == null)
            {
                return false;
            }
            _PersonInfo = clsPerson.Find(_DriverInfo.PersonID);
            if(_PersonInfo == null)
            {
                return false;
            }
            _SetInfo();
            return true;

        }

    }
}
