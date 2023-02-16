using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;


namespace Task22.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
       
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cities = _weatherService.GetWeatherDetails();
            return View(cities);
        }

        [Route("/weather/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {
            // if cityCode is not supplied
            if (string.IsNullOrEmpty(cityCode))
            {
                // send null as model object to "Views/Home/City" view
                return View();
            }

            // invoke service method
            CityWeather? city = _weatherService.GetCityWeather(cityCode);

            // send matching city object to "Views/Weather/City"
            return View(city);
        }
    }
}
