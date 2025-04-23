using System.ComponentModel.DataAnnotations.Schema;
using NetDevPack.Domain;

namespace BaseModel.Domain.Entities
{
    public abstract class EntityBase : Entity, IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public Guid? UpdatedBy { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public Guid? DeletedBy { get; protected set; }
        [NotMapped]
        public virtual string Metadata { get; protected set; } = "";

        public void SetDeletion(Guid id, DateTime? deletedAt = null)
        {
            DeletedAt = deletedAt ?? DateTime.UtcNow.ToUniversalTime();
            DeletedBy = id;
        }

        public void SetAlteration(Guid id)
        {
            UpdatedAt = DateTime.UtcNow.ToUniversalTime();
            UpdatedBy = id;
        }

        public void SetCreation(Guid id)
        {
            CreatedAt = DateTime.UtcNow.ToUniversalTime();
            if(CreatedBy == null || CreatedBy == Guid.Empty){
                CreatedBy = id;
            }
        }
        public void SetCreatedBy(Guid user)
        {
            CreatedBy = user;
        }

        public void SetCreatedAt(DateTime date)
        {
            CreatedAt = date;
        }
    }
}
