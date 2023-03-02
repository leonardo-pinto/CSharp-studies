﻿using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly PersonsDbContext _db;

        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            if (_db.Countries.Count(country => country.CountryName == countryAddRequest.CountryName) > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryID = Guid.NewGuid();

            _db.Countries.Add(country);
            _db.SaveChanges();

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _db.Countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            Country? country_response_from_list = _db.Countries.FirstOrDefault(country => country.CountryID == countryID);

            return country_response_from_list?.ToCountryResponse();
        }

        // Without DB
        //    private readonly List<Country> _countries;

        //    public CountriesService(bool initialize = true)
        //    {
        //        _countries = new List<Country>();
        //        if (initialize)
        //        {
        //            _countries.AddRange(new List<Country>()
        //            {
        //                new Country()
        //                { CountryID = Guid.Parse("58907889-5F10-43DA-9CD8-000BCDD4E073"), CountryName = "Canada" },
        //                new Country()
        //                { CountryID = Guid.Parse("72BBA61E-AA93-4721-A46D-7DE894F48CF5"), CountryName = "Brazil" },
        //                new Country()
        //                { CountryID = Guid.Parse("3CA2F22E-B6A9-4D60-BDBF-8FAEE2515599"), CountryName = "Nigeria" },
        //            });
        //        }
        //    }

        //    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        //    {
        //        if (countryAddRequest == null)
        //        {
        //            throw new ArgumentNullException(nameof(countryAddRequest));
        //        }

        //        if (countryAddRequest.CountryName == null)
        //        {
        //            throw new ArgumentException(nameof(countryAddRequest.CountryName));
        //        }

        //        if (_countries.Where(country => country.CountryName == countryAddRequest.CountryName).Any())
        //        {
        //            throw new ArgumentException("Given country name already exists");
        //        }

        //        Country country = countryAddRequest.ToCountry();

        //        country.CountryID = Guid.NewGuid();

        //        _countries.Add(country);

        //        return country.ToCountryResponse();
        //    }

        //    public List<CountryResponse> GetAllCountries()
        //    {
        //      return _countries.Select(country => country.ToCountryResponse()).ToList();
        //    }

        //    public CountryResponse? GetCountryByCountryID(Guid? countryID)
        //    {
        //        if (countryID == null)
        //        {
        //            return null;
        //        }

        //        Country? country_response_from_list = _countries.FirstOrDefault(country => country.CountryID == countryID);

        //        return country_response_from_list?.ToCountryResponse();
        //    }
    }
}