using DVLD.Licenses;
using DVLD.People;
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

namespace DVLD.Drivers
{
    public partial class frmDriversList : Form
    {
        private DataTable _dt;
        public frmDriversList()
        {
            InitializeComponent();
        }
        private void _ReloadDGV()
        {
            _dt = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dt;
            lblDriversCount.Text = dgvDrivers.Rows.Count.ToString();
            dgvDrivers.RowHeadersVisible = false;
        }

        private void frmDriversList_Load(object sender, EventArgs e)
        {
            _ReloadDGV();
            dgvDrivers.Columns[5].Width = 132;
            dgvDrivers.Columns[4].Width += 20;
            dgvDrivers.Columns[3].Width += 120;
            // adding Filters options and set it to None
            cboxFilters.Items.Add("None");
            cboxFilters.Items.Add("Driver ID");
            cboxFilters.Items.Add("Person ID");
            cboxFilters.Items.Add("National No.");
            cboxFilters.Items.Add("Full Name");
            cboxFilters.SelectedIndex = 0; // Set default selection to "None"
            cboxFilters.DropDownStyle = ComboBoxStyle.DropDownList;
            


        }


        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonLIcenseHistory((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Filtering(string FilterString)
        {
            if (FilterString == "Driver ID" || FilterString == "Person ID")
            {
                txtFilters.Visible = true;

            }
            else if (FilterString == "National No." || FilterString == "Full Name")
            {
                txtFilters.Visible = true;
            }
            else
            {
                txtFilters.Visible = false;
            }
        }
        private void cboxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering(cboxFilters.SelectedItem.ToString());
            txtFilters.Text = "";
        }

        private void txtFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboxFilters.Text == "Person ID" || cboxFilters.Text == "Driver ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent the key from being entered into the textbox
                }
            }
        }

        private void txtFilters_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilters.Text.ToString().Trim()))
            {
                _ReloadDGV();
            }
            else
            {
                string filterExpression = "";
                switch (cboxFilters.SelectedItem.ToString())
                {
                    case "Driver ID":
                        filterExpression = $"Convert(DriverID, 'System.String') LIKE '%{txtFilters.Text}%'";
                        break;
                    case "Person ID":
                        filterExpression = $"Convert(PersonID, 'System.String') LIKE '%{txtFilters.Text}%'";
                        break;
                    case "National No.":
                        filterExpression = $"NationalNo LIKE '%{txtFilters.Text}%'";
                        break;
                    case "Full Name":
                        filterExpression = $"FullName LIKE '%{txtFilters.Text}%'";
                        break;
                    default:
                        filterExpression = "";
                        break;
                }
                DataView dv = new DataView(_dt);
                dv.RowFilter = filterExpression;
                dgvDrivers.DataSource = dv;
                lblDriversCount.Text = dgvDrivers.Rows.Count.ToString();
            }
        }
    }
}
