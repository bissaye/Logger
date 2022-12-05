using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Constantes
{
    public static class ConsoleColors
    {
        public static Dictionary<string, dynamic> color = new()
        {
            {LogLevel.log_level["Information"] , ConsoleColor.DarkGreen},
            {LogLevel.log_level["Debug"], ConsoleColor.DarkYellow},
            {LogLevel.log_level["Trace"], ConsoleColor.Yellow },
            {LogLevel.log_level["Warning"], ConsoleColor.DarkCyan },
            {LogLevel.log_level["Error"], ConsoleColor.DarkRed }
        };
    }
}
