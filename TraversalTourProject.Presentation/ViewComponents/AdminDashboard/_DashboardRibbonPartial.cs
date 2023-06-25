using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.ViewComponents.AdminDashboard
{
    public class _DashboardRibbonPartial : ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        GuideManager _guideManager = new GuideManager(new EfGuideDal());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.DestinationCount = _destinationManager.TGetListAll().Count;
            ViewBag.GuideCount = _guideManager.TGetListAll().Count;
            ViewBag.UserCount = context.Users.Count();
            return View();
        }
    }
}
