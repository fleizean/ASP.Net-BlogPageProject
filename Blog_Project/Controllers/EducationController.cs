using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EducationController : Controller
    {
        EducationManager educationManager = new EducationManager(new EfEducationDal());
        public IActionResult Index()
        {
            var values = educationManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteEducation(int id)
        {
            var values = educationManager.TGetByID(id);
            educationManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            educationManager.TAdd(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEducation(int id)
        {
            var values = educationManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditEducation(Education education)
        {
            educationManager.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}

