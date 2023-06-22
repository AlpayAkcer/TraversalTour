using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.DataAccessLayer.Concrete;

namespace TraversalTourProject.Presentation.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var _context = new Context();
            ViewBag.Rotalar = _context.Destinations.Count();
            ViewBag.Rehberler = _context.Guides.Count();
            ViewBag.Musteriler = "285";
            return View();
        }
    }
}
