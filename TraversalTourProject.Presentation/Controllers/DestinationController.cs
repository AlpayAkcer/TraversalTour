using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager _destination = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var model = _destination.TGetListAll().Where(x => x.IsActive == true).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult RotaDetail(int id)
        {
            var model = _destination.TGetByID(id);
            return View(model);
        }

    }
}
