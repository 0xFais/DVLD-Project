using DVLD.GlobalClasses;
using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmAddUpdateLocalDrivingLicenseApplications : Form
    {
        private int LocalDrivingLicenseApplictionID;
        private clsLocalDrivingLicenseApplication _LDLApp;
        private enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        public frmAddUpdateLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            this._LDLApp = new clsLocalDrivingLicenseApplication();
        }
        public frmAddUpdateLocalDrivingLicenseApplications(int LocalDrivingLicenseApplictionID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            this.LocalDrivingLicenseApplictionID = LocalDrivingLicenseApplictionID;
            this._LDLApp = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplictionID);
        }

        private void frmAddUpdateLocalDrivingLicenseApplications_Load(object sender, System.EventArgs e)
        {

            //Adding License Classes comboBox Items
            cboxLicenseClass.Items.Add("Class 1 - Light Motorcycle Driving License");
            cboxLicenseClass.Items.Add("Class 2 - Heavy Motorcycle Driving License");
            cboxLicenseClass.Items.Add("Class 3 - Ordinary Driving License");
            cboxLicenseClass.Items.Add("Class 4 - Commercial Driving License");
            cboxLicenseClass.Items.Add("Class 5 - Agricultural Driving License");
            cboxLicenseClass.Items.Add("Class 6 - Small and Medium Bus Driving License");
            cboxLicenseClass.Items.Add("Class 7 - Trucks and Heavy Vehicle Driving License");
            //Loading the form 
            _RestInfo();
            if (_Mode == enMode.Update)
            {
                _LoadInfo();
            }
        }
        private void _LoadInfo()
        {
            lblTitle.Text = "Update Local Driving License Application";
            lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplictionID.ToString();
            lblAppDate.Text = _LDLApp.ApplicationDate.ToShortDateString();
            lblAppFees.Text = "15";
            lblCreatedByUserName.Text = _LDLApp.UserInfo.UserName;
            ctrlPersonCardFilter1.LoadPersonValuesByID(_LDLApp.ApplicantPersonID);
            switch (_LDLApp.LicenseClassID)
            {
                case 1:
                    cboxLicenseClass.SelectedItem = "Class 1 - Light Motorcycle Driving License";
                    break;
                case 2:
                    cboxLicenseClass.SelectedItem = "Class 2 - Heavy Motorcycle Driving License";
                    break;
                case 3:
                    cboxLicenseClass.SelectedItem = "Class 3 - Ordinary Driving License";
                    break;
                case 4:
                    cboxLicenseClass.SelectedItem = "Class 4 - Commercial Driving License";
                    break;
                case 5:
                    cboxLicenseClass.SelectedItem = "Class 5 - Agricultural Driving License";
                    break;
                case 6:
                    cboxLicenseClass.SelectedItem = "Class 6 - Small and Medium Bus Driving License";
                    break;
                case 7:
                    cboxLicenseClass.SelectedItem = "Class 7 - Trucks and Heavy Vehicle Driving License";
                    break;
            }
            ctrlPersonCardFilter1.FilterEnable(false);
        }
        private void _RestInfo()
        {
            ctrlPersonCardFilter1.LoadPersonValuesByID(-1);
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = "15";
            lblCreatedByUserName.Text = clsGlobal.User.UserID.ToString();
            lblLDLAppID.Text = "?????";
            cboxLicenseClass.SelectedItem = "Class 3 - Ordinary Driving License";
            lblTitle.Text = "Add New Local Driving License Application";

        }
        private void _SetInfo()
        {
            _LDLApp.ApplicationDate = DateTime.Now;
            _LDLApp.LastStatusDate = DateTime.Now;
            _LDLApp.ApplicationFees = 15;
            _LDLApp.ApplicantPersonID = ctrlPersonCardFilter1._PersonID;
            _LDLApp.LicenseClassID = cboxLicenseClass.SelectedIndex + 1;
            _LDLApp.CreatedByUserID = clsGlobal.User.UserID;
            _LDLApp.ApplicationStatus = clsApplications.enStatus.New;
            _LDLApp.ApplicationType = clsApplicationTypes.enApplicationType.NewDrivingLicense;
        }


        private void btnNext_Click(object sender, System.EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["tpApplicationInfo"];
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _SetInfo();
            if (ctrlPersonCardFilter1._PersonID == -1)
            {
                MessageBox.Show("Please Select a person first");
                return;
            }
            if (clsLocalDrivingLicenseApplication.IsThisPersonHaveThisClassAndItIsNew(_LDLApp.ApplicantPersonID, _LDLApp.LicenseClassID))
            {
                   MessageBox.Show("This person already have a new application for this License Class");
                return;
            }
            if (clsLicense.DoesPersonHaveThisLicenseClass(_LDLApp.ApplicantPersonID, (clsLicenseClass.enLicenseClass)_LDLApp.LicenseClassID))
            {
                MessageBox.Show("This person already have this License Class");
                return;
            }
            if (_Mode == enMode.AddNew)
            {
                if (!_LDLApp.Save())
                {
                    MessageBox.Show("Error in saving the application");
                    return;
                }
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("The application has been successfully Added");
                ctrlPersonCardFilter1.FilterEnable(false);
            }
            else
            {
                if (!_LDLApp.Save())
                {
                    MessageBox.Show("Error in updating the application");
                    return;
                }
                MessageBox.Show("The application has been successfully Updated");
            }
        }
        private void cboxLicenseClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (cboxLicenseClass.SelectedItem.ToString())
            {
                case "Class 1 - Light Motorcycle Driving License":
                    _LDLApp.LicenseClassID = 1;
                    break;
                case "Class 2 - Heavy Motorcycle Driving License":
                    _LDLApp.LicenseClassID = 2;
                    break;
                case "Class 3 - Ordinary Driving License":
                    _LDLApp.LicenseClassID = 3;
                    break;
                case "Class 4 - Commercial Driving License":
                    _LDLApp.LicenseClassID = 4;
                    break;
                case "Class 5 - Agricultural Driving License":
                    _LDLApp.LicenseClassID = 5;
                    break;
                case "Class 6 - Small and Medium Bus Driving License":
                    _LDLApp.LicenseClassID = 6;
                    break;
                case "Class 7 - Trucks and Heavy Vehicle Driving License":
                    _LDLApp.LicenseClassID = 7;
                    break;
            }
        }
    }
}