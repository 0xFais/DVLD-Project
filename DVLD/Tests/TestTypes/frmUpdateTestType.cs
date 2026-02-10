using DVLD_Buisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Tests.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType testType;
        public frmUpdateTestType(int testTypeID)
        {
            InitializeComponent();
            testType = clsTestType.Find(testTypeID);
            _LoadTestTypeInfo();
        }

        private void _LoadTestTypeInfo()
        {
            lblID.Text = testType.TestTypeID.ToString();
            txtTitle.Text = testType.TestTypeTitle;
            txtDescription.Text = testType.TestTypeDescription;
            txtFees.Text = testType.TestTypeFees.ToString();
        }

        private void _SetTestTypeInfo()
        {
            testType.TestTypeTitle = txtTitle.Text;
            testType.TestTypeDescription = txtDescription.Text;
            testType.TestTypeFees = float.Parse(txtFees.Text);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateTestTypes_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("you have to fill all fields correctly");
                return;
            }
            _SetTestTypeInfo();
            if (!testType.Save())
            {
                MessageBox.Show("Save failed");
                return;
            }
            MessageBox.Show("Saved");
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this shouldn't be empty");
                return;
            }
            errorProvider1.SetError(txtTitle, null);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "this shouldn't be empty");
                return;
            }
            errorProvider1.SetError(txtDescription, null);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "this shouldn't be empty");
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