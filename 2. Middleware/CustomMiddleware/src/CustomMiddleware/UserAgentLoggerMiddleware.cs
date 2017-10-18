using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    public class UserAgentLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public UserAgentLoggerMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<UserAgentLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("User Agent: " + context.Request.Headers["user-agent"]);
            await _next.Invoke(context);
            _logger.LogInformation("User Agent Logged.");
        }
    }

    public static class UserAgentLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserAgentLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAgentLoggerMiddleware>();
        }
    }
}