﻿using Microsoft.AspNetCore.Mvc;

namespace PartialViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {

            //ViewData["ListTitle"] = "Cities";
            //ViewData["ListItems"] = new List<string>()
            //{
            //    "Paris",
            //    "Toronto",
            //    "Hamilton"
            //};

            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
