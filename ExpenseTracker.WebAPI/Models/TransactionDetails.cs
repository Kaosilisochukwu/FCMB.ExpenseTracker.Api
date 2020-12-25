using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Models
{
    public class TransactionDetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Range(2, 50, ErrorMessage = "Description must not be less than 2 characters and not more that 50 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Title is required", AllowEmptyStrings = false)]
        public string Title { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Added by is required", AllowEmptyStrings = false)]
        [ForeignKey("User")]
        public string AddedBy { get; set; }

        public ApplicationUser User { get; set; }
    }
}
