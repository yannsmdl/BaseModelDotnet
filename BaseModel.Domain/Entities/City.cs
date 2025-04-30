using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Validation;

namespace BaseModel.Domain.Entities
{
    public sealed class City : EntityBase
    {
        public City(Guid id, string name, string ibgeId, Guid stateId)
        {
            DomainExpectionValidation.When(id == Guid.Empty || id == null, "Id is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
            DomainExpectionValidation.When(stateId == Guid.Empty || stateId == null, "StateId is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(ibgeId), "IbgeId is required");

            Id = id;
            Name = name;
            StateId = stateId;
            IbgeId = ibgeId;
        }
        public void Update(string name, string ibgeId, Guid stateId)
        {
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
            DomainExpectionValidation.When(stateId == Guid.Empty || stateId == null, "StateId is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(ibgeId), "IbgeId is required");

            Name = name;
            StateId = stateId;
            IbgeId = ibgeId;
        }

        public string Name { get; private set; }
        public string IbgeId { get; private set; }
        public Guid StateId { get; private set; } 
        public State State { get; private set; }
    }
}