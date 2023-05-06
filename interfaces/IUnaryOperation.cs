namespace reverse_polish_notation;

public interface IUnaryOperation: IOperation
{
    public double Calculate(double operand);
}