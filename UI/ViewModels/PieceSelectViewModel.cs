using OrganStopConsole.Service;

namespace OrganStopConsole.UI.ViewModels;

public class PieceSelectViewModel
{
    private readonly PieceService _pieceService = new PieceService(new NetworkClient());

    public async Task<List<PieceSummary>> GetPieceSummaries()
    {
        var pieces = await _pieceService.GetPieces();
        return pieces.Select(p => new PieceSummary(p.Name, p.Composer)).ToList();
    }
}
