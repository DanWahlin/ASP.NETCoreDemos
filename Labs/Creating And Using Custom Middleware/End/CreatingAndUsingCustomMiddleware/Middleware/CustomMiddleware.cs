using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CreatingAndUsingCustomMiddleware {
    public class CustomMiddleware {
        readonly RequestDelegate _next;
        readonly ILogger _logger;

        public CustomMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<CustomMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogDebug("Testing my custom request middleware!");
            await _next.Invoke(context);
            _logger.LogDebug("Testing my custom response middleware!");
        }

    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }

}