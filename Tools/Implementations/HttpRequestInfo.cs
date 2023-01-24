using Logger.Exceptions;
using Logger.Tools.Interfaces;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Tools.Implementations
{
    public class HttpRequestInfo: IHttpRequestInfo
    {
        public  List<dynamic> getInComingErrorCode()
        {
            return new List<dynamic>();
        }
        public string getCorrelationId()
        {
            return "";
        }
        public string createCorrelationId()
        {
            return "";
        }

        public string getRequestBody()
        {
            #if DEBUG
            if (!string.IsNullOrWhiteSpace(IHttpRequestInfo.requestBody))
            {
                return IHttpRequestInfo.requestBody;
            }
            #endif
            return "-";
        }
    }
}
