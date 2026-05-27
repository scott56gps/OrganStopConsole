using OrganStopConsole.UI.ViewModels;

namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly List<PieceSummary> _pieceSummaries;

    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");
    protected override IViewComponent Content => new OptionListView(
        _pieceSummaries.Select(p => $"{p.PieceName} - {p.ComposerName}").ToList()
    );

    public PieceSelectScreen(List<PieceSummary> pieceSummaries)
    {
        _pieceSummaries = pieceSummaries;
    }

    public override Task<NavResult> Navigate(string input)
    {
        if (input == "q") return Task.FromResult<NavResult>(new Quit());
        if (ParseSelection(input, _pieceSummaries.Count) is int index)
            return Task.FromResult<NavResult>(new Push(new SchemeSelectScreen(_pieceSummaries[index].PieceName)));
        return Task.FromResult<NavResult>(new Identity());
    }
}
