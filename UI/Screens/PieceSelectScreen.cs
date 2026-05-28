using OrganStopConsole.Models;

namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly List<Piece> _pieces;

    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");
    protected override IViewComponent Content => new OptionListView(
        _pieces.Select(p => $"{p.Name} - {p.Composer}").ToList()
    );

    public PieceSelectScreen(List<Piece> pieces)
    {
        _pieces = pieces;
    }

    public override Task<NavResult> Navigate(string input)
    {
        if (input == "q") return Task.FromResult<NavResult>(new Quit());

        if (ParseSelection(input, _pieces.Count) is int index)
        {
            // Do we need to push the SchemeSelectScreen?
            if (_pieces[index].StopSchemes.Count > 1)
            return Task.FromResult<NavResult>(new Push(new SchemeSelectScreen(_pieces[index])));
        }
        return Task.FromResult<NavResult>(new Identity());
    }
}
