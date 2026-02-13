using System.Diagnostics;

namespace PetMonitoring.Movement.API.Middlewares
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
        public async Task Invoke(HttpContext context)
        {
            try
            {
                var sw = Stopwatch.StartNew();
                _logger.LogInformation("Request started. {Method} {Path}", context.Request.Method, context.Request.Path);
                await _next(context);
                _logger.LogInformation("Request finished. {Method} {Path} - {StatusCode} in {Elapsed} ms", context.Request.Method, context.Request.Path, context.Response.StatusCode, sw.ElapsedMilliseconds);
                sw.Stop();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Unhandled exception. Path: {Path}, Method: {Method}", context.Request.Path, context.Request.Method);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Internal Server Error"
                });
            }
        }
    }
}
