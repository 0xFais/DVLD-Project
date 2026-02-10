using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments: Form
    {
        private clsTestType.enTestType _Mode { get; set; }
        private clsLocalDrivingLicenseApplication _LDLApp;
        private DataTable _dtAppointments;

        public frmListTestAppointments(int LDLAppID, clsTestType.enTestType TestType )
        {
            InitializeComponent();
            _LDLApp = clsLocalDrivingLicenseApplication.Find(LDLAppID);
            _Mode = TestType;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Reset()
        {
            switch(_Mode)
            {
                case clsTestType.enTestType.Vision:
                    _dtAppointments = clsTestAppointment.GetAllTestAppointmentsForLDLAppAndTestType(_LDLApp.LocalDrivingLicenseApplictionID, (int)clsTestType.enTestType.Vision);
                    lblTitle.Text = "Vision Test Appointments";
                    break;
                case clsTestType.enTestType.Written:
                    _dtAppointments = clsTestAppointment.GetAllTestAppointmentsForLDLAppAndTestType(_LDLApp.LocalDrivingLicenseApplictionID, (int)clsTestType.enTestType.Written);
                    lblTitle.Text = "Written Test Appointments";
                    break;
                case clsTestType.enTestType.Street:
                    _dtAppointments = clsTestAppointment.GetAllTestAppointmentsForLDLAppAndTestType(_LDLApp.LocalDrivingLicenseApplictionID, (int)clsTestType.enTestType.Street);
                    lblTitle.Text = "Street Test Appointments";
                    break;
            }

            _dtAppointments =
                clsTestAppointment.GetAllTestAppointmentsForLDLAppAndTestType(_LDLApp.LocalDrivingLicenseApplictionID,
                    (int)_Mode);
            
            dgvAppointments.DataSource = _dtAppointments;
            dgvAppointments.RowHeadersVisible = false;
            lblAppointmentRecords.Text = _dtAppointments.Rows.Count.ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _Reset();
            ctrlLDLAppInfo1.LoadLDLAppInfo(_LDLApp.LocalDrivingLicenseApplictionID);
            //right positioning for the list
            dgvAppointments.Columns[0].Width = 105;
            dgvAppointments.Columns[1].Width = 80;
            dgvAppointments.Columns[2].Width = 160;
            dgvAppointments.Columns[3].Width = 105;
            dgvAppointments.Columns[4].Width = 80;
            dgvAppointments.Columns[6].Width = 75;
            dgvAppointments.Columns[7].Width = 140;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            //check if the Application have an active Test Appoinment and if did he pass this test
            if(clsTestAppointment.DoesThisApplicationHaveThisTestAppointmentAndItsActive(_LDLApp.LocalDrivingLicenseApplictionID, _Mode ))
            {
                MessageBox.Show("This Application Have this Test Appointment And it's Active Test");
                return;
            }
            if(clsTest.DoesThisApplicationPassThisTest(_LDLApp.LocalDrivingLicenseApplictionID, (int)_Mode))
            {   
                MessageBox.Show("This application pass this test");
                return;
            }
            Form frm = new frmScheduleTest(_LDLApp.LocalDrivingLicenseApplictionID, _Mode);
            frm.ShowDialog();
            _Reset();
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmScheduleTest((int)dgvAppointments.CurrentRow.Cells[0].Value,(bool)dgvAppointments.CurrentRow.Cells[6].Value);
            frm.ShowDialog();
            _Reset();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value, _Mode);
            frm.ShowDialog();
            _Reset();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            takeTestToolStripMenuItem.Enabled = !(bool)dgvAppointments.CurrentRow.Cells[6].Value;
        }
    }
}
