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
    public class AwardsController : Controller
    {
        AwardsManager awardsManager = new AwardsManager(new EfAwardsDal());
        public IActionResult Index()
        {
            var values = awardsManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteAwards(int id)
        {
            var values = awardsManager.TGetByID(id);
            awardsManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAwards()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAwards(Awards awards)
        {
            awardsManager.TAdd(awards);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAwards(int id)
        {
            var values = awardsManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAwards(Awards awards)
        {
            awardsManager.TUpdate(awards);
            return RedirectToAction("Index");
        }
    }
}

