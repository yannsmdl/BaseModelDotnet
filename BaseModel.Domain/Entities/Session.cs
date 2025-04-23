
namespace BaseModel.Domain.Entities
{
    public sealed class Session : EntityBase
    {
        public Session(Guid id, string userId, string token, DateTime? revokedAt = null)
        {
            Id = id;
            UserId = userId;
            Token = token;
            RevokedAt = revokedAt;
        }
        public void Revoke() => RevokedAt = DateTime.UtcNow;
        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public string UserId { get; private set; }
        public DateTime? RevokedAt { get; private set; }
    }
}