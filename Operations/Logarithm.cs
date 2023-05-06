namespace reverse_polish_notation;

public class Logarithm : Operation, IUnaryOperation
{
    public Logarithm() : base("Logarithm", "ln", "calculates the natural logarithm of a number")
    {
    }

    public double Calculate(double operand)
    {
        return Math.Log(operand);
    }
}