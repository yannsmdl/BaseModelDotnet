using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Tenant
{
    public class GetByTenantUrlQuery : IRequest<Domain.Entities.Tenant>
    {
        public string TenantUrl { get; set; }
        public GetByTenantUrlQuery(string tenantUrl)
        {
            TenantUrl = tenantUrl;
        }
    }
}
