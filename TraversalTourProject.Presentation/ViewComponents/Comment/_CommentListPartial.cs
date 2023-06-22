using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.ViewComponents.Comment
{
    public class _CommentListPartial : ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var model = _commentManager.TGetDestinationByID(id);            
            return View(model);
        }
    }
}
