namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly List<string> _pieces = ["Wachet Auf - Bach", "Mode de Re - Langlais", "Wedding March - Mader"];
    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");

    protected override IViewComponent Content => new OptionListView(_pieces);

    public override Screen? Navigate(string input)
    {
        var selectedIndex = ParseSelection(input, _pieces.Count);
        if (selectedIndex == null) return this;
        // TODO: Detect if there is only one scheme for the given piece and skip ahead to the CueSelectScreen if so
        return new SchemeSelectScreen(input);
    }
}
