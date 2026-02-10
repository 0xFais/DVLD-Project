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
using System.Security.Cryptography.X509Certificates;

namespace DVLD.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class ctrlLDLAppInfo: UserControl
    {
        public ctrlLDLAppInfo()
        {
            InitializeComponent();
        }
        private clsLocalDrivingLicenseApplication _LDLApp;
        private void _LoadLDLAppInfo()
        {
            ctrlApplicationInfo1.LoadApplicationInfo(_LDLApp.ApplicationID);
            lblAppliedForLicense.Text = _LDLApp.LicenseClassInfo.ClassName;
            lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplictionID.ToString();
            lblPassedTests.Text = _LDLApp.TestsPassed.ToString();
        }
        private void _ResetLDLAppInfo() 
        {
            //reset ctrlApplicationInfo1 to default values
            ctrlApplicationInfo1.LoadApplicationInfo(-1);
            lblAppliedForLicense.Text = string.Empty;
            lblLDLAppID.Text = string.Empty;
            lblPassedTests.Text = string.Empty;
        }
        public bool LoadLDLAppInfo(int LDLAppID)
        {
            _LDLApp = clsLocalDrivingLicenseApplication.Find(LDLAppID);
            if(_LDLApp != null)
            {
                _LoadLDLAppInfo();
                return true;
            }
            else
            {
                _ResetLDLAppInfo();
                return false;
            }
        }

        private void ctrlLDLAppInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
