using DVLD_DataAccess;
using System.Data;

namespace DVLD_Buisness
{
    public class clsApplicationTypes
    {
        enum enMode { enAddNew = 0, enUpdate = 1 }
        private enMode Mode { get; set; }
        public int ApplicationID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public clsApplicationTypes()
        {
            Mode = enMode.enAddNew;
            ApplicationID = -1;
            Title = "";
            Fees = -1;
        }
        private clsApplicationTypes(int ApplicationID, string Title, float Fees)
        {
            this.ApplicationID = ApplicationID;
            this.Title = Title;
            this.Fees = Fees;
            Mode = enMode.enUpdate;
        }
        public enum enApplicationType
        {
            NewDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamgedDrivingLicense = 4,
            ReleaseDetainedLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }
        public string ApplicationTypeName
        {
            get 
            { 
                switch(ApplicationID)
                {
                    case 1:
                        return "New Driving License";
                    case 2:
                        return "Renew Driving License";
                    case 3:
                        return "Replace Lost Driving License";
                    case 4:
                        return "Replace Damaged Driving License";
                    case 5:
                        return "Release Detained License";
                    case 6:
                        return "New International License";
                    case 7:
                        return "Retake Test";
                    default:
                        return "Unknown";
                }
            }
        }
        static public clsApplicationTypes Find(int ApplicationTypeID)
        {
            string title = "";
            float fees = -1;
            if (clsApplicationTypeData.GetApplicationType(ApplicationTypeID, ref title, ref fees))
            {
                return new clsApplicationTypes(ApplicationTypeID, title, fees);
            }
            else
            {
                return null;
            }
        }

        private bool _Add()
        {
            this.ApplicationID = clsApplicationTypeData.AddNewApplicationType(this.Title, this.Fees);
            if (this.ApplicationID == -1)
            {
                return false;
            }
            return true;
        }

        private bool _Update()
        {
            return clsApplicationTypeData.UpdateApplicatoinType(this.ApplicationID, this.Title, this.Fees);
        }
        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                if (_Add())
                {
                    Mode = enMode.enUpdate;
                    return true;
                }
                return false;
            }
            else
            {
                return _Update();
            }
        }

        public bool Delete()
        {
            return clsApplicationTypeData.DeleteApplicationType(this.ApplicationID);
        }

        static public bool DoesApplicationTypeExist(int ApplicationTypeID)
        {
            return clsApplicationTypeData.DoesApplicationTypeExist(ApplicationTypeID);
        }
        static public DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationType();
        }
    }
}