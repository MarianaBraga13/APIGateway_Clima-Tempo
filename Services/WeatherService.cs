using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherGateway.DTOs;

namespace WeatherGateway.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY = "SUA_CHAVE_WEATHERAPI";
        private const string BASE_URL = "http://api.weatherapi.com/v1/current.json";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponseDto?> GetWeatherAsync(string city)
        {
            // Monta a URL da API externa
            var url = $"{BASE_URL}?key={API_KEY}&q={city}&aqi=no";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<WeatherApiResponse>(url);

                if (response == null) return null;

                // Mapeia para o seu DTO de saída
                return new WeatherResponseDto
                {
                    City = response.Location.Name,
                    Condition = response.Current.Condition.Text,
                    TemperatureC = response.Current.TempC,
                    Humidity = response.Current.Humidity
                };
            }
            catch
            {
                return null;
            }
        }
    }

    // Classes para mapear JSON da WeatherAPI (simplificado)
    public class WeatherApiResponse
    {
        public Location Location { get; set; } = new Location();
        public Current Current { get; set; } = new Current();
    }

    public class Location { public string Name { get; set; } = string.Empty; }
    public class Current
    {
        public float TempC { get; set; }
        public int Humidity { get; set; }
        public Condition Condition { get; set; } = new Condition();
    }

    public class Condition { public string Text { get; set; } = string.Empty; }
}