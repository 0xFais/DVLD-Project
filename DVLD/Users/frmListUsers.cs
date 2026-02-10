using DVLD_Buisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmListUsers : Form
    {
        private string FilterString = "";
        private DataTable _dt;
        public frmListUsers()
        {
            InitializeComponent();
        }
        private void _ReloadList()
        {
            _dt = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dt;
            lblUserCount.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _ReloadList();
            dgvUsersList.RowHeadersVisible = false;
            //spacing between columns to fit the form correctly
            dgvUsersList.Columns[0].Width = 93;
            dgvUsersList.Columns[1].Width = 100;
            dgvUsersList.Columns[2].Width = 350;
            dgvUsersList.Columns[3].Width = 120;
            dgvUsersList.Columns[4].Width = 110;

            //adding filter box options
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("User ID");
            cbFilters.Items.Add("User Name");
            cbFilters.Items.Add("Active");
            cbFilters.Items.Add("Person ID");
            cbFilters.Items.Add("Full Name");
            //adding active filter box options
            cbActiveFilter.Items.Add("All");
            cbActiveFilter.Items.Add("Active");
            cbActiveFilter.Items.Add("Not Active");
            //default value for the filter box and the active filter box
            cbFilters.Text = "None";
            cbActiveFilter.Visible = false;
            dgvUsersList.Rows[0].Selected = true;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowUserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _ReloadList();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _ReloadList();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUser.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
            {
                _ReloadList();
                MessageBox.Show("User deleted succesffuly");
                return;
            }
            MessageBox.Show("User wasn't Deleted because of issue");
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterSearch.Visible = true;
            cbActiveFilter.Visible = false;
            switch (cbFilters.SelectedItem)
            {
                case "None":
                    FilterString = "None";
                    txtFilterSearch.Visible = false;
                    break;
                case "User ID":
                    FilterString = "UserID";
                    break;
                case "User Name":
                    FilterString = "UserName";
                    break;
                case "Active":
                    FilterString = "IsActive";
                    txtFilterSearch.Visible = false;
                    cbActiveFilter.Visible = true;
                    cbActiveFilter.SelectedIndex = 0;
                    break;
                case "Person ID":
                    FilterString = "PersonID";
                    break;
                case "Full Name":
                    FilterString = "FullName";
                    break;
            }
            _dt.DefaultView.RowFilter = "";
            txtFilterSearch.Text = "";

        }

        private void txtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterSearch.Text.Trim() == "")
            {
                _dt.DefaultView.RowFilter = "";
                lblUserCount.Text = dgvUsersList.Rows.Count.ToString();
                return;
            }
            if (FilterString == "FullName" || FilterString == "UserName")
            { 
                _dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterString, txtFilterSearch.Text.Trim());
            }
                //in this case we deal with integer not string.
            else if (FilterString == "Active")
            {

            }
            else
            {
                _dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterString, txtFilterSearch.Text.Trim());
            }
            lblUserCount.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ActiveFilterString = "";
            switch (cbActiveFilter.SelectedItem)
            {
                case "All":
                    ActiveFilterString = "All";
                    break;
                case "Active":
                    ActiveFilterString = "1";
                    break;
                case "Not Active":
                    ActiveFilterString = "0";
                    break;
            }
            if (ActiveFilterString == "All")
                _dt.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterString, ActiveFilterString);

            lblUserCount.Text = _dt.Rows.Count.ToString();
        }

        private void txtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {        
            if(FilterString == "UserID" || FilterString == "PersonID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
