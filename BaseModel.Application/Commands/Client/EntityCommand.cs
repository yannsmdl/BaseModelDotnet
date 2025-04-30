using BaseModel.Application.DTOs;
using BaseModel.Domain.Enums;
using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.Client
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmailMain { get; set; }
        public string Name { get;  set; }
        public string Document { get;  set; }
        public TypeClientEnum TypeClient { get; private set;}

        public Guid? ProfessionId { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public GenderEnum? Gender { get; private set; } 
        public MatrialStatusEnum? MatrialStatus { get; private set; } 
        public string? Identity { get; private set; } 
        public string? DispatcherOrganizationIdentity { get; private set; } 
        public DateOnly? DateIssuanceIdentity { get; private set; }

        public string? FantasyName { get; private set; } 
        public string? Cnae { get; private set; } 
        public string? Crea { get; private set; } 
        public string? MunicipalRegistrationNumber { get; private set; } 
        public string? StateRegistrationNumber { get; private set; } 
        
        public IEnumerable<AddressClientDTO> AddressesClient { get; set; }
        public IEnumerable<EmailClientDTO> EmailsClient { get; set; }
        public IEnumerable<PhoneClientDTO> PhonesClient { get; set; }
    }
}
