using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;

namespace BaseModel.Infra.Data.Services
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationDbContext _authDb;

        public TenantProvider(IHttpContextAccessor httpContextAccessor, AuthenticationDbContext authDb)
        {
            _httpContextAccessor = httpContextAccessor;
            _authDb = authDb;
        }

        public Tenant GetCurrentTenant()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            var tenantUrl = request?.Headers["X-Tenant-Url"].FirstOrDefault();

            if (string.IsNullOrEmpty(tenantUrl))
                throw new Exception("Tenant URL header not found");

            var tenant = _authDb.Tenants.FirstOrDefault(t => t.TenantUrl == tenantUrl);
            if (tenant == null)
                throw new Exception("Tenant not found");

            return tenant;
        }
    }
}