using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface INewsRepository
    {
        NewsModel GetNews(int id);
        List<NewsModel> GetAllNews();
        List<NewsModel> GetLastNews(int count);

        void AddNews(NewsModel newsModel);

        void UpdateNews(int id, NewsModel newsModel);

        void DeleteNews(int id);
    }
}
