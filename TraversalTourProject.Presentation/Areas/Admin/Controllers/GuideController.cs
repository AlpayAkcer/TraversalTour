using FluentValidation.Resources;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.BusinessLayer.ValidationRules;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var value = _guideService.TGetListAll();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                guide.IsActive = true;
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult ChangeStatus(int id)
        {
            var model = _guideService.TGetByID(id);
            if (model.IsActive == true)
            {
                model.IsActive = false;
            }
            else
            {
                model.IsActive = true;
            }
            _guideService.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
