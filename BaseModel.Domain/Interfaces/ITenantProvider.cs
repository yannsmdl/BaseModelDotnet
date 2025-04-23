using BaseModel.Domain.Entities;

namespace BaseModel.Domain.Interfaces
{
    public interface ITenantProvider
    {
        Tenant GetCurrentTenant();
    }
}