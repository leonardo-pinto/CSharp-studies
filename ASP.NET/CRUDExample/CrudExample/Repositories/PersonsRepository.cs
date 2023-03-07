using Entities;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        public Task<Person> AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePerson(Guid? personID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetPersonByPersonID(Guid? personID)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}