using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        // ✅ Tek constructor
        public ArticleController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 9;

            var articles = await _articleService.TGetPagedArticlesAsync(page, pageSize);
            var totalArticles = await _articleService.TGetTotalArticleCountAsync();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalArticles / pageSize);
            ViewBag.CurrentPage = page;

            return View(articles);
        }

        [Route("Article/ArticleDetail/{slug}")]
        public IActionResult ArticleDetail(string slug)
        {
            var article = _articleService.TGetListAll()
                .FirstOrDefault(x => x.Slug == slug);

            if (article == null)
            {
                return NotFound();
            }

            ViewBag.ArticleId = article.ArticleId; // ✅ Burada düzeltme
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int articleId, string commentText)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Yorum eklemek için giriş yapmalısınız." });
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Comment comment = new Comment
            {
                ArticleId = articleId,
                CommentDetail = commentText,
                CommentDate = DateTime.Now,
                IsValid = true,
                AppUserId = userId,
                IsToxic = false // İstersek checker çağırırız
            };

            await _commentService.TInsertAsync(comment);

            return Json(new { success = true, message = "Yorum başarıyla eklendi." });
        }
    }
}
