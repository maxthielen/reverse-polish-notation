namespace reverse_polish_notation;

public class Program
{
    static void Main(string[] args)
    {
        var calculator = new RpnCalculator(true);
        var parser = new Parser(calculator.SupportedOperators);
        var menu = new TextMenu(calculator.OperationsHelpText);
        var controller = new Controller(calculator, parser, menu);
        
        controller.Run();
    }
}