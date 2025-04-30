
namespace BaseModel.Domain.Entities
{
    public sealed class Session : EntityBase
    {
        public Session(Guid id, string userId, string token, Guid tenantId, DateTime? revokedAt = null)
        {
            Id = id;
            UserId = userId;
            Token = token;
            TenantId = tenantId;
            RevokedAt = revokedAt;
        }
        public void Revoke() => RevokedAt = DateTime.UtcNow;
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; private set; }
        public string Token { get; private set; }
        public string UserId { get; private set; }
        public DateTime? RevokedAt { get; private set; }
    }
}