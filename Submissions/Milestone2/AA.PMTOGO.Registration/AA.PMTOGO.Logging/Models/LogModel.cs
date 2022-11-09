using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.Logging.Models
{
    internal class LogModel
    {
        public string? Log_msg { get; set; }

        public LogType Log_type { get; set; }

        public LogCategory Log_category { get; set; }

        public DateTime DTStamp { get; set; }   
    }
}
