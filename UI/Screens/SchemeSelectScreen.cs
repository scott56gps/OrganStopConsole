namespace OrganStopConsole.UI.Screens;

class SchemeSelectScreen : Screen
{
    private readonly string _pieceName = "Mode de Re";
    private readonly List<string> _schemes = ["Home Organ", "Hermiston 9th Street", "Richland Thayer", "Richland Gage"];

    protected override IViewComponent Header => new HeaderComponent($"Please select a scheme for {_pieceName}:");

    protected override IViewComponent Content => new OptionListView(_schemes);

    public SchemeSelectScreen(string pieceName)
    {
        _pieceName = pieceName;
    }

    public override Screen? Navigate(string input)
    {
        var selectedIndex = ParseSelection(input, _schemes.Count);
        if (selectedIndex == null) return this;
        return new CueSelectScreen();
    }
}
