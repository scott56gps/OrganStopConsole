namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly List<string> _pieces = ["Wachet Auf - Bach", "Mode de Re - Langlais", "Wedding March - Mader"];
    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");

    protected override IViewComponent Content => new OptionListView(_pieces);

    public override Screen? Navigate(string input)
    {
        // TODO: Parse input, return next screen
        return null;
    }
}
