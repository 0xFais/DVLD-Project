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

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationInfo: UserControl
    {
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }
        private clsApplications _App;
        private void _LoadAppInfo()
        {
            lblID.Text = _App.ApplicantPersonID.ToString();
            lblApplicant.Text = _App.FullName;
            lblCreatedByUserName.Text = _App.UserInfo.UserName;
            lblDate.Text = _App.ApplicationDate.ToShortDateString();
            lblFees.Text = _App.ApplicationFees.ToString();
            lblStatus.Text = _App.ApplicationStatus.ToString();
            lblType.Text = _App.ApplicationTypeInfo.ApplicationTypeName;
            lblStatusDate.Text = _App.LastStatusDate.ToShortDateString();
        }
        private void _ResetAppInfo()
        {
            lblID.Text = string.Empty;
            lblApplicant.Text = string.Empty;
            lblCreatedByUserName.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblFees.Text = string.Empty;
            lblStatus.Text = string.Empty;
            lblType.Text = string.Empty;
            lblStatusDate.Text = string.Empty;
        }
        public bool  LoadApplicationInfo(int ApplicationID)
        {
            _App = clsApplications.FindBaseApplication(ApplicationID);
            if (_App == null)
            {
                _ResetAppInfo();
                return false;
            }
            _LoadAppInfo();
            return true;
        } 
    }
}
