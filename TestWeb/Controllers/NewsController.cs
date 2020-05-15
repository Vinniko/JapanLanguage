using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;
using TestWeb.Services;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class NewsController : Controller
    {
        #region Constructors

        public NewsController(INewsRepository newsRepository, DataBaseService dataBaseService, IRegistrationService registrationService)
        {
            _newsRepository = newsRepository;
            _registrationService = registrationService;
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic
        

        [HttpGet]
        public IActionResult NewsView(int id, int userId)
        {
            if (id != 0) _pageNumber = id - 1;
            ViewBag.News = _newsRepository.GetAllNews();
            ViewBag.PageNumber = _pageNumber;
            if(userId != 0) ViewBag.User = _dataBaseService.GetUser(userId);
            return View();
        }

        [HttpGet]
        public IActionResult OpenNewsView(int id, int userId)
        {
            if (id != 0) ViewBag.NewsOpen = _newsRepository.GetNews(id);
            ViewBag.News = _newsRepository.GetLastNews(__newsCount);
            if (userId != 0) ViewBag.User = _dataBaseService.GetUser(userId);
            return View();
        }


        #endregion



        #region Fields

        private INewsRepository _newsRepository;
        private IRegistrationService _registrationService;
        private DataBaseService _dataBaseService;

        private int _pageNumber = 0;
        private const int __newsCount = 4;

        #endregion
    }
}