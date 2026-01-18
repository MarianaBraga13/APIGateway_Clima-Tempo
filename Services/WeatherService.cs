using System.Text.Json;
using WeatherGateway.Api.DTOs;

namespace WeatherGateway.Api.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<WeatherResponseDto> GetWeatherAsync(string city)
    {
        var apiKeyEnvName =
            _configuration["ExternalApis:WeatherApi:ApiKeyEnv"];

        var apiKey = Environment.GetEnvironmentVariable(apiKeyEnvName!);

        if (string.IsNullOrEmpty(apiKey))
            throw new Exception("Weather API Key não configurada");

        var baseUrl =
            _configuration["ExternalApis:WeatherApi:BaseUrl"];

        var url = $"{baseUrl}current.json?key={apiKey}&q={city}&lang=pt";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);

        var root = doc.RootElement;

        return new WeatherResponseDto
        {
            City = root.GetProperty("location").GetProperty("name").GetString()!,
            Country = root.GetProperty("location").GetProperty("country").GetString()!,
            TemperatureC = root.GetProperty("current").GetProperty("temp_c").GetDecimal(),
            Condition = root.GetProperty("current")
                .GetProperty("condition")
                .GetProperty("text")
                .GetString()!
        };
    }
}