﻿using Logger.Constantes;
using Logger.Exceptions;
using Logger.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Implementations
{
    public class Display : IDisplay
    {

        private const string space = "  ";
        private const string defaultIfNull = "-";

        private TokenInfo _tokenInfo;
        private HttpRequestInfo _httpRequestInfo;
        private string endpoint;
        private string logString;
        private string shopId;
        private string terminalId;
        private string requestBody;
        private string dateGMT;
        private string host;
        private string correlationID;
        private List<dynamic> errorCode;

        public void display(DateTime date, string log_level, string message, string className, string appName, int line, string memberName)
        {
            _tokenInfo = new TokenInfo();
            _httpRequestInfo = new HttpRequestInfo();

            errorCode = IDisplay._errorCode == null ? new List<dynamic> {"-", "-" }: IDisplay._errorCode;
            
            try
            {
                endpoint = IDisplay._request.Path;
                if (endpoint == null || endpoint == "")
                {
                    endpoint = defaultIfNull;
                }
            }
            catch (Exception)
            {
                endpoint = defaultIfNull;
            }

            try
            {
                host = IDisplay._request.Host.ToString();
                if (host == null || host == "")
                {
                    host = defaultIfNull;
                }
            }
            catch (Exception)
            {
                endpoint = defaultIfNull;
            }

            try
            {
                shopId = _tokenInfo.getShopId();
            }
            catch (BadTokenException)
            {
                shopId = defaultIfNull;
            }
            catch (NoTokenException)
            {
                shopId = defaultIfNull;
            }

            try
            {
                terminalId = _tokenInfo.getTerminalId();
            }
            catch (BadTokenException)
            {   
                terminalId = defaultIfNull;
            }
            catch (NoTokenException)
            {
                terminalId = defaultIfNull;
            }

            // Test if debug mode
            try
            {
                requestBody = _httpRequestInfo.getRequestBody();
            }
            catch (BadTokenException)
            {
                requestBody = defaultIfNull;
            }
            catch (NoTokenException)
            {
                requestBody = defaultIfNull;
            }


            if(IDisplay._correlationId == null)
            {
                correlationID = defaultIfNull;
            }
            else
            {
                correlationID = IDisplay._correlationId;
            }

            dateGMT = date.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss \"GMT\" %K");
            Console.Write($"[{dateGMT}]{space}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColors.color[log_level];
            Console.Write($"{log_level}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            logString = $"{space}{appName}{space}{className}{space}{memberName}[{line}]{space}{host}{space}{endpoint}{space}" +
                $"{errorCode[0]}{space}{errorCode[1]}{space}{shopId}{space}{terminalId}{space}{IDisplay._clientIpAddress}" +
                $"{space}{IDisplay._correlationId}"+
                $"{space}[{requestBody}]{space}\"{message}\"";

            Console.WriteLine(logString);
        }

    }
}
