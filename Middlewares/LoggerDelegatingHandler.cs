using Logger.Tools;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerService = Logger.Services.Implementations.Logger;
using AppName = System.Reflection.Assembly;
using Logger.Tools.Implementations;
using Logger.Tools.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using LoggerHttp = Logger.Constantes.Http;

namespace Logger.Middlewares
{
    public class LoggerDelegatingHandler : DelegatingHandler
    {
        private readonly LoggerService _logger;
        private readonly HttpRequestInfo _httpRequestInfo;
        public LoggerDelegatingHandler(IOptions<LoggingConfiguration> logger)
        {
            _logger = new LoggerService(logger);
            _httpRequestInfo = new HttpRequestInfo();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains(LoggerHttp.CorrelationId))
            {
                request.Headers.Add(LoggerHttp.CorrelationId, _httpRequestInfo.getCorrelationId());
            }

            var response = await base.SendAsync(request, cancellationToken);
            
            _logger.logInformation($"outgoing request to {request.RequestUri.ToString()}; status: {response.StatusCode.GetHashCode().ToString()} AvkCode: {IHttpRequestInfo.getOutGoingErrorCode(await response.Content.ReadAsStringAsync())[1]}");

            return response;
        }
    }
}
