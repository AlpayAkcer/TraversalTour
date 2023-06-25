using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager _guideManager = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var value = _guideManager.TGetListAll().Take(6).ToList();
            return View(value);
        }
    }
}
