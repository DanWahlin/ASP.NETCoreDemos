using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    public class UserAgentLoggerMiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger _Logger;

        public UserAgentLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _Next = next;
            _Logger = loggerFactory.CreateLogger<UserAgentLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _Logger.LogInformation("User Agent: " + context.Request.Headers["user-agent"]);
            await _Next.Invoke(context);
            _Logger.LogInformation("User Agent Logged.");
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