using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    
    // suffix Controller identifies a class as a controller
    // [Controller] also indicates a controller 
    public class HomeController : Controller
   {
        [Route("/")]
        // IActionResult is the parent of Content, Json, File, and etc...
        public IActionResult Index()
        {
            //return new ContentResult() { Content = "Hello from Index", ContentType = "text/plain" };
            // alternative to the above by inheriting Controller class
            //return Content("Hello from Index", "text/plain");
            return Content("<h1>This is HTML</h1>", "text/html");
        }

        [Route("/about")]
        public JsonResult About()
        {
            Person person = new()
            {
                Id = new Guid(),
                FirstName = "Joseph",
                LastName = "Richards",
                Age = 56
            };
            // return new JsonResult(person);
            return Json(person);
        }

        [Route("/contact")]
        public string Contact()
        {
            return "Hello from Contact";
        }

        // example of virtual file
        [Route("/file-download")]
        public VirtualFileResult FileDownload()
        {
            return new VirtualFileResult("/example0.png", "application/png");
        }

        // Example of physical file 
        [Route("/file-download-physical")]
        public PhysicalFileResult FileDownloadPhysical()
        {
            return new PhysicalFileResult("/example0.png", "application/png");
        }
    }
}
