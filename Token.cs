namespace reverse_polish_notation;

using System.Linq;

public class Token
{
    public TokenType TokenType { get; }
    public string Value { get; }
    public double NumericValue { get; }
    public bool IsOperator { get; }
    public bool IsNumber { get; }
    
    public Token(TokenType tokenType, string text)
    {
        Value = text;
        TokenType = tokenType;

        if (tokenType == TokenType.Number)
        {
            IsNumber = true;
            IsOperator = false;
            NumericValue = Double.Parse(text);
        }
        else if(tokenType == TokenType.Operator)
        {
            IsNumber = false;
            IsOperator = true;
        }
        else throw new ArgumentException();
    }
}