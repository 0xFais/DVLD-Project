using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {
        static public DataTable GetAllTestTypes()
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM TestTypes";
            SqlCommand command = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
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
                conn.Close();
            }

            return dt;
        }

        static public bool UpdateTestType(int testTypeID, string Title, string Description, float Fess)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Update  TestTypes  set TestTypeTitle = @Title, TestTypeDescription=@Description, TestTypeFees = @Fees where TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fess);
            int rowsAffected = -1;
            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }

        static public int AddNewTestType(string Title, string Description, float Fess)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Insert into TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFess) values (@Title,@Description,@Fess) Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fess", Fess);
            int TestTypeID = -1;
            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    TestTypeID = ID;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                conn.Close();
            }

            return TestTypeID;
        }

        static public bool DeleteTestType(int testTypeID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Delete TestTypes where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            int rowsAffected = -1;
            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0;
        }

        static public bool GetTestType(int testTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref float TestTypeFess)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFess", TestTypeFess);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFess = Convert.ToSingle(reader["TestTypeFees"]);
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

        static public bool DoesThisTestTypeExist(int testTypeID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from TestTypes where TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            bool IsFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return IsFound;
        }

    }
}