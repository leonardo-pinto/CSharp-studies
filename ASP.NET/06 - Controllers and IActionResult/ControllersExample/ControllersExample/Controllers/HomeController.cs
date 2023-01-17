using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    // suffix Controller identifies a class as a controller
   public class HomeController
    {
        [Route("/")]
        public string method1()
        {
            return "Hello from method 1";
        }

        [Route("/hello")]
        public string method2()
        {
            return "Hello from method 2";
        }
    }
}
