using OrganStopConsole.Models;

namespace OrganStopConsole.UI.Screens;

class SchemeSelectScreen : Screen
{
    private readonly Piece _piece;
    private readonly List<string> _schemes = ["Home Organ", "Hermiston 9th Street", "Richland Thayer", "Richland Gage"];

    protected override IViewComponent Header => new HeaderComponent($"Please select a scheme for {_piece.Name}:");
    protected override IViewComponent Content => new OptionListView(_schemes);
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
        var selectedIndex = ParseSelection(input, _schemes.Count);
        if (selectedIndex != null) return Task.FromResult<NavResult>(new Push(new CueSelectScreen()));
        return Task.FromResult<NavResult>(new Identity());
    }
}
