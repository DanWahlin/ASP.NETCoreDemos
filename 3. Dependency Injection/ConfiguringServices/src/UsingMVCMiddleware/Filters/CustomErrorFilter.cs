using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace ConfiguringServices.Filters
{
    public class CustomExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        ILogger _logger;

        public CustomExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomExceptionFilter");
        }

        public void OnException(ExceptionContext expContext)
        {
            //Log exception
            if (expContext.Exception != null)
            {
                _logger.LogError($"Error in {expContext.HttpContext.Request.Path}: {expContext.Exception.Message}");
            }
        }
    }
}
