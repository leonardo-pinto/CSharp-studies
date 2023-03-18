using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Person entity
    /// </summary>
    public interface IPersonsDeleterService
    {
        /// <summary>
        /// Deletes a person based on the given person ID
        /// </summary>
        /// <param name="PersonID">Person id to delete</param>
        /// <returns>Returns true if deletion is successfull</returns>
        Task<bool> DeletePerson(Guid? personID);
    }
}
