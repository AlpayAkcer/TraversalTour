using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;

namespace TraversalTourProject.Presentation.ViewComponents.Default
{
    public class _FeaturedPartial : ViewComponent
    {
        FeaturedManager _featuredManager = new FeaturedManager(new EfFeaturedDal());
        public IViewComponentResult Invoke()
        {
            //var value = _featuredManager.TGetListAll();
            ViewBag.BigOne = _featuredManager.TGetListAll().FirstOrDefault();
            return View(/*value*/);
        }
    }
}
