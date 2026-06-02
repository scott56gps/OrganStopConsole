namespace OrganStopConsole.Models;

public record Piece
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string? Composer{ get; init; }
    public List<StopScheme> StopSchemes { get; init; } = [];
}

public record StopScheme
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string? Notes { get; init; }
    public Organ Organ { get; init; } = new();
    public List<StopCue> StopCues { get; init; } = [];
}

public record Organ
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Location { get; init; } = "";
}

public record StopCue
{
    public int Id { get; init; }
    public string? Label { get; init; }
}

public record StopCueDetail
{
    public int Id { get; init; }
    public string? Label { get; init; }
    public List<Division> Divisions { get; init; } = [];
}

public record Division
{
    public string Name { get; init; } = "";
    public bool HasExpression { get; init; }
    public ExpressionPosition? ExpressionPosition { get; init; }
    public List<Stop> Stops { get; init; } = [];
}

public record Stop
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string? Pitch { get; init; }
    public StopFamily Family { get; init; } = new();
}
