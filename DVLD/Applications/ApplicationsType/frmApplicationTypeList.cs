using DVLD_Buisness;
using System;
using System.Data;
using System.Windows.Forms;


namespace DVLD.Applications.ApplicationsType
{
    public partial class frmApplicationTypeList : Form
    {
        private DataTable _dt;
        public frmApplicationTypeList()
        {
            InitializeComponent();
        }

        private void _ReloadList()
        {
            dgvApplictaionType.RowHeadersVisible = false;
            _dt = clsApplicationTypes.GetAllApplicationTypes();
            dgvApplictaionType.DataSource = _dt;
        }
        private void frmApplicationTypeList_Load(object sender, EventArgs e)
        {
            _ReloadList();
            dgvApplictaionType.Columns[1].Width = 400;
            dgvApplictaionType.Columns[2].Width = 177;

            lblApplicationsCount.Text = _dt.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _ReloadList();
        }

        private void updateApplicatoinTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUpdateApplicationType((int)dgvApplictaionType.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _ReloadList();
        }
    }
}