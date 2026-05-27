using System.Text.Json;
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
        try
        {
            return await _networkClient.SendRequest<List<Piece>>("/api/pieces");
        } catch (HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to contact the API.", e);
        } catch (JsonException e)
        {
            throw new InvalidOperationException("Failed to parse pieces response.", e);
        }
    }
}
