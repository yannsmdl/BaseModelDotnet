using BaseModel.Application.Queries.Tenant;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Tenants
{
    public class GetTenantsQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.Tenant>>
    {
        private readonly ITenantRepository _tenantRepository;
        public GetTenantsQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Tenant>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _tenantRepository.GetAll();
        }
    }
}
