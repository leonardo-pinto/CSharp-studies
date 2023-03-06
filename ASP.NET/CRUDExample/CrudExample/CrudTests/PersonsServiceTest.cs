using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Entities;
using ServiceContracts.Enums;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;

namespace CrudTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;
        private readonly ITestOutputHelper _testOutputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            var countriesInitialData = new List<Country>();
            var personsInitialData = new List<Person>();
            DbContextMock<ApplicationDbContext> dbContextMock = new(
                new DbContextOptionsBuilder<ApplicationDbContext>().Options
            );

            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Countries, countriesInitialData);
            dbContextMock.CreateDbSetMock(temp => temp.Persons, personsInitialData);

            _countriesService = new CountriesService(dbContext);
            _personsService = new PersonsService(dbContext, _countriesService);
        }

        #region AddPerson
        [Fact]
        public async Task AddPerson_NullPerson()
        {
            // Arrange
            PersonAddRequest? personAddRequest = null;

            // Assert
            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => {
                await _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public async Task AddPerson_PersonNameNull()
        {
            // Arrange
            PersonAddRequest? personAddRequest = new() { PersonName = null };

            // Assert
            // Act
            await Assert.ThrowsAsync<ArgumentException>(async () => {
                await _personsService.AddPerson(personAddRequest);
            });
        }

        [Fact]
        public async Task AddPerson_ProperPersonDetails()
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
            PersonResponse person_response_from_add = await _personsService.AddPerson(personAddRequest);
            List<PersonResponse> persons_list = await _personsService.GetAllPersons();

            // Assert
            Assert.True(person_response_from_add.PersonID != Guid.Empty);
            Assert.Contains(person_response_from_add, persons_list);
        }

        #endregion

        #region GetAllPersons

        [Fact]
        public async Task GetAllPersons_EmptyList()
        {
            // Act
            List<PersonResponse> persons_from_get = await _personsService.GetAllPersons();
            Assert.Empty(persons_from_get);  
        }

        [Fact]
        public async Task GetAllPersons_AddFewPersons()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = await _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = await _countriesService.AddCountry(country_request_2);

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
                PersonResponse person_response = await _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }

            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }


            List<PersonResponse> persons_list_from_get = await _personsService.GetAllPersons();

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
        public async Task GetPersonByPersonID_NullPersonID()
        {
            Guid? personID = null;
            PersonResponse? person_response_from_get = await _personsService.GetPersonByPersonID(personID);
            Assert.Null(person_response_from_get);            
        }

        [Fact]
        public async Task GetPersonByPersonID_ProperPersonID()
        {
            // Arrange
            CountryAddRequest country_request = new()
            { CountryName = "Indonesia" };

            CountryResponse country_response = await _countriesService.AddCountry(country_request);

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

            PersonResponse person_response_from_add = await _personsService.AddPerson(person_request);

            PersonResponse? person_response_from_get = await _personsService.GetPersonByPersonID(person_response_from_add.PersonID);

            Assert.Equal(person_response_from_add, person_response_from_get);
        }
        #endregion

        #region GetFilteredPersons

        [Fact]
        public async Task GetFilteredPersons_EmptySearchText()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = await _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = await _countriesService.AddCountry(country_request_2);

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
                PersonResponse person_response = await _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }

            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }


            List<PersonResponse> persons_list_from_search = await _personsService.GetFilteredPersons(nameof(Person.PersonName), "");

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
        public async Task GetFilteredPersons_SearchByPersonName()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = await _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = await _countriesService.AddCountry(country_request_2);

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
                PersonResponse person_response = await _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }

            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }


            List<PersonResponse> persons_list_from_search = await _personsService.GetFilteredPersons(nameof(Person.PersonName), "Doe");

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

        #region GetSortedPersons

        [Fact]
        public async Task GetSortedPersons_SortByPersonName()
        {
            CountryAddRequest country_request_1 = new() { CountryName = "Canada" };
            CountryAddRequest country_request_2 = new() { CountryName = "Japan" };

            CountryResponse country_response_1 = await _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = await _countriesService.AddCountry(country_request_2);

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
                PersonResponse person_response = await _personsService.AddPerson(person);
                person_response_list_from_add.Add(person_response);
            }


            List<PersonResponse> persons_list_from_get = await _personsService.GetAllPersons();
            List<PersonResponse> persons_list_from_sort = await _personsService.GetSortedPersons(persons_list_from_get, nameof(Person.PersonName), SortOrderOptions.DESC);

            person_response_list_from_add = person_response_list_from_add.OrderByDescending(person => person.PersonName).ToList();

            for (int i = 0; i < person_response_list_from_add.Count; i++)
            {
                Assert.Equal(person_response_list_from_add[i], persons_list_from_sort[i]);
            }
           
        }

        #endregion

        #region UpdatePerson

        [Fact]
        public async Task UpdatePerson_NullPerson()
        {
            PersonUpdateRequest person_update_request = null;
        
            await Assert.ThrowsAsync<ArgumentNullException>(async () => {
                await _personsService.UpdatePerson(person_update_request);
            });
        }

        [Fact]
        public async Task UpdatePerson_InvalidPersonID()
        {
            PersonUpdateRequest person_update_request = new()
            {
                PersonID = Guid.NewGuid(),
            };

            await Assert.ThrowsAsync<ArgumentException>(async () => {
                await _personsService.UpdatePerson(person_update_request);
            });
        }

        [Fact]
        public async Task UpdatePerson_PersonNameIsNull()
        {
            CountryAddRequest country_add_request = new() { CountryName = "Etiopia" };
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response_from_add.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonResponse person_response_from_add = await _personsService.AddPerson(person_add_request);
            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();
            person_update_request.PersonName = null;


            await Assert.ThrowsAsync<ArgumentException>(async () => {
                await _personsService.UpdatePerson(person_update_request);
            });
        }

        [Fact]
        public async Task UpdatePerson_PersonFullDetails()
        {
            CountryAddRequest country_add_request = new() { CountryName = "Etiopia" };
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response_from_add.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonResponse person_response_from_add = await _personsService.AddPerson(person_add_request);
            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();
            person_update_request.PersonName = "Jimmy";
            person_update_request.Email = "jimmy.doe@mail.com";

            PersonResponse person_response_from_update = await _personsService.UpdatePerson(person_update_request);

            PersonResponse person_response_from_get = await _personsService.GetPersonByPersonID(person_response_from_update.PersonID);

            Assert.Equal(person_response_from_get, person_response_from_update);
        }
        #endregion

        #region DeletePerson

        [Fact]
        public async Task DeletePerson_InvalidPersonID()
        {
            bool isDeleted = await _personsService.DeletePerson(Guid.NewGuid());
            Assert.False(isDeleted);
        }

        [Fact]
        public async Task DeletePerson_ValidPersonID()
        {
            CountryAddRequest country_add_request = new() { CountryName = "Etiopia" };
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = new()
            {
                PersonName = "John Doe",
                Email = "john.doe@mail.com",
                CountryID = country_response_from_add.CountryID,
                Address = "John Doe Boulevar, 52",
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            PersonResponse person_add_response = await _personsService.AddPerson(person_add_request);

            bool isDeleted = await _personsService.DeletePerson(person_add_response.PersonID);
            Assert.True(isDeleted);
        }

        #endregion
    }
}
