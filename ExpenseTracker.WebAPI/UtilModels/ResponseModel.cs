using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Models
{
    public class ResponseModel
    {
        public ResponseModel(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public int Status { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
