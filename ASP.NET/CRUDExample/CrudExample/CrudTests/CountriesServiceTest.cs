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
            Assert.Throws<ArgumentNullException>(() =>
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

            // Assert
            Assert.True(response.CountryID != Guid.Empty);
            
        }
    }
}
