using DVLD_DataAccess;
using System;
using System.ComponentModel.Design;
using System.Data;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplications
    {


        public int LocalDrivingLicenseApplictionID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public short TestsPassed
        {
            get
            {
                return clsTest.HowManyTestsPassed(LocalDrivingLicenseApplictionID);
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            this._Mode = enMode.AddNew;
            this.LocalDrivingLicenseApplictionID = -1;
            this.ApplicationID = -1;
            this.ApplicationType = clsApplicationTypes.enApplicationType.NewDrivingLicense;
            this.ApplicantPersonID = -1;
            this.CreatedByUserID = -1;
            this.ApplicationFees = -1;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationStatus = enStatus.New;
            this.LicenseClassID = -1;

        }

        private clsLocalDrivingLicenseApplication
        (
            int LocalDrivingLicenseApplictionID,
            int LicenseClassID,
            int ApplicationID,
            int ApplicantPersonID,
            int CreatedByUserID,
            float ApplicationFees,
            DateTime ApplicationDate,
            DateTime LastStatusDate,
            clsApplicationTypes.enApplicationType ApplicationType,
            enStatus ApplicationStatus)
        {
            this._Mode = enMode.Update;
            this.LocalDrivingLicenseApplictionID = LocalDrivingLicenseApplictionID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationFees = ApplicationFees;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationType = ApplicationType;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationTypeInfo = clsApplicationTypes.Find((int)this.ApplicationType);
            this.UserInfo = clsUser.Find(CreatedByUserID);
        }

        static public clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplictionID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;
            if (!clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfo(
                    LocalDrivingLicenseApplictionID, ref ApplicationID, ref LicenseClassID))
            {
                return null;
            }
            clsApplications app = clsApplications.FindBaseApplication(ApplicationID);
            return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplictionID, LicenseClassID,
                app.ApplicationID, app.ApplicantPersonID, app.CreatedByUserID, app.ApplicationFees, app.ApplicationDate,
                app.LastStatusDate, app.ApplicationType, app.ApplicationStatus);
        }

        private bool _AddNewLDLA()
        {
            this.LocalDrivingLicenseApplictionID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);
            return this.LocalDrivingLicenseApplictionID != -1;
        }

        private bool _UpdateLDLA()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplictionID, ApplicationID, LicenseClassID);
        }
        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (!base.Save())
                {
                    return false;
                }
                if (!_AddNewLDLA())
                {
                    return false;
                }
            }
            else
            {
                if (!base.Save())
                {
                    return false;
                }
                if (!_UpdateLDLA())
                {
                    return false;
                }
            }

            return true;
        }

        public bool Delete()
        {
            if (_Mode == enMode.AddNew)
            {
                return false;
            }
            if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplictionID))
            {
                return base.Delete();
            }
            return false;
        }

        static public bool DoesLocalDrivingLicenseApplictionExistByID(int LocalDrivingLicenseApplictionID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesLocalDrivingLicenseApplicationExistByID(
                LocalDrivingLicenseApplictionID);
        }
        static public bool IsThisPersonHaveThisClassAndItIsNew(int ApplicantPersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.DosePersonHaveThisLicenseClassNew(ApplicantPersonID, LicenseClassID);
        }

        static public DataTable GetAllLocalDrivingLicensApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationData();
        }

        public int IssueLicenseFirstTime(string Notes, int CreatedByUserID)
        {
            // check if all tests  are passed
            if (this.TestsPassed < 3)
            {
                return -1;
            }
            //check if person is Driver or not, if not create new driver
            int driverID = -1;
            if (!clsDriver.IsPersonADriver(this.ApplicantPersonID))
            {
                clsDriver driver = new clsDriver(this.ApplicantPersonID, CreatedByUserID);
                if (!driver.Save())
                {
                    return -1;
                }
                driverID = driver.DriverID;
            }
            else
            {
                // check if this person have this license class and it is new, if not return -1
                if (clsLicense.DoesPersonHaveThisLicenseClass(this.ApplicantPersonID, (clsLicenseClass.enLicenseClass)LicenseClassID))
                {
                    return -1;
                }
            }
            // create new license
            clsLicense license = new clsLicense(
                this.ApplicationID,
                driverID,
                this.LicenseClassID,
                Notes,
                this.ApplicationFees,
                true,
                clsLicense.enIssueReason.FirstTime,
                CreatedByUserID
                );
            if(!license.Save()) {return -1;}
            SetComplete();
            return license.LicenseID;
        }
    }
}