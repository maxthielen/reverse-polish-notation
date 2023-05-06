namespace reverse_polish_notation;

public class Division: Operation, IBinaryOperation
{
    public Division() : base("Division", "/", "calculates the division of two numbers")
    {
    }

    public double Calculate(double lhs, double rhs)
    {
        return lhs / rhs;
    }
}