using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsLicense
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode _Mode {  get; private set; }
        public int LicenseID { get; private set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public int ApplicationID { get; set; }
        public clsApplications ApplicationInfo { get; private set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamageReplacement = 3, LostReplacement = 4 }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; private set; }

        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.DamageReplacement:
                        return "Damage Replacement";
                    case enIssueReason.LostReplacement:
                        return "Lost Replacement";
                    default:
                        return "Unknown";
                }
            }
        }
        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            ApplicationInfo = clsApplications.FindBaseApplication(applicationID);
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(licenseClassID);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            this.IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            _Mode = enMode.Update;

        }
        public clsLicense(int applicationID, int driverID, int licenseClassID,string notes, float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = -1;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(licenseClassID);
            IssueDate = DateTime.Today;
            ExpirationDate = DateTime.Today.AddYears(LicenseClassInfo.DefaultValidityLength);
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            _Mode = enMode.AddNew;
        }
        public static clsLicense Find(int licenseID)
        {
            int appID = -1, driverID = -1, licenseClassID = -1, createdByUserID = -1;
            int issueReason = -1;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            float paidFees = 0.0f;
            bool isActive = false;
            if (clsLicenseData.GetLicenseByID(licenseID, ref appID, ref driverID, ref licenseClassID, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive,ref issueReason, ref createdByUserID))
            {
                return new clsLicense(licenseID, appID, driverID, licenseClassID, issueDate, expirationDate, notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID);
            }
            return null;
        }
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int licenseID = -1, driverID = -1, licenseClassID = -1, createdByUserID = -1;
            int issueReason = -1;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            string notes = string.Empty;
            float paidFees = 0.0f;
            bool isActive = false;
            if (clsLicenseData.GetLicenseByApplicationID(ref licenseID, ApplicationID, ref driverID, ref licenseClassID, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive,ref issueReason, ref createdByUserID))
            {
                return new clsLicense(licenseID, ApplicationID, driverID, licenseClassID, issueDate, expirationDate, notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID);
            }
            return null;
        }
        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserID);
            return this.LicenseID > 0;
        }
        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(!_AddNewLicense())
                    {
                        return false;
                    }
                    _Mode = enMode.Update;
                    return true;
                case enMode.Update:
                    return _UpdateLicense();

            }
            return false;
        }
        public bool Delete()
        {
            if (_Mode == enMode.AddNew) { return false; };
            return clsLicenseData.DeleteLicense(this.LicenseID);
        }
        public static bool DoesDriverHaveThisLicenseClass(int DriverID,clsLicenseClass.enLicenseClass licenseClass )
        {
            return clsLicenseData.DoesDriverHaveThisLicenseClass(DriverID,(int) licenseClass);
        }
        public static bool DoesPersonHaveThisLicenseClass(int PersonID, clsLicenseClass.enLicenseClass LicenseClass)
        {
            return clsLicenseData.DoesPersonHaveThisLicenseClass(PersonID, (int)LicenseClass);
        }
        public bool DoesHaveThisLicenseClass(clsLicenseClass.enLicenseClass LicenseClass)
        {
            return clsLicenseData.DoesPersonHaveThisLicenseClass(this.DriverID, (int)LicenseClass);
        } 
    }
}
