using Logger.Exceptions;
using Logger.Tools.Interfaces;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppName = System.Reflection.Assembly;

namespace Logger.Tools.Implementations
{
    public class HttpRequestInfo: IHttpRequestInfo
    {
        private readonly string _appName;

        public HttpRequestInfo()
        {
            _appName = AppName.GetEntryAssembly().GetName().Name;
        }
        public  List<dynamic> getInComingErrorCode()
        {
            return new List<dynamic>();
        }
        private string createCorrelationId()
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] byteHash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(_appName + DateTime.Now));
            StringBuilder byteCorrelationId = new StringBuilder();
            string correlationId;
            for (int i = 0; i < byteHash.Length; i++)
            {
                byteCorrelationId.Append(byteHash[i].ToString("x2"));
            }
            correlationId = $"{byteCorrelationId}/{_appName}";
            return correlationId;
        }

        public string getCorrelationId()
        {
            if (IDisplay._correlationId == null)
            {
                IDisplay._correlationId = createCorrelationId();
                return IDisplay._correlationId;
            }

            return IDisplay._correlationId;
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
