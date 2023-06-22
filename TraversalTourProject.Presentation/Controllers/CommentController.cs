using Microsoft.AspNetCore.Mvc;
using System;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());

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
            _commentManager.TAdd(comment);
            return RedirectToAction("Index", "Destination");
        }
    }
}
