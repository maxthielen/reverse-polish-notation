namespace reverse_polish_notation;

public class TextMenu : IMenu
{
    public IList<string> OperationsHelp { get; set; }

    public TextMenu(IList<string> operationsHelp)
    {
        OperationsHelp = operationsHelp;
    }
    
    public void ShowMenu()
    {
        Console.WriteLine("RPN Calculator" +
                          "\nEnter an RPN expression to evaluate." +
                          "\nEnter '(h)elp' for help." +
                          "\nEnter '(o)ps' for available operations." +
                          "\nEnter '(s)witch' to switch calculators." +
                          "\nEnter '(q)uit' to exit.");
    }

    public void ShowOperations()
    {
        Console.WriteLine("Calculator operations:");
        foreach (string s in OperationsHelp)
        {
            Console.WriteLine("\t" + s);
        }
    }

    public void ShowHelp()
    {
        Console.WriteLine("Enter expressions using RPN notation, for instance to calculate:" +
                          "\n\t2 + 3 * 4" +
                          "\n\tenter '2 3 4 * +'" +
                          "\nenter (o)ps to see available operations");
    }
}