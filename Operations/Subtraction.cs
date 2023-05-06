namespace reverse_polish_notation;

public class Subtraction: Operation, IBinaryOperation
{
    public Subtraction() : base("Subtraction", "-", "calculates the subtraction of two numbers")
    {
    }

    public double Calculate(double lhs, double rhs)
    {
        return lhs - rhs;
    }
}