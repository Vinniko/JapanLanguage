using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Interfaces
{
    public interface IArticleRepository
    {
        ArticleModel GetArticle(int id);
        List<ArticleModel> GetAllArticles();
        List<ArticleModel> GetLastArticles(int count);

        void AddArticle(ArticleModel articleModel);

        void UpdateArticle(int id, ArticleModel articleModel);

        void DeleteArticle(int id);
    }
}
