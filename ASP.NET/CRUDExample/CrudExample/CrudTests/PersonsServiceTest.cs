using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Entities;
using ServiceContracts.Enums;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;
using AutoFixture;
using FluentAssertions;
using Moq;
using System.Linq.Expressions;

namespace CrudTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;
        private readonly IPersonsRepository _personsRepository;
        private readonly Mock<IPersonsRepository> _personsRepositoryMock;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IFixture _fixture;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _fixture = new Fixture();
            // create mock instance
            _personsRepositoryMock = new Mock<IPersonsRepository>();
            _personsRepository = _personsRepositoryMock.Object;

            var countriesInitialData = new List<Country>();
            var personsInitialData = new List<Person>();
            DbContextMock<ApplicationDbContext> dbContextMock = new(
                new DbContextOptionsBuilder<ApplicationDbContext>().Options
            );

            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Countries, countriesInitialData);
            dbContextMock.CreateDbSetMock(temp => temp.Persons, personsInitialData);

            _countriesService = new CountriesService(null);
            _personsService = new PersonsService(_personsRepository);
        }

        #region AddPerson
        [Fact]
        public async Task AddPerson_NullPerson_ToBeArgumentNullException()
        {
            // Arrange
            PersonAddRequest? personAddRequest = null;

            // Assert
            // Act
            // Without FluentAssertions
            //await Assert.ThrowsAsync<ArgumentNullException>(async () => {
            //    await _personsService.AddPerson(personAddRequest);
            //});

            // Using Fluent Assertion
            Func<Task> action = async () =>
            {
                await _personsService.AddPerson(personAddRequest);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddPerson_PersonNameNull_ToBeArgumentException()
        {
            // Arrange
            PersonAddRequest? personAddRequest = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.PersonName, null as string)
                .Create();

            // Assert
            // Act
            //await Assert.ThrowsAsync<ArgumentException>(async () => {
            //    await _personsService.AddPerson(personAddRequest);
            //});

            Func<Task> action = async () =>
            {
                await _personsService.AddPerson(personAddRequest);
            };

            await action.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task AddPerson_FullPersonDetails_ToBeSuccessful()
        {
            // using AutoFixture
            // Creates with all default properties
            //PersonAddRequest? personAddRequest = _fixture.Create<PersonAddRequest>();
            // Build.With to customize specific properties
            PersonAddRequest? personAddRequest = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.Email, "mail@mail.com")
                .Create();

            // convert request into person to be used in mock
            Person person = personAddRequest.ToPerson();

            // create expected response
            PersonResponse person_response_expected = person.ToPersonResponse();

            // if we supply any argument value to the method
            // it should return the same value
            _personsRepositoryMock
                .Setup(temp => temp.AddPerson(It.IsAny<Person>()))
                .ReturnsAsync(person);

            // Arrange
            //PersonAddRequest? personAddRequest = new()
            //{ 
            //    PersonName = "John Doe",
            //    Email = "john.doe@mail.com",
            //    CountryID = Guid.NewGuid(),
            //    Address = "John Doe Boulevar, 52",
            //    Gender = GenderOptions.Male,
            //    DateOfBirth = DateTime.Parse("2000-01-01"),
            //    ReceiveNewsLetters = true
            //};

            // Act
            PersonResponse person_response_from_add = await _personsService.AddPerson(personAddRequest);
            //List<PersonResponse> persons_list = await _personsService.GetAllPersons();

            person_response_expected.PersonID = person_response_from_add.PersonID;

            // Assert
            //Assert.True(person_response_from_add.PersonID != Guid.Empty);
            person_response_from_add.PersonID.Should().NotBe(Guid.Empty);

            //Assert.Contains(person_response_from_add, persons_list);
            //persons_list.Should().Contain(person_response_from_add);

            person_response_from_add.Should().Be(person_response_expected);
        }

        #endregion

        #region GetAllPersons

        [Fact]
        public async Task GetAllPersons_EmptyList_ToBeEmpty()
        {
            // Arrange
            _personsRepositoryMock
                .Setup(temp => temp.GetAllPersons())
                .ReturnsAsync(new List<Person>());

            // Act
            List<PersonResponse> persons_from_get = await _personsService.GetAllPersons();
            persons_from_get.Should().BeEmpty();
            //Assert.Empty(persons_from_get);  
        }

        [Fact]
        public async Task GetAllPersons_WithFewPersons_ToBeSuccessful()
        {
            // Arrange
            List<Person> persons = new()
            {
                _fixture.Build<Person>()
                 .With(temp => temp.Email, "any_mail1@mail.com")
                 .With(temp => temp.Country, null as Country) // null to avoid circular dependence
                 .Create(),

                _fixture.Build<Person>()
                 .With(temp => temp.Email, "any_mail2@mail.com")
                 .With(temp => temp.Country, null as Country) // null to avoid circular dependence
                 .Create()

             };

            List<PersonResponse> person_response_list_expected = persons.Select(person => person.ToPersonResponse()).ToList();

            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_expected)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            _personsRepositoryMock.Setup(item => item.GetAllPersons()).ReturnsAsync(persons);

            List<PersonResponse> persons_list_from_get = await _personsService.GetAllPersons();

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse person_response_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            persons_list_from_get.Should().BeEquivalentTo(person_response_list_expected);
        }

        #endregion

        #region GetPersonByPersonID
        [Fact]
        public async Task GetPersonByPersonID_NullPersonID_ToBeNull()
        {
            Guid? personID = null;
            PersonResponse? person_response_from_get = await _personsService.GetPersonByPersonID(personID);
            Assert.Null(person_response_from_get);
            person_response_from_get.Should().BeNull();
        }

        [Fact]
        public async Task GetPersonByPersonID_WithPersonID_ToBeSuccessful()
        {
            // Arrange
            Person person = _fixture.Build<Person>()
                .With(temp => temp.Email, "mail@mail.com")
                .With(temp => temp.Country, null as Country)
                .Create();
            PersonResponse person_response_expected = person.ToPersonResponse();

            _personsRepositoryMock
                .Setup(temp => temp.GetPersonByPersonID(It.IsAny<Guid>()))
                .ReturnsAsync(person);

            PersonResponse? person_response_from_get = await _personsService.GetPersonByPersonID(person.PersonID);

            //Assert.Equal(person_response_from_add, person_response_from_get);
            person_response_from_get.Should().Be(person_response_expected);
        }
        #endregion

        #region GetFilteredPersons

        [Fact]
        public async Task GetFilteredPersons_EmptySearchText_ToBeSuccessful()
        {
            // Arrange
            List<Person> persons = new()
            {
               _fixture.Build<Person>()
                .With(temp => temp.Email, "any_mail1@mail.com")
                .With(temp => temp.Country, null as Country) // null to avoid circular dependence
                .Create(),

               _fixture.Build<Person>()
                .With(temp => temp.Email, "any_mail2@mail.com")
                .With(temp => temp.Country, null as Country) // null to avoid circular dependence
                .Create()

            };

            List<PersonResponse> person_response_list_expected = persons.Select(person => person.ToPersonResponse()).ToList();


            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_expected)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            _personsRepositoryMock
                .Setup(temp => temp.GetFilteredPersons(It.IsAny<Expression<Func<Person, bool>>>()))
                .ReturnsAsync(persons);

            List<PersonResponse> persons_list_from_search = await _personsService.GetFilteredPersons(nameof(Person.PersonName), "");

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse person_response_from_get in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            //foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            //{
            //    Assert.Contains(person_response_from_add, persons_list_from_search);
            //}

            persons_list_from_search.Should().BeEquivalentTo(person_response_list_expected);
        }

        [Fact]
        public async Task GetFilteredPersons_SearchByPersonName_ToBeSuccesful()
        {
            // Arrange
            List<Person> persons = new()
            {
               _fixture.Build<Person>()
                .With(temp => temp.PersonName, "John Doe")
                .With(temp => temp.Email, "any_mail1@mail.com")
                .With(temp => temp.Country, null as Country) // null to avoid circular dependence
                .Create(),

               _fixture.Build<Person>()
                .With(temp => temp.Email, "any_mail2@mail.com")
                .With(temp => temp.Country, null as Country) // null to avoid circular dependence
                .Create()

            };

            List<PersonResponse> person_response_list_expected = persons.Select(person => person.ToPersonResponse()).ToList();


            // print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected: ");
            foreach (PersonResponse person_response_from_add in person_response_list_expected)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            _personsRepositoryMock
                .Setup(temp => temp.GetFilteredPersons(It.IsAny<Expression<Func<Person, bool>>>()))
                .ReturnsAsync(persons);

            List<PersonResponse> persons_list_from_search = await _personsService.GetFilteredPersons(nameof(Person.PersonName), "oe");

            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse person_response_from_get in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            //foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            //{
            //    Assert.Contains(person_response_from_add, persons_list_from_search);
            //}

            persons_list_from_search.Should().BeEquivalentTo(person_response_list_expected);
        }

        #endregion

        #region GetSortedPersons

        [Fact]
        public async Task GetSortedPersons_SortByPersonName()
        {
            CountryAddRequest country_request_1 = _fixture.Create<CountryAddRequest>();
            CountryAddRequest country_request_2 = _fixture.Create<CountryAddRequest>();

            CountryResponse country_response_1 = await _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = await _countriesService.AddCountry(country_request_2);

            PersonAddRequest? person_request_1 = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.PersonName, "John Doe")
                .With(temp => temp.Email, "someone_1@mail.com")
                .With(temp => temp.CountryID, country_response_1.CountryID)
                .Create();

            PersonAddRequest? person_request_2 = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.PersonName, "Jane Doe")
                .With(temp => temp.Email, "someone_2@mail.com")
                .With(temp => temp.CountryID, country_response_2.CountryID)
                .Create();

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

            //person_response_list_from_add = person_response_list_from_add.OrderByDescending(person => person.PersonName).ToList();

            //for (int i = 0; i < person_response_list_from_add.Count; i++)
            //{
            //    Assert.Equal(person_response_list_from_add[i], persons_list_from_sort[i]);
            //}

            persons_list_from_sort.Should().BeInDescendingOrder(temp => temp.PersonName);

        }

        #endregion

        #region UpdatePerson

        [Fact]
        public async Task UpdatePerson_NullPerson()
        {
            PersonUpdateRequest person_update_request = null;

            Func<Task> action = async () =>
            {
                await _personsService.UpdatePerson(person_update_request);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();


            //await Assert.ThrowsAsync<ArgumentNullException>(async () => {
            //    await _personsService.UpdatePerson(person_update_request);
            //});
        }

        [Fact]
        public async Task UpdatePerson_InvalidPersonID()
        {
            PersonUpdateRequest person_update_request = _fixture.Build<PersonUpdateRequest>().Create();

            Func<Task> action = async () =>
            {
                await _personsService.UpdatePerson(person_update_request);
            };

            await action.Should().ThrowAsync<ArgumentException>();

            //await Assert.ThrowsAsync<ArgumentException>(async () => {
            //    await _personsService.UpdatePerson(person_update_request);
            //});
        }

        [Fact]
        public async Task UpdatePerson_PersonNameIsNull()
        {
            CountryAddRequest country_add_request = _fixture.Create<CountryAddRequest>();
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.Email, "someone_1@mail.com")
                .With(temp => temp.CountryID, country_response_from_add.CountryID)
                .Create();

            PersonResponse person_response_from_add = await _personsService.AddPerson(person_add_request);
            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();
            person_update_request.PersonName = null;

            Func<Task> action = async () =>
            {
                await _personsService.UpdatePerson(person_update_request);
            };

            await action.Should().ThrowAsync<ArgumentException>();

            //await Assert.ThrowsAsync<ArgumentException>(async () => {
            //    await _personsService.UpdatePerson(person_update_request);
            //});
        }

        [Fact]
        public async Task UpdatePerson_PersonFullDetails()
        {
            CountryAddRequest country_add_request = _fixture.Create<CountryAddRequest>();
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.Email, "someone_1@mail.com")
                .With(temp => temp.CountryID, country_response_from_add.CountryID)
                .Create();

            PersonResponse person_response_from_add = await _personsService.AddPerson(person_add_request);
            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();
            person_update_request.PersonName = "Jimmy";
            person_update_request.Email = "jimmy.doe@mail.com";

            PersonResponse person_response_from_update = await _personsService.UpdatePerson(person_update_request);

            PersonResponse person_response_from_get = await _personsService.GetPersonByPersonID(person_response_from_update.PersonID);

            person_response_from_update.Should().Be(person_response_from_get);

            //Assert.Equal(person_response_from_get, person_response_from_update);
        }
        #endregion

        #region DeletePerson

        [Fact]
        public async Task DeletePerson_InvalidPersonID()
        {
            bool isDeleted = await _personsService.DeletePerson(Guid.NewGuid());

            isDeleted.Should().BeFalse();
            //Assert.False(isDeleted);
        }

        [Fact]
        public async Task DeletePerson_ValidPersonID()
        {
            CountryAddRequest country_add_request = _fixture.Create<CountryAddRequest>();
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.Email, "someone_1@mail.com")
                .With(temp => temp.CountryID, country_response_from_add.CountryID)
                .Create();

            PersonResponse person_add_response = await _personsService.AddPerson(person_add_request);

            bool isDeleted = await _personsService.DeletePerson(person_add_response.PersonID);
            isDeleted.Should().BeTrue();
            //Assert.True(isDeleted);
        }

        #endregion
    }
}
