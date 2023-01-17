using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    // suffix Controller identifies a class as a controller
   public class HomeController
   {
        [Route("/")]
        public string Index()
        {
            return "Hello from Index";
        }

        [Route("/about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("/contact")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
