using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Validation;

namespace BaseModel.Domain.Entities
{
    public sealed class State : EntityBase
    {
        public State(Guid id, string name, string initials)
        {
            DomainExpectionValidation.When(id == Guid.Empty || id == null, "Id is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(initials), "Initials is required");

            Id = id;
            Name = name;
            Initials = initials;
        }
        public void Update(string name, string initials)
        {
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(initials), "Initials is required");

            Name = name;
            Initials = initials;
        }

        public string Name { get; private set; }
        public string Initials { get; private set; }
    }
}