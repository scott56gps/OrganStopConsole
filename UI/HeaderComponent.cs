namespace OrganStopConsole.UI;

public class HeaderComponent : IViewComponent
{
    private readonly string _title;

    public HeaderComponent(string title)
    {
        _title = title;
    }

    public void Render()
    {
        string centered = _title.PadLeft((_title.Length + Console.WindowWidth) / 2);
        Console.WriteLine(centered);
        Console.WriteLine(new string('-', Console.WindowWidth));
    }
}
