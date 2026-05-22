namespace OrganStopConsole.UI;

public abstract class Screen : IViewComponent
{
    protected abstract IViewComponent Header { get; }
    protected abstract IViewComponent Content { get; }
    protected virtual IReadOnlyList<CommandHint> Commands =>
        [new CommandHint("q", "Quit")];

    public abstract NavResult Navigate(string input);

    protected int? ParseSelection(string input, int count)
    {
        if (int.TryParse(input, out int selection) && selection >= 1 && selection <= count)
            return selection - 1; //convert to zero-based index
        return null; //incorrect input was parsed
    }

    public void Render()
    {
        Console.Clear();
        Header.Render();
        Content.Render();
        new CommandBar(Commands).Render();
    }
}
