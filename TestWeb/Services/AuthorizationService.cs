using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Exeptions;

namespace TestWeb.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Constructors

        public AuthorizationService()
        {
            
        }
        public AuthorizationService(IValidationService validationService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _validationService = validationService;
        }

        #endregion



        #region Main Logic

        public UserModel Authorization(string email, string password)
        {
            try
            {
                if (_validationService.EmailTest(email))
                {
                    throw new UserNotExistException(_userNotExists);
                }
            }
            catch (UserAlreadyExistException ex)
            {
                var userModel = _userRepository.GetUser(email);
                if (userModel.Password == password)
                {
                    return userModel;
                }
                else throw new BadPasswordException(_passwordIsNotRight);
            }
            return null;
        }

        #endregion



        #region Fields

        IValidationService _validationService;
        IUserRepository _userRepository;
        private const string _userNotExists = "Такого пользователя не существует. Зарегистрируйтесь";
        private const string _passwordIsNotRight = "Неправильный пароль. Повторите попытку";

        #endregion

    }
}
