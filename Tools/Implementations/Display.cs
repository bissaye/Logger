using Logger.Constantes;
using Logger.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Implementations
{
    public class Display : IDisplay

    {
        public void display(DateTime date, string log_level, string message)
        {
            Console.WriteLine(date);
            Console.BackgroundColor = ConsoleColors.color[log_level];
            Console.WriteLine(log_level);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }
    }
}
