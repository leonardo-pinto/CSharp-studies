using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;

namespace CrudTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;

        public PersonsServiceTest()
        {
            _personsService = new PersonsService();
            _countriesService = new CountriesService();
        }

        #region AddPerson
        [Fact]
        public void AddPerson_NullPerson()
        {
            // Arrange
            PersonAddRequest? personAddRequest = null;

            // Assert
            // Act
            Assert.Throws<ArgumentNullException>(() => {
                _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_PersonNameNull()
        {
            // Arrange
            PersonAddRequest? personAddRequest = new() { PersonName = null };

            // Assert
            // Act
            Assert.Throws<ArgumentException>(() => {
                _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            // Arrange
            PersonAddRequest? personAddRequest = new()
            { 
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = Guid.NewGuid(),
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            // Act
            PersonResponse person_response_from_add = _personsService.AddPerson(personAddRequest);
            List<PersonResponse> persons_list = _personsService.GetAllPersons();

            // Assert
            Assert.True(person_response_from_add.PersonID != Guid.Empty);
            Assert.Contains(person_response_from_add, persons_list);
        }

        #endregion

        #region GetAllPersons
        #endregion

        #region GetPersonByPersonID

        [Fact]
        public void GetPersonByPersonID_NullPersonID()
        {
            Guid? personID = null;
            PersonResponse? person_response_from_get = _personsService.GetPersonByPersonID(personID);
            Assert.Null(person_response_from_get);            
        }

        [Fact]
        public void GetPersonByPersonID_ProperPersonID()
        {
            // Arrange
            CountryAddRequest country_request = new()
            { CountryName = "Indonesia" };

            CountryResponse country_response = _countriesService.AddCountry(country_request);

            PersonAddRequest? person_request = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonResponse person_response_from_add = _personsService.AddPerson(person_request);

            PersonResponse? person_response_from_get = _personsService.GetPersonByPersonID(person_response_from_add.PersonID);

            Assert.Equal(person_response_from_add, person_response_from_get);
        }
        #endregion
    }
}
