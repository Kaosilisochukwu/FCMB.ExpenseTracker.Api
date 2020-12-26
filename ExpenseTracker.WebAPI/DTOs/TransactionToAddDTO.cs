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
        [Range(2, 20, ErrorMessage = "Title must not be less that 2 characters or greater than 20 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Transaction Method Id is required")]
        [ForeignKey("TransactionMethod")]
        public int TransactionMethodId { get; set; }

        [Required(ErrorMessage = "Give a deacription for the transaction", AllowEmptyStrings = false)]
        [Range(2, 50, ErrorMessage = "Description must not be less than 2 characters and not more that 50 characters")]
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Amount for the transaction is required")]
        public decimal Amount { get; set; }
    }
}
