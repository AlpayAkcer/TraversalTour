using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ICommentService _commentService;

        public DestinationController(IDestinationService destinationService, ICommentService commentService)
        {
            _destinationService = destinationService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var model = _destinationService.TGetListAll().Where(x => x.IsActive == true).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult RotaDetail(int id)
        {
            //Partial içerisinde id değerini yakalayabilmek ve bağlı olan yorumları getirebilmek için 
            //ViewBag komutu ile veri taşımamız gerekiyor.
            var yorumtoplami = _commentService.TGetDestinationByID(id).Count();
            ViewBag.CommentID = id;
            ViewBag.CommentCount = yorumtoplami;
            var model = _destinationService.TGetByID(id);
            return View(model);
        }

    }
}
