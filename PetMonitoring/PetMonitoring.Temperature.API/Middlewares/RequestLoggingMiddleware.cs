using System.Diagnostics;
using System.Text;

namespace PetMonitoring.Temperature.API.Middlewares
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
            var sw = Stopwatch.StartNew();

            try
            {
                context.Request.EnableBuffering();

                var request = context.Request;

                var queryString = request.QueryString.HasValue
                    ? request.QueryString.Value
                    : string.Empty;

                var headers = request.Headers
                    .Where(h => !IsSensitiveHeader(h.Key))
                    .ToDictionary(h => h.Key, h => h.Value.ToString());

                string body = string.Empty;

                if (IsJson(request))
                {
                    request.Body.Position = 0;

                    using var reader = new StreamReader(
                        request.Body,
                        Encoding.UTF8,
                        false,
                        leaveOpen: true
                    );

                    body = await reader.ReadToEndAsync();
                    request.Body.Position = 0;

                    body = Truncate(body, 2000);
                }

                _logger.LogInformation(
                    "Request started \n {@Request}",
                    new
                    {
                        Method = request.Method,
                        Path = request.Path,
                        Query = queryString,
                        Headers = headers,
                        Body = body
                    }
                );

                await _next(context);

                sw.Stop();

                _logger.LogInformation(
                    "Request finished {Method} {Path} - {StatusCode} in {ElapsedMs} ms",
                    request.Method,
                    request.Path,
                    context.Response.StatusCode,
                    sw.ElapsedMilliseconds
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unhandled exception. Path: {Path}, Method: {Method}",
                    context.Request.Path,
                    context.Request.Method);

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        error = "Internal Server Error"
                    });
                }
            }
        }
        private static bool IsJson(HttpRequest request)
        => request.ContentType?.Contains("application/json") == true;

        private static bool IsSensitiveHeader(string header)
            => header.Equals("Authorization", StringComparison.OrdinalIgnoreCase)
            || header.Equals("Cookie", StringComparison.OrdinalIgnoreCase);

        private static string Truncate(string value, int maxLength)
            => string.IsNullOrEmpty(value)
                ? value
                : value.Length <= maxLength
                    ? value
                    : value.Substring(0, maxLength) + "...(truncated)";
    }
}
