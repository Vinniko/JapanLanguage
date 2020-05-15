using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Services;

namespace TestWeb.Repository
{
    public class UserRepository : IUserRepository
    {

        #region Constructors

        public UserRepository()
        {

        }

        public UserRepository(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic
        public UserModel GetUser(int id)
        {
            return _dataBaseService.GetUser(id);
        }
        public UserModel GetUser(string email)
        {
            return _dataBaseService.GetUser(email);
        }

        public int AddUser(UserModel user)
        {
           return _dataBaseService.AddUser(user);
        }

        public bool LoginExist(string login)
        {
           return _dataBaseService.LoginExistTester(login);
        }
        public bool EmailExist(string email)
        {
            return _dataBaseService.EmailExistTester(email);
        }

        public void ChangeUser(UserModel user, bool loginFlag, bool passwordFlag, bool ageFlag, bool countryFlag, bool moneyFlag)
        {
            if (loginFlag)
            {
                _dataBaseService.ChangeUserLogin(user.Login, user.Id);
            }
            if (passwordFlag)
            {
                _dataBaseService.ChangeUserPassword(user.Password, user.Id);
            }
            if (countryFlag)
            {
                _dataBaseService.ChangeUserCountry(user.Country, user.Id);
            }
            if (ageFlag)
            {
                _dataBaseService.ChangeUserAge(user.Age, user.Id);
            }
            if (moneyFlag)
            {
                _dataBaseService.ChangeUserMoney(user.Money, user.Id);
            }
            _dataBaseService.ChangeUserEmail(user.Email, user.Id);
           
        }

        #endregion



        #region Fields

        DataBaseService _dataBaseService;

        #endregion

    }
}
