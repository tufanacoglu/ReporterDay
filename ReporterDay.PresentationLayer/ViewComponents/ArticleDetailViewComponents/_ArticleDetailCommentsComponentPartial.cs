using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.BusinessLayer.Utilities;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailCommentsComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ArticleDetailCommentsComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = _commentService.TGetCommentsByArticleId(id);
            var checker = new ToxicContentChecker();

            foreach (var comment in values)
            {
                comment.IsToxic = await checker.IsToxicAsync(comment.CommentDetail);
            }

            return View(values);
        }
    }
}
