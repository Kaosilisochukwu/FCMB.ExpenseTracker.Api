using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public TransactionType TransactionType { get; set; }
        public int TransactionTypeId { get; set; }
        public int TransactionMethodId { get; set; }
        public TransactionMethod TransactionMethod { get; set; }
        public string Descriptioin { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
