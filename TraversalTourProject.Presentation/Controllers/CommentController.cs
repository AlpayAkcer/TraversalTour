using Microsoft.AspNetCore.Mvc;
using System;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.IsActive = true;
            comment.DestinationID = 2;
            _commentService.TAdd(comment);
            return RedirectToAction("Index", "Destination");
        }
    }
}
