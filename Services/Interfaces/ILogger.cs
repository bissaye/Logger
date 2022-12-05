using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Services.Interfaces
{
    public interface ILogger
    {
        public string logInformation(string message);
        public string logDebug(string message);
        public string logTrace(string message);
        public string logWarning(string message);
        public string logError(string message);
    }
}
