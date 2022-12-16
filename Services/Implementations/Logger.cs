using Logger.Constantes;
using Logger.Services.Interfaces;
using Logger.Tools.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AppName = System.Reflection.Assembly;

namespace Logger.Services.Implementations
{
    public class Logger : ILogger
    {
        private readonly Display _Log;
        private readonly int _log_ranking;
        private StackTrace _stackTrace = new StackTrace();
        private string _methodName = new StackFrame(1).GetMethod().Name;
        private string _className = new StackFrame(1).GetMethod().DeclaringType.Name;
        private string _appName = AppName.GetEntryAssembly().GetName().Name;


        public Logger(string level = "Err")
        {
            _Log = new Display();
            try
            {
                _log_ranking = LogLevel.log_level_ranking[level];
            }
            catch (KeyNotFoundException ex)
            {
                _log_ranking = LogLevel.log_level_ranking["Err"];
            }
           
        }
        public string logDebug(string message)
        {
            string log_level = LogLevel.log_level["Debug"];
            int log_level_ranking = LogLevel.log_level_ranking[log_level];
            DateTime date = DateTime.Now;

            if (log_level_ranking <= _log_ranking)
            {
                Console.WriteLine($" level:{log_level_ranking} log level: {_log_ranking}");
                _Log.display(date, log_level, message, _className, _appName);
            }
            
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logError(string message)
        {
            string log_level = LogLevel.log_level["Error"];
            int log_level_ranking = LogLevel.log_level_ranking[log_level];
            DateTime date = DateTime.Now;

            if (log_level_ranking <= _log_ranking)
            {
                Console.WriteLine($" level:{log_level_ranking} log level: {_log_ranking}");
                _Log.display(date, log_level, message, _className, _appName);
            }
            
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logInformation(string message)
        {
            string log_level = LogLevel.log_level["Information"];
            int log_level_ranking = LogLevel.log_level_ranking[log_level];
            DateTime date = DateTime.Now;
            
            if (log_level_ranking <= _log_ranking)
            {
                Console.WriteLine($"level:{log_level_ranking} log level: {_log_ranking}");
                _Log.display(date, log_level, message, _className, _appName);
            }
            
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logTrace(string message)
        {
            string log_level = LogLevel.log_level["Trace"];
            int log_level_ranking = LogLevel.log_level_ranking[log_level];
            DateTime date = DateTime.Now;
            
            if (log_level_ranking <= _log_ranking)
            {
                Console.WriteLine($" level:{log_level_ranking} log level: {_log_ranking}");
                _Log.display(date, log_level, message, _className, _appName);
            }
            
            string log = $"{date} : {log_level} : {message}";
            return log;
        }

        public string logWarning(string message)
        {
            string log_level = LogLevel.log_level["Warning"];
            int log_level_ranking = LogLevel.log_level_ranking[log_level];
            DateTime date = DateTime.Now;
            
            if (log_level_ranking <= _log_ranking)
            {
                Console.WriteLine($" level:{log_level_ranking} log level: {_log_ranking}");
                _Log.display(date, log_level, message, _className, _appName);
            }
                                    
            string log = $"{date} : {log_level} : {message}";
            return log;
        }
    }
}
