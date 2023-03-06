using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly PersonsDbContext _db;

        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }

        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
        {
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            if (await _db.Countries.CountAsync(country => country.CountryName == countryAddRequest.CountryName) > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryID = Guid.NewGuid();

            _db.Countries.Add(country);
            await _db.SaveChangesAsync();

            return country.ToCountryResponse();
        }

        public async Task<List<CountryResponse>> GetAllCountries()
        {
            return await _db.Countries.Select(country => country.ToCountryResponse()).ToListAsync();
        }

        public async Task<CountryResponse?> GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            Country? country_response_from_list = await _db.Countries.FirstOrDefaultAsync(country => country.CountryID == countryID);

            return country_response_from_list?.ToCountryResponse();
        }

        public async Task<int> UploadCountriesFromExcelFile(IFormFile formFile)
        {
            MemoryStream memoryStream = new();
            await formFile.CopyToAsync(memoryStream);
            int insertedCountries = 0;
            using (ExcelPackage excelPackage = new(memoryStream))
            {
                // should provice an excel template file
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets["Countries"];

                int rowCount = workSheet.Dimension.Rows;
                for (int row = 1; row <= rowCount; row++)
                {
                    string? cellValue = Convert.ToString(workSheet.Cells[row, 1].Value);

                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        string? countryName = cellValue;

                        if(_db.Countries.Where(temp => temp.CountryName == countryName).Count() == 0)
                        {
                            Country country = new() { CountryName = countryName };
                            _db.Countries.Add(country);
                            await _db.SaveChangesAsync();
                            insertedCountries++;
                        }
                    }
                }
            }
            return insertedCountries;
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