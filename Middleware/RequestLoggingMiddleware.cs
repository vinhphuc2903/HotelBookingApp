using System.Diagnostics;

namespace MyHotelBookingApp.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var request = context.Request;
            _logger.LogInformation(
                "➡️ Incoming Request: {method} {url} from {ip}",
                request.Method,
                request.Path,
                context.Connection.RemoteIpAddress?.ToString()
            );

            // Lưu lại body nếu cần debug
            // request.EnableBuffering();
            // using var reader = new StreamReader(request.Body, leaveOpen: true);
            // var body = await reader.ReadToEndAsync();
            // request.Body.Position = 0;
            // _logger.LogInformation("Request Body: {body}", body);

            await _next(context);

            stopwatch.Stop();

            _logger.LogInformation(
                "⬅️ Response: {statusCode} - {method} {url} ({elapsed} ms)",
                context.Response.StatusCode,
                request.Method,
                request.Path,
                stopwatch.ElapsedMilliseconds
            );
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
