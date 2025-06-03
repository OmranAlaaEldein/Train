using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MyApp.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Log the exception details
                _logger.LogError(ex, "An unhandled exception occurred.");

                // Return a custom error response
                httpContext.Response.StatusCode = 500; // Internal Server Error
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync("{\"message\": \"An unexpected error occurred.\"}");
            }
        }
    }
}

