using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace CrudExample.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }


        [Route("upload-from-excel")]
        public IActionResult UploadFromExcel()
        {
            return View();
        }

        [HttpPost]
        [Route("upload-from-excel")]
        // use the same parameter name as it is in the form
        public async Task<IActionResult> UploadFromExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ViewBag.ErrorMessage = "Please select an excel file";
                return View();
            }

            if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.ErrorMessage = "Unsupport file type. 'xlsx' file is expected'";
                return View();
            }

            int countriesCountInserted = await _countriesService.UploadCountriesFromExcelFile(excelFile);

            ViewBag.Message = $"{countriesCountInserted} countries uploaded!";
            return View();
        }
    }
}
