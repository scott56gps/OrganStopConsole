using System.Text.Json;

namespace OrganStopConsole.Service;

public class NetworkClient
{
    private static readonly HttpClient httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:5294"),
    };

    public async Task<T> SendRequest<T>(string endpoint)
    {
        using HttpResponseMessage response = await httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        var bytes = await response.Content.ReadAsByteArrayAsync();
        return JsonSerializer.Deserialize<T>(bytes)
            ?? throw new InvalidDataException($"Failed to deserialize response from {endpoint}");
    }
}
