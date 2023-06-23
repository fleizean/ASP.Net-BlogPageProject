using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
    public class InterestController : Controller
    {
        InterestsManager interestsManager = new InterestsManager(new EfInterestsDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = interestsManager.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Interests interests)
        {
            interestsManager.TUpdate(interests);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

