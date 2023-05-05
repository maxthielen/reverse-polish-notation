namespace reverse_polish_notation;

public interface IMenu
{
    public IList<string> OperationsHelp { get; set; }

    public void ShowMenu();
    public void ShowOperations();
    public void ShowHelp();
}