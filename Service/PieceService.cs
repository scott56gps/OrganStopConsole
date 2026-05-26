using OrganStopConsole.Models;

namespace OrganStopConsole.Service;

public class PieceService
{
    private readonly NetworkClient _networkClient;

    public PieceService(NetworkClient networkClient)
    {
        _networkClient = networkClient;
    }

    public async Task<List<Piece>> GetPieces()
    {
        return await _networkClient.SendRequest<List<Piece>>("/api/pieces");
    }
}
