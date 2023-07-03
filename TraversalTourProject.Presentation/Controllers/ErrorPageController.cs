using Microsoft.AspNetCore.Mvc;

namespace TraversalTourProject.Presentation.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int code)
        {
            return View();
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            ViewBag.Code = 403;
            return View("PageError");
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            ViewBag.Code = 404;
            return View("PageError");
        }

        public ActionResult Page500()
        {
            Response.StatusCode = 500;
            ViewBag.Code = 500;
            return View("PageError");
        }
    }
}
