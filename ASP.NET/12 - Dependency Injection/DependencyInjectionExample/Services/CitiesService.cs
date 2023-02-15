using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;

        private Guid _serviceInstanceId;

        public Guid ServiceInstanceId
        { 
            get
            { 
                return _serviceInstanceId; 
            }
        }
      
        public CitiesService() 
        {
            _serviceInstanceId = Guid.NewGuid();
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