using AA.PMTOGO.Logging.LoggingDAL.Abstractions;
using AA.PMTOGO.Logging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.Logging.Abstractions
{
    public interface ILogger
    {
        Task<Result> Log(string message);
    }

    public interface IDataAccessObject
    {
        object LogData(string message);
    }

    public interface IDataReader
    {
        Result ReadData();
    }

    public interface IDataWriter 
    {
        Result WriteData(string data);
    }

}
