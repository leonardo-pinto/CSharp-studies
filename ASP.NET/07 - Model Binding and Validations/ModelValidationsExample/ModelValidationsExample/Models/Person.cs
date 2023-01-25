using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person
    {
        // Model validation
        // may be configured using the ErrorMessage attribute
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Range(0, 120, ErrorMessage = "{0} should be between {1} and {2}")]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Person name: {PersonName}, Email: {Email}, Phone: {Phone}";
        }
    }
}
