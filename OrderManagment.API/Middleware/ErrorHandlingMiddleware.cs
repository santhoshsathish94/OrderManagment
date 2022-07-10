using OrderManagment.Application.Helpers;
using System.Net;

namespace OrderManagment.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Adding Trace here for debugging purpose
            _logger.LogError(exception.Message + ". Trace: " + exception.StackTrace);
            var code = StatusCodes.Status500InternalServerError; // 500 if unexpected

            var result = APIResponse.Error(exception.Message).ToJsonString();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
