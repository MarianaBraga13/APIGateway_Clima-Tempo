namespace WeatherGateway.DTOs
{
    public class WeatherResponseDto
    {
        public required string City { get; set; }
        public required string Condition { get; set; }
        public float TemperatureC { get; set; }
        public int Humidity { get; set; }
    }
}