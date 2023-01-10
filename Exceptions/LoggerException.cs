using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Exceptions
{
    public class NoTokenException : Exception
    {
        public NoTokenException() : base() { }
        public NoTokenException(string msg) : base(msg) { }
    }

    public class BadTokenException : Exception
    {
        public BadTokenException() : base() { }
        public BadTokenException(string msg) : base(msg) { }
    }

    public class NoErrorCodeException : Exception
    {
        public NoErrorCodeException() : base() { }
        public NoErrorCodeException(string msg) : base(msg) { }
    }
}
