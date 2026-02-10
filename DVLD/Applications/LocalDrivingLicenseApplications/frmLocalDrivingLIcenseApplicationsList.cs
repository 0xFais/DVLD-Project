using DVLD.Licenses;
using DVLD.Licenses.LocalLicenses;
using DVLD.Tests;
using DVLD_Buisness;
using System;
using System.Data;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmLocalDrivingLIcenseApplicationsList : Form
    {
        public frmLocalDrivingLIcenseApplicationsList()
        {
            InitializeComponent();
        }
        private DataTable _dt = new DataTable();
        private string _CurrentFilter = "None";
        private void _ReloadDGV()
        {
            _dt = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicensApplications();
            dgvLDLA.DataSource = _dt;
            lblCount.Text = dgvLDLA.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FilterApp()
        {
            //Add Filters options and set it to None 
            cbFilters.SelectedText = "None";
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("L.D.L.AppID");
            cbFilters.Items.Add("National No.");
            cbFilters.Items.Add("Full Name");
            cbFilters.Items.Add("Status");
            cbFilters.SelectedIndex = 0; // Set default selection to "None"
            txtFilterSearch.Visible = false;
        }
        private void dgvSetColumns()
        {
            dgvLDLA.Columns[0].Width = 70;
            dgvLDLA.Columns[0].HeaderText = "LDL App ID";

            dgvLDLA.Columns[1].Width = 190;
            dgvLDLA.Columns[2].Width = 73;
            dgvLDLA.Columns[3].Width = 212;

            dgvLDLA.Columns[5].Width = 50;
            dgvLDLA.Columns[5].HeaderText = "Test Passed";

            dgvLDLA.Columns[6].Width = 60;
        }
        private void LocalDrivingLIcenseApplicationsList_Load(object sender, EventArgs e)
        {
            dgvLDLA.RowHeadersVisible = false;
            //load dgv data and set count number
            _ReloadDGV();
            FilterApp();
            if (dgvLDLA.Rows.Count > 0)
            {
                dgvSetColumns();
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilters.SelectedItem)
            {
                case "L.D.L.AppID":
                    _CurrentFilter = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    _CurrentFilter = "NationalNo";
                    break;
                case "Full Name":
                    _CurrentFilter = "FullName";
                    break;
                case "Status":
                    _CurrentFilter = "Status";
                    break;
                default:
                    _CurrentFilter = "None";
                    break;
            }
            if (_CurrentFilter != "None")
            {
                txtFilterSearch.Visible = true;
            }
            else
            {
                txtFilterSearch.Visible = false;
            }

            txtFilterSearch.Text = "";
        }

        private void txtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterSearch.Text.ToString().Trim()))
            {
                _dt.DefaultView.RowFilter = "";
                lblCount.Text = _dt.Rows.Count.ToString();
                return;
            }

            if (_CurrentFilter == "LocalDrivingLicenseApplicationID")
            {
                _dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", _CurrentFilter, txtFilterSearch.Text.Trim());
            }
            else
            {
                _dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", _CurrentFilter, txtFilterSearch.Text.Trim());
            }
            lblCount.Text = _dt.Rows.Count.ToString();
        }

        private void txtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilter == "LocalDrivingLicenseApplicationID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent the key from being entered into the textbox
                }
            }
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicenseApplications((int)dgvLDLA.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _ReloadDGV();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find((int)dgvLDLA.CurrentRow.Cells[0].Value);
            if (app.Delete())
            {
                MessageBox.Show("Local Driving License Application deleted");
                _ReloadDGV();
                return;
            }
            MessageBox.Show("Local Driving License Application wanst Deleted");
        }

        private void _ResetStripMenuItems()
        {
            viewInfoToolStripMenuItem.Enabled = false;
            updateToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            cancelToolStripMenuItem.Enabled = false;
            scheduleToolStripMenuItem.Enabled = false;
            issueDrivingLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            personLicenseHistoryToolStripMenuItem.Enabled = false;

            visionTestToolStripMenuItem.Enabled = false;
            writtenTestToolStripMenuItem.Enabled = false;
            streetToolStripMenuItem.Enabled = false;
        }
        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ResetStripMenuItems();
            switch (dgvLDLA.CurrentRow.Cells[6].Value.ToString())
            {
                case "New":
                    _NewMode();
                    break;
                case "Cancelled":
                    _CancelledMode();
                    break;
                case "Completed":
                    _CompletedMode();
                    break;
                default:
                    break;
            }
        }
        private void _CompletedMode()
        {
            viewInfoToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = true;
            personLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void _CancelledMode()
        {
            viewInfoToolStripMenuItem.Enabled = true;
            personLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void _NewMode()
        {
            viewInfoToolStripMenuItem.Enabled = true;
            updateToolStripMenuItem.Enabled = true;
            cancelToolStripMenuItem.Enabled = true;
            scheduleToolStripMenuItem.Enabled = true;
            personLicenseHistoryToolStripMenuItem.Enabled = true;
            //for Tests menu Enabling and Disabling
            switch ((int)dgvLDLA.CurrentRow.Cells[5].Value)
            {
                case 0:
                    deleteToolStripMenuItem.Enabled = true;
                    visionTestToolStripMenuItem.Enabled = true;
                    break;
                case 1:
                    writtenTestToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    streetToolStripMenuItem.Enabled = true;
                    break;
                case 3:
                    scheduleToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = true;
                    break;
            }

        }
        private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLDLAppInfo((int)dgvLDLA.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestAppointments((int)dgvLDLA.CurrentRow.Cells[0].Value, clsTestType.enTestType.Vision);
            frm.ShowDialog();
            _ReloadDGV() ;
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmListTestAppointments((int)dgvLDLA.CurrentRow.Cells[0].Value, clsTestType.enTestType.Written);
            form.ShowDialog();
            _ReloadDGV();
        }

        private void streetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestAppointments((int)dgvLDLA.CurrentRow.Cells[0].Value, clsTestType.enTestType.Street);
            frm.ShowDialog();
            _ReloadDGV();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicenseApplications();
            frm.ShowDialog();
            _ReloadDGV();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cancel this Application
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find((int)dgvLDLA.CurrentRow.Cells[0].Value);
            app.ApplicationStatus = clsLocalDrivingLicenseApplication.enStatus.Cancelled;
            if(app.Save())
            {
                MessageBox.Show("Local Driving License Application Cancelled");
                _ReloadDGV();
                return;
            }
            else
            {
                MessageBox.Show("Local Driving License Application was not Cancelled");
            }
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmIssueLicense((int)dgvLDLA.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _ReloadDGV();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLicenseInfo(clsLocalDrivingLicenseApplication.Find((int)dgvLDLA.CurrentRow.Cells[0].Value).ApplicationID);
            frm.ShowDialog();
        }

        private void personLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonLIcenseHistory(clsPerson.Find(dgvLDLA.CurrentRow.Cells[2].Value.ToString()).PersonID);
            frm.ShowDialog();
        }
    }
}