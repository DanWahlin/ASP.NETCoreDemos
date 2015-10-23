using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Framework.Logging;
using System;

namespace WebApi.Filters
{
    public class CustomExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        ILogger _Logger;
        public CustomExceptionFilter(ILoggerFactory loggerFactory)
        {
            _Logger = loggerFactory.CreateLogger("CustomExceptionFilter");
        }
        public void OnException(ExceptionContext expContext)
        {
            //Log exception
            if (expContext.Exception != null)
            {
                _Logger.LogError($"Error in {expContext.HttpContext.Request.Path}: {expContext.Exception.Message}");
            }
        }
    }
}
