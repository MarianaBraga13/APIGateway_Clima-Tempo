using Microsoft.AspNetCore.Mvc;
using WeatherGateway.Api.DTOs;
using WeatherGateway.Api.Services;

namespace WeatherGateway.Api.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherController(IWeatherService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna dados climáticos simplificados
    /// </summary>
    /// <remarks>
    /// Requer API Key no header X-API-Key
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<WeatherResponseDto>> Get([FromQuery] string city)
    {
        var result = await _service.GetWeatherAsync(city);
        return Ok(result);
    }
}