using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception ex)
            {
                writeToResponse(ex);
            }
            async Task writeToResponse(Exception ex)
            {
                await context.Response.WriteAsync("this is a middleware message"+ex.Message);
            }
        }
    }
}
