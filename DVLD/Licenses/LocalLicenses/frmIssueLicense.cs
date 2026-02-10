using DVLD.GlobalClasses;
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

namespace DVLD.Licenses
{
    public partial class frmIssueLicense: Form
    {
        private int _LDLAppID { get; set; }
        private clsLocalDrivingLicenseApplication _LDLAppInfo { get; set; }
        public frmIssueLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LDLAppID = LocalDrivingLicenseID;
            _LDLAppInfo = clsLocalDrivingLicenseApplication.Find(_LDLAppID);
        }

        private void frmIssueLicense_Load(object sender, EventArgs e)
        {
            ctrlLDLAppInfo1.LoadLDLAppInfo(_LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int licenseID = this._LDLAppInfo.IssueLicenseFirstTime(txtNotes.Text, clsGlobal.User.UserID); 
            if(licenseID != -1)
            {
                MessageBox.Show("License issued successfully. License ID: " + licenseID.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to issue license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

    }
}
