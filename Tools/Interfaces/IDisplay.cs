using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Interfaces
{
    public interface IDisplay
    {
        public void display(DateTime date, string log_level, string message, string className, string appName);
    }
}
