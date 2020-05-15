using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Exeptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string message)
        : base(message)
        { }
    }
}
