using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Exeptions
{
    public class BadAgeException : Exception
    {
        public BadAgeException(string message)
          : base(message)
        { }
    }
}
