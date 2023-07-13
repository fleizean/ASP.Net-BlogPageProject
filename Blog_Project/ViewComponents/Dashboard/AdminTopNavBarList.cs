using System;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Project.ViewComponents.Dashboard
{
	public class AdminTopNavBarList : ViewComponent
    {
        private readonly UserManager<AdminUser> _userManager;

        public AdminTopNavBarList(UserManager<AdminUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.v1 = values.ImageUrl;
            ViewBag.v2 = values.Name + " " + values.Surname;
            var roles = _userManager.GetRolesAsync(values).Result;
            if (roles[0] != null)
                ViewBag.v3 = roles[0];
            else
                ViewBag.v3 = "Atanmamış";

            return View();
        }
    }
}

