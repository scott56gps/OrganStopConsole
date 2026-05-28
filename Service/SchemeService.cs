using System.Text.Json;
using OrganStopConsole.Models;

namespace OrganStopConsole.Service;

public class SchemeService
{
    private readonly NetworkClient _networkClient;

    public SchemeService(NetworkClient networkClient)
    {
        _networkClient = networkClient;
    }

    /**
       Gets the detailed cues for a scheme.
    */
    public async Task<List<StopCueDetail>> GetCueDetails(int schemeId)
    {
        try
        {
            return await _networkClient.SendRequest<List<StopCueDetail>>($"/api/schemes/{schemeId}/stop-cues/detail");
        }
        catch (HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to contact the API.", e);
        }
        catch (JsonException e)
        {
            throw new InvalidOperationException("Failed to parse pieces response.", e);
        }
    }
}
