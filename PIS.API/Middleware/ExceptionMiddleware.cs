using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using PIS.DTO.Responses;
using System;
using System.Threading.Tasks;

namespace PIS.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                APIResponse response = _env.IsDevelopment()
                    ? new APIResponse(500, ex.Message, ex.StackTrace.ToString())
                    : new APIResponse(500);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
