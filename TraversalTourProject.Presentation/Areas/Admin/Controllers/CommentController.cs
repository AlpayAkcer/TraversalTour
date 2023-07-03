using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var value = _commentService.TGetListCommentDestination();
            return View(value);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.TGetByID(id);
            _commentService.TDelete(value);
            return RedirectToAction("Index");
        }

    }
}
