using System;

namespace ExpenseTracker.WebAPI.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}