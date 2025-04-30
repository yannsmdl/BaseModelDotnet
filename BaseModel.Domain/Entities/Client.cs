using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Enums;
using BaseModel.Domain.Validation;

namespace BaseModel.Domain.Entities
{
    public sealed class Client : EntityBase
    {
        public Client(
            Guid id, 
            string userId, 
            string name, 
            string document, 
            TypeClientEnum typeClient,
            Guid professionId,
            DateOnly birthDate, 
            GenderEnum gender, 
            MatrialStatusEnum matrialStatus,
            string identity,
            string dispatcherOrganizationIdentity,
            DateOnly dateIssuanceIdentity
        )
        {
            Id = id;
            UserId = userId;
            Name = name;
            Document = document;
            BirthDate = birthDate;
            TypeClient = typeClient;
            ProfessionId = professionId;
            MatrialStatus = matrialStatus;
            Gender = gender;
            Identity = identity;
            DispatcherOrganizationIdentity = dispatcherOrganizationIdentity;
            DateIssuanceIdentity = dateIssuanceIdentity;
        }
        public Client(
            Guid id, 
            string userId, 
            string name, 
            string document, 
            TypeClientEnum typeClient,
            string fantasyName,
            string cnae,
            string crea,
            string municipalRegistrationNumber,
            string stateRegistrationNumber
        )
        {
            Id = id;
            UserId = userId;
            Name = name;
            Document = document;
            TypeClient = typeClient;
            FantasyName = fantasyName;
            Cnae = cnae;
            Crea = crea;
            MunicipalRegistrationNumber = municipalRegistrationNumber;
            StateRegistrationNumber = stateRegistrationNumber;
        }
        public void Update( 
            string name, 
            string document, 
            Guid professionId,
            DateOnly birthDate, 
            GenderEnum gender, 
            MatrialStatusEnum matrialStatus,
            string identity,
            string dispatcherOrganizationIdentity,
            DateOnly dateIssuanceIdentity
        )
        {
            Name = name;
            Document = document;
            BirthDate = birthDate;
            ProfessionId = professionId;
            MatrialStatus = matrialStatus;
            Gender = gender;
            Identity = identity;
            DispatcherOrganizationIdentity = dispatcherOrganizationIdentity;
            DateIssuanceIdentity = dateIssuanceIdentity;
        }
        public void Update(
            string name, 
            string document, 
            string fantasyName,
            string cnae,
            string crea,
            string municipalRegistrationNumber,
            string stateRegistrationNumber
        )
        {
            Name = name;
            Document = document;
            FantasyName = fantasyName;
            Cnae = cnae;
            Crea = crea;
            MunicipalRegistrationNumber = municipalRegistrationNumber;
            StateRegistrationNumber = stateRegistrationNumber;
        }
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public TypeClientEnum TypeClient { get; private set; }
        // Data PF
        public Guid? ProfessionId { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public GenderEnum? Gender { get; private set; } 
        public MatrialStatusEnum? MatrialStatus { get; private set; } 
        public string? Identity { get; private set; } 
        public string? DispatcherOrganizationIdentity { get; private set; } 
        public DateOnly? DateIssuanceIdentity { get; private set; }
        // Data PJ
        public string? FantasyName { get; private set; } 
        public string? Cnae { get; private set; } 
        public string? Crea { get; private set; } 
        public string? MunicipalRegistrationNumber { get; private set; } 
        public string? StateRegistrationNumber { get; private set; } 
    }
}