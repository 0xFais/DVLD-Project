using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Buisness
{
    public class clsPerson
    {
        private clsPerson
        (
            int PersonID,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            string NationalNo,
            DateTime DateOfBirth,
            short Gender,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryId,
            string ImagePath
        )
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryId;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountry.Find(NationalityCountryId);
            this.Mode = enMode.enUpdate;
        }
        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalNo = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = -1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            this.Mode = enMode.enAddNew;
        }
        public enum enMode { enAddNew = 0, enUpdate = 1 }
        public enMode Mode = enMode.enAddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public clsCountry CountryInfo;
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public static clsPerson Find(int ID)
        {
            int PersonID = ID;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string NationalNo = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            bool IsFound = clsPersonData.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo(ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, NationalNo, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
            {
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(
            this.FirstName,
            this.SecondName,
            this.ThirdName,
            this.LastName,
            this.NationalNo,
            this.DateOfBirth,
            this.Gender,
            this.Address,
            this.Phone,
            this.Email,
            this.NationalityCountryID,
            this.ImagePath);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(
            this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.NationalNo, this.DateOfBirth, this.Gender,
            this.Address, this.Phone, this.Email,
            this.NationalityCountryID, this.ImagePath);
        }
        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    { return false; }
                case enMode.enUpdate:

                    return _UpdatePerson();
            }
            return false;
        }
        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public static bool IsPersonExist(string nationaNo)
        {
            return clsPersonData.IsPersonExist(nationaNo);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
    }

}
