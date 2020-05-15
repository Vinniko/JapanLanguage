using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Exeptions
{
    public class BadPasswordException : Exception
    {
        public BadPasswordException(string message)
        : base(message)
        { }
    }
}
