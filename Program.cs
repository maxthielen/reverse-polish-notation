namespace reverse_polish_notation;

public class Program
{
    static void Main(string[] args)
    {
        var calculator = new RpnCalculator(true)
        {
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division(),
            new Sqrt(),
            new Exponent(),
            new Logarithm(),
            new Constant("pi", "pi", "constant pi", Math.PI),
            new Constant("e", "e", "constant e", Math.E)
        };

        var parser = new Parser(calculator.SupportedOperators);
        var menu = new TextMenu(calculator.OperationsHelpText);
        var controller = new Controller(calculator, parser, menu);
        
        controller.Run();
    }
}