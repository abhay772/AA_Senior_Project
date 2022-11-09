using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.RegistrationDAO;

public class SqlRegistrationDAO
{
    private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AA.PMTOGO.Registration;Trusted_Connection=True;Encrypt=false";

	public SqlRegistrationDAO()
	{
		
	}

	public bool AddUser(string email, string password, SqlDateTime dob)
	{
		using(var connection = new SqlConnection(_connectionString))
		{
			connection.Open();

            string sqlQuery = "insert into Users values ( @email, @password, @dob)";

            var command = new SqlCommand(sqlQuery, connection);

            command.Parameters.AddWithValue("@email", email);
			command.Parameters.AddWithValue("@password", password);
			command.Parameters.AddWithValue("@dob", dob);

			var rows = command.ExecuteNonQuery();

			if (rows == 1) return true;
        }

        return false;
	}

}
