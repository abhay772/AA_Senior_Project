using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

	public bool AddUser(string email, string password, DateOnly dob)
	{
		using(var connection = new SqlConnection())

		return false;
	}

}
