using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTest
    {
        enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode { get; set; }
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            _Mode = enMode.AddNew;
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
        }
        private clsTest( int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            _Mode = enMode.Update;
        }
        static public clsTest Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;
            bool IsFound = clsTestData.GetTestInfo(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);
            if (!IsFound)
            {
                return null;
            }
            return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }
        private bool _AddNewTest()
        {
            if(!clsTestAppointmentData.DoesThisTestAppointmentExist(TestAppointmentID))
            {
                return false;
            }
            int TestID = -1;
            TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return TestID != -1;
        }
        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(TestID,TestAppointmentID,TestResult,Notes,CreatedByUserID);
        }
        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                return _AddNewTest();
            }
            else
            {
                return _UpdateTest();
            }
        }
        public bool Delete()
        {
            return clsTestData.DeleteTest(TestID);
        }
        static public bool DoesThisApplicationPassThisTest(int LDLApp, int TestType)
        {
            return clsTestData.DoesThisApplicationPassThisTest(LDLApp, TestType);
        }
        static public short HowManyTestsPassed(int LDLApp)
        {
            short PassedTests = 0;
            for(int i = 1; i <= 3; i++)
            {
                if (clsTestData.DoesThisApplicationPassThisTest(LDLApp, i))
                {
                    PassedTests++;
                }
                else
                {
                    break;
                }
            }
            return PassedTests;
        }
        public short HowManyTestsPassed()
        {
            return HowManyTestsPassed(TestAppointmentInfo.LocalDrivingLicenseApplicationID);
        }

    }
}
