using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BaseModel.Domain.Enums;
namespace BaseModel.Application.DTOs
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailMain { get; set; }
        public string Name { get;  set; }
        [Required(ErrorMessage = "Document is Required")]
        public string Document { get;  set; }
        [Required(ErrorMessage = "TypeClient is Required")]
        public TypeClientEnum TypeClient { get;  set; }
        public Guid? ProfessionId { get;  set; }
        public DateOnly? BirthDate { get;  set; }
        public GenderEnum? Gender { get;  set; } 
        public MatrialStatusEnum? MatrialStatus { get;  set; } 
        public string? Identity { get;  set; } 
        public string? DispatcherOrganizationIdentity { get;  set; } 
        public DateOnly? DateIssuanceIdentity { get;  set; }
        public string? FantasyName { get;  set; } 
        public string? Cnae { get;  set; } 
        public string? Crea { get;  set; } 
        public string? MunicipalRegistrationNumber { get;  set; } 
        public string? StateRegistrationNumber { get;  set; } 
        public IEnumerable<AddressClientDTO> AddressesClient { get; set; }
        public IEnumerable<EmailClientDTO> EmailsClient { get; set; }
        public IEnumerable<PhoneClientDTO> PhonesClient { get; set; }
    }
}