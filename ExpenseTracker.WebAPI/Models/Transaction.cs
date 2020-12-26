using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.WebAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title property is required")]
        [StringLength(50, ErrorMessage = "Title must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Title must not be less that 2 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Transaction Method Id is required")]
        [ForeignKey("TransactionMethod")]
        public int TransactionMethodId { get; set; }
        public TransactionMethod TransactionMethod { get; set; }

        [Required(ErrorMessage = "Give a deacription for the transaction", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Description must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Description must not be less that 2 characters")]
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="Amount for the transaction is required")]
        public decimal Amount { get; set; }
    }
}
