using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Exeptions;

namespace TestWeb.Controllers
{
    public class SettingsController : Controller
    {
        #region Constructors

        public SettingsController(IUserRepository userRepository, IValidationService validationService, ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _validationService = validationService;
            _countryRepository = countryRepository;
        }

        #endregion



        #region Main Logic

        public IActionResult SettingsView(int userId, string loginMessage, string passwordMessage, string ageMessage)
        {
            var tmpList = new List<string>();
            for(var i = 0; i < _countryRepository.GetCountries().Count; i++)
            {
               tmpList.Add(_countryRepository.GetCountries().ElementAt(i).Key);
            }
            ViewBag.User = _userRepository.GetUser(userId);
            ViewBag.Countries = tmpList;
            ViewBag.LoginMessage = loginMessage;
            ViewBag.PasswordMessage = passwordMessage;
            ViewBag.AgeMessage = ageMessage;
            return View();
        }

        [HttpPost]
        public IActionResult SaveSettings(int _userId, string login, string password, string email, string country, short age, int money)
        {
            try
            {
                UserModel user = _userRepository.GetUser(_userId);
                bool tmpLoginFlag = false;
                bool tmpPasswordFlag = false;
                bool tmpAgeFlag = false;
                bool tmpCountryFlag = false;
                bool tmpMoneyFlag = false;
                if(user.Login != login)
                {
                    if(_validationService.LoginTest(login))
                        tmpLoginFlag = true;
                }
                if(user.Password != password)
                {
                    if(_validationService.PasswordTest(password))
                    tmpPasswordFlag = true;
                }
                if(user.Country != country)
                {
                    tmpCountryFlag = true;
                }
                if(user.Age != age)
                {
                    if(_validationService.AgeTest(age))
                    tmpAgeFlag = true;
                }
                if (user.Money != money)
                {
                    tmpMoneyFlag = true;
                }
                if(tmpAgeFlag || tmpCountryFlag || tmpLoginFlag || tmpMoneyFlag || tmpPasswordFlag)
                {
                    _userRepository.ChangeUser(new UserModel(_userId, login, password, email, country, age, money), tmpLoginFlag, tmpPasswordFlag, tmpAgeFlag, tmpCountryFlag, tmpMoneyFlag);
                }
            }
            catch (BadAgeException ex)
            {
                return RedirectToAction("SettingsView", new { userId = _userId, ageMessage = ex.Message});
            }
            catch (BadLoginException ex)
            {
                return RedirectToAction("SettingsView", new { userId = _userId, loginMessage = ex.Message });
            }
            catch (BadPasswordException ex)
            {
                return RedirectToAction("SettingsView", new { userId = _userId, passwordMessage = ex.Message });
            }

            return RedirectToAction("SettingsView", new { userId = _userId });
        }

        #endregion



        #region Fields

        IUserRepository _userRepository;
        IValidationService _validationService;
        ICountryRepository _countryRepository;

        #endregion
    }
}