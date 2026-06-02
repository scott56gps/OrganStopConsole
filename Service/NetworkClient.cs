using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrganStopConsole.Service;

public class NetworkClient
{
    private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };
    private static readonly HttpClient httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:5294"),
    };

    public async Task<T> SendRequest<T>(string endpoint)
    {
        using HttpResponseMessage response = await httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        var bytes = await response.Content.ReadAsByteArrayAsync();
        return JsonSerializer.Deserialize<T>(bytes, _jsonOptions)
            ?? throw new InvalidDataException($"Failed to deserialize response from {endpoint}");
    }
}
