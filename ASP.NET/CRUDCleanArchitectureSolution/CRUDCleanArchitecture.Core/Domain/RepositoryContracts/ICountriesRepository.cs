using Entities;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Country Entity
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// Adds a new country to the data base
        /// </summary>
        /// <param name="country">Country object to add</param>
        /// <returns>Returns the country object after adding it to the database</returns>
        Task<Country> AddCountry(Country country);

        /// <summary>
        /// Returns all countries in the database
        /// </summary>
        /// <returns>All countries from the database</returns>
        Task<List<Country>> GetAllCountries();

        /// <summary>
        /// Returns a country based on the ID or null
        /// </summary>
        /// <param name="countryID">CountryID (guid) to search</param>
        /// <returns>Matching Country object</returns>
        Task<Country?> GetCountryByCountryID(Guid? countryID);

        /// <summary>
        /// Returns a country object based on its name
        /// </summary>
        /// <param name="countryName">Country name to search</param>
        /// <returns>Matching country or null</returns>
        Task<Country?> GetCountryByCountryName(string countryName);
    }
}