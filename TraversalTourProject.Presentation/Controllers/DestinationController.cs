using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager _destination = new DestinationManager(new EfDestinationDal());
        CommentManager _commentManager = new CommentManager(new EfCommentDal());

        public IActionResult Index()
        {
            var model = _destination.TGetListAll().Where(x => x.IsActive == true).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult RotaDetail(int id)
        {
            //Partial içerisinde id değerini yakalayabilmek ve bağlı olan yorumları getirebilmek için 
            //ViewBag komutu ile veri taşımamız gerekiyor.
            var yorumtoplami = _commentManager.TGetDestinationByID(id).Count();
            ViewBag.CommentID = id;
            ViewBag.CommentCount = yorumtoplami;
            var model = _destination.TGetByID(id);
            return View(model);
        }

    }
}
