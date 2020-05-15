using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Exeptions
{
    public class UserNotExistException :Exception
    {
        public UserNotExistException(string message)
        : base(message)
        { }
    }
}
