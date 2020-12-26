using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.WebAPI.Models
{
    public class TransactionMethod
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Title must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Title must not be less that 2 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, ErrorMessage = "Description must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Description must not be less that 2 characters")]
        public string Description { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Added by is required", AllowEmptyStrings = false)]
        [ForeignKey("User")]
        public string AddedBy { get; set; }

        public ApplicationUser User { get; set; }
    }
}