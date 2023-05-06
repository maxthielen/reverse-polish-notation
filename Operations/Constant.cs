namespace reverse_polish_notation;

public class Constant: Operation, INullaryOperation
{
    public Constant(string name, string op, string desc, double val): base (name, op, desc)
    {
        Value = val;
    }

    public double Value { get; }
} 