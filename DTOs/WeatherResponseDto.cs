namespace WeatherGateway.Api.DTOs;

public class WeatherResponseDto
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public decimal TemperatureC { get; set; }
    public string Condition { get; set; } = string.Empty;
}