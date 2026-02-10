using DVLD_Buisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Applications.ApplicationsType
{
    public partial class frmUpdateApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationTypes _ApplicationType;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            this._ApplicationTypeID = ApplicationTypeID;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill all the information above.", "DVLD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SetApplicationTypeID();
            if (!_ApplicationType.Save())
            {
                MessageBox.Show("Unable to save changes.", "DVLD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Application Type Saved", "DVLD", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool _LoadApplicationType()
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);
            if (_ApplicationTypeID == null)
            {
                return false;
            }
            lblApplicationTypeID.Text = _ApplicationType.ApplicationID.ToString();
            txtFees.Text = _ApplicationType.Fees.ToString();
            txtTitle.Text = _ApplicationType.Title;
            return true;
        }

        private void _SetApplicationTypeID()
        {
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = float.Parse(txtFees.Text);
        }
        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            if (!_LoadApplicationType())
            {
                MessageBox.Show("Didn't Load the Application type Correctly ", "DVLD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this Field should not be empty");
                return;
            }
            errorProvider1.SetError(txtTitle, null);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "this Field should not be empty");
                return;
            }
            errorProvider1.SetError(txtFees, null);
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the key from being entered into the textbox
            }
        }
    }
}
