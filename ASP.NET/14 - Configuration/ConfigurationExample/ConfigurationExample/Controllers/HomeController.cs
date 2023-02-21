using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey = _configuration["MyKey"];
            //ViewBag.Id = _configuration["weatherapi:id"];
            //ViewBag.Secret = _configuration["weatherapi:secret"];

            //ViewBag.MyKey = _configuration["MyKey"];
            //ViewBag.Id = _configuration.GetSection("weatherapi")["id"];
            //ViewBag.Secret = _configuration["weatherapi:secret"];
            ViewBag.MyKey = _configuration["MyKey"];

            WeatherApiOptions options = _configuration.GetSection("Weatherapi").Get<WeatherApiOptions>();

            ViewBag.Id = options.Id;
            ViewBag.Secret = options.Secret;

            return View();
        }
    }
}
