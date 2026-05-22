namespace OrganStopConsole.UI.Screens;

class CueSelectScreen : Screen
{
    private readonly List<string> _cues = ["mm. 1", "mm. 32", "mm. 45", "mm. 62"];

    protected override IViewComponent Header => new HeaderComponent("Please select a cue:");

    protected override IViewComponent Content => new OptionListView(_cues);

    public override Screen? Navigate(string input)
    {
        var selectedIndex = ParseSelection(input, _cues.Count);
        if (selectedIndex == null) return this;
        return new CueViewScreen();
    }
}
