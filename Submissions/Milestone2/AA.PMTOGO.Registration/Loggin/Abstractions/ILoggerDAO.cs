using AA.PMTOGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.LoggerDAO.Abstractions;

// Reference: CECS 491A - sec 04, Vong.
public interface ILoggerDAO
{
    Result LogData(string level, string Event, string category, string message);
}

