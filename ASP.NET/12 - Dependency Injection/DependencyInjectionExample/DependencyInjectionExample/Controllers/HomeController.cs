using Microsoft.AspNetCore.Mvc;
using Services;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        public HomeController()
        {
            // create object of CitiesService class
            _citiesService = new CitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
