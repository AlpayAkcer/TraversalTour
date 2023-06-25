using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        GuideManager _guideManager = new GuideManager(new EfGuideDal());

        public IActionResult Index()
        {
            var value = _guideManager.TGetListAll();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            var value = _guideManager.TGetListAll();
            return View(value);
        }

        [HttpPost]
        public IActionResult AddGuide(Guide p)
        {
            var value = _guideManager.TGetListAll();
            return View(value);
        }
    }
}
