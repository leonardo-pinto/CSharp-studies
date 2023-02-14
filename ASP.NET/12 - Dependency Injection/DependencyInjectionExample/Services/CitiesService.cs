using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;

        public CitiesService() 
        {
            _cities = new List<string>()
            {
                "Toronto", "Etobicoke", "Aurora"
            };
        }

        public List<string> GetCities ()
        {
            // should fetch data from db
            return _cities;
        }
    }
}