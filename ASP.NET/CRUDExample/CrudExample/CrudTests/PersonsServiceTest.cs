using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;

namespace CrudTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonsService _personsService;
    
        public PersonsServiceTest()
        {
            _personsService = new PersonsService();
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
    }
}
