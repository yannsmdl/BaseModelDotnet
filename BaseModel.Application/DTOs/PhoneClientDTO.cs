using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BaseModel.Application.DTOs
{
    public class PhoneClientDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }
        [Required(ErrorMessage = "ClientId is required")]
        public Guid ClientId { get; set; }
        public bool Main { get; set; }

    }
}