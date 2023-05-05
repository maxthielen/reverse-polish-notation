using System.Diagnostics;

namespace reverse_polish_notation;

public class RpnCalculator: ICalculator
{
    private bool _verbose { get; }
    public IList<string> SupportedOperators { get; }
    public IList<string> OperationsHelpText { get; }

    public RpnCalculator(bool verbose = false)
    {
        _verbose = verbose;
        
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
        int count = 1;
        foreach (Token t in expression)
        {
            if(_verbose) Console.WriteLine($"Step {count}:");
            if (t.IsNumber)
            {
                if(_verbose) Console.WriteLine($"\t pushed {t.Value}");
                n.Push(t.NumericValue);
            }
            else if (t.IsOperator)
            {
                if (t.Value == "+")
                {
                    double x = n.Pop();
                    double y = n.Pop();
                    if(_verbose) Console.WriteLine($"\t popped {x} and {y}");
                    double s = y + x;
                    n.Push( s );
                    if(_verbose) Console.WriteLine($"\t pushed {y} + {x} = {s}");
                }
                else if (t.Value == "-")
                {
                    double x = n.Pop();
                    double y = n.Pop();
                    if(_verbose) Console.WriteLine($"\t popped {x} and {y}");
                    double s = y - x;
                    n.Push( s );
                    if(_verbose) Console.WriteLine($"\t pushed {y} - {x} = {s}");
                }
                else if (t.Value == "*")
                {
                    double x = n.Pop();
                    double y = n.Pop();
                    if(_verbose) Console.WriteLine($"\t popped {x} and {y}");
                    double s = y * x;
                    n.Push( s );
                    if(_verbose) Console.WriteLine($"\t pushed {y} * {x} = {s}");
                }
                else if (t.Value == "/")
                {
                    double x = n.Pop();
                    double y = n.Pop();
                    if(_verbose) Console.WriteLine($"\t popped {x} and {y}");
                    double s = y / x;
                    n.Push( s );
                    if(_verbose) Console.WriteLine($"\t pushed {y} / {x} = {s}");
                }
                else if (t.Value == "^")
                {
                    double x = n.Pop();
                    double y = n.Pop();
                    if(_verbose) Console.WriteLine($"\t popped {x} and {y}");
                    double s = Math.Pow(y, x);
                    n.Push( s );
                    if(_verbose) Console.WriteLine($"\t pushed {y} ^ {x} = {s}");
                }
                else if (t.Value == "sqrt")
                {
                    double x = n.Pop();
                    if (_verbose) Console.WriteLine($"\t popped {x}");
                    double s = Math.Sqrt(x);
                    n.Push(s);
                    if (_verbose) Console.WriteLine($"\t pushed sqrt({x}) = {s}");
                }
                else throw new ArgumentException();
            }
            else throw new ArgumentException();

            if (_verbose)
            {
                Console.Write("Current stack:");
                foreach (double d in n) Console.Write($" {d},");
                Console.WriteLine();
                count++;
            }
        }

        if (n.Count == 1) return n.Pop();
        throw new UnreachableException();
    }
}