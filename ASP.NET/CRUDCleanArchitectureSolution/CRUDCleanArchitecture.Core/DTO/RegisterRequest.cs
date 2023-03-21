using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCleanArchitecture.Core.DTO
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Name can't be blank")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        [Remote(action:"IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email already exists")] // generate js code automaticallt
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
