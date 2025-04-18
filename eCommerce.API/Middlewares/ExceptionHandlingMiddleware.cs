﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCommerce.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, return a custom error response, etc.)
                httpContext.Response.StatusCode = 500; // Internal Server Error
                _logger.LogError(ex.GetType().ToString(), "An unhandled exception occurred while processing the request.");
                
                if(ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.ToString(), "An unhandled exception occurred while processing the request.");
                }
                await httpContext.Response.WriteAsJsonAsync(new {Message = ex.Message, Type = ex.GetType().ToString()});
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
