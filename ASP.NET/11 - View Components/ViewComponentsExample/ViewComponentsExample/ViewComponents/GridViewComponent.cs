using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    // Attribute or ViewComponent suffix, 
    // in which the second is recommended
    //[ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        // method must be public and async
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PersonGridModel model = new()
            {
                GridTitle = "Persons List",
                Persons = new List<Person>() {
                    new Person(){ Id = 1, Name = "John Doe" },
                    new Person(){ Id = 2, Name = "Joseph Richards" }
                }
            };

            ViewBag.Grid = model;

            // pass View name as argument if it is different
            // than Default.cshtml
            return View(); 
            // invoked a partial view from
            // Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
