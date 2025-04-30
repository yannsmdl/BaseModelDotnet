using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BaseModel.Application.DTOs
{
    public class AddressClientDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Complement is required")]
        public string Complement { get; set; }
        [Required(ErrorMessage = "Neighborhood is required")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public string Number { get; set; }

        [Required(ErrorMessage = "CityId is required")]
        public Guid CityId { get; set; }
        [Required(ErrorMessage = "ClientId is required")]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "ZipCode is required")]
        public string ZipCode { get; set; }
    }
}