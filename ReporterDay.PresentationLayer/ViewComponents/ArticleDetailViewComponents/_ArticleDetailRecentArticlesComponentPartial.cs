using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailRecentArticlesComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleDetailRecentArticlesComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var articles = _articleService.TGetListAll()
                .OrderByDescending(x => x.CreatedDate)
                .Take(5)
                .ToList();

            return View(articles);
        }
    }
}
