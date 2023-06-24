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

        public IActionResult Index()
        {
            /*var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.ImageUrl;*/
            return View();
        }


    }
}

