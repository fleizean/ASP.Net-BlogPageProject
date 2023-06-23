using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Project.ViewComponents.Interests
{
	public class InterestsList : ViewComponent
    {
        InterestsManager interestsManager = new InterestsManager(new EfInterestsDal());
        public IViewComponentResult Invoke()
        {
            var values = interestsManager.TGetList();
            return View(values);
        }
    }
}

