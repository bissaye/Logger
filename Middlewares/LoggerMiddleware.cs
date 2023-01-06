using Logger.Tools.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var feature = context.Features.Get<IHttpConnectionFeature>();

            IDisplay._request = context.Request;
            IDisplay._response = context.Response;
            IDisplay._clientIpAddress = context.Connection.RemoteIpAddress?.ToString();
            IDisplay._serverIpAddress = feature?.LocalIpAddress.ToString();

            await _next(context);
        }
    }

    public static class ALoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseALoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerMiddleware>();
        }
    }
}
