using System.Collections;
using System.Diagnostics;
using System.Text;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Forwarder;
using Yarp.ReverseProxy.Model;

namespace PetMonitoring.Gateway.ApiGateway
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

            var request = context.Request;
            var originalPath = request.Path.Value;
            var originalResponseBody = context.Response.Body;

            context.Request.EnableBuffering();

            var query = request.QueryString.Value;

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
                    leaveOpen: true);

                requestBody = await reader.ReadToEndAsync();
                request.Body.Position = 0;

                requestBody = Truncate(requestBody, 2000);
            }

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            Exception? exception = null;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                sw.Stop();

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                responseText = Truncate(responseText, 2000);

                await responseBody.CopyToAsync(originalResponseBody);

                var proxyFeature = context.Features.Get<IReverseProxyFeature>();
                var routeConfig = proxyFeature?.Route?.Config;

                var routeId = routeConfig?.RouteId;
                var clusterId = proxyFeature?.Cluster?.Config?.ClusterId;

                var downstreamAddress = proxyFeature?
                    .AvailableDestinations?
                    .FirstOrDefault()?
                    .Model?
                    .Config?
                    .Address;

                var transformedPath = CalculateTransformedPath(
                    originalPath,
                    routeConfig
                );

                var downstreamUrl = downstreamAddress != null
                    ? $"{downstreamAddress.TrimEnd('/')}{transformedPath}{query}"
                    : null;

                _logger.LogInformation(
                    "Gateway Request Log {@Log}",
                    new
                    {
                        Request = new
                        {
                            Method = request.Method,
                            Scheme = request.Scheme,
                            Host = request.Host.Value,
                            Path = originalPath,
                            Query = query,
                            Headers = headers,
                            Body = requestBody
                        },
                        Routing = new
                        {
                            RouteId = routeId,
                            ClusterId = clusterId,
                            DownstreamUrl = downstreamUrl
                        },
                        Response = new
                        {
                            StatusCode = context.Response.StatusCode,
                            Body = responseText
                        },
                        Performance = new
                        {
                            ElapsedMs = sw.ElapsedMilliseconds
                        },
                        Error = exception == null
                            ? null
                            : new
                            {
                                exception.Message,
                                StackTrace = exception.StackTrace
                            }
                    }
                );
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

        private static string? CalculateTransformedPath(
            string? originalPath,
            RouteConfig? routeConfig)
        {
            if (originalPath == null || routeConfig == null)
                return originalPath;

            var matchPath = routeConfig.Match?.Path;
            var transform = routeConfig.Transforms?
                .FirstOrDefault(t => t.TryGetValue("PathPattern", out _));

            if (matchPath == null || transform == null)
                return originalPath;

            var pathPattern = transform["PathPattern"];
            var matchPrefix = matchPath.Replace("/{**catch-all}", "");

            if (!originalPath.StartsWith(matchPrefix, StringComparison.OrdinalIgnoreCase))
                return originalPath;

            var catchAll = originalPath.Substring(matchPrefix.Length);

            return pathPattern.Replace(
                "{**catch-all}",
                catchAll.TrimStart('/')
            );
        }
    }
}
