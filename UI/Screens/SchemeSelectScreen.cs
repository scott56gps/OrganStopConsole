using OrganStopConsole.Models;

namespace OrganStopConsole.UI.Screens;

class SchemeSelectScreen : Screen
{
    private readonly Piece _piece;

    protected override IViewComponent Header => new HeaderComponent($"Please select a scheme for {_piece.Name}:");
    protected override IViewComponent Content => new OptionListView(
        _piece.StopSchemes.Select(s => $"{s.Organ.Name} - {s.Name}").ToList()
    );
    protected override IReadOnlyList<CommandHint> Commands =>
        [..base.Commands, new CommandHint("b", "Back")];

    public SchemeSelectScreen(Piece piece)
    {
        _piece = piece;
    }

    public override Task<NavResult> Navigate(string input)
    {
        if (input == "q") return Task.FromResult<NavResult>(new Quit());
        if (input == "b") return Task.FromResult<NavResult>(new Pop());

        if (ParseSelection(input, _piece.StopSchemes.Count) is int index)
            return Task.FromResult<NavResult>(
                new Push(new CueSelectScreen(_piece.StopSchemes[index].StopCues)));
        return Task.FromResult<NavResult>(new Identity());
    }
}
