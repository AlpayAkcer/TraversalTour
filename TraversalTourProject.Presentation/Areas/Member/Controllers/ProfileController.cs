using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using TraversalTourProject.EntityLayer.Concrete;
using TraversalTourProject.Presentation.Areas.Member.Models;

namespace TraversalTourProject.Presentation.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = value.Name;
            userEditViewModel.Surname = value.Surname;
            userEditViewModel.PhoneNumber = value.PhoneNumber;
            userEditViewModel.Gender = value.Gender;
            userEditViewModel.Description = value.Description;
            userEditViewModel.City = value.City;
            userEditViewModel.Email = value.Email;
            userEditViewModel.ImageUrl = value.ImageUrl;
            return View(userEditViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ProfileEdit()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = value.Name;
            userEditViewModel.Surname = value.Surname;
            userEditViewModel.PhoneNumber = value.PhoneNumber;
            userEditViewModel.Description = value.Description;
            userEditViewModel.Gender = value.Gender;
            userEditViewModel.City = value.City;
            userEditViewModel.Email = value.Email;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(UserEditViewModel model)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/Upload/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                value.ImageUrl = imagename;
            }
            value.Name = model.Name;
            value.Surname = model.Surname;
            value.PhoneNumber = model.PhoneNumber;
            value.Gender = model.Gender;
            value.Description = model.Description;
            value.Email = model.Email;
            value.City = model.City;
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, model.Password);
            var result = await _userManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
