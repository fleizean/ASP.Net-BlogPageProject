using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog_Project.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;

        public RegisterController(UserManager<AdminUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (p.Picture == null || string.IsNullOrEmpty(p.Picture.FileName))
            {
                ModelState.AddModelError("Picture", "Resim alanı boş olamaz.");
                return View(p);
            }

            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(p.Picture.FileName);
            var imagename = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/userimage/" + imagename;

            var stream = new FileStream(savelocation, FileMode.Create);
            await p.Picture.CopyToAsync(stream);
            p.ImageUrl = imagename;

            AdminUser w = new AdminUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName,
                ImageUrl = imagename,
            };

            if (string.IsNullOrEmpty(p.Password) || string.IsNullOrEmpty(p.ConfirmPassword))
            {
                ModelState.AddModelError("", "Şifre alanı boş olamaz.");
                return View(p);
            }

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(w, p.Password);

                if (result.Succeeded)
                {
                    return Redirect("/Login/");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifre ve şifre tekrarı eşleşmiyor.");
            }

            return View(p);
        }
    }
}

