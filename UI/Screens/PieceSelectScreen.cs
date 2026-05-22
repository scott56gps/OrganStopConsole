namespace OrganStopConsole.UI.Screens;

class PieceSelectScreen : Screen
{
    private readonly List<string> _pieces = ["Wachet Auf - Bach", "Mode de Re - Langlais", "Wedding March - Mader"];
    protected override IViewComponent Header => new HeaderComponent("Please select a piece:");

    protected override IViewComponent Content => new PieceListView(_pieces);

    public override Screen? Navigate(string input)
    {
        // TODO: Parse input, return next screen
        return null;
    }
}

class PieceListView : IViewComponent
{
    private readonly List<string> _pieces;

    public PieceListView(List<string> pieces)
    {
        _pieces = pieces;
    }

    public void Render()
    {
        for (int i = 0; i < _pieces.Count; i++)
            Console.WriteLine($"{i+1}) {_pieces[i]}");
    }
}
