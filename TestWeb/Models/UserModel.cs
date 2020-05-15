using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class UserModel
    {
        #region Constructors

        public UserModel()
        {

        }
        public UserModel(int id, string login, string password, string email, string country, short age, int money)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            Country = country;
            Age = age;
            Money = money;
        }

        #endregion



        #region Get/Set

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                _country = value;
            }
        }

        public short Age
        {
            get => _age;
            set
            {
                _age = value;
            }
        } 

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
            }
        }

        #endregion



        #region Fields

        private int _id;

        private string _login;
        private string _password;
        private string _email;
        private string _country;

        private short _age;

        private int _money;

        #endregion

    }
}
