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
    protected override IViewComponent Content => new CueViewContent(_cueData.Item2);

    public override Screen? Navigate(string input)
    {
        return this;
    }
}

class DivisionView : IViewComponent
{
    public const int Width = 20;
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

    /**
       Provides the content of this view as a list of horizontal lines.
     */
    public List<string> ToLines()
    {
        var lines = new List<string>();
        var divisionName = _division.DivisionName;
        string centered = divisionName.PadLeft((divisionName.Length + Width) / 2);
        lines.Add(centered.PadRight(Width));
        lines.Add(new string('-', Width));
        foreach (var stop in _division.Stops)
            lines.Add($"{stop}".PadRight(Width));
        return lines;
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
        // Each column is one line of renderable data:
        // col[0]:  Great             Swell       Pedal
        // col[1]: --------          --------    --------
        var columns = _divisions.Select(d => new DivisionView(d).ToLines()).ToList();
        int height = columns.Max(c => c.Count); // The distance down to loop through

        for (int row = 0; row < height; row++)
        {
            foreach (var col in columns)
            {
                string line = row < col.Count ? col[row] : new string(' ', DivisionView.Width);
                Console.Write(line + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
