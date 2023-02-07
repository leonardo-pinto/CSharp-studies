using Microsoft.AspNetCore.Mvc;
using PartialViewsExample.Models;

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

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listModel = new()
            {
                ListTitle = "Programming Languages",
                ListItems = new List<string>()
                {
                    "C#", "Java", "Python"
                }
            };

            return PartialView("_ListPartialView", listModel);
            //return new PartialViewResult() { ViewName = "_ListPartialView", Model = listModel}
        }
    }
}
