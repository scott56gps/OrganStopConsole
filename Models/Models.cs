namespace OrganStopConsole.Models;

public record Piece(int Id, string Name, string? Composer, List<StopScheme> StopSchemes);
public record StopScheme(int Id, string Name, string? Notes, Organ Organ, List<StopCue> StopCues);
public record Organ(int Id, string Name, string Location);
public record StopCue(int Id, string? Label);
public record StopCueDetail(int Id, string? Label, List<Division> Divisions);
public record Division(string Name, bool HasExpression, ExpressionPosition? ExpressionPosition, List<Stop> Stops);
public record Stop(int Id, string Name, string? Pitch, StopFamily Family);
