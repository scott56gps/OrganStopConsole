namespace OrganStopConsole.UI;

public class Navigator
{
    private readonly Stack<Screen> _stack = new();

    public void Push(Screen screen) => _stack.Push(screen);

    public async Task Run()
    {
        while (_stack.Count > 0)
        {
            var current = _stack.Peek();
            current.Render();
            var input = Console.ReadLine() ?? "";
            var result = await current.Navigate(input);
            switch (result)
            {
                case Push p: _stack.Push(p.Screen); break;
                case Pop: _stack.Pop(); break;
                case Quit: _stack.Clear(); break;
                case Identity: break;
            }
        }
    }
}
