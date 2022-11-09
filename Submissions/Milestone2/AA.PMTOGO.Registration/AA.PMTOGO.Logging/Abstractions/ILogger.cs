using AA.PMTOGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AA.PMTOGO.Logging.Abstractions
{
    public interface ILogger
    {
        Result Log(string Level , string Event, string message);
        Task<Result> AsyncLog(string Level, string Event, string message); 
    }
}
