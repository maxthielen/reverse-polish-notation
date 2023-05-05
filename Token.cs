namespace reverse_polish_notation;

public class Token
{
    public TokenType TokenType { get; }
    public string Value { get; }
    public double NumericValue { get; }
    public bool IsOperator { get; }
    public bool IsNumber { get; }

    public Token(TokenType tokenType, string text)
    {
        
    }
}