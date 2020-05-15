using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Interfaces;
using TestWeb.Models;
using TestWeb.Services;

namespace TestWeb.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        #region Constructors

        public ArticleRepository()
        {

        }
        public ArticleRepository(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        #endregion



        #region Main Logic

        public ArticleModel GetArticle(int id)
        {
            return _dataBaseService.GetArticle(id);
        }
        public List<ArticleModel> GetAllArticles()
        {
            var tmpList = _dataBaseService.GetAllArticles();
            tmpList.Reverse();
            return tmpList;
        }
        public List<ArticleModel> GetLastArticles(int count)
        {
            var tmpList = _dataBaseService.GetAllArticles();
            tmpList.Reverse();
            return tmpList.GetRange(0, count);
        }

        public void AddArticle(ArticleModel articleModel)
        {
            _dataBaseService.AddArticle(articleModel);
        }

        public void UpdateArticle(int id, ArticleModel articleModel)
        {
            _dataBaseService.UpdateArticle(id, articleModel);
        }

        public void DeleteArticle(int id)
        {
            _dataBaseService.DeleteArticle(id);
        }

        #endregion



        #region Fields

        private DataBaseService _dataBaseService;

        #endregion
    }
}
