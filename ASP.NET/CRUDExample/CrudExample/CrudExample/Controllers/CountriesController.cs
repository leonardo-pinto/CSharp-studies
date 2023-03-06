using Microsoft.AspNetCore.Mvc;

namespace CrudExample.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        [Route("upload-from-excel")]
        public IActionResult UploadFromExcel()
        {
            return View();
        }
    }
}
