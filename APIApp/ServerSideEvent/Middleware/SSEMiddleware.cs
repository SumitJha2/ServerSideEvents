using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServerSideEvent.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ServerSideEvent.Middleware
{
    public class SSEMiddleware
    {
        private readonly RequestDelegate _next;

        public SSEMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().Equals("/RTPortfolioStatus"))
            {
                var response = httpContext.Response;
                response.Headers.Add("Content-Type", "text/event-stream");
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                
            }
            await _next(httpContext);
        }
    }
    public static class SSEMiddlewareExtensions
    {
        public static IApplicationBuilder UseSSEMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SSEMiddleware>();
        }
    }
}
