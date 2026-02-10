using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {
        static public bool GetApplicationInfo(int ApplicationID, ref int PersonID, ref int UserID, ref int ApplicationTypeID,
            ref float Fees, ref int Status, ref DateTime ApplicationDate, ref DateTime StatusDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from Applications Where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    PersonID = (int)reader["ApplicantPersonID"];
                    UserID = (int)reader["CreatedByUserID"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    Fees = Convert.ToSingle(reader["PaidFees"]);
                    Status = (byte)reader["ApplicationStatus"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    StatusDate = (DateTime)reader["LastStatusDate"];
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        static public int AddNewApplication(int ApplicantPersonID, int CreatedByUserID, int ApplicationTypeID,
             float PaidFees, int ApplicationStatus, DateTime ApplicationDate, DateTime LastStatusDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Insert into Applications (ApplicantPersonID, CreatedByUserID, ApplicationTypeID,ApplicationStatus,PaidFees,ApplicationDate,LastStatusDate) Values (@ApplicatnPersonID, @CreatedByUserID, @ApplicationTypeID,@ApplicationStatus, @PaidFees, @ApplicationDate, @LastStatusDate) Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);
            int ApplicationID = -1;
            command.Parameters.AddWithValue("@ApplicatnPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    ApplicationID = ID;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            return ApplicationID;
        }

        static public bool UpdateApplication(int ApplicationID, int ApplicantPersonID, int CreatedByUserID, int ApplicationTypeID,
            float PaidFees, int ApplicationStatus, DateTime ApplicationDate, DateTime LastStatusDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query =
                "Update Applications Set ApplicantPersonID = @ApplicantPersonID, CreatedByUserID = @CreatedByUserID, ApplicationTypeID = @ApplicationTypeID, PaidFees = @PaidFees, ApplicationStatus = @ApplicationStatus,ApplicationDate = @ApplicationDate, LastStatusDate = @LastStatusDate Where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            int AffectedRows = -1;
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            return AffectedRows > 0;
        }

        static public bool DeleteApplication(int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Delete Applications Where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            int AffectedRows = -1;
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            return AffectedRows > 0;
        }

        static public bool SetStatusForApplication(int ApplicationID, int status)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query =
                            "Update Applications Set ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate Where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", status);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Today);
            int AffectedRows = -1;
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connection.Close();
            }
            return AffectedRows > 0;
        }
    }
}