using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;

        public DashboardController(UserManager<AdminUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name;
            int ratio = 4;

            ratio -= String.IsNullOrEmpty(values.Name) ? 1 : 0;
            ratio -= String.IsNullOrEmpty(values.Surname) ? 1 : 0;
            ratio -= String.IsNullOrEmpty(values.Email) ? 1 : 0;
            ratio -= String.IsNullOrEmpty(values.ImageUrl) ? 1 : 0;

            if (ratio * 25 == 100)
            {
                ViewBag.v2 = "0";
                ViewBag.v3 = "Profilini tekrar düzenlemek için aşağıdaki butonu kullan!";
            }
            else
            {
                ViewBag.v2 = 100 - (ratio * 25);
                ViewBag.v3 = "Profilindeki düzenlenmemiş alanları kontrol etmek için aşağıdaki butonu kullan!";
            }
            
            return View();
        }
    }
}

