

namespace AA.PMTOGO.Logging.Models
{
    public enum LogType
    {

    }

    public class Result 
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public object? Payload;
    }
}
