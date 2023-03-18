using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Person entity
    /// </summary>
    public interface IPersonsGetterService
    {
        /// <summary>
        /// Returns all existing person
        /// </summary>
        /// <returns>List of PersonResponse</returns>
        Task<List<PersonResponse>> GetAllPersons();

        /// <summary>
        /// Returns the person object based on the given person id
        /// </summary>
        /// <param name="personID">Person id to search</param>
        /// <returns>Returns matching person object</returns>
        Task<PersonResponse?> GetPersonByPersonID(Guid? personID);

        /// <summary>
        /// Returns all person objects that matches with the given search field and search string
        /// </summary>
        /// <param name="searchBy">Search field</param>
        /// <param name="searchString">Search string</param>
        /// <returns>Returns all matching persons based on the given search field and string</returns>
        Task<List<PersonResponse>> GetFilteredPersons(string searchBy, string? searchString);
    }
}
