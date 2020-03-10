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

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        private NewsRepository _newsRepository;
        DataBaseService _dataBaseService;
        NewsModel newsModel = new NewsModel();
        public HomeController(NewsRepository newsRepository, DataBaseService dataBaseService)
        {
            _newsRepository = newsRepository;
            _dataBaseService = dataBaseService;
            //_dataBaseService.AddNews("Start");
        }

        public  IActionResult Index()
        {
            newsModel.Text = _newsRepository.title;
            newsModel.Title = _dataBaseService.GetNews();
            return View(newsModel);
        }

        public IActionResult AuthorizationView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(string title)
        {
            _dataBaseService.EditNews(newsModel.Title + "T");
            newsModel.Title = _dataBaseService.GetNews();
            newsModel.Text = _newsRepository.title;
            return View(newsModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
