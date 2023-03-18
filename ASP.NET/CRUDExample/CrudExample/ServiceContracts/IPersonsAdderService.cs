using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Person entity
    /// </summary>
    public interface IPersonsAdderService
    {
        /// <summary>
        /// Add new person into the list of person
        /// </summary>
        /// <param name="personAddRequest">Person to add</param>
        /// <returns>Returns the same person details, along with newly renerated PersonID</returns>
        Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest);
    }
}
