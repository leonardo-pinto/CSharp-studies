using Microsoft.AspNetCore.Mvc;

namespace CRUDCleanArchitecture.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
