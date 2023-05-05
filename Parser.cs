namespace reverse_polish_notation;

public class Parser: IParser
{
    public IList<string> SupportedOperators { get; set; }

    public Parser()
    {
        throw new NotImplementedException();
    }
    
    public Parser(IList<string> supportedOperators)
    {
        SupportedOperators = supportedOperators;
    }

    public IList<string> Tokenize(string expression)
    {
        throw new NotImplementedException();
    }

    public IList<Token> Lex(IList<string> expression)
    {
        throw new NotImplementedException();
    }
}