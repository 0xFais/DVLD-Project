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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlLicenseHistory : UserControl
    {
        public ctrlLicenseHistory()
        {
            InitializeComponent();
        }
        public int PersonID { get; private set; }

        private DataTable _dtLocal { get; set; }
        private DataTable _dtInternational { get; set; }

        private void _RefreshDGV(clsDriver Driver)
        {
            _dtLocal = Driver.GetAllLocalLicenses();
            _dtInternational = Driver.GetAllInternationalLicenses();

            dgvLocal.DataSource = _dtLocal;
            dgvInternational.DataSource = _dtInternational;

            lblLocalDrivingLIcenseCount.Text = _dtLocal.Rows.Count.ToString();
            lblinterNationalLicenseCount.Text = _dtInternational.Rows.Count.ToString();

            dgvInternational.RowHeadersVisible = false;
            dgvLocal.RowHeadersVisible = false;
        }
        public void LoadLicenseHistory(int personID)
        {
            PersonID = personID;
            clsDriver driver = clsDriver.FindByPersonID(PersonID);
            _RefreshDGV(driver);
        }
    }
}
