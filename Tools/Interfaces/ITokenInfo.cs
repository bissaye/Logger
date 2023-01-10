using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Interfaces
{
    public interface ITokenInfo
    {
        public string getToken();
        public string getShopId();
        public string getTerminalId();
    }
}
