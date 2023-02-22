using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Entities;
using ServiceContracts.Enums;
using Xunit.Abstractions;

namespace CrudTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;
        private readonly ITestOutputHelper _testOutputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _personsService = new PersonsService();
            _countriesService = new CountriesService();
            _testOutputHelper = testOutputHelper;
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

        [Fact]
        public void GetAllPersons_EmptyList()
        {
            // Act
            List<PersonResponse> persons_from_get = _personsService.GetAllPersons();
            Assert.Empty(persons_from_get);  
        }

        [Fact]
        public void GetAllPersons_AddFewPersons()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest? person_request_1 = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response_1.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest? person_request_2 = new()
            {
                PersonName = "Jane Doe",
                Email = "jane.doe@mail.com",
                CountryID = country_response_2.CountryID,
                Address = "Jane Doe Boulevar, 52",
                Gender = GenderOptions.Female,
                DateOfBirth = DateTime.Parse("2002-01-01"),
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> persons_requests = new()
            { person_request_1, person_request_2 };

            List<PersonResponse> person_response_list_from_add = new();

            foreach (PersonAddRequest person in persons_requests)
            {
                PersonResponse person_response = _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }

            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }


            List<PersonResponse> persons_list_from_get = _personsService.GetAllPersons();

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse person_response_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_get);
            }
        }

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

        #region GetFilteredPersons

        [Fact]
        public void GetFilteredPersons_EmptySearchText()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest? person_request_1 = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response_1.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest? person_request_2 = new()
            {
                PersonName = "Jane Doe",
                Email = "jane.doe@mail.com",
                CountryID = country_response_2.CountryID,
                Address = "Jane Doe Boulevar, 52",
                Gender = GenderOptions.Female,
                DateOfBirth = DateTime.Parse("2002-01-01"),
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> persons_requests = new()
            { person_request_1, person_request_2 };

            List<PersonResponse> person_response_list_from_add = new();

            foreach (PersonAddRequest person in persons_requests)
            {
                PersonResponse person_response = _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }

            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }


            List<PersonResponse> persons_list_from_search = _personsService.GetFilteredPersons(nameof(Person.PersonName), "");

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse person_response_from_get in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_search);
            }
        }

        [Fact]
        public void GetFilteredPersons_SearchByPersonName()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest? person_request_1 = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response_1.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonAddRequest? person_request_2 = new()
            {
                PersonName = "Jane Doe",
                Email = "jane.doe@mail.com",
                CountryID = country_response_2.CountryID,
                Address = "Jane Doe Boulevar, 52",
                Gender = GenderOptions.Female,
                DateOfBirth = DateTime.Parse("2002-01-01"),
                ReceiveNewsLetters = false
            };

            List<PersonAddRequest> persons_requests = new()
            { person_request_1, person_request_2 };

            List<PersonResponse> person_response_list_from_add = new();

            foreach (PersonAddRequest person in persons_requests)
            {
                PersonResponse person_response = _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }

            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }


            List<PersonResponse> persons_list_from_search = _personsService.GetFilteredPersons(nameof(Person.PersonName), "Doe");

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse person_response_from_get in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                if (person_response_from_add.PersonName != null)
                {
                    if (person_response_from_add.PersonName.Contains("Doe", StringComparison.OrdinalIgnoreCase))
                    {
                        Assert.Contains(person_response_from_add, persons_list_from_search);
                    }
                }
            }
        }

        #endregion
    }
}
