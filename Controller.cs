namespace reverse_polish_notation;

public class Controller
{
    private IMenu _menu;

    public List<IExpressionEvaluator> Evaluators { get; } = new();

    private IExpressionEvaluator _currentEvaluator;

    public IExpressionEvaluator CurrentEvaluator
    {
        get => _currentEvaluator;
        set
        {
            if (_menu is not null) _menu.Help = value?.Help;
            _currentEvaluator = value;
        }
    }

    public Controller(IExpressionEvaluator[] evaluators, IMenu menu)
    {
        Evaluators.AddRange(evaluators);
        _menu = menu;

        CurrentEvaluator = Evaluators.First();
    }
    
    private void _switchEvaluator()
    {
        do
        {
            var input = Console.ReadLine();
        } while ( /*need some condition */);
    }

    public void Run()
    {
        _menu.ShowMenu();
        string input;
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
                case "s":
                    _switchEvaluator();
                    break;
                default:
                    // an expression is expected here
                    try
                    {
                        var eval = CurrentEvaluator.Evaluate(input);
                        var output = eval.Success ? $"\n {eval.Result}\n" : eval.ErrorMessage;
                        Console.WriteLine(output);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        } while(!input.ToLower().Equals("q"));
        Console.WriteLine("\nCalculator is quitting. Bye!");
    }
}