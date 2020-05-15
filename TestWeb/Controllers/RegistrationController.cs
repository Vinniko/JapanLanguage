using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Models;
using TestWeb.Repository;
using TestWeb.Services;
using TestWeb.Interfaces;
using TestWeb.Exeptions;

namespace TestWeb.Controllers
{
    public class RegistrationController : Controller
    {
        #region Constructors

        public RegistrationController(INewsRepository newsRepository, DataBaseService dataBaseService, IRegistrationService registrationService)
        {
            _newsRepository = newsRepository;
            _registrationService = registrationService;
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic


        [HttpPost]
        public ActionResult Registration(string login, string password)
        {
            UserModel userModel = new UserModel();
            try
            {
                userModel = _registrationService.Registration(login, password);
            }
            catch (BadEmailException ex)
            {
                return RedirectToAction("Index", "Home", new { ex.Message });
            }
            catch (BadLoginException ex)
            {
                return RedirectToAction("Index", "Home", new { ex.Message });
            }
            catch (BadPasswordException ex)
            {
                return RedirectToAction("Index", "Home", new { ex.Message });
            }
            catch (UserAlreadyExistException ex)
            {
                return RedirectToAction("Index", "Home", new { ex.Message });
            }
            return RedirectToAction("HomeViewWithUser", "Home", new { userId = userModel.Id});
        }
        #endregion



        #region Fields

        private INewsRepository _newsRepository;
        private IRegistrationService _registrationService;
        private DataBaseService _dataBaseService;

        private const int _newsCount = 5;

        #endregion
    }
}