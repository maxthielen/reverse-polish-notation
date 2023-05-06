using System.Collections;
using System.Diagnostics;

namespace reverse_polish_notation;

public class RpnCalculator: ICalculator, ICollection<IOperation>
{
    private bool Verbose { get; }
    private IDictionary<string, IOperation> _operations;

    public IList<string> SupportedOperators
    {
        get
        {
            var tmp = new List<string>();
            foreach (IOperation o in _operations.Values) tmp.Add(o.Operator);
            return tmp;
        }
    }

    public IList<string> OperationsHelpText
    {
        get
        {
            var tmp = new List<string>();
            foreach (IOperation o in _operations.Values) tmp.Add($"{o.Operator}:\t {o.Name} -\t {o.Description}");
            return tmp;
        }
    }

    public int Count { get; private set; }
    public bool IsReadOnly { get; }

    public RpnCalculator(bool verbose = false)
    {
        Verbose = verbose;
        _operations = new Dictionary<string, IOperation>();

        Count = 0;
        IsReadOnly = false;
    }
    
    public double Calculate(IList<Token> expression)
    {
        var n = new Stack<double>();
        var stepCount = 1;
        foreach (Token t in expression)
        {
            if(Verbose) Console.WriteLine($"Step {stepCount}:");
            switch (t.TokenType)
            {
                case TokenType.Number:
                    if(Verbose) Console.WriteLine($"\t pushed {t.Value}");
                    n.Push(t.NumericValue);
                    break;
                case TokenType.Operator:
                    if(!_operations.ContainsKey(t.Value)) 
                        throw new InvalidOperationException($"Unknown operation: {t.Value}");
                    
                    switch (_operations[t.Value])
                    {
                        case IBinaryOperation binOp:
                        {
                            double x = n.Pop();
                            double y = n.Pop();
                            if (Verbose) Console.WriteLine($"\t popped {x} and {y}");
                            double s = binOp.Calculate(y, x);
                            n.Push(s);
                            if (Verbose) Console.WriteLine($"\t pushed {y} {binOp.Operator} {x} = {s}");
                            break;
                        }
                        case IUnaryOperation unOp:
                        {
                            double x = n.Pop();
                            if (Verbose) Console.WriteLine($"\t popped {x}");
                            double s = unOp.Calculate(x);
                            n.Push(s);
                            if (Verbose) Console.WriteLine($"\t pushed {unOp.Operator} of {x} = {s}");
                            break;
                        }
                        case INullaryOperation nullOp:
                            n.Push(nullOp.Value);
                            break;
                    }
                    break;
                default:
                    throw new InvalidOperationException($"Unknown token type: {t.TokenType}");
                    
            }

            if (!Verbose) continue;
            Console.Write("Current stack:");
            foreach (double d in n) Console.Write($" {d},");
            Console.WriteLine();
            stepCount++;
        }

        if (n.Count == 1) return n.Pop();
        throw new UnreachableException();
    }

    public IEnumerator<IOperation> GetEnumerator()
    {
        return _operations.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(IOperation item)
    {
        Count++;
        _operations.Add(item.Operator, item);
    }

    public void Clear()
    {
        Count = 0;
        _operations.Clear();
    }

    public bool Contains(IOperation item)
    {
        return _operations.ContainsKey(item.Operator);
    }

    public void CopyTo(IOperation[] array, int arrayIndex)
    {
        _operations.Values.CopyTo(array, arrayIndex);
    }

    public bool Remove(IOperation item)
    {
        Count--;
        return _operations.Remove(item.Operator);
    }
}