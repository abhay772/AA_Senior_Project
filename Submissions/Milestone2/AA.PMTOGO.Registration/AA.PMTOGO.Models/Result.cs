// Reference: CECS 491A - sec 04, Vong.
namespace AA.PMTOGO.Models;


public class Result
{
    public bool IsSuccessful { get; set; }
    public string ErrorMessage { get; set; }

    public object? Payload;
}
