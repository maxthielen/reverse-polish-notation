namespace reverse_polish_notation;

public class Sqrt: Operation, IUnaryOperation
{
    public Sqrt() : base("Square Root", "sqrt", "calculates the root of a number")
    {
    }

    public double Calculate(double operand)
    {
        return Math.Sqrt(operand);
    }
}