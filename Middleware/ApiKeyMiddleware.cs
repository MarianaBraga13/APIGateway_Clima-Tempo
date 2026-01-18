namespace WeatherGateway.Api.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _headerName;
    private readonly string _validKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _headerName = configuration["Authentication:ClientApiKeyHeader"]!;
        _validKey = Environment.GetEnvironmentVariable("CLIENT_API_KEY")!;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(_headerName, out var clientKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key não informada");
            return;
        }

        if (clientKey != _validKey)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("API Key inválida");
            return;
        }

        await _next(context);
    }
}