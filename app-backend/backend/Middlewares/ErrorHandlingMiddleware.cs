using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace backend.Middlewares
{
    /// Log exception data for unhandled exceptions

    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
            }


            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var response = new ApiResponse(context.Response.StatusCode);

                var json = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(json);
            }
        }
    }   
    }