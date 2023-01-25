using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Interfaces
{
    public interface IDisplay
    {
        public static string _correlationId = null;
        public static HttpRequest _request;
        public static HttpResponse _response;
        public static List<dynamic> _errorCode;
        public static string _clientIpAddress;
        public static string _serverIpAddress;
        public void display(DateTime date, string log_level, string message, string className, string appName, int line, string memberName);
    }
}
