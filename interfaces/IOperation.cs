namespace reverse_polish_notation;

public interface IOperation
{
    public string Name { get; }
    public string Operator { get; }
    public string Description { get; }
}