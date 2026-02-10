using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 1, Update = 2}
        public enMode Mode { get; private set; }
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; private set; }
        public clsApplications ApplicationInfo { get; private set; }
        public int DriverID { get; private set; }
        public int IssueUsingLocalLicenseID { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; private set; }



        public clsInternationalLicense(int LocalLicenseID,int CreatedByUserID)
        {
            this.InternationalLicenseID = -1;
            this.ApplicationInfo = new clsApplications();
            clsLicense LicenseInfo = clsLicense.Find(LocalLicenseID);
            this.ApplicationInfo.ApplicantPersonID = LicenseInfo.ApplicationInfo.ApplicantPersonID;
            this.ApplicationInfo.ApplicationFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicense).Fees;
            this.ApplicationInfo.ApplicationDate = DateTime.Now;
            this.ApplicationInfo.LastStatusDate = DateTime.Now;
            this.ApplicationInfo.CreatedByUserID = CreatedByUserID;
            this.ApplicationInfo.ApplicationStatus = clsApplications.enStatus.Completed;
            this.ApplicationInfo.ApplicationType = clsApplicationTypes.enApplicationType.NewInternationalLicense;

            this.DriverID = clsDriver.FindByPersonID(ApplicationInfo.ApplicantPersonID).DriverID;
            this.IssueUsingLocalLicenseID = LocalLicenseID;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(1);
            this.IsActive = true;
            this.CreatedByUserID = CreatedByUserID;
            this.Mode = enMode.AddNew;
        }
        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssueUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.ApplicationInfo = clsApplications.FindBaseApplication(ApplicationID);
            this.DriverID = DriverID;
            this.IssueUsingLocalLicenseID = IssueUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.Mode = enMode.Update;
        }
        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LocalLicenseID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsInternationalLicenseData.GetInternationalLicenseByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref LocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return null;
            }
            return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, LocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }


        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddInternationalLicense(this.ApplicationInfo.ApplicationID, this.DriverID, this.IssueUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return this.InternationalLicenseID != -1;
        }
        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssueUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }
        public bool Save()
        {
            if(this.Mode == enMode.AddNew)
            {
                if(!this.ApplicationInfo.Save())
                {
                    return false;
                }
                this.ApplicationID = this.ApplicationInfo.ApplicationID;
                return _AddNewInternationalLicense();
            }
            else if(this.Mode == enMode.Update)
            {
                return _UpdateInternationalLicense();
            }
            return false;
        }
        public static bool IsThisLicenseHaveAnInternationalLicense(int LocalLicenseID)
        {
            return clsInternationalLicenseData.DoesThisLocalLicenseHaveAnInternationalLicense(LocalLicenseID);
        }





    }
}
