using Microsoft.AspNetCore.Mvc;

namespace TraversalTourProject.Presentation.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
