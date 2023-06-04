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
            if (_menu is not null) _menu.Help = value?.Help ?? throw new Exception("unable to set _currentEvaluator to null");
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
        Console.WriteLine($"Current Evaluator: {_currentEvaluator.Description}" +
                          $"\n\tAvailable Evaluators: {String.Join("\n\t\t", Evaluators.Select(e => e.Description))}" +
                          $"\n\tenter 1 - {Evaluators.Count} to select your next evaluator.");
        string input;
        int index;
        do
        {
            Console.Write("> ");
            input = Console.ReadLine() ?? "";
        } while (!int.TryParse(input, out index) && (index > Evaluators.Count || index < 1));
    
        CurrentEvaluator = Evaluators[index - 1];
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