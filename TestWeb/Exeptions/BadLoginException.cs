using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Exeptions
{
    public class BadLoginException : Exception
    {
        public BadLoginException(string message)
           : base(message)
        { }
    }
}
