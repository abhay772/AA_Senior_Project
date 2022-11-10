using AA.PMTOGO.LoggerDAO;
using AA.PMTOGO.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace AA.PMTOGO.RegistrationDAO;

public class SqlRegistrationDAO
{
    private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AA.PMTOGO.Registration;Trusted_Connection=True;Encrypt=false";
    private SqlLogger _sqlLogger = new SqlLogger("business");
	public SqlRegistrationDAO()
	{
		
	}

	public Result AddUser(string email, string password, SqlDateTime dob, string firstName, string lastName, 
        string city, string securityQuestion, string securityAnswer)
	{
		var result = new Result();	
		using(var connection = new SqlConnection(_connectionString))
		{
			connection.Open();

            string sqlQuery = "insert into pmtogo_registration.Users values ( @email, @password, @dob," +
                " @firstName, @lastName, @city, @securityQuestion, @securityAnswer)";

            var command = new SqlCommand(sqlQuery, connection);

            command.Parameters.AddWithValue("@email", email);
			command.Parameters.AddWithValue("@password", password);
			command.Parameters.AddWithValue("@dob", dob);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@securityQuestion", securityQuestion);
            command.Parameters.AddWithValue("@securityAnswer", securityAnswer);

            try
            {
                var rows = command.ExecuteNonQuery();

                if (rows == 1)
                {
                    result.IsSuccessful = true;
                    return result;
                }

                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "too many rows affected";
                    return result;
                }
            }

            catch (SqlException e)
            {
                if (e.Number == 208)
                {
                    _sqlLogger.LogData("error", "addUser", "Specified table not found.");
                }
            }

        }

		result.IsSuccessful = false;
        return result;
	}

    public Result FindUser(string email)
    {
        var result = new Result();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sqlQuery = "select * from pmtogo_registration.Users where Email = @email";

            var command = new SqlCommand(sqlQuery, connection);

            command.Parameters.AddWithValue("@email", email);
            try
            {
                var rows = command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                if(e.Number==208)
                {
                    _sqlLogger.LogData("error", "findUser", "Specified table not found.");
                }
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (email.Equals(reader["Email"]))
                    {
                        result.IsSuccessful = true;
                        result.ErrorMessage = "Email already exists.";
                        return result;
                    }
                }
            }

            result.IsSuccessful = false;
            return result;
        }
    }
}
