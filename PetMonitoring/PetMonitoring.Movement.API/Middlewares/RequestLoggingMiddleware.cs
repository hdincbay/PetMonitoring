using System.Diagnostics;
using System.Text;

namespace PetMonitoring.Movement.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            var originalResponseBody = context.Response.Body;

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

                string requestBody = string.Empty;

                if (IsJson(request))
                {
                    request.Body.Position = 0;
                    using var reader = new StreamReader(
                        request.Body,
                        Encoding.UTF8,
                        false,
                        leaveOpen: true
                    );

                    requestBody = await reader.ReadToEndAsync();
                    request.Body.Position = 0;

                    requestBody = Truncate(requestBody, 2000);
                }

                _logger.LogInformation(
                    "Request started \n {@Request}",
                    new
                    {
                        Method = request.Method,
                        Path = request.Path,
                        Query = queryString,
                        Headers = headers,
                        Body = requestBody
                    }
                );
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);

                sw.Stop();

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                responseText = Truncate(responseText, 2000);

                _logger.LogInformation(
                    "Request finished \n {Method} {Path} - {StatusCode} in {ElapsedMs} ms {@Response}",
                    request.Method,
                    request.Path,
                    context.Response.StatusCode,
                    sw.ElapsedMilliseconds,
                    new
                    {
                        Body = responseText
                    }
                );

                await responseBody.CopyToAsync(originalResponseBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Unhandled exception. Path: {Path}, Method: {Method}",
                    context.Request.Path,
                    context.Request.Method
                );

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        error = "Internal Server Error"
                    });
                }
            }
            finally
            {
                context.Response.Body = originalResponseBody;
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
