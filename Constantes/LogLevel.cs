using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Constantes
{
    public static class LogLevel
    {
        public static Dictionary<string, string> log_level = new()
        {
            {"Information" , "Information" },
            {"Debug", "Debug" },
            {"Trace", "Trace" },
            {"Warning", "Warning" },
            {"Error", "Error" }
        };
    }
}
