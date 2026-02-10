using DVLD_DataAccess;
using System.Data;

namespace DVLD_Buisness
{
    public class clsLicenseClass
    {
        private enum enMode { AddNew = 1, Update = 2 }
        public enum  enLicenseClass
        {
           SmallMotorCycle = 1,
           HeavyMotorCycle = 2,
           OrdinaryVehicle = 3,
              Comercial = 4,
              Agricultural = 5,
              SmallAndMediumBus = 6,
              TruckAndHeavyVehicle = 7,

        }
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        private enMode _Mode { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            _Mode = enMode.AddNew;
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 18;
            DefaultValidityLength = 10;
            ClassFees = -1;
        }

        private clsLicenseClass(int licenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge,
            byte DefaultValidityLength, float ClassFees)
        {
            _Mode = enMode.Update;
            this.LicenseClassID = licenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        static public clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 10;
            float ClassFees = -1;
            if (!clsLicenseClassData.GetLicenseClassByClassID(LicenseClassID, ref ClassName, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return null;
            }
            return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }
        static public clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 10;
            float ClassFees = -1;
            if (!clsLicenseClassData.GetLicenseClassByClassName(ref LicenseClassID, ClassName, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return null;
            }
            return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }

        private bool _AddNew()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return this.LicenseClassID != -1;
        }
        private bool _Update()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
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
                return false;
            }
            if (_Update())
            {
                return true;
            }
            return false;
        }

        static public DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllClasses();
        }
    }
}