using Logger.Constantes;
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
        private TokenInfo _tokenInfo;
        private HttpRequestInfo _httpRequestInfo;
        private string space = "  ";
        string logString;
        string shopId;
        string terminalId;
        List<dynamic> errorCode;

        public void display(DateTime date, string log_level_display, string message, string className, string appName, int line, string memberName)
        {
            _tokenInfo = new TokenInfo();
            _httpRequestInfo = new HttpRequestInfo();

            errorCode = IDisplay._errorCode == null ? new List<dynamic> {"-", "-" }: IDisplay._errorCode;
            
            try
            {
                shopId = _tokenInfo.getShopId();
            }
            catch (BadTokenException)
            {
                shopId = "-";
            }
            catch (NoTokenException)
            {
                shopId = "-";
            }

            try
            {
                terminalId = _tokenInfo.getTerminalId();
            }
            catch (BadTokenException)
            {   
                terminalId = "-";
            }
            catch (NoTokenException)
            {
                terminalId = "-";
            }

            Console.Write($"[{date}]{space}");
            Console.BackgroundColor = ConsoleColors.color[log_level_display];
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{log_level_display}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            logString = $"{space}{appName}{space}{className}{space}{memberName}[{line}]{space}{errorCode[0]}{space}{errorCode[1]}{space}{shopId}{space}{terminalId}{space}{IDisplay._clientIpAddress}{space}\"{message}\"";

            Console.WriteLine(logString);
        }

    }
}
