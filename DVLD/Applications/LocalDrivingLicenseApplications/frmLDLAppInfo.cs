using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmLDLAppInfo: Form
    {
        public frmLDLAppInfo(int LDLAppID)
        {
            InitializeComponent();
            ctlrLDLAppInfo1.LoadLDLAppInfo(LDLAppID);
        }

    }
}
