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
        private StackTrace _trace = new StackTrace(1);
        private _frame = _trace.GetFrame(1);

        public void display(DateTime date, string log_level, string message, string className, string appName)
        {
            
            Console.Write($"{date}{space}");
            Console.BackgroundColor = ConsoleColors.color[log_level];
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{log_level}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Calling app : {appName}; Calling class : {className}; line : \n{message}");
        }

        public static int Line([CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }

        public static int getLine()
        {
            
            return _frame.GetFileLineNumber();
        }

    }
}
