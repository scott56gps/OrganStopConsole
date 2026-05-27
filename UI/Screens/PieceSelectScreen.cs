using OrganStopConsole.UI.ViewModels;

namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly PieceSelectViewModel viewModel = new PieceSelectViewModel();
    private readonly List<PieceSummary> _pieceSummaries;

    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");
    protected override IViewComponent Content => new OptionListView(_pieces.Select(p => $"{p.PieceName} - {p.ComposerName}").ToList());

    public PieceSelectScreen(List<PieceSummary> pieceSummaries)
    {
        _pieceSummaries = pieceSummaries;
    }

    public override NavResult Navigate(string input)
    {
        if (input == "q") return new Quit();
        if (ParseSelection(input, _pieces.Count) is int index)
            return new Push(new SchemeSelectScreen(_pieces[index].PieceName));
        return new Identity();
    }
}
