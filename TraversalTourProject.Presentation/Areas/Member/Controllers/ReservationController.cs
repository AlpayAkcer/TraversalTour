using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalTourProject.BusinessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.EntityFramework;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.Presentation.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());

        public readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _reservationManager.GetListWithReservationByAccepted(user.Id);
            return View(value);
        }

        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _reservationManager.GetListWithReservationByWaitApproval(user.Id);
            return View(value);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _reservationManager.GetListWithReservationByPrevious(user.Id);
            return View(value);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> value = (from x in _destinationManager.TGetListAll()
                                          select new SelectListItem
                                          {
                                              Text = x.City,
                                              Value = x.DestinationID.ToString()
                                          }).ToList();
            ViewBag.DestinationRote = value;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user.Id != null)
                {
                    p.AppUserID = user.Id;
                    p.ReservationDate = DateTime.Now;
                    p.IsActive = true;
                    p.StatusID = 1; // OnayBekleniyor
                    _reservationManager.TAdd(p);
                    return RedirectToAction("MyCurrentReservation");
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            else
            {
                return RedirectToAction("NewReservation");
            }
        }

    }
}
