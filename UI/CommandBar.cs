namespace OrganStopConsole.UI;

public class CommandBar : IViewComponent
{
    private readonly IReadOnlyList<CommandHint> _commands;

    public CommandBar(IReadOnlyList<CommandHint> commands)
    {
        _commands = commands;
    }

    public void Render()
    {
        Console.WriteLine();
        foreach (var hint in _commands)
            Console.Write($"  {hint.Key}: {hint.Label}  ");
        Console.WriteLine();
        Console.Write("> ");
    }
}
