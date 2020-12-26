using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.DTOs
{
    public class TransactionMethodToAddDTO
    {
        [Required(ErrorMessage = "Title is required", AllowEmptyStrings = false)]
        [Range(2, 20, ErrorMessage = "Title must not be less that 2 characters or greater than 20 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Range(2, 50, ErrorMessage = "Description must not be less than 2 characters and not more that 50 characters")]
        public string Description { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Added by is required", AllowEmptyStrings = false)]
        [ForeignKey("User")]
        public string AddedBy { get; set; }
    }
}
