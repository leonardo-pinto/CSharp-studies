using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            // Controller should supply all the data to View
            ViewData["appTitle"] = "* ASP.NET Core Demo App *";
            //string appTitle = "ASP.NET Core Demo App";

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "John Doe", Age=40, Gender=Gender.Male },
                new Person() { Name = "Jane Doe", Age=30, Gender=Gender.Female },
                new Person() { Name = "Jimmy Doe", Age=15, Gender=Gender.Male },

            };

            ViewData["people"] = people;

            return View(); // /Views/Home/Index.cshtml
        }
    }
}
