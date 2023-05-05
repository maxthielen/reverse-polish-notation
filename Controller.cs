namespace reverse_polish_notation;

public class Controller
{
    private ICalculator _calc;
    private IParser _parser;
    private IMenu _menu;

    public Controller(ICalculator calc, IParser parser, IMenu menu)
    {
        _calc = calc;
        _parser = parser;
        _menu = menu;
    }

    public void Run()
    {
        _menu.ShowMenu();
        var input = string.Empty;
        do
        {
            Console.Write("> ");
            input = Console.ReadLine() ?? "quit";
            switch (input)
            {
                case "q":
                    break;
                case "h":
                    _menu.ShowHelp();
                    break;
                case "o":
                    _menu.ShowOperations();
                    break;
                default:
                    // an RPN expression is expected here
                    try
                    {
                        var split = _parser.Tokenize(input);
                        if (split.Count != 0)
                        {
                            var tokens = _parser.Lex(split);
                            var result = _calc.Calculate(tokens);
                            Console.WriteLine($"\n {result}\n");
                        }
                    }
                    // if the input is not valid, an exception is thrown by calculator or parser
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        } while(!input.ToLower().Equals("q"));
        Console.WriteLine("\nCalculator is quitting. Bye!");
    }
}