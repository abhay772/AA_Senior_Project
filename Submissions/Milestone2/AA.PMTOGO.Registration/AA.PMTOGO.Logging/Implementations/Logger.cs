using AA.PMTOGO.Logging.Abstractions;
using AA.PMTOGO.Logging.Models;
using AA.PMTOGO.Logging.LoggingDAL.Abstractions;
using System.Data.SqlClient;


namespace AA.PMTOGO.Logging.Implementations
{
    public class Logger : ILogger
    {
        private readonly ILoggerDAO _dao;
        public Logger(ILoggerDAO dao) // Inversion of Control
        {
            _dao = dao;
        }

        public async Task<Result> Log(String message)
        {
            // TODO: Lot to database
            //var tcs = new TaskCompletionSource<Result>();
            //Key to find the number of cores
            var numOfProccessors = Environment.ProcessorCount-1;
            if (Environment.ProcessorCount > 1)
            { 
                //numOfProccessors;
            }

            //Task parallelism
            // Parallel.For(numOfProccessors, );
            


            var result = new Result();
            // Step 1: Input validation

            if (message == null)
            {
                result.IsSuccessful = true;
                return result;
            }

            if(message.Length > 200)
            {
                result.IsSuccessful = false;
                return result;
            }

            if(message.Contains("<"))
            {
                result.IsSuccessful = false;
                return result;
            }

            // Step 2: Perform the work
            //database server, database, table, column

            var daoResults = await _dao.LogData(message).ConfigureAwait(false);

            if (daoResults.IsSuccessful)
            {
                result.IsSuccessful = true;
                return result;
            }

            result.IsSuccessful = false;
            result.ErrorMessage = daoResults.ErrorMessage;

            return result;
        }

    }
}
