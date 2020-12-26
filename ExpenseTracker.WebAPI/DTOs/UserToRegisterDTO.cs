using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.DTOs
{
    public class UserToRegisterDTO
    {
        [Required(ErrorMessage = "First Name is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "First Name must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "First Name must not be less that 2 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Last Name must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Last Name must not be less that 2 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Address must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Address must not be less that 2 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email must be a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "City is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "City must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "City must not be less that 2 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "State must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "State must not be less that 2 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Occupation is Required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Occupation must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Occupation must not be less that 2 characters")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Company is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Company must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Company must not be less that 2 characters")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Username is Required", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username must contain only letters and numbers")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="this field is Required")]
        [Compare("Password", ErrorMessage = "This field must match the password field")]
        public string ConfirmPassword { get; set; }


        public string PhotoUrl { get; set; }

        public string PhotoPublicId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
