namespace reverse_polish_notation;

public class Exponent: Operation, IBinaryOperation
{
    public Exponent() : base("Exponents", "^", "calculates the power of one numbers to the other")
    {
    }

    public double Calculate(double lhs, double rhs)
    {
        return Math.Pow(lhs, rhs);
    }
}