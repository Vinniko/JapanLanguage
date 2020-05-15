using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUser(int id);
        UserModel GetUser(string email);

        int AddUser(UserModel user);

        bool LoginExist(string login);
        bool EmailExist(string login);

        void ChangeUser(UserModel user, bool loginFlag, bool passwordFlag, bool ageFlag, bool countryFlag, bool moneyFlag);
        
    }
}
