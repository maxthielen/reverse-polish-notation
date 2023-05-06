namespace reverse_polish_notation;

public interface IBinaryOperation
{
    // lhs => left-hand-side & rhs => right-hand-side
    public double Calculate(double lhs, double rhs);
}