using DVLD_DataAccess;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;


namespace DVLD_Buisness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set;}
        public bool IsActive { get; set; }
        public clsPerson Person;
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.Mode = enMode.AddNew;
        }
        private clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            Mode = enMode.Update;
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Person = clsPerson.Find(personID);
        }
        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            if (clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
        static public string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        static public clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;
            string hashedPassword = ComputeHash(Password);
            if (clsUserData.GetUserInfoByUserNameAndPassword(ref UserID, ref PersonID, UserName, hashedPassword, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, hashedPassword, IsActive);
            }
            else
            {
                return null;
            }
        }
        static public clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            if (clsUserData.GetUserInfoByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, ComputeHash(this.Password), this.IsActive);
            if (this.UserID == -1)
            {
                return false;
            }

            return true;
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, ComputeHash(this.Password), this.IsActive);
        }
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewUser())
                {
                    this.Mode = enMode.Update;
                    return true;
                }
            }
            else
            {
                return _UpdateUser();
            }
            return false;
        }
        public bool ChangePassword(int UserID, string NewPassword)
        {
            return clsUserData.ChangePassword(UserID, NewPassword);
        }
        static public bool DoesUserExistByPersonID(int PersonID)
        {
            return clsUserData.DoesUserExistByPersonID(PersonID);
        }
        static public bool DoesUserExistByUserID(int UserID)
        {
            return clsUserData.DoesUserExist(UserID);
        }
        static public bool DoesUserExistByUserName(string UserName)
        {
            return clsUserData.DoesUserExistByUserName(UserName);
        }
        static public bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public bool CheckPassword(string Password)
        {
            return this.Password == ComputeHash(Password);
        }
    }
}
