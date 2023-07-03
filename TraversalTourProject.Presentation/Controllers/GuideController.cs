using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Abstract;

namespace TraversalTourProject.Presentation.Controllers
{
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }


        public IActionResult Index()
        {
            var model = _guideService.TGetListAll();
            return View(model);
        }
    }
}
