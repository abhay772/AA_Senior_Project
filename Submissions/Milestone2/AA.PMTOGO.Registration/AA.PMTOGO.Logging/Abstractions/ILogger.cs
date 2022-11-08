using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AA.PMTOGO.Logging.Abstractions
{
    public interface ILogger
    {
        Result Log(string message); 
    }

    public interface IDataAccessObject
    {
        object LogData(string message);
        Result ReadData();
        Result WriteData();
    }

    public interface IDataReader
    {
        Result ReadData();
    }

}
