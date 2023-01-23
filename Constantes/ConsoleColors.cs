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
            {LogLevel.log_level_display["Information"] , ConsoleColor.DarkGreen},
            {LogLevel.log_level_display["Debug"], ConsoleColor.DarkYellow},
            {LogLevel.log_level_display["Trace"], ConsoleColor.Yellow },
            {LogLevel.log_level_display["Warning"], ConsoleColor.DarkCyan },
            {LogLevel.log_level_display["Error"], ConsoleColor.DarkRed }
        };
    }
}
