using BaseModel.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BaseModel.Infra.Data.Identity
{
    public class BaseUser : IdentityUser
    {
        public Guid? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
