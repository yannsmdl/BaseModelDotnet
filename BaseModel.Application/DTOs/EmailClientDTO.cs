using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BaseModel.Application.DTOs
{
    public class EmailClientDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ClientId is required")]
        public Guid ClientId { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public bool Main { get; set; }

    }
}