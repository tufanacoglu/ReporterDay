using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReporterDay.DataAccessLayer.Abstract;
using ReporterDay.DataAccessLayer.Context;
using ReporterDay.DataAccessLayer.Repositories;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly ArticleContext _context;
        public EfArticleDal(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public List<Article> GetArticlesByAuthor(string id)
        {
            var values = _context.Articles.Where(x=>x.AppUserId == id).ToList();
            return values;
        }

        public List<Article> GetArticlesByCategoryId1()
        {
            var values = _context.Articles.Where(x=>x.CategoryId == 1).ToList();
            return values;
        }

        public List<Article> GetArticlesWithAppUser()
        {
           var values = _context.Articles.Include(x=>x.AppUser).ToList();
            return values;
        }

        public Article GetArticlesWithAuthorAndCategoriesById(int id)
        {
            return _context.Articles
                .Include(x => x.Category)
                .Include(x => x.AppUser) // ✅ AppUser Include edildi
                .FirstOrDefault(x => x.ArticleId == id);
        }

        public List<Article> GetArticlesWithCategories()
        {
            return _context.Articles.Include(x=>x.Category).ToList();
        }

        public List<Article> GetArticlesWithCategoriesAndAppUsers()
        {
            return _context.Articles.Include(x=> x.Category).Include(y=>y.AppUser).ToList();
        }

        public async Task<List<Article>> GetPagedArticlesAsync(int page, int pageSize)
        {
            return await _context.Articles
        .OrderByDescending(x => x.CreatedDate)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
        }

        public List<Article> GetPagedArticlesWithCategoriesAndAppUsers(int page, int pageSize)
        {
            return _context.Articles
                .Include(x => x.AppUser)
                .Include(x => x.Category)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<int> GetTotalArticleCountAsync()
        {
            return await _context.Articles.CountAsync();
        }
    }
}
