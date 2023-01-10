using Logger.Tools.Interfaces;
using LoggerService = Logger.Services.Implementations.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Logger.Tools.Implementations;
using Microsoft.Extensions.Options;
using Logger.Tools;

namespace Logger.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LoggerService _logger;
        public LoggerMiddleware(RequestDelegate next, IOptions<LoggingConfiguration> options)
        {
            _next = next;
            _logger = new LoggerService(options);
        }
        
        public async Task Invoke(HttpContext context)
        {

            var feature = context.Features.Get<IHttpConnectionFeature>();

            IDisplay._request = context.Request;
            IDisplay._response = context.Response;
            IDisplay._clientIpAddress = context.Connection.RemoteIpAddress?.ToString();
            IDisplay._serverIpAddress = feature?.LocalIpAddress.ToString();
            Stream originalBody = context.Response.Body;
            try
            {
                var response = context.Response;
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;
                    await _next(context);
                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();
                    IDisplay._errorCode = IHttpRequestInfo.getOutGoingErrorCode(responseBody);
                    _logger.logInformation("Incomming request");
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }
            
            
            await _next(context);

            
        }
    }

    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseALoggerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerMiddleware>();
        }
    }
}
