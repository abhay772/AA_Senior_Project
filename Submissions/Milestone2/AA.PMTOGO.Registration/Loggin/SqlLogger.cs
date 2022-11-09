using Microsoft.Data.SqlClient;
using System.Data;

namespace AA.PMTOGO.Logger;

public class SqlLogger
{
    private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AA.PMTOGO.Logs;Trusted_Connection=True;Encrypt=false";
    private readonly string _category;

    public SqlLogger(string category)
    {
        _category = category;
    }

    public bool LogData(string level, string Event, string message)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sqlQuery = "insert into Logs values ( @Timestamp, @Level, @Event, @Category, @Message)";
            var command = new SqlCommand(sqlQuery, connection);
            
            command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
            command.Parameters.AddWithValue("@Level", level);
            command.Parameters.AddWithValue("@Event", Event);
            command.Parameters.AddWithValue("@Category", _category);
            command.Parameters.AddWithValue("@Message", message);

            var rows = command.ExecuteNonQuery();

            if(rows == 1)
            {
                return true;
            }
        }
        return false;
    }
}


