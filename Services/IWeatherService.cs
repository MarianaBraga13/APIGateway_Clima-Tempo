using WeatherGateway.Api.DTOs;

public interface IWeatherService
{
    Task<WeatherResponseDto> GetWeatherAsync(string city);
}
