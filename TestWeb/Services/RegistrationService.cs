using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Repository;

namespace TestWeb.Services
{
    public class RegistrationService : IRegistrationService
    {
        #region Constructors

        public RegistrationService()
        {

        }
        public RegistrationService(IValidationService validationService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _validationService = validationService;
        }

        #endregion



        #region Main Logic

        public UserModel Registration(string email, string password)
        {
            if (_validationService.EmailTest(email) && _validationService.PasswordTest(password))
            {
                int id = _userRepository.AddUser(new UserModel(0, LoginCreate(email), password, email, String.Empty, 1, 0));
                return _userRepository.GetUser(id);
            }
            return null;
        }

        #endregion



        #region Staff

        private string LoginCreate(string email)
        {
            return email.Split("@")[0];
        }

        #endregion



        #region Fields

        private IUserRepository _userRepository;
        private IValidationService _validationService;

        #endregion
    }
}
