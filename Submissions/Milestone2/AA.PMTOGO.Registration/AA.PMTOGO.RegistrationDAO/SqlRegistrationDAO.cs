using AA.PMTOGO.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace AA.PMTOGO.RegistrationDAO;

public class SqlRegistrationDAO
{
    private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AA.PMTOGO.Registration;Trusted_Connection=True;Encrypt=false";

	public SqlRegistrationDAO()
	{
		
	}

	public Result AddUser(string email, string password, SqlDateTime dob)
	{
		var result = new Result();	
		using(var connection = new SqlConnection(_connectionString))
		{
			connection.Open();

            string sqlQuery = "insert into pmtogo_registration.Users values ( @email, @password, @dob)";

            var command = new SqlCommand(sqlQuery, connection);

            command.Parameters.AddWithValue("@email", email);
			command.Parameters.AddWithValue("@password", password);
			command.Parameters.AddWithValue("@dob", dob);

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

		result.IsSuccessful = false;
        return result;
	}

    public Result FindUser(string email)
    {
        var result = new Result();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sqlQuery = "select * from Users where Email = @email";

            var command = new SqlCommand(sqlQuery, connection);

            command.Parameters.AddWithValue("@email", email);

            var rows = command.ExecuteNonQuery();

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
