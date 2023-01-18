using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/book")]
        // class IActionResult is the parent of all return types
        public IActionResult Index()
        {
            // Book id should be applied
            if (!Request.Query.ContainsKey("bookId"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }
            
            // Book id can`t be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
            {
                Response.StatusCode = 400;
                return Content("Book id can`t be null or empty");
            }

            // Book id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookId"]);
        
            if (bookId <= 0)
            {
                Response.StatusCode = 400;
                return Content("Book id can`t be less then or equal to zero");
            }
            if (bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id can`t be greater than 1000");
            }

            // isLoggedIn should be true
            if (Convert.ToBoolean(Request.Query["isLoggedIn"]) == false)
            {
                Response.StatusCode = 401;
                return Content("User must be authenticated");
            }

            // Here we have a problem declaring the method return type
            // ContentResult x FileResult
            return File("/example2.png", "content/png");
        }
    }
}
