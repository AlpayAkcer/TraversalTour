using Microsoft.AspNetCore.Mvc;

namespace TraversalTourProject.Presentation.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
