namespace OrganStopConsole.UI;

class OptionListView : IViewComponent
{
    private readonly List<string> _options;

    public OptionListView(List<string> options)
    {
        _options = options;
    }

    public void Render()
    {
        for (int i = 0; i < _options.Count; i++)
            Console.WriteLine($"{i + 1}) {_options[i]}");
    }
}
