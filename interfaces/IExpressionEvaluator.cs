namespace reverse_polish_notation;

public interface IExpressionEvaluator
{
    EvaluationResult Evaluate(string expression);
    
    IList<string> Help { get; }
    
    string Description { get; }
}