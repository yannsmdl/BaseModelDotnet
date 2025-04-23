using BaseModel.Domain.Validation;

namespace BaseModel.Domain.Entities
{
    public sealed class Category : EntityBase
    {

        private void ValidationDomain(string name)
        {
            DomainExpectionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
            DomainExpectionValidation.When(name.Length < 3, "Name too short, minimal 3 charecteres");
            Name = name;
        }

        public void Update(string name)
        {
            ValidationDomain(name);
        }

        public Category(Guid id, string name)
        {
            DomainExpectionValidation.When(id == Guid.Empty || id == null, "Id is required");
            ValidationDomain(name);
            Id = id;
        }

        public string Name { get; private set; }
    }
}
