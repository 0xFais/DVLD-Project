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

namespace DVLD.Licenses.LocalLicenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public delegate void DataBackHandler(object sender, int DriverLicenseID);
        public DataBackHandler DataBack;
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        public int DriverLicenseID { get; private set; }

        private void ctrlDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(clsLicense.Find(Convert.ToInt32(txtLicenseID.Text)) == null)
            {
                MessageBox.Show("No license found with the provided ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DriverLicenseID = Convert.ToInt32(txtLicenseID.Text);
            ctrlDriverLicenseInfo1.LoadDriverLicense(DriverLicenseID);
            DataBack?.Invoke(this,DriverLicenseID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Prevent the key from being entered into the textbox
                }
        }
    }
}
