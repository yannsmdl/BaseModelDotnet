using BaseModel.Application.Queries.Tenant;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Tenant
{
    public class GetTenantByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.Tenant?>
    {
        private readonly ITenantRepository _tenantRepository;
        public GetTenantByIdQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task<Domain.Entities.Tenant?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tenantRepository.GetById(request.Id);
        }
    }
}
