using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;
using Moq;

namespace CrudTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
    
        public CountriesServiceTest()
        {
            var countriesInitialData = new List<Country>();
            DbContextMock<ApplicationDbContext> dbContextMock = new(
                new DbContextOptionsBuilder<ApplicationDbContext>().Options
            );
            
            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Countries, countriesInitialData);

            _countriesService = new CountriesService(dbContext);
        }

        #region AddCountry
        // When CountryAddRequest is null, 
        [Fact]// it should throws ArgumentNullException
        public async Task AddCountry_NullCountry()
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => 
            { 
                // Act
                await _countriesService.AddCountry(request);
            });
        }

        // When the CountryName is null, it should throw
        // ArgumentNullException
        [Fact]
        public async Task AddCountry_NullCountryName()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = null
            };

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // Act
                await _countriesService.AddCountry(request);
            });
        }

        // When the CountryName is duplicated, it should throw
        // ArgumentException
        [Fact]
        public async Task AddCountry_DuplicateCountryName()
        {
            // Arrange
            CountryAddRequest? request1 = new CountryAddRequest()
            {
                CountryName = "Canada"
            };

            CountryAddRequest? request2 = new CountryAddRequest()
            {
                CountryName = "Canada"
            };

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // Act
                await _countriesService.AddCountry(request1);
                await _countriesService.AddCountry(request2);
            });
        }


        // When supplied proper CountryName, it should
        // be add to the existing list of countries
        [Fact]
        public async Task AddCountry_ProperCountryDetails()
        {
            // Arrange
            CountryAddRequest? request = new ()
            {
                CountryName = "Japan"
            };

            // Act
            CountryResponse response = await _countriesService.AddCountry(request);
            List<CountryResponse> countries_from_GetAllCountries = await _countriesService.GetAllCountries();

            // Assert
            Assert.True(response.CountryID != Guid.Empty);
            Assert.Contains(response, countries_from_GetAllCountries);
        }
        #endregion

        #region GetAllCountries

        [Fact]
        // The list of countries should be empty by default
        public async Task GetAllCountries_EmptyList()
        {
            // Acts
            List<CountryResponse> actual_contry_response_list = await _countriesService.GetAllCountries();

            // Assert
            Assert.Empty(actual_contry_response_list);
        }

        [Fact]
        // Should return a list with the correct countries
        public async Task GetAllCountries_AddFewCountries()
        {
            List<CountryAddRequest> country_request_list = new()
            {
                new CountryAddRequest(){ CountryName = "Japan" },
                new CountryAddRequest(){ CountryName = "Canada" }
            };

            List<CountryResponse> countries_list_from_add_country = new();

            foreach(CountryAddRequest country_request in country_request_list)
            {
                countries_list_from_add_country.Add(await _countriesService.AddCountry(country_request));
            }

            List<CountryResponse> actualCountryResponseList = await _countriesService.GetAllCountries();

            foreach (CountryResponse expected_country in countries_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }

        #endregion

        #region GetCountryById

        [Fact]
        public async Task GetCountryByCountryID_NullCountryID()
        {
            // Arrange
            Guid? countryID = null;

            // Act
            CountryResponse? country_response_from_get_method =  await _countriesService.GetCountryByCountryID(countryID);

            // Assert
            Assert.Null(country_response_from_get_method);
        }

        [Fact]
        public async Task GetCountryByCountryID_ValidCountryID()
        {
            // Arrange
            CountryAddRequest? country_add_request = new() { CountryName = "Brazil" };
            CountryResponse country_add_response = await _countriesService.AddCountry(country_add_request);

            // Act
            CountryResponse? country_actual_response = await _countriesService.GetCountryByCountryID(country_add_response.CountryID);

            // Assert
            Assert.Equal(country_add_response, country_actual_response);
        }
        #endregion
    }
}
