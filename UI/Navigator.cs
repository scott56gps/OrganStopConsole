namespace OrganStopConsole.UI;

public class Navigator
{
    private readonly Stack<Screen> _stack = new();

    public void Push(Screen screen) => _stack.Push(screen);

    public void Run()
    {
        while (_stack.Count > 0)
        {
            var current = _stack.Peek();
            current.Render();
            var input = Console.ReadLine() ?? "";
            var next = current.Navigate(input);
            if (next is not null)
                _stack.Push(next);
            else
                _stack.Pop();
        }
    }
}
