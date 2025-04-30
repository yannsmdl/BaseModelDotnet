using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Validation;

namespace BaseModel.Domain.Entities
{
    public sealed class AddressClient : EntityBase
    {
        public AddressClient(Guid id, string street, string number, string complement, string neighborhood, Guid cityId, string zipCode, Guid clientId)
        {
            DomainExpectionValidation.When(id == Guid.Empty || id == null, "Id is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(street), "Street is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(number), "Number is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(neighborhood), "Neighborhood is required");
            DomainExpectionValidation.When(cityId == Guid.Empty || cityId == null, "cityId is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(zipCode), "ZipCode is required");
            DomainExpectionValidation.When(clientId == Guid.Empty || clientId == null, "ClientId is required");

            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            CityId = cityId;
            ZipCode = zipCode;
            ClientId = clientId;
        }
        public void Update(string street, string number, string complement, string neighborhood, Guid cityId, string zipCode)
        {
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(street), "Street is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(number), "Number is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(neighborhood), "Neighborhood is required");
            DomainExpectionValidation.When(cityId == Guid.Empty || cityId == null, "cityId is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(zipCode), "ZipCode is required");

            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            CityId = cityId;
            ZipCode = zipCode;
        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public Guid CityId { get; private set; }
        public string ZipCode { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        
    }
}