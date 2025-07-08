using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        public List<Article> TGetArticlesByCategoryId1();
        public List<Article> TGetArticlesWithAppUser();
        public List<Article> TGetArticlesWithCategories();
        public List<Article> TGetArticlesWithCategoriesAndAppUsers();
        public Article TGetArticlesWithAuthorAndCategoriesById(int id);
        List<Article> TGetArticlesByAuthor(string id);
        public Task<List<Article>> TGetPagedArticlesAsync(int page, int pageSize);
        public Task<int> TGetTotalArticleCountAsync();
        List<Article> TGetPagedArticlesWithCategoriesAndAppUsers(int page, int pageSize);

    }
}
