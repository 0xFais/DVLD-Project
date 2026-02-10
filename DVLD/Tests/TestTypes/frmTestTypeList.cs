using DVLD_Buisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Tests.TestTypes
{
    public partial class frmTestTypeList : Form
    {
        private DataTable dt;

        private void _ReloadList()
        {
            dt = clsTestType.GetAllTestTypes();
            dgvTestTypeLIst.DataSource = dt;
            lblTestTypesCount.Text = dt.Rows.Count.ToString();
        }
        public frmTestTypeList()
        {
            InitializeComponent();
            dgvTestTypeLIst.RowHeadersVisible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTestTypeList_Load(object sender, EventArgs e)
        {
            _ReloadList();
            dgvTestTypeLIst.Columns[0].Width = 70;
            dgvTestTypeLIst.Columns[1].Width = 120;
            dgvTestTypeLIst.Columns[2].Width = 400;
            dgvTestTypeLIst.Columns[3].Width = 100;
        }

        private void updateTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUpdateTestType((int)dgvTestTypeLIst.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _ReloadList();
        }
    }
}