using CRUDCleanArchitecture.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using CRUDCleanArchitecture.UI.Controllers;
using CrudExample.Controllers;

namespace CRUDCleanArchitecture.UI.Controllers
{
    [Route("[controller/[action]")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            return RedirectToAction(nameof(PersonsController.Index), "Persons");
        }
    }
}
