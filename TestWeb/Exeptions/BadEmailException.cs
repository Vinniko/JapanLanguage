using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Exeptions
{
    public class BadEmailException : Exception
    {
        public BadEmailException(string message)
           : base(message)
        { }
    }
}
