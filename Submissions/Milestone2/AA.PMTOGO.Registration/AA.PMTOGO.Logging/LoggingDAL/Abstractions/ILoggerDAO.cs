using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.Logging.LoggingDAL.Abstractions
{
    public interface ILoggerDAO
    {
        Task<Result> LogData(string message);
    }
}
