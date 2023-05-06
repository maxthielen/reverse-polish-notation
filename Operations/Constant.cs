namespace reverse_polish_notation;

public class Constant: Operation, INullaryOperation
{
    public Constant(string name, string op, string desc) : base(name, op, desc)
    {
    }

    public double Value { get; }
} 