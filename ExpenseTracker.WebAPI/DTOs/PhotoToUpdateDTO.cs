using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.DTOs
{
    public class PhotoToUpdateDTO
    {
        [Required(ErrorMessage = "Photo Url is required")]
        public string PhotoUrl { get; set; }

        [Required(ErrorMessage = "Photo public Id is required")]
        public string PhotoPublicId { get; set; }
    }
}
