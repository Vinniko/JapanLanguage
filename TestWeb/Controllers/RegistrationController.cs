using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Models;
using TestWeb.Repository;
using TestWeb.Services;

namespace TestWeb.Controllers
{
    public class RegistrationController : Controller
    {
        private NewsRepository _newsRepository;
        DataBaseService _dataBaseService;
        NewsModel newsModel = new NewsModel();
        public RegistrationController(NewsRepository newsRepository, DataBaseService dataBaseService)
        {
            _newsRepository = newsRepository;
            _dataBaseService = dataBaseService;
            //_dataBaseService.AddNews("Start");
        }

        public IActionResult Index()
        {
            newsModel.Text = _newsRepository.title;
            newsModel.Title = _dataBaseService.GetNews();
            return View(newsModel);
        }

        public IActionResult AuthorizationView()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public string Registration()
        {

            return "kek";
        }
    }
}