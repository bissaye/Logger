using Logger.Constantes;
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
        private string space = "  ";

        public void display(DateTime date, string log_level, string message, string className, string appName, int line, string memberName)
        {
            
            Console.Write($"{date}{space}");
            Console.BackgroundColor = ConsoleColors.color[log_level];
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{log_level}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {appName} {className} {memberName} l.{line}: {message}");
        }

    }
}
