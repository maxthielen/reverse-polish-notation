using System.Data.Common;

namespace reverse_polish_notation;

public interface ICalculator
{
    public IList<string> SupportedOperators { get; }
    public IList<string> OperationsHelpText { get; }

    public double Calculate(IList<Token> expression);
}