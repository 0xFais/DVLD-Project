using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsDriver
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode _Mode { get; private set; }
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; private set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; private set; }
        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            PersonInfo = clsPerson.Find(PersonID);
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            _Mode = enMode.Update;

        }
        public clsDriver(int personID, int createdByUserID)
        {
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            PersonInfo = clsPerson.Find(PersonID);
            _Mode = enMode.AddNew;
        }
        public static clsDriver FindByDriverID(int DriverID)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;
            if (clsDriverData.GetDriverByDriverID(DriverID, ref personID, ref createdByUserID, ref createdDate))
            {
                return new clsDriver(DriverID, personID, createdByUserID, createdDate);
            }
            else
            {
                return null;
            }
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;
            if (clsDriverData.GetDriverByPersonID(ref DriverID, PersonID, ref createdByUserID, ref createdDate))
            {
                return new clsDriver(DriverID, PersonID, createdByUserID, createdDate);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
        private int AddNew()
        {
            int id = clsDriverData.AddNewDriver(PersonID, CreatedByUserID, DateTime.Now);
            if (id > 0)
            {
                DriverID = id;
                CreatedDate = DateTime.Now;
                _Mode = enMode.Update;
            }
            return id;
        }
        private bool Update()
        {
            return clsDriverData.UpdateDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
        }
        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if(clsDriverData.IsPersonADriver(PersonID))
                {
                    return false;
                }
                return AddNew() > 0;
            }
            else
            {
                return Update();
            }
        }
        public bool Delete()
        {
            if (_Mode == enMode.Update)
            {
                if (clsDriverData.DeleteDriver(DriverID))
                {
                    DriverID = -1;
                    PersonID = -1;
                    CreatedByUserID = -1;
                    CreatedDate = DateTime.MinValue;
                    _Mode = enMode.AddNew;
                    return true;
                }
            }
            return false;
        }
        public static bool IsDriverExists(int DriverID)
        {
            return clsDriverData.DriverExists(DriverID);
        }
        public static bool IsPersonADriver(int PersonID)
        {
            return clsDriverData.IsPersonADriver(PersonID);
        }
        public DataTable GetAllLocalLicenses()
        {
            return clsLicenseData.GetAllLocalLicenses(DriverID);
        }
        public DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicensesByDriverID(DriverID);
        }
    }
}
