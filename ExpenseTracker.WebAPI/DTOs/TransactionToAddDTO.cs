using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.DTOs
{
    public class TransactionToAddDTO
    {
        [Required(ErrorMessage = "Title property is required")]
        [StringLength(20, ErrorMessage = "Title must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Title must not be less that 2 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Transaction Method Id is required")]
        [ForeignKey("TransactionMethod")]
        public int TransactionMethodId { get; set; }

        [Required(ErrorMessage = "Give a deacription for the transaction", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "Description must not be more that 50 characters")]
        [MinLength(2, ErrorMessage = "Description must not be less that 2 characters")]
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Amount for the transaction is required")]
        public decimal Amount { get; set; }
    }
}
