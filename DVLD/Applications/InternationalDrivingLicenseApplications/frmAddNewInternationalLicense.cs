using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.GlobalClasses;

namespace DVLD.Applications.InternationalDrivingLicenseApplications
{
    public partial class frmAddNewInternationalLicense : Form
    {
        public int DriverLicenseID { get; set; }
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.DataBack += SetDriverLicenseID;
        }
        private void _LoadApplicationInfoData()
        {
            
        }
        private void AddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            LinklblShowHistoryLicense.Enabled = false;
            LinklblShowLicenseInfo.Enabled = false;
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.User.UserName;
        }
        //delegate
        public void SetDriverLicenseID(object sender, int DriverLicenseID)
        {
            btnIssue.Enabled = false;
            LinklblShowHistoryLicense.Enabled = false;
            LinklblShowLicenseInfo.Enabled = false;
            this.DriverLicenseID = DriverLicenseID;
            clsLicense License = clsLicense.Find(DriverLicenseID);
            if(License == null)
            {
                MessageBox.Show("Driver License not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(License.LicenseClassID != 3)
            {
                LinklblShowHistoryLicense.Enabled = true;
                MessageBox.Show("Only Ordinary Driving License (Class 3) is eligible for International Driving License.", "Ineligible License Class", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            if(clsInternationalLicense.IsThisLicenseHaveAnInternationalLicense(DriverLicenseID))
            {
                LinklblShowHistoryLicense.Enabled = true;
                LinklblShowLicenseInfo.Enabled = true;
                MessageBox.Show("This Driver License already has an International Driving License.", "Duplicate International License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LinklblShowHistoryLicense.Enabled = true;
            btnIssue.Enabled = true;
            lblLocalLicenseID.Text = License.LicenseID.ToString();
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinklblShowHistoryLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void LinklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsInternationalLicense License = new clsInternationalLicense(DriverLicenseID, clsGlobal.User.UserID);
            if(License.Save())
            {
                MessageBox.Show("International Driving License issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                lblInternationAppID.Text = License.ApplicationID.ToString();
                lblInternationlLicenseID.Text = License.InternationalLicenseID.ToString();
                LinklblShowLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Failed to issue International Driving License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LinklblShowLicenseInfo.Enabled = true;
        }
    }
}
