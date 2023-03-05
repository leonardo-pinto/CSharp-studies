using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Person domain model class
    /// </summary>
    public class Person
    {
        // Entity Framework Core

        [Key]
        public Guid PersonID { get; set; }

        [StringLength(40)] // nvarchar(40)
        public string? PersonName { get; set; }
        
        [StringLength(40)]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [StringLength(6)]
        public string? Gender { get; set; }
        
        // unnique identifier
        public Guid? CountryID { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }
        
        // bit
        public bool ReceiveNewsLetters { get; set; }
    
        public string? TIN { get; set; }
    }

    // Without DB
    //public class Person
    //{
    //    public Guid PersonID { get; set; }
    //    public string? PersonName { get; set; }
    //    public string? Email { get; set; }
    //    public DateTime? DateOfBirth { get; set; }
    //    public string? Gender { get; set; }
    //    public Guid? CountryID { get; set; }
    //    public string? Address { get; set; }
    //    public bool ReceiveNewsLetters { get; set; }
    //}
}
