namespace reverse_polish_notation;

public class Addition: Operation, IBinaryOperation
{
    public Addition() : base("Addition", "+", "calculates the addition of two numbers")
    {
    }

    public double Calculate(double lhs, double rhs)
    {
        return lhs + rhs;
    }
}