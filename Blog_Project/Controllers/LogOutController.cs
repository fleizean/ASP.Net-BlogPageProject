using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
    public class LogOutController : Controller
    {
        private readonly SignInManager<AdminUser> _userManager;

        public LogOutController(SignInManager<AdminUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           await _userManager.SignOutAsync();
           return RedirectToAction("Index", "Login");
        }
    }
}

