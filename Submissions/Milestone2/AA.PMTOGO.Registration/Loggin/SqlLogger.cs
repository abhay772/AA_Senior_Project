﻿using AA.PMTOGO.LoggerDAO.Abstractions;
using AA.PMTOGO.Models;
using Microsoft.Data.SqlClient;


namespace AA.PMTOGO.LoggerDAO;

public class SqlLogger : ILoggerDAO
{
    private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AA.PMTOGO.Logs;Trusted_Connection=True;Encrypt=false";
    private string _category;

    public SqlLogger(string category)
    {
        _category = category;
    }

    public Result LogData(string level, string Event, string message)
    {
        Result result = new Result();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();


            string sqlQuery = "insert into pmtogo_logger.Logs values ( @Timestamp, @Level, @Event, @Category, @Message)";
            var command = new SqlCommand(sqlQuery, connection);
            
            command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
            command.Parameters.AddWithValue("@Level", level);
            command.Parameters.AddWithValue("@Event", Event);
            command.Parameters.AddWithValue("@Category", _category);
            command.Parameters.AddWithValue("@Message", message);

            var rows = command.ExecuteNonQuery();

            if(rows == 1)
            {
                result.IsSuccessful = true;
                return result;
            }

            else
            {
                result.IsSuccessful = false;
                result.ErrorMessage = "Too many rows affected.";
            }
        }

        result.IsSuccessful = false;
        return result;
    }

    public async Task<Result> AsyncLogData(string level, string Event, string message)
    {
        Result result = new Result();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();


            string sqlQuery = "insert into PMTOGO.Logs values ( @Timestamp, @Level, @Event, @Category, @Message)";
            var command = new SqlCommand(sqlQuery, connection);

            command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
            command.Parameters.AddWithValue("@Level", level);
            command.Parameters.AddWithValue("@Event", Event);
            command.Parameters.AddWithValue("@Category", _category);
            command.Parameters.AddWithValue("@Message", message);

            var rows = await command.ExecuteNonQueryAsync();
            
            if (rows == 1)
            {
                result.IsSuccessful = true;
                return result;
            }

            else
            {
                result.IsSuccessful = false;
                result.ErrorMessage = "Too many rows affected.";
            }
        }

        result.IsSuccessful = false;
        return result;
    }
}


