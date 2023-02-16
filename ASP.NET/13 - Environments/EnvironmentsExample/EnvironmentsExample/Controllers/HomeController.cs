using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("same-route")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("same-route")]
        public IActionResult Other()
        {
            return View();
        }
    }
}
