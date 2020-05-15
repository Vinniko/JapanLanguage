using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;
using TestWeb.Services;
using TestWeb.Models;
using TestWeb.Exeptions;

namespace TestWeb.Controllers
{
    public class AuthorizationController : Controller
    {
        #region Constructors

        public AuthorizationController(INewsRepository newsRepository, DataBaseService dataBaseService, IAuthorizationService authorizationService)
        {
            _newsRepository = newsRepository;
            _authorizationService = authorizationService;
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic


        [HttpPost]
        public ActionResult Authorization(string email, string password)
        {
            UserModel userModel = new UserModel();
            try
            {
                userModel = _authorizationService.Authorization(email, password);
            }
            catch (BadEmailException ex)
            {
                return RedirectToAction("AuthorizationView", "Home", new { ex.Message });
            }
            catch (BadLoginException ex)
            {
                return RedirectToAction("AuthorizationView", "Home", new { ex.Message });
            }
            catch (BadPasswordException ex)
            {
                return RedirectToAction("AuthorizationView", "Home", new { ex.Message });
            }
            catch (UserNotExistException ex)
            {
                return RedirectToAction("AuthorizationView", "Home", new { ex.Message });
            }
            return RedirectToAction("HomeViewWithUser", "Home", new { userId = userModel.Id });
        }

        


        #endregion



        #region Fields

        private INewsRepository _newsRepository;
        private IAuthorizationService _authorizationService;
        private DataBaseService _dataBaseService;

        private const int _newsCount = 5;

        #endregion
    }
}