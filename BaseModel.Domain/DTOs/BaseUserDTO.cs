namespace BaseModel.Domain.DTOs
{
    public class BaseUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public Guid TenantId { get; set; }
    }
}