using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.DTOs
{
    public class TransactionMethodToUpdate : TransactionMethodToAddDTO
    {
        public int Id { get; set; }
    }
}
