namespace reverse_polish_notation;

public class Operation : IOperation
{
    public string Name { get; }
    public string Operator { get; }
    public string Description { get; }

    public Operation(string name, string op, string desc)
    {
        Name = name;
        Operator = op;
        Description = desc;
    }
}