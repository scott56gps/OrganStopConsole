namespace OrganStopConsole.UI.Screens;

class CueViewScreen : Screen
{
    private readonly (string, List<(string Division, List<string> Stops)>) _cueData = (
        "1", [
            ("Great", ["8' Principal", "4' Octave"]),
            ("Swell", ["8' Hohlflote", "2 2/3' Mixture"])
        ]);
    private readonly string _pieceName = "Mode de re";

    protected override IViewComponent Header => new HeaderComponent($"Cue {_cueData.Item1}: {_pieceName}");
    protected override IViewComponent Content => new OptionListView(["1", "2"]);

    public override Screen? Navigate(string input)
    {
        return this;
    }
}

class DivisionView : IViewComponent
{
    private const int Width = 20;
    private readonly (string DivisionName, List<string> Stops) _division;

    public DivisionView((string, List<string>) division)
    {
        _division = division;
    }

    public void Render()
    {
        string centered = _division.DivisionName.PadLeft((_division.DivisionName.Length + Width) / 2);
        Console.WriteLine(centered);
        Console.WriteLine(new string('-', Width));
        foreach (var stop in _division.Stops)
            Console.WriteLine($"{stop}");
    }
}

class CueViewContent : IViewComponent
{
    private const int Padding = 8;
    private readonly List<(string Division, List<string> Stops)> _divisions;

    public CueViewContent(List<(string Division, List<string> Stops)> divisions)
    {
        _divisions = divisions;
    }

    public void Render()
    {
    }
}
