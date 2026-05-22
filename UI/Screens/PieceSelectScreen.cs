namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly List<string> _pieces = ["Wachet Auf - Bach", "Mode de Re - Langlais", "Wedding March - Mader"];
    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");

    protected override IViewComponent Content => new OptionListView(_pieces);

    public override NavResult Navigate(string input)
    {
        if (input == "q") return new Quit();
        if (ParseSelection(input, _pieces.Count) is int index)
            return new Push(new SchemeSelectScreen(_pieces[index]));
        return new Identity();
    }
}
