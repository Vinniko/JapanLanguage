using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Interfaces;
using TestWeb.Services;

namespace TestWeb.Repository
{
    public class NewsRepository : INewsRepository
    {
        #region Constructors
        public NewsRepository()
        {

        }
        public NewsRepository(DataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        #endregion




        #region MainLogic

        public NewsModel GetNews(int id)
        {
            return _dataBaseService.GetNews(id);
        }
        public List<NewsModel> GetAllNews()
        {
            var tmpList = _dataBaseService.GetAllNews();
            tmpList.Reverse();
            return tmpList;
        }
        public List<NewsModel> GetLastNews(int count)
        {
            var tmpList = _dataBaseService.GetAllNews();
            tmpList.Reverse();
            return tmpList.GetRange(0, count);
        }

        public void AddNews(NewsModel newsModel)
        {
            _dataBaseService.AddNews(newsModel);
        }

        public void UpdateNews(int id, NewsModel newsModel)
        {
            _dataBaseService.UpdateNews(id, newsModel);
        }

        public void DeleteNews(int id)
        {
            _dataBaseService.DeleteNews(id);
        }

        #endregion
        


        #region Fields

        private DataBaseService _dataBaseService;

        #endregion

    }
}
