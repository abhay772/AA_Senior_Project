﻿using System.Data.SqlClient;

public class LoggingDAO
{
    private readonly string _connectionString;
    private readonly SqlDataAdapter _adapter = new SqlDataAdapter();

    public LoggingDAO(string connectionString)
    {
        _connectionString = connectionString;
    }


    public bool ExecuteSQL(string sql)
    {
        var connectionString = "Server=.\\;Database=AA.PMtoGo.Logs;Integrated Securtiy = True; Encrypt=False";
        using (var connection = new SqlConnection(connectionString)) //ADO.NET, ANSI SQL
        {
            connection.Open();

            //Insert SQL statement
            var insertSql = "INSERT INTO AA.PMtoGo.Logs (Message) values(%messgae)";

            var parameter = new SqlParameter();

            var command = new SqlCommand(insertSql, connection);
            command.Parameters.Add(parameter);

            //Excecution of SQL
            var rows = command.ExecuteNonQuery();

            if (rows == 1)
            {
                result.IsSuccessful = true;
                return result;
            }

            result.IsSuccessful = false;
            result.ErrorMessage = $"was not 1 {rows}";
            return false;
        }
        return false;
    }
}