using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.ApiFramework.Api;
using TaskManagement.Common.Enums;

namespace TaskManagement.ApiFramework.ConfigMiddleware
{
    public static class CustomExceptionMiddlewareExtention
    {

        public static IApplicationBuilder UseCustomException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        public CustomExceptionMiddleware(RequestDelegate next, IHostingEnvironment env, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                _ = writeToResponse(ex);
            }

            async Task writeToResponse(ApiException ex)
            {
                _logger.LogTrace("Exception was thrown --> at : " + DateTime.Now + Environment.NewLine + ex.Message +
                                 Environment.NewLine + ex.StackTrace);
                context.Response.StatusCode =(int)ex.HttpStatusCode;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
