using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface IAuthorizationService
    {
        UserModel Authorization(string email, string password);
    }
}
