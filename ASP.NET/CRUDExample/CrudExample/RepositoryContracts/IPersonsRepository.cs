using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Person entity
    /// </summary>
    public interface IPersonsRepository
    {
        /// <summary>
        /// Add new person into the data base
        /// </summary>
        /// <param name="person">Person to add</param>
        /// <returns>Returns the same person details, along with newly renerated PersonID</returns>
        Task<Person> AddPerson(Person person);

        /// <summary>
        /// Returns all existing person
        /// </summary>
        /// <returns>List of Person objects</returns>
        Task<List<Person>> GetAllPersons();

        /// <summary>
        /// Returns the person object based on the given person id
        /// </summary>
        /// <param name="personID">Person id to search</param>
        /// <returns>Returns matching person object</returns>
        Task<Person?> GetPersonByPersonID(Guid? personID);

        /// <summary>
        /// Returns all person objects based on the given expression
        /// </summary>
        /// <param name="predicate">LINQ expression to check</param>
        /// <returns>Returns all matching persons with given condition</returns>
        Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate);

        /// <summary>
        /// Updates a person object (person name and other details) based on the person id
        /// </summary>
        /// <param name="person">Person object to update</param>
        /// <returns>Returns the updated person object</returns>
        Task<Person> UpdatePerson(Person person);
       
        /// <summary>
        /// Deletes a person based on the given person ID
        /// </summary>
        /// <param name="PersonID">Person id to delete</param>
        /// <returns>Returns true if deletion is successfull</returns>
        Task<bool> DeletePerson(Guid? personID);
    }
}
