using BaseModel.Application.Queries.Tenant;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Tenant
{
    public class GetByTenantUrlQueryHandler : IRequestHandler<GetByTenantUrlQuery, Domain.Entities.Tenant?>
    {
        private readonly ITenantRepository _tenantRepository;
        public GetByTenantUrlQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task<Domain.Entities.Tenant?> Handle(GetByTenantUrlQuery request, CancellationToken cancellationToken)
        {
            return await _tenantRepository.GetByTenantUrl(request.TenantUrl);
        }
    }
}
