using OrganStopConsole.Models;

namespace OrganStopConsole.UI.Screens;

class CueViewScreen : Screen
{
    private readonly List<StopCueDetail> _cues;
    private int _currentIndex = 0;

    protected override IViewComponent Header => new HeaderComponent($"Cue {_currentIndex + 1}");
    protected override IViewComponent Content => new CueViewContent(_cues[_currentIndex].Divisions);
    protected override IReadOnlyList<CommandHint> Commands =>
        [.. base.Commands, new CommandHint("b", "Back"), new CommandHint("<enter>", "Next Cue")];

    public CueViewScreen(List<StopCueDetail> cues)
    {
        _cues = cues;
    }

    public override Task<NavResult> Navigate(string input) => input switch
    {
        ""  => Task.FromResult<NavResult>(AdvanceCue()),
        "q" => Task.FromResult<NavResult>(new Quit()),
        "b" => Task.FromResult<NavResult>(new Pop()),
        _   => Task.FromResult<NavResult>(new Identity())
    };

    private NavResult AdvanceCue()
    {
        _currentIndex = (_currentIndex < _cues.Count - 1) ? _currentIndex + 1 : 0;
        return new Identity();
    }
}

class CueViewContent : IViewComponent
{
    private const int Padding = 2;
    private readonly List<Division> _divisions;

    public CueViewContent(List<Division> divisions)
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
                Console.Write(line + new string(' ', Padding));
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

class DivisionView : IViewComponent
{
    public const int Width = 20;
    private readonly Division _division;

    public DivisionView(Division division)
    {
        _division = division;
    }

    public void Render()
    {
        var divisionName = _division.Name;
        string centered = divisionName.PadLeft((divisionName.Length + Width) / 2);
        Console.WriteLine(centered);
        Console.WriteLine(new string('-', Width));
        foreach (var stop in _division.Stops)
            Console.WriteLine($"{stop.Pitch} {stop.Name}");
    }

    /**
       Provides the content of this view as a list of horizontal lines.
     */
    public List<string> ToLines()
    {
        var lines = new List<string>();
        var divisionName = _division.Name;
        string centered = divisionName.PadLeft((divisionName.Length + Width) / 2);
        lines.Add(centered.PadRight(Width));
        lines.Add(new string('-', Width));
        foreach (var stop in _division.Stops)
            lines.Add($"{stop.Pitch} {stop.Name}");
        return lines;
    }
}
