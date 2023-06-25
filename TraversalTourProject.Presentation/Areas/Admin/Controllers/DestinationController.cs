using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var value = _destinationManager.TGetListAll();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationManager.TAdd(destination);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationManager.TGetByID(id);
            _destinationManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationManager.TGetByID(id);
            return View(value);
        }


        //[HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationManager.TUpdate(destination);
            return RedirectToAction("Index");
        }
    }
}
