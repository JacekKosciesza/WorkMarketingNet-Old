﻿using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkMarketingNet.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

		[Route("settings")]
		//[LocalRoute]
		public IActionResult Settings()
		{
			return View();
		}
	}
}
