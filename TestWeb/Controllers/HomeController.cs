using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWeb.Models;
using TestWeb.Repository;
using TestWeb.Services;
using TestWeb.Interfaces;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {

        #region Constructors

        public HomeController(INewsRepository newsRepository, DataBaseService dataBaseService, IRegistrationService registrationService, IArticleRepository articleRepository)
        {
            _newsRepository = newsRepository;
            _registrationService = registrationService;
            _dataBaseService = dataBaseService;
            _articleRepository = articleRepository;
        }

        #endregion



        #region MainLogic

        [HttpGet]
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            ViewBag.Articles = _articleRepository.GetLastArticles(_articlesCount);
            return View(_newsRepository.GetLastNews(_newsCount));
        }

        public IActionResult AuthorizationView(string message)
        {
            ViewBag.News = _newsRepository.GetLastNews(_newsCount);
            ViewBag.Error = message;
            ViewBag.Articles = _articleRepository.GetLastArticles(_articlesCount);
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HomeViewWithUser(int userId)
        {
            ViewBag.User = _dataBaseService.GetUser(userId);
            ViewBag.News = _newsRepository.GetLastNews(_newsCount);
            ViewBag.Articles = _articleRepository.GetLastArticles(_articlesCount);
            return View();
        }

        #endregion



        #region Fields

        private INewsRepository _newsRepository;
        private IRegistrationService _registrationService;
        private IArticleRepository _articleRepository;
        private DataBaseService _dataBaseService;

        private const int _newsCount = 5;
        private const int _articlesCount = 3;

        #endregion
    }
}
