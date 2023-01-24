using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Task10.Controllers
{
    public class BankController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h1>Welcome to the Best Bank</h1>", "text/html");
        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            return new JsonResult(
                new
                {
                    accountNumber = 1001,
                    accountHolderName = "John Doe",
                    currentBalance = 5000
                }
            );
        }

        [Route("/get-current-balance/{accountNumber}")]
        public IActionResult CurrentBalance()
        {
            int accountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            if (accountNumber == 1001)
            {
                return Content("5000");
            }
            else
            {
                return NotFound();
            }
        }
    }

}
