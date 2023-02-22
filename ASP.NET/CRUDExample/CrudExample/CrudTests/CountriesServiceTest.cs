using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CrudTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
    
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry
        // When CountryAddRequest is null, 
        [Fact]// it should throws ArgumentNullException
        public void AddCountry_NullCountry()
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => 
            { 
                // Act
                _countriesService.AddCountry(request);
            });
        }

        // When the CountryName is null, it should throw
        // ArgumentNullException
        [Fact]
        public void AddCountry_NullCountryName()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = null
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countriesService.AddCountry(request);
            });
        }

        // When the CountryName is duplicated, it should throw
        // ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
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
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }


        // When supplied proper CountryName, it should
        // be add to the existing list of countries
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            // Arrange
            CountryAddRequest? request = new ()
            {
                CountryName = "Japan"
            };

            // Act
            CountryResponse response = _countriesService.AddCountry(request);
            List<CountryResponse> countries_from_GetAllCountries = _countriesService.GetAllCountries();

            // Assert
            Assert.True(response.CountryID != Guid.Empty);
            Assert.Contains(response, countries_from_GetAllCountries);
        }
        #endregion

        #region GetAllCountries

        [Fact]
        // The list of countries should be empty by default
        public void GetAllCountries_EmptyList()
        {
            // Acts
            List<CountryResponse> actual_contry_response_list = _countriesService.GetAllCountries();

            // Assert
            Assert.Empty(actual_contry_response_list);
        }

        [Fact]
        // Should return a list with the correct countries
        public void GetAllCountries_AddFewCountries()
        {
            List<CountryAddRequest> country_request_list = new()
            {
                new CountryAddRequest(){ CountryName = "Japan" },
                new CountryAddRequest(){ CountryName = "Canada" }
            };

            List<CountryResponse> countries_list_from_add_country = new();

            foreach(CountryAddRequest country_request in country_request_list)
            {
                countries_list_from_add_country.Add(_countriesService.AddCountry(country_request));
            }

            List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();

            foreach (CountryResponse expected_country in countries_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }



        }

        #endregion
    }
}
