namespace OrganStopConsole.UI;

public abstract class Screen : IViewComponent
{
    protected abstract IViewComponent Header { get; }
    protected abstract IViewComponent Content { get; }
    protected virtual IReadOnlyList<CommandHint> Commands =>
        [new CommandHint("q", "Quit")];

    public void Render()
    {
        Console.Clear();
        Header.Render();
        Content.Render();
        new CommandBar(Commands).Render();
    }

    public abstract Screen? Navigate(string input);
}
