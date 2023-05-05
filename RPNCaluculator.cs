namespace reverse_polish_notation;

public class RPNCaluculator: ICalculator
{
    public IList<string> SupportedOperators { get; }
    public IList<string> OperationsHelpText { get; }

    public RPNCaluculator()
    {
        
    }
    
    public double Calculate(IList<Token> expression)
    {
        throw new NotImplementedException();
    }
}