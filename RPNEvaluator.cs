namespace reverse_polish_notation;

public class RpnEvaluator : IExpressionEvaluator
{
    private ICalculator _calculator;

    public ICalculator Calculator { get; set; }
    public IParser Parser { get; set; }

    public RpnEvaluator(ICalculator calculator, IParser parser)
    {
        Parser = parser;
        Calculator = calculator;
        // TODO: set the supported operations for Parser obtained from calculator
    }

    public EvaluationResult Evaluate(string expression)
    {
        var parsed = Parser.Tokenize(expression);
        var tokens = Parser.Lex(parsed);
        var result = Calculator.Calculate(tokens);
        return new EvaluationResult(result: result);
    }

    public IList<string> Help => new List<string>{ "nothing yet" };
    
    public string Description => "RPN Calculator";
}