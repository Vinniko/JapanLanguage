using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models
{
    public class UserModel
    {

        #region Get/Set

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

        private string _login;
        private string _password;
        private string _email;
        private string _country;
        private short _age;
        private int _money;

        #endregion

    }
}
