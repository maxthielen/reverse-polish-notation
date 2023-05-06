namespace reverse_polish_notation;

public class Multiplication: Operation, IBinaryOperation
{
    public Multiplication() : base("Multiplication", "*", "calculates the multiplication of two numbers")
    {
    }

    public double Calculate(double lhs, double rhs)
    {
        return lhs * rhs;
    }
}