using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Person entity
    /// </summary>
    public interface IPersonsSorterService
    {
        /// <summary>
        /// Returns sorted list of persons
        /// </summary>
        /// <param name="allPersons">List of persons to sort</param>
        /// <param name="sortBy">Name of the property to sort</param>
        /// <param name="sortOptions">ASC or DESC</param>
        /// <returns>Returns sorted persons as PersonResponse list</returns>
        Task<List<PersonResponse>> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOptions);
    }
}
