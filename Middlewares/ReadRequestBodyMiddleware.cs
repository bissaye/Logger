using Logger.Tools;
using Logger.Tools.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerService = Logger.Services.Implementations.Logger;

namespace Logger.Middlewares
{
    public class ReadRequestBodyMiddleware
    {
        private readonly RequestDelegate _next;
        public ReadRequestBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var injectedRequestStream = new MemoryStream();
            
            try
            {

                var requestLog = "";

                using (var bodyReader = new StreamReader(context.Request.Body))
                {
                    var bodyAsText = bodyReader.ReadToEndAsync().Result;
                    if (!string.IsNullOrWhiteSpace(bodyAsText))
                    {
                        requestLog = bodyAsText;
                    }

                    var bytesToWrite = Encoding.UTF8.GetBytes(bodyAsText);
                    injectedRequestStream.Write(bytesToWrite, 0, bytesToWrite.Length);
                    injectedRequestStream.Seek(0, SeekOrigin.Begin);
                    context.Request.Body = injectedRequestStream;
                    //Console.WriteLine($"REQUEST BODY : {requestLog}");
                    
                    IHttpRequestInfo.requestBody = requestLog;

                    await _next.Invoke(context);
                }
            }
            finally
            {
                injectedRequestStream.Dispose();
            }

            
        }
    }

    public static class ReadRequestBodyMiddlewareExtensions
    {
        public static IApplicationBuilder UseReadRequestBodyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ReadRequestBodyMiddleware>();
        }
    }
}
