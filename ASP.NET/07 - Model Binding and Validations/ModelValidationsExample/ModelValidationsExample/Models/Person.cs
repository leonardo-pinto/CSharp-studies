﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.CustomValidators;

namespace ModelValidationsExample.Models
{
    public class Person : IValidatableObject
    {
        // Model validation
        // may be configured using the ErrorMessage attribute
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        //[RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot(.)")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        public string? Email { get; set; }
       
        public string? Phone { get; set; }
        //[Range(0, 120, ErrorMessage = "{0} should be between {1} and {2}")]
        //public int Age { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} don't match")]
        [Display(Name = "Password confirmation")]
        public string? ConfirmPassword { get; set; }

        // Example custom validation
        [Required]
        [MinimumYearValidator(1995, ErrorMessage = "Date of birth should be less than {0}")]
        // ignores this property for model binding
        [BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }




        public override string ToString()
        {
            return $"Person name: {PersonName}, Email: {Email}, Phone: {Phone}";
        }

        // used when you want specific custom validation
        // which sould not be re-utilized
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either date of birth or age must be supplied", new[] { nameof(Age) });
            }

            // allows multiple return validations
            // only when using "yield" keyboard
            // which converts to a IEnumerable
            // only executes when all validations passes
        }
    }
}