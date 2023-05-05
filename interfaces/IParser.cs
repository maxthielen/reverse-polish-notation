namespace reverse_polish_notation;

public interface IParser
{
    public IList<string> SupportedOperators { get; }

    public IList<Token> Tokenize(string expression);
}