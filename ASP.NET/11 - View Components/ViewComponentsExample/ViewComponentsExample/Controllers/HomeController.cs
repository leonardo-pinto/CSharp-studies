using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("load-friends-list")]
        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new()
            {
                GridTitle = "Persons List",
                Persons = new List<Person>() {
                    new Person(){ Id = 1, Name = "John Doe" },
                    new Person(){ Id = 2, Name = "Joseph Richards" }
                }
            };


            return ViewComponent("Grid", new { grid = personGridModel });
        }
    }
}
