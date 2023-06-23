using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Project.ViewComponents.Awards
{
	public class AwardsList : ViewComponent
    {
        AwardsManager awardsManager = new AwardsManager(new EfAwardsDal());

        public IViewComponentResult Invoke()
        {
            var values = awardsManager.TGetList();
            return View(values);
        }
    }
}

