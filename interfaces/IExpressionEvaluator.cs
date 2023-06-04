namespace reverse_polish_notation;

public interface IExpressionEvaluator
{
    EvaluationResult Evaluate(string expression);
    
    string Help { get; }
    
    string Description { get; }
}