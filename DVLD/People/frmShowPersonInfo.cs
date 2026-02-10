using System;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID = -1;
        public frmShowPersonInfo()
        {
            InitializeComponent();
        }
        public frmShowPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
        }
        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfoByPersonID(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
