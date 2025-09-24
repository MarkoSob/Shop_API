using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Shop_API.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var response = new
            {
                message = GetErrorMessage(exception),
                statusCode = GetStatusCode(exception)
            };

            httpContext.Response.StatusCode = response.statusCode;
            httpContext.Response.ContentType = "application/json";

            if (exception is ArgumentException)
            {
                _logger.LogWarning(exception, $"Argument validation failed: {exception.Message}");
            }
            else
            {
                _logger.LogError(exception, "An unhandled exception occurred");
            }

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }

        private static string GetErrorMessage(Exception exception)
        {
            return exception switch
            {
                ArgumentException argEx => argEx.Message,
                _ => "Internal server error"
            };
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
