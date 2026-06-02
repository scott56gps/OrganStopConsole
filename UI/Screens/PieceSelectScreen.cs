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
            var selectedPiece = _pieces[index];
            if (selectedPiece.StopSchemes.Count == 1)
            {
                return Task.FromResult<NavResult>(
                    new Push(new CueSelectScreen(
                                 selectedPiece.StopSchemes[0].Id,
                                 selectedPiece.StopSchemes[0].StopCues)));
            }
            else
            {
                return Task.FromResult<NavResult>(new Push(new SchemeSelectScreen(selectedPiece)));
            }
        }
        return Task.FromResult<NavResult>(new Identity());
    }
}
