using System.Diagnostics;

namespace reverse_polish_notation;

public class RpnCalculator: ICalculator
{
    public IList<string> SupportedOperators { get; }
    public IList<string> OperationsHelpText { get; }

    public RpnCalculator()
    {
        SupportedOperators = new List<string> { "+", "-", "*", "/", "^", "sqrt" };
        OperationsHelpText = new List<string> { "+: plus - calculates the addition of two numbers", 
                                                "-: minus - calculates the subtraction of two numbers", 
                                                "*: multiply - calculates the multiplication of two numbers", 
                                                "/: divide - calculates the division of two numbers", 
                                                "^: exponent - calculates the exponential of two numbers", 
                                                "sqrt: square root - calculates the root of a number" };
    }
    
    public double Calculate(IList<Token> expression)
    {
        var n = new Stack<double>();
        foreach (Token t in expression)
        {
            if (t.IsNumber) n.Push(t.NumericValue);
            else if (t.IsOperator)
            {
                if (t.Value == "+") n.Push(n.Pop() + n.Pop());
                else if (t.Value == "-") n.Push(n.Pop() - n.Pop());
                else if (t.Value == "*") n.Push(n.Pop() * n.Pop());
                else if (t.Value == "/") n.Push(n.Pop() / n.Pop());
                else if (t.Value == "^") n.Push(Math.Pow( n.Pop(), n.Pop() ));
                else if (t.Value == "sqrt") n.Push(Math.Sqrt( n.Pop() ));
                else throw new ArgumentException();
            }
            else throw new ArgumentException();
        }

        if (n.Count == 1) return n.Pop();
        throw new UnreachableException();
    }
}