using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WeatherGateway.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER = "X-API-Key";
        private const string API_KEY_VALUE = "SUA_CHAVE_AQUI"; // troque por uma chave real

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("API Key ausente");
                return;
            }

            if (!extractedApiKey.Equals(API_KEY_VALUE))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("API Key inválida");
                return;
            }

            await _next(context);
        }
    }
}