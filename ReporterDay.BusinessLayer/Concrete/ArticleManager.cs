using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.BusinessLayer.Utilities;
using ReporterDay.DataAccessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> GetArticlesWithCategories()
        {
            return _articleDal.GetArticlesWithCategories();
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);

        }

        public List<Article> TGetArticlesByAuthor(string id)
        {
            return _articleDal.GetArticlesByAuthor(id);
        }

        public List<Article> TGetArticlesByCategoryId1()
        {
            return _articleDal.GetArticlesByCategoryId1();
        }

        public List<Article> TGetArticlesWithAppUser()
        {
            return _articleDal.GetArticlesWithAppUser();
        }

        public Article TGetArticlesWithAuthorAndCategoriesById(int id)
        {
            return _articleDal.GetArticlesWithAuthorAndCategoriesById(id);
        }

        public List<Article> TGetArticlesWithCategories()
        {
            return _articleDal.GetArticlesWithCategories();
        }

        public List<Article> TGetArticlesWithCategoriesAndAppUsers()
        {
            return _articleDal.GetArticlesWithCategoriesAndAppUsers();
        }

        public Article TGetById(int id)
        {
           return _articleDal.GetById(id);
        }

        public List<Article> TGetListAll()
        {
            return _articleDal.GetListAll();
        }

        public Task<List<Article>> TGetPagedArticlesAsync(int page, int pageSize)
        {
            return _articleDal.GetPagedArticlesAsync(page,pageSize);
        }
        public List<Article> TGetPagedArticlesWithCategoriesAndAppUsers(int page, int pageSize)
        {
            return _articleDal.GetPagedArticlesWithCategoriesAndAppUsers(page, pageSize);
        }

        public double TGetTotalArticleCount()
        {
            throw new NotImplementedException();
        }

        //public double TGetTotalArticleCount()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<int> TGetTotalArticleCountAsync()
        {
            return await _articleDal.GetTotalArticleCountAsync();
        }

        public void TInsert(Article entity)
        {
            if (entity.Title!=null && entity.Title.Length>10 && entity.CategoryId!=0 && entity.Content.Length <=1000)
            {
                entity.Slug = SlugHelper.GenerateSlug(entity.Title);
                _articleDal.Insert(entity);
            }
            else
            {
                //Hata mesajı
            }
        }

        public void TUpdate(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}
