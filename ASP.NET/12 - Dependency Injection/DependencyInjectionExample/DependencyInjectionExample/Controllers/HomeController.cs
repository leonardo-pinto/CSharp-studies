using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        // EXAMPLE OF CONSTRUCTOR INJECTION

        //private readonly ICitiesService _citiesService;

        //public HomeController(ICitiesService citiesService)
        //{
            // create object of CitiesService class
            // Controller is tightly coupled with the services
            // this represents a dependency problem
            // The higher-level modules (clients) should not
            // depend on low-level modules (dependencies)
            // Both should depend on abstractions (interfaces or abstract class) 
            // Must create object indirectly
            //_citiesService = new CitiesService();

            // using dependency injection and ioc
        //    _citiesService = citiesService;
        //}

        // EXAMPLE OF METHOD INJECTION
        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService _citiesService)
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
