using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD.Licenses;
using DVLD.Licenses.LocalLicenses;
using DVLD.People;

namespace DVLD.Applications.InternationalDrivingLicenseApplications
{
    public partial class frmListInternationalDrivingLicenseApplications : Form
    {
        private DataTable dtInternationalDrivingLicenseApplications;
        public frmListInternationalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _ReloadDgv()
        {
            dtInternationalDrivingLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            dgvILApps.DataSource = dtInternationalDrivingLicenseApplications;
            lblRecordsCount.Text = dtInternationalDrivingLicenseApplications.Rows.Count.ToString();
        }
//Filters
        private void _AddTheFilters()
        {
            cBoxFilters.Items.Add("None");
            cBoxFilters.Items.Add("International License ID");
            cBoxFilters.Items.Add("Application ID");
            cBoxFilters.Items.Add("Driver ID");
            cBoxFilters.Items.Add("Local License ID");
            cBoxFilters.Items.Add("Is Active");
            cBoxFilters.SelectedIndex = 0;

            cBoxIsActiveFilters.Items.Add("All");
            cBoxIsActiveFilters.Items.Add("Active");
            cBoxIsActiveFilters.Items.Add("Note Active");
            cBoxIsActiveFilters.SelectedIndex = 0;
        }
        private string _GetTheFilterString()
        {
            switch (cBoxFilters.SelectedIndex)
            {
               case 0:
                   return "None";
               case 1:
                   return "InternationalLicenseID";
               case 2:
                   return "ApplicationID";
               case 3:
                   return "DriverID";
               case 4:
                   return "IssuedUsingLocalLicenseID";
               case 5:
                   return "IsActive";
               default:
                   return "None";
            }
        }
        private void cBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterSearch.Visible = !(_GetTheFilterString() == "None" || _GetTheFilterString() == "IsActive");
            cBoxIsActiveFilters.Visible = _GetTheFilterString() == "IsActive";
            txtFilterSearch.Text = "";
            dtInternationalDrivingLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text =  dgvILApps.Rows.Count.ToString();
        }
        private void txtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            if (_GetTheFilterString() != "IsActive" && txtFilterSearch.Text.Trim() != "")
            {
                dtInternationalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                    _GetTheFilterString(), txtFilterSearch.Text.Trim());
            }
            else
            {
                dtInternationalDrivingLicenseApplications.DefaultView.RowFilter = "";
            }

            lblRecordsCount.Text = dgvILApps.RowCount.ToString();
        }
        private void cBoxIsActiveFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxIsActiveFilters.SelectedIndex == 0)
            {
                dtInternationalDrivingLicenseApplications.DefaultView.RowFilter = "";
            }
            else
            {
                dtInternationalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", _GetTheFilterString(),cBoxIsActiveFilters.SelectedIndex == 1 ? 1 : 0);
            }

            lblRecordsCount.Text = dgvILApps.RowCount.ToString();
        }
        //Loading elements
        private void frmListInternationalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _ReloadDgv();
            _AddTheFilters();
        }
        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo(clsApplications.FindBaseApplication((int)dgvILApps.CurrentRow.Cells[1].Value).ApplicantPersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLicenseInfo((int)dgvILApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(clsApplications.FindBaseApplication((int)dgvILApps.CurrentRow.Cells[1].Value).ApplicantPersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
            _ReloadDgv();
        }

    }
}