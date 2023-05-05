namespace reverse_polish_notation;

public class Parser: IParser
{
    private IList<string> _supportedOperators;
    public IList<string> SupportedOperators { get => _supportedOperators; set => _supportedOperators = value; }

    public Parser()
    {
        _supportedOperators = new List<string> { "+", "-", "*", "/", "^", "sqrt" };
    }
    
    public Parser(IList<string> supportedOperators)
    {
        _supportedOperators = supportedOperators;
    }

    public IList<Token> Tokenize(string expression)
    {
        string[] expressions = expression.Split(' ');
        var tokens = new List<Token>();
        foreach(string e in expressions)
        {
            if (e.All(char.IsDigit)) tokens.Add(new Token(TokenType.Number, e));
            else if (_supportedOperators.Contains(e)) tokens.Add(new Token(TokenType.Operator, e));
            else throw new ArgumentException();
        }
        
        return tokens;
    }
}