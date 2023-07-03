using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var value = _destinationService.TGetListAll();
            return View(value);
        }

        [HttpGet]
        [Route("AddDestination")]
        public IActionResult AddDestination()
        {
            return View();
        }

        [Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.IsActive = true;
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            _destinationService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateDestination/{id}")]
        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            return View(value);
        }


        [HttpPost]
        [Route("UpdateDestination/{id}")]
        public IActionResult UpdateDestination(Destination destination)
        {
            destination.IsActive = true;
            _destinationService.TUpdate(destination);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        [Route("RotaDetail/{id}")]
        public IActionResult RotaDetail(int id)
        {
            ViewBag.DestinationId = id;
            var value = _destinationService.TGetByID(id);
            return View(value);
        }
    }
}
