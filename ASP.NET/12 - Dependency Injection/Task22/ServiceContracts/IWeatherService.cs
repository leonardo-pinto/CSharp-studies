using Models;

namespace ServiceContracts
{
    /// <summary>
    /// Represents a service contract that handles weather details of cities
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Returns a list of CityWeather objects that contains weather details of cities
        /// </summary>
        /// <returns>List of CityWeather objects that contains weather details of cities</returns>
        List<CityWeather> GetWeatherDetails();

        /// <summary>
        /// Returns an object of CityWeather
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        CityWeather? GetCityWeather(string cityCode);
    }
}