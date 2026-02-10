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

namespace DVLD.Tests
{
    public partial class frmTakeTest: Form
    {
        private clsTestType.enTestType _Mode { get; set; }
        private int _TestAppointmentID { get; set; }
        private clsTestAppointment _TestAppointmentInfo { get; set; }
        private clsTest _TestInfo { get; set; }
        private clsTestType _TestTypeInfo { get; set; }
        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            _TestTypeInfo = clsTestType.Find((int)TestType);
            _Mode = TestType; 
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            gboxTest.Text = _TestTypeInfo.TestTypeTitle + " Test";
            _LoadTestInfo();

        }
        private void _LoadTestInfo()
        {
            lblDLAppID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _TestTypeInfo.TestTypeTitle;
            lblName.Text = clsLocalDrivingLicenseApplication.Find(_TestAppointmentInfo.LocalDrivingLicenseApplicationID).FullName;
            lblTrails.Text = clsTestAppointment.TrailsCountForThisTest(_TestAppointmentInfo.LocalDrivingLicenseApplicationID, _Mode).ToString();
            lblDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();

        }
        private void _SetTestInfo()
        {
            _TestInfo = new clsTest();
            _TestInfo.TestAppointmentID = _TestAppointmentID;
            _TestInfo.TestResult = rBtnPass.Checked;
            _TestInfo.Notes = txtNotes.Text;
            _TestInfo.CreatedByUserID = clsGlobal.User.UserID;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SetTestInfo();
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!_TestInfo.Save())
            {
                MessageBox.Show("Failed to save the test result, please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestAppointmentInfo.IsLocked = true;
            if(!_TestAppointmentInfo.Save())
            {
                
                MessageBox.Show("Test Result Didn't Saved Successfully", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Test Result Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void rBtnPass_Validating(object sender, CancelEventArgs e)
        {
            if(!rBtnPass.Checked && !rBtnFail.Checked)
            {
                e.Cancel = true;
                errorProvider1.SetError(rBtnPass, "You must select Pass or Fail");
            }
            else
            {
                errorProvider1.SetError(rBtnPass, "");
            }
        }
    }
}
