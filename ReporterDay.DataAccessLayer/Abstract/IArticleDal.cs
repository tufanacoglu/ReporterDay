using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticlesByCategoryId1();
        List<Article> GetArticlesWithAppUser();
        List<Article> GetArticlesWithCategories();
        List<Article> GetArticlesWithCategoriesAndAppUsers();

        Article GetArticlesWithAuthorAndCategoriesById(int id);
        List<Article> GetArticlesByAuthor(string id);
        Task<List<Article>> GetPagedArticlesAsync(int page, int pageSize);
        Task<int> GetTotalArticleCountAsync();
        List<Article> GetPagedArticlesWithCategoriesAndAppUsers(int page, int pageSize);
    }
}
