﻿using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>Returns the country object after adding it (including generated id)</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Returns all countries from the list
        /// </summary>
        /// <returns>List of all countries</returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// Returns a country based on the ID
        /// </summary>
        /// <param name="countryID">CountryID (guid) to search</param>
        /// <returns>Matching country as CountryResponse object</returns>
        CountryResponse? GetCountryByCountryID(Guid? countryID);
    }
}