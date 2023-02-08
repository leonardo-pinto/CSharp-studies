using Microsoft.AspNetCore.Mvc;

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
            // pass View name as argument if it is different
            // than Default.cshtml
            return View(); 
            // invoked a partial view from
            // Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
