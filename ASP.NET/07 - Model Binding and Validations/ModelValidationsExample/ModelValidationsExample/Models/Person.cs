using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person
    {
        // Model validation
        [Required]
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public override string ToString()
        {
            return $"Person name: {PersonName}, Email: {Email}, Phone: {Phone}";
        }
    }
}
