using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.RegistrationDAO;

public class SqlDAO
{
    private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AA.Product.Logs;Trusted_Connection=True;Encrypt=false";

	public SqlDAO()
	{
		
	}

}
