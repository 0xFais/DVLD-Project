using DVLD.GlobalClasses;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmScheduleTest: Form
    {
        private enum enMode
        {
            AddNew = 1,
            Update = 2,
            Info = 3
        }
        private enum enStatus { FirstTime = 1 , Retake = 2}
        // 3 * 2 * 2 = 12 possible mode for this page 
        // Mode and status and testtype
        private enStatus _Status { get; set; }
        private enMode _Mode { get; set; }
        private clsTestType.enTestType _TestType { get; set; }
        private clsTestType _TestTypeInfo { get; set; }
        private clsLocalDrivingLicenseApplication _LDLApp { get; set; }
        private clsTestAppointment _TestAppointmentInfo { get; set; }

        public frmScheduleTest(int LDLAppID,clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LDLApp = clsLocalDrivingLicenseApplication.Find(LDLAppID);
            _TestType = TestType;
            _TestTypeInfo = clsTestType.Find((int)_TestType);
            _TestAppointmentInfo = new clsTestAppointment(TestType, LDLAppID, clsGlobal.User.UserID);
            _Mode = enMode.AddNew;
        }
        public frmScheduleTest(int TestAppointmentID, bool IsLocked)
        {
            InitializeComponent();
           _TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID); 
           _LDLApp = clsLocalDrivingLicenseApplication.Find(_TestAppointmentInfo.LocalDrivingLicenseApplicationID);
           _TestType = (clsTestType.enTestType)_TestAppointmentInfo.TestTypeID;
           _TestTypeInfo = clsTestType.Find(_TestAppointmentInfo.TestTypeID);
            _Mode = IsLocked ? enMode.Info : enMode.Update;
        }
        // in loading form phase we specify and status 
        //
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _Status = _TestAppointmentInfo.CheckRetake() ? enStatus.Retake : enStatus.FirstTime;
            if(_Mode != enMode.Info)
            {
                dtpDate.MinDate = DateTime.Now;
            }
            // writing the correct title based on all 12 modes for this form 
            _PrintTitle();
            _ResetTestAppointmentInfo();
            if (_Mode == enMode.Update || _Mode == enMode.Info)
            {
                _LoadTestAppointmentInfo();
            }
            _ResetRetakeInfo();
            if (_Status == enStatus.Retake)
            {
                _LoadRetakeInfo();
            }
            
        }
        private void _PrintTitle()
        {
            
            string strMode = "";
            switch (_Mode)
            {
                case enMode.AddNew:
                    strMode = "Add New ";
                    break;
                case enMode.Update:
                    strMode = "Update ";
                    break;
                case enMode.Info:
                    strMode = "Info ";
                    break;
            } 
            switch (_TestType)
            {
                case clsTestType.enTestType.Vision :
                    strMode += "Vision Test Appointment";
                    break;
                case clsTestType.enTestType.Written :
                    strMode += "Written Test Appointment";
                    break;
                case clsTestType.enTestType.Street :
                    strMode += "Street Test Appointment";
                    break;
            }
            lblTitle.Text = strMode; 
        }
        //all these 4 function to load the form and fetch the data for all 12 modes
        private void _LoadRetakeInfo()
        {
            lblRAppFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).Fees.ToString();
            lblTotalFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            if (_Mode != enMode.AddNew) { lblRTestAppID.Text = _TestAppointmentInfo.RetakeTestID.ToString(); }
        }
        private void _ResetRetakeInfo()
        {
            lblRAppFees.Text = "???";
            lblTotalFees.Text = "???";
            lblRTestAppID.Text = "???";
            if(_Status != enStatus.Retake)
            {
                gboxRetakeInfo.Enabled = false;
            }
        }
        private void _LoadTestAppointmentInfo()
        {
            dtpDate.Value = DateTime.Now;
            if (_Mode == enMode.Info)
            {
                dtpDate.Value = _TestAppointmentInfo.AppointmentDate;
                btnSave.Enabled = false; 
                dtpDate.Enabled = false;
            }
        }
        private void _ResetTestAppointmentInfo()
        {
            lblLDLappID.Text = _LDLApp.LocalDrivingLicenseApplictionID.ToString();
            lblDclass.Text = _LDLApp.LicenseClassInfo.ClassName;
            lblName.Text = _LDLApp.FullName;
            lblFees.Text = _TestTypeInfo.TestTypeFees.ToString();
            dtpDate.Value = DateTime.Today.AddDays(1);
            lblTrail.Text = clsTestAppointment.TrailsCountForThisTest(_LDLApp.LocalDrivingLicenseApplictionID, _TestType).ToString();
            
        }   
        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointmentInfo.AppointmentDate = dtpDate.Value;
            if (_TestAppointmentInfo.Save())
            {
                MessageBox.Show("Saved Successfully");
            }
            else
            {
                MessageBox.Show("Saved Failed");
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
