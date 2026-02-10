using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestAppointment
    {
        private enum enMode { AddNew = 1, Update = 2};
        private enMode _Mode { get; set; }
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestID { get; private set; }

        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            RetakeTestID = -1;
            IsLocked = false;
        }
        public clsTestAppointment(clsTestType.enTestType TestType, int LocalDrivingLicenseApplicationID, int CreatedByUserID)
        {
            _Mode = enMode.AddNew;
            this.TestAppointmentID = -1;
            this.TestTypeID = (int)TestType;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = DateTime.Now;
            if(CheckRetake())
            {
                this.PaidFees =  clsTestType.Find(this.TestTypeID).TestTypeFees+ clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.RetakeTest).Fees;
            }
            else
            {
                this.PaidFees = clsTestType.Find(this.TestTypeID).TestTypeFees;
            }
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = false;
            this.RetakeTestID = -1;

        }
        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestID)
        {
            _Mode = enMode.Update;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestID = RetakeTestID;
            
        }
        static public clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestID = -1;
            bool IsFound = clsTestAppointmentData.GetTestAppointmentInfo(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestID);
            if(!IsFound)
            {
                return null;
            }
            return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestID);
        }
        private bool _AddNewTest()
        {
            TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestID);
            return TestAppointmentID > 0;
        }
        private bool _UpdateTest()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestID);
        }
        private int _CreateRetakeApp()
        {
            //create a new application with the same info as the original one
            var RetakeApp = new clsApplications();
            var LocalApp = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            RetakeApp.ApplicantPersonID = LocalApp.ApplicantPersonID;
            RetakeApp.ApplicationType = clsApplicationTypes.enApplicationType.RetakeTest;
            RetakeApp.ApplicationStatus = clsApplications.enStatus.New;
            RetakeApp.CreatedByUserID = this.CreatedByUserID;
            RetakeApp.ApplicationDate = DateTime.Now;
            RetakeApp.LastStatusDate = DateTime.Now;
            RetakeApp.ApplicationFees = 5;
            if (RetakeApp.Save())
            {
                return RetakeApp.ApplicationID ;
            }

            return -1;
        }
        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                //in case it's retake it will create a new application, app type : retake
                if (CheckRetake())
                {
                    this.RetakeTestID = _CreateRetakeApp();
                    if (this.RetakeTestID == -1)
                    {
                        return false;
                    }
                }

                return _AddNewTest();
            }
            else
            {
                return _UpdateTest();
            }
        }
        public bool Delete()
        {
            if(_Mode == enMode.AddNew)
            {
                return false;
            }
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointmentID);
        }
        public static DataTable GetAllTestAppointmentsForLDLAppAndTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.GetAllTestAppointmentsForLDLAppAndTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool DoesThisApplicationHaveThisTestAppointmentAndItsActive(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
           return clsTestAppointmentData.DoesThisLDLAppHaveThisAppointmentAndItsNotLocked(LocalDrivingLicenseApplicationID,(int) TestTypeID); 
        }

        public static bool DoesThisApplicationHaveThisTestTypeAppointment(int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.DoesThisApplicationHaveThisTestTypeAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        
        public static int TrailsCountForThisTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.HowManyTrailsOfThisTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool CheckRetake()
        {
            if(_Mode == enMode.AddNew)
            {
                return clsTestAppointmentData.DoesThisApplicationHaveThisTestTypeAppointment(
                        this.LocalDrivingLicenseApplicationID, this.TestTypeID);
            }
            return RetakeTestID != -1;
        }
    }
}
