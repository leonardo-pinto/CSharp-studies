using Microsoft.AspNetCore.Mvc;
using Models;

namespace Task22.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            ViewBag.CityCssClass = GetCssClassByFahrenheit(city.TemperatureFahrenheit);
            return View(city);
        }

        public string GetCssClassByFahrenheit(int temperatureFahrenheit)
        {
            return temperatureFahrenheit switch
            {
                (< 44) => "blue-black",
                (>= 44) and (< 75) => "green-black",
                (>= 75) => "orange-black"
            };
        }
    }
}
