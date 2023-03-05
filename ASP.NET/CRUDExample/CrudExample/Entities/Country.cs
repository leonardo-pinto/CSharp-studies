using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain Model for country details
    /// </summary>
    public class Country
    {
        // Entity Framework Core
        [Key] // Primary key
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

        // if you want to access all persons based on the country id
        //public virtual ICollection<Person>? Persons { get; set; }
    }

    // Without DB
    //public class Country
    //{
    //    public Guid CountryID { get; set; }
    //    public string? CountryName { get; set; }
    //}
}

