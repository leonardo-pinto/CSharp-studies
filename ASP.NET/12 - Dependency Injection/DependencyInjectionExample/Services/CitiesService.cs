using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
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
            // TO DO: add logic to open the db connection
        }

        public List<string> GetCities ()
        {
            // should fetch data from db
            return _cities;
        }

        public void Dispose()
        {
            // Dispose method is called by default
            // if you register the service as scoped service
            // TO DO: add logic to close db connection
        }
    }
}