namespace reverse_polish_notation;

public class EvaluationResult
{
    private double _result;
    private string _errorMessage;
    public double Result
    {
        get
        {
            if (Success) return _result;
            throw new Exception("Unable to obtain result. Please see ErrorMessage.");
        }
        init { _result = value; }
    }

    public string ErrorMessage
    {
        get
        {
            if (!Success) return _errorMessage;
            throw new Exception("No error. Please see Result.");
        }
        init { _errorMessage = value; }
    }
    
    public bool Success { get; }

    public EvaluationResult(double result=-1.0, string errorMessage="")
    {
        Result = result;
        ErrorMessage = errorMessage;
        Success = errorMessage=="";
    }
}