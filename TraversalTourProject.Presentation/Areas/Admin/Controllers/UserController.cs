using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var list = _appUserService.TGetListAll();
            return View(list);
        }


        public IActionResult DeleteUser(int id)
        {
            var model = _appUserService.TGetByID(id);
            _appUserService.TDelete(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var model = _appUserService.TGetByID(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetListAll();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var model = _reservationService.GetListWithReservationByAccepted(id);
            return View(model);
        }
    }
}
