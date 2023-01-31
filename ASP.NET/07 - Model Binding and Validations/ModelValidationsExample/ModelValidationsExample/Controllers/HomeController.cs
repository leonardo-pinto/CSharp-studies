using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinder;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        // model bindings automatically creates person object
        // and assigns into person variable
        [HttpPost("register")]
        //public IActionResult Index(Person person)
        // Bind states which parameters should be validated
        //public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email))] Person person)
        // ModelBinder
        //public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBuilder))] Person person)
        public IActionResult Index([FromBody]Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            // accessing headers without model binding
            //ControllerContext.HttpContext.Request.Headers["keyName"]



            if (!ModelState.IsValid)
            {
                // using LINQ methods
                string errors = string.Join("\n",
                ModelState.Values.SelectMany(value => value.Errors)
                .Select(error => error.ErrorMessage).ToList());

                // without LINQ methods
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
