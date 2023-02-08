using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents
{
    // Attribute or ViewComponent suffix, 
    // in which the second is recommended
    //[ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        Task<IViewComponentResult> InvokeAsync()
        {
            return View(); 
            // invoked a partial view from
            // Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
