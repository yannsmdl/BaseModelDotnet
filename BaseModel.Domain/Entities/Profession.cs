using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Validation;

namespace BaseModel.Domain.Entities
{
    public sealed class Profession : EntityBase
    {
        public Profession(Guid id, string name)
        {
            DomainExpectionValidation.When(id == Guid.Empty || id == null, "Id is required");
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");

            Id = id;
            Name = name;
        }
        public void Update(string name)
        {
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");

            Name = name;
        }

        public string Name { get; private set; }
    }
}