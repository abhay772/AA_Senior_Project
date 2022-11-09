using AA.PMTOGO.LoggerDAO.Abstractions;
using AA.PMTOGO.Logging.Abstractions;
using AA.PMTOGO.Models;

namespace AA.PMTOGO.Logging.Implementations
{
    public class DatabaseLogger : ILogger
    {
        private ILoggerDAO _dao;
        private string _category;
        public DatabaseLogger(string category, ILoggerDAO dao) // Inversion of Control
        {
            _category = category;
            _dao = dao;
        }

        public Result Log(string Level, string Event,string message)
        {
            return _dao.LogData(Level, Event, message);
        }

        public async Task<Result> AsyncLog(string Level, string Event,string message)
        {
            var result = new Result();

            if (message == null) 
            {
                result.IsSuccessful = false;
                return result;
            }



            var daoResults = await _dao.AsyncLogData(Level, Event, message).ConfigureAwait(false);

            if (daoResults.IsSuccessful) 
            {
                result.IsSuccessful = true;
                return result;
            }

            result.IsSuccessful = false;
            result.ErrorMessage = daoResults.ErrorMessage;

            return result;

        }

        //public async Task<Result> Log(String message)
        //{
        //    // TODO: Lot to database
        //    //var tcs = new TaskCompletionSource<Result>();
        //    //Key to find the number of cores
        //    var numOfProccessors = Environment.ProcessorCount-1;
        //    if (Environment.ProcessorCount > 1)
        //    { 
        //        //numOfProccessors;
        //    }

        //    //Task parallelism
        //    // Parallel.For(numOfProccessors, );



        //    var result = new Result();
        //    // Step 1: Input validation

        //    if (message == null)
        //    {
        //        result.IsSuccessful = true;
        //        return result;
        //    }

        //    if(message.Length > 200)
        //    {
        //        result.IsSuccessful = false;
        //        return result;
        //    }

        //    if(message.Contains("<"))
        //    {
        //        result.IsSuccessful = false;
        //        return result;
        //    }

        //    // Step 2: Perform the work
        //    //database server, database, table, column

        //    var daoResults = await _dao.LogData(message).ConfigureAwait(false);

        //    if (daoResults.IsSuccessful)
        //    {
        //        result.IsSuccessful = true;
        //        return result;
        //    }

        //    result.IsSuccessful = false;
        //    result.ErrorMessage = daoResults.ErrorMessage;

        //    return result;
        //}
    }
}
