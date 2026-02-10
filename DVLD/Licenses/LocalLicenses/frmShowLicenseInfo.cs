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

namespace DVLD.Licenses.LocalLicenses
{
    public partial class frmShowLicenseInfo : Form
    {
        private int _LicenseID { get; set; }
        public frmShowLicenseInfo(int ApplicationID)
        {
            InitializeComponent();
            clsLicense license = clsLicense.FindByApplicationID(ApplicationID); 
            _LicenseID = license.LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadDriverLicense(_LicenseID);
        }
    }
}
