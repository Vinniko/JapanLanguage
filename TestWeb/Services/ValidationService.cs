using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Exeptions;
using System.Text.RegularExpressions;

namespace TestWeb.Services
{
    public class ValidationService : IValidationService
    {
        #region Constructors

        public ValidationService()
        {

        }
        public ValidationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion



        #region Main Logic

        public bool LoginTest(string login)
        {
            if (login == null)
            {
                throw new BadLoginException(_loginCanNotByEmty);
            }
            else if(login.Length == 0)
            {
                throw new BadLoginException(_loginCanNotByEmty);
            }
            else if (_userRepository.LoginExist(login))
            {
                throw new BadLoginException(_loginAlreadyExist);
            }
            else if (login.Contains(" "))
            {
                throw new BadLoginException(_loginHasBadSymbols);
            }
            else
            {
                return true;
            }
        }
        public bool EmailTest(string email)
        {
            if ( email == null)
            {
                throw new BadEmailException(_emailNotRight);
            }
            else if(email.Length == 0)
            {
                throw new BadEmailException(_emailNotRight);
            }
            else if (email.Contains(" "))
            {
                throw new BadEmailException(_emailNotRight);
            }
            else if(!Regex.IsMatch(email, _emailPattern))
            {
                throw new BadEmailException(_emailNotRight);
            }
            else if (_userRepository.EmailExist(email))
            {
                throw new UserAlreadyExistException(_userAlreadyExist);
            }
            else
            {
                return true;
            }
        }
        public bool PasswordTest(string password)
        {
            if(password == null)
            {
                throw new BadPasswordException(_passwordIsSmall);
            }
            else if (password.Contains(" "))
            {
                throw new BadPasswordException(_passwordHasBadSymbols);
            }
            else if (password.Length < _minimalPasswordLength)
            {
                throw new BadPasswordException(_passwordIsSmall);
            }
            else
            {
                return true;
            }
        }
        public bool AgeTest(int age)
        {
            if(age > 0 && age < 200)
            {
                return true;
            }
            else
            {
                throw new BadAgeException(_ageIsBad);
            }
        }

        #endregion



        #region Fields

        private IUserRepository _userRepository;

        private const string _emailNotRight = "В поле Email допущена ошибка";
        private const string _loginCanNotByEmty = "Логин не может быть пустым";
        private const string _loginAlreadyExist = "Пользователь с таким логином уже существует";
        private const string _loginHasBadSymbols = "В логине есть недопустимые символы";
        private const string _userAlreadyExist = "Пользователь с таким Email уже существует";
        private const string _passwordIsSmall = "Пароль слишком маленький. Минимальная длина 8 символов";
        private const string _passwordHasBadSymbols = "В пароле есть недпостимые символы";
        private const string _ageIsBad = "Такой возраст не возможен";

        private const short _minimalPasswordLength = 8;

        private const string _emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        #endregion
    }
}
