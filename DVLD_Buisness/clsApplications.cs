using DVLD_DataAccess;
using System;

namespace DVLD_Buisness
{
    public class clsApplications
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enum enStatus { New = 1, Completed = 3, Cancelled = 2 }
        public enMode _Mode { get; set; }
        public clsApplicationTypes.enApplicationType ApplicationType { get; set; }
        public clsApplicationTypes ApplicationTypeInfo { get; set; }
        public enStatus ApplicationStatus { get; set; }
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public string FullName
        {
            get { return clsPerson.Find(ApplicantPersonID).FullName; }
        }
        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }
        public float ApplicationFees { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }

        public clsApplications()
        {
            this._Mode = enMode.AddNew;
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.CreatedByUserID = -1;
            this.ApplicationFees = -1;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationStatus = enStatus.New;

        }
        public clsApplications
        (
            int ApplicantPersonID,
            int CreatedByUserID,
            clsApplicationTypes.enApplicationType ApplicationType,
            enStatus ApplicationStatus
        )
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = ApplicantPersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationType = ApplicationType;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationTypeInfo = clsApplicationTypes.Find((int)this.ApplicationType);
            this.UserInfo = clsUser.Find(CreatedByUserID);
            this.ApplicationFees = this.ApplicationTypeInfo.Fees;
            this._Mode = enMode.AddNew;
        }
        private clsApplications
        (
            int ApplicationID,
            int ApplicantPersonID,
            int CreatedByUserID,
            float ApplicationFees,
            DateTime ApplicationDate,
            DateTime LastStatusDate,
            clsApplicationTypes.enApplicationType ApplicationType,
            enStatus ApplicationStatus)
        {
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
            this._Mode = enMode.Update;
        }
        static public clsApplications FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            int CreatedByUserID = -1;
            float ApplicationFees = 0;
            DateTime ApplicationDate = new DateTime();
            DateTime LastStatusDate = new DateTime();
            int ApplicationType = -1;
            int ApplicationStatus = -1;
            if (!clsApplicationData.GetApplicationInfo(ApplicationID, ref ApplicantPersonID, ref CreatedByUserID,
                    ref ApplicationType, ref ApplicationFees, ref ApplicationStatus, ref ApplicationDate,
                    ref LastStatusDate))
            {
                return null;
            }
            return new clsApplications(ApplicationID, ApplicantPersonID, CreatedByUserID, ApplicationFees, ApplicationDate, LastStatusDate, (clsApplicationTypes.enApplicationType)ApplicationType, (enStatus)ApplicationStatus);
        }

        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.CreatedByUserID, (int)this.ApplicationType, this.ApplicationFees, (int)ApplicationStatus, this.ApplicationDate, this.LastStatusDate);
            return this.ApplicationID != -1;
        }

        private bool _Update()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID,
                this.CreatedByUserID, (int)this.ApplicationType, this.ApplicationFees, (int)this.ApplicationStatus,
                this.ApplicationDate, this.LastStatusDate);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNew())
                {
                    _Mode = enMode.Update;
                    return true;
                }
            }
            else
            {
                if (_Update())
                {
                    return true;
                }
            }

            return false;
        }

        public bool Delete()
        {
            if (this._Mode == enMode.Update)
            {
                if (clsApplicationData.DeleteApplication(this.ApplicationID))
                {
                    return true;
                }
            }
            return false;
        }
        public bool Cancel()
        {
            if(_Mode == enMode.AddNew)
            {
                return false;
            }
            ApplicationStatus = enStatus.Cancelled;
            return clsApplicationData.SetStatusForApplication(ApplicationID,(int)enStatus.Cancelled);
        }
        public bool SetComplete()
        {
            if (_Mode == enMode.AddNew)
            {
                return false;
            }
            ApplicationStatus = enStatus.Completed;
            return clsApplicationData.SetStatusForApplication(ApplicationID,(int)enStatus.Completed);
        }

    }
}