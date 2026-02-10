using DVLD_DataAccess;
using System.Data;

namespace DVLD_Buisness
{
    public class clsTestType
    {
        enum enMode { Upate = 0, AddNew = 1 }
        private enMode _Mode;
        public enum enTestType { Vision = 1, Written = 2, Street = 3 }
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public clsTestType()
        {
            _Mode = enMode.AddNew;
            TestTypeID = -1;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = -1;
        }

        private clsTestType(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            _Mode = enMode.Upate;
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }

        static public clsTestType Find(int TestTypeID)
        {
            string titel = "";
            string des = "";
            float fees = -1;
            if (!clsTestTypeData.GetTestType(TestTypeID, ref titel, ref des, ref fees))
            {
                return null;
            }
            return new clsTestType(TestTypeID, titel, des, fees);
        }

        private bool _Update()
        {
            return clsTestTypeData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        private bool _AddNew()
        {
            this.TestTypeID = clsTestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return this.TestTypeID != -1;
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNew())
                {
                    _Mode = enMode.Upate;
                    return true;
                }

                return false;
            }
            else
            {
                if (_Update())
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        static public DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
    }
}