﻿using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.WebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "First Name must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "First Name must not be less that 2 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Last Name must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Last Name must not be less that 2 characters")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Address is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Address must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Address must not be less that 2 characters")]
        public string Address { get; set; }

        [Required (ErrorMessage = "City is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "City must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "City must not be less that 2 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "State must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "State must not be less that 2 characters")]
        public string State { get; set; }

        [Required (ErrorMessage = "Occupation is Required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Occupation must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Occupation must not be less that 2 characters")]
        public string Occupation { get; set; }

        [Required (ErrorMessage = "Company is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Company must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Company must not be less that 2 characters")]
        public string Company { get; set; }

       
        [StringLength(100)]
        public string PhotoUrl { get; set; }

        [StringLength(20)]
        public string PhotoPublicId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
