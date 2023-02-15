using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        // EXAMPLE OF CONSTRUCTOR INJECTION

        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController(
            ICitiesService citiesService1,
            ICitiesService citiesService2,
            ICitiesService citiesService3,
            IServiceScopeFactory serviceScopeFactory
        )
        {
            //create object of CitiesService class
            //Controller is tightly coupled with the services
            //this represents a dependency problem

            //The higher-level modules (clients) should not
            //depend on low-level modules (dependencies)
            //Both should depend on abstractions (interfaces or abstract class) 
            // Must create object indirectly
            //_citiesService = new CitiesService();

            // using dependency injection and ioc
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        // EXAMPLE OF METHOD INJECTION
        //[Route("/")]
        //public IActionResult Index([FromServices] ICitiesService _citiesService)
        //{
        //    List<string> cities = _citiesService.GetCities();
        //    return View(cities);
        //}

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService1.GetCities();

            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;
            
            // Service Scope
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                // Inject CitiesService
                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();

                ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceInstanceId;
                // Db Work
                
            } // end of scope -> calls Dipose method of the service
            
            return View(cities);
        }
    }
}
