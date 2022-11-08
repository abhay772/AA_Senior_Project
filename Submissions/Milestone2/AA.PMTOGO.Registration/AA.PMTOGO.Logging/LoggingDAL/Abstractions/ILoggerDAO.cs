namespace AA.PMTOGO.Logging.LoggingDAL.Abstractions
{
    public interface ILoggerDAO
    {
        Task<Result> LogData(string message);
    }
}
