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
                new Person() { Name = "john", Age=40, Gender=Gender.Male },
                new Person() { Name = "jane", Age=30, Gender=Gender.Female },
                new Person() { Name = "jimmy", Age=15, Gender=Gender.Male },
            };

            //ViewData["people"] = people;
            //ViewBag.people = people;

            return View(people); // /Views/Home/Index.cshtml
        }

        [Route("/person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Person name can't be null");
            }
            else
            {
                List<Person> people = new List<Person>()
                {
                    new Person() { Name = "john", Age=40, Gender=Gender.Male },
                    new Person() { Name = "jane", Age=30, Gender=Gender.Female },
                    new Person() { Name = "jimmy", Age=15, Gender=Gender.Male },
                };

                Person? matchingPerson = people.Where(person => person.Name == name).FirstOrDefault();
                // Should add View first argument if dont matches the method name
                return View(matchingPerson);
            }
        }
    }
}
