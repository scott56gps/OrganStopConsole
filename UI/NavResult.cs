using OrganStopConsole.UI;

public abstract record NavResult;
public record Push(Screen Screen) : NavResult;
public record Pop : NavResult;
public record Quit : NavResult;
public record Identity : NavResult;
