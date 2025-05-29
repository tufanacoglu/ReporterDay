using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Article> GetArticlesByCategoryId1()
        {
            var values = _context.Articles.Where(x=>x.CategoryId == 1).ToList();
            return values;
        }
    }
}
