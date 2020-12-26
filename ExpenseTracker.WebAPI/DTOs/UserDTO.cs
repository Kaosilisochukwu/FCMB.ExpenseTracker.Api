using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.DTOs
{
    public class UserDTO : UserToRegisterDTO
    {
        public string Id { get; set; }
    }
}
