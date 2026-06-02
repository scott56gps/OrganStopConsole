using OrganStopConsole.Models;
using OrganStopConsole.Service;

namespace OrganStopConsole.UI.Screens;

class CueSelectScreen : Screen
{
    private readonly int _schemeId;
    private readonly SchemeService _schemeService = new SchemeService(new NetworkClient());
    private readonly List<StopCue> _cues;

    protected override IViewComponent Header => new HeaderComponent("Please select a cue:");
    protected override IViewComponent Content => new OptionListView(
        _cues.Select(c => $"{c.Label}").ToList()
    );
    protected override IReadOnlyList<CommandHint> Commands =>
        [.. base.Commands, new CommandHint("b", "Back")];

    public CueSelectScreen(int schemeId, List<StopCue> cues)
    {
        _schemeId = schemeId;
        _cues = cues;
    }

    public override async Task<NavResult> Navigate(string input)
    {
        if (input == "q") return new Quit();
        if (input == "b") return new Pop();
        var selectedIndex = ParseSelection(input, _cues.Count);
        if (ParseSelection(input, _cues.Count) is int index)
            return new Push(new CueViewScreen(
                                await _schemeService.GetCueDetails(_schemeId)));
        return new Identity();
    }
}
