using OrganStopConsole.Models;

namespace OrganStopConsole.UI.Screens;

class CueSelectScreen : Screen
{
    private readonly List<StopCue> _cues;

    protected override IViewComponent Header => new HeaderComponent("Please select a cue:");
    protected override IViewComponent Content => new OptionListView(
        _cues.Select(c => $"{c.Label}").ToList()
    );
    protected override IReadOnlyList<CommandHint> Commands =>
        [.. base.Commands, new CommandHint("b", "Back")];

    public CueSelectScreen(List<StopCue> cues)
    {
        _cues = cues;
    }

    public override Task<NavResult> Navigate(string input)
    {
        if (input == "q") return Task.FromResult<NavResult>(new Quit());
        if (input == "b") return Task.FromResult<NavResult>(new Pop());
        var selectedIndex = ParseSelection(input, _cues.Count);
        if (selectedIndex != null) return Task.FromResult<NavResult>(new Push(new CueViewScreen()));
        return Task.FromResult<NavResult>(new Identity());
    }
}
