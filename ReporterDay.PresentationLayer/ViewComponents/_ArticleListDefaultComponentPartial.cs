using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;

namespace ReporterDay.PresentationLayer.ViewComponents
{
    public class _ArticleListDefaultComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleListDefaultComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page, int pageSize)
        {
            var values = _articleService.TGetPagedArticlesWithCategoriesAndAppUsers(page, pageSize);
            var totalCount = await _articleService.TGetTotalArticleCountAsync();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.CurrentPage = page;

            return View(values);
        }
    }
}
