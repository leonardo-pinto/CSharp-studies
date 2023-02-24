using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services.Helpers;
using ServiceContracts.Enums;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;

        public PersonsService(bool initialize = true)
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        
            if (initialize)
            {
                _persons.Add(
                    new Person()
                    {
                        PersonID = Guid.Parse("903CC86A-1DE5-48A8-911B-0DB06D48D82E"),
                        PersonName = "Chuco",
                        Email = "chuco@mail.com",
                        DateOfBirth = DateTime.Parse("1993-08-13"),
                        Gender = GenderOptions.Male.ToString(),
                        CountryID = Guid.Parse("58907889-5F10-43DA-9CD8-000BCDD4E073"),
                        Address = "Rainbow Avenue, 432",
                        ReceiveNewsLetters = true,
                    }
                );
                _persons.Add(
                   new Person()
                   {
                       PersonID = Guid.Parse("0305A650-CD28-4462-AEB0-6FCD0B486097"),
                       PersonName = "John Doe",
                       Email = "johndoe@mail.com",
                       DateOfBirth = DateTime.Parse("1995-02-11"),
                       Gender = GenderOptions.Male.ToString(),
                       CountryID = Guid.Parse("72BBA61E-AA93-4721-A46D-7DE894F48CF5"),
                       Address = "Ellesmere Avenue, 432",
                       ReceiveNewsLetters = true,
                   }
               );
                _persons.Add(
                   new Person()
                   {
                       PersonID = Guid.Parse("2D82CD45-1C6C-4BD2-989E-FA3B4D0B70C3"),
                       PersonName = "Jane Doe",
                       Email = "jane@mail.com",
                       DateOfBirth = DateTime.Parse("1999-11-15"),
                       Gender = GenderOptions.Female.ToString(),
                       CountryID = Guid.Parse("3CA2F22E-B6A9-4D60-BDBF-8FAEE2515599"),
                       Address = "Danford Road, 15",
                       ReceiveNewsLetters = false,
                   }
               );


                // {903CC86A-1DE5-48A8-911B-0DB06D48D82E}
                // {0305A650-CD28-4462-AEB0-6FCD0B486097}
                // {2D82CD45-1C6C-4BD2-989E-FA3B4D0B70C3}
            }
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;
            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            // Using model validations
            ValidationHelper.ModelValidation(personAddRequest);

            Person person = personAddRequest.ToPerson();
            person.PersonID = Guid.NewGuid();

            _persons.Add(person);

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(person => person.ToPersonResponse()).ToList();
        }

        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
            {
                return null;
            }

            Person? person = _persons.FirstOrDefault(person => person.PersonID == personID);

            if (person == null)
            {
                return null;
            }

            return person.ToPersonResponse();
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
            {
                return matchingPersons;
            }

            switch (searchBy)
            {
                case nameof(Person.PersonName):
                    matchingPersons = allPersons.Where(person =>
                        (!string.IsNullOrEmpty(person.PersonName) ?
                        person.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true)).ToList();
                    break;
                case nameof(Person.Email):
                    matchingPersons = allPersons.Where(person =>
                        (!string.IsNullOrEmpty(person.Email) ?
                        person.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true)).ToList();
                    break;
                case nameof(Person.DateOfBirth):
                    matchingPersons = allPersons.Where(person =>
                        (person.DateOfBirth != null) ?
                        person.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true).ToList();
                    break;
                case nameof(Person.Gender):
                    matchingPersons = allPersons.Where(person =>
                        (!string.IsNullOrEmpty(person.Gender) ?
                        person.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true)).ToList();
                    break;
                case nameof(Person.Address):
                    matchingPersons = allPersons.Where(person =>
                        (!string.IsNullOrEmpty(person.Address) ?
                        person.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                        : true)).ToList();
                    break;
                default:
                    matchingPersons = allPersons;
                    break;
            }

            return matchingPersons;
        }


        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOptions)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return allPersons;
            }

            List<PersonResponse> sortedPersons = (sortBy, sortOptions)
            switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC)
                => allPersons.OrderBy(person => person.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(person => person.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Email), SortOrderOptions.ASC)
                => allPersons.OrderBy(person => person.Email, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.Email), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(person => person.Email, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC)
                => allPersons.OrderBy(person => person.DateOfBirth).ToList(),
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(person => person.DateOfBirth).ToList(),
                (nameof(PersonResponse.Age), SortOrderOptions.ASC)
                => allPersons.OrderBy(person => person.Age).ToList(),
                (nameof(PersonResponse.Age), SortOrderOptions.DESC)
                => allPersons.OrderByDescending(person => person.Age).ToList(),
                _ => allPersons
            };

            return sortedPersons;
        }

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(personUpdateRequest));
            }

            ValidationHelper.ModelValidation(personUpdateRequest);

            Person? matchingPerson = _persons.FirstOrDefault(person => person.PersonID == personUpdateRequest.PersonID);
            if (matchingPerson == null)
            {
                throw new ArgumentException("Given person id does not exist");
            }

            matchingPerson.PersonName = personUpdateRequest?.PersonName;
            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;
            matchingPerson.CountryID = personUpdateRequest.CountryID;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();

            return matchingPerson.ToPersonResponse();
        }

        public bool DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }
            Person? person = _persons.FirstOrDefault(person => person.PersonID == personID);
            
            if (person == null)
            {
                return false;
            }

            _persons.RemoveAll(person => person.PersonID == personID);
            return true;
        }
    }
}
