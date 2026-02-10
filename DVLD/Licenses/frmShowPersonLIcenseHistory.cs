using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowPersonLIcenseHistory : Form
    {
        public int PersonID { get; private set; }
        public frmShowPersonLIcenseHistory(int PerosnID)
        {
            InitializeComponent();
            this.PersonID = PerosnID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonLIcenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfoByPersonID(this.PersonID);
            ctrlLicenseHistory1.LoadLicenseHistory(this.PersonID);
        }

    }
}
