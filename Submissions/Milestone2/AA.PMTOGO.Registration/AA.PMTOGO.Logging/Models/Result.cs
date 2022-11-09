using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.PMTOGO.Logging.Models
{
    public class Result
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public object? Payload;
    }
}
