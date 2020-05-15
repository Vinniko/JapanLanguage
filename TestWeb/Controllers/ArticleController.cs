using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Interfaces;

namespace TestWeb.Controllers
{
    public class ArticleController : Controller
    {
        #region Constructors

        public ArticleController(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        #endregion



        #region Main Logic

        [HttpGet]
        public IActionResult ArticlesView(int id, int userId)
        {
            if (id != 0) _pageNumber = id - 1;
            ViewBag.Articles = _articleRepository.GetAllArticles();
            ViewBag.PageNumber = _pageNumber;
            if (userId != 0) ViewBag.User = _userRepository.GetUser(userId);
            return View();
        }

        [HttpGet]
        public IActionResult OpenArticleView(int id, int userId)
        {
            if (id != 0) ViewBag.ArticleOpen = _articleRepository.GetArticle(id);
            ViewBag.Articles = _articleRepository.GetLastArticles(__articlesCount);
            if (userId != 0) ViewBag.User = _userRepository.GetUser(userId);
            return View();
        }

        #endregion



        #region Fields

        IArticleRepository _articleRepository;
        IUserRepository _userRepository;

        private int _pageNumber = 0;
        private const int __articlesCount = 4;

        #endregion
    }
}