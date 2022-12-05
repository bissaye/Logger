using Logger.Constantes;
using Logger.Services.Interfaces;
using Logger.Tools.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Services.Implementations
{
    public class Logger : ILogger
    {
        private readonly Display Log;

        public Logger()
        {
            Log = new Display();
        }
        public string logDebug(string message)
        {
            string log_level = LogLevel.log_level["Debug"];
            DateTime date = DateTime.Now;
            Log.display(date, log_level, message);
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logError(string message)
        {
            string log_level = LogLevel.log_level["Error"];
            DateTime date = DateTime.Now;
            Log.display(date, log_level, message);
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logInformation(string message)
        {
            string log_level = LogLevel.log_level["Information"];
            DateTime date = DateTime.Now;
            Log.display(date, log_level, message);
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logTrace(string message)
        {
            string log_level = LogLevel.log_level["Trace"];
            DateTime date = DateTime.Now;
            Log.display(date, log_level, message);
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logWarning(string message)
        {
            string log_level = LogLevel.log_level["Warning"];
            DateTime date = DateTime.Now;
            Log.display(date, log_level, message);
            string log = $"{date} : {log_level} : {message}";
            return log;
        }
    }
}
