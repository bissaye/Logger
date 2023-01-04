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
            {"Information" , "Inf" },
            {"Debug", "Deb" },
            {"Trace", "Tra" },
            {"Warning", "War" },
            {"Error", "Err" }
        };

        public static Dictionary<string, int> log_level_ranking = new()
        {
            {log_level["Error"],  1},
            {log_level["Warning"], 2},
            {log_level["Information"] , 3},
            {log_level["Debug"], 4},
            {log_level["Trace"],  5}
        };
    }
}
