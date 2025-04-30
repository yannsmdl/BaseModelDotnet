using BaseModel.Application.Queries.AddressClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.AddressClient
{
    public class GetByClientIdQueryHandler : IRequestHandler<GetByClientIdQuery, IEnumerable<Domain.Entities.AddressClient>>
    {
        private readonly IAddressClientRepository _addressClientRepository;
        public GetByClientIdQueryHandler(IAddressClientRepository addressClientRepository)
        {
            _addressClientRepository = addressClientRepository;
        }
        public async Task<IEnumerable<Domain.Entities.AddressClient>> Handle(GetByClientIdQuery request, CancellationToken cancellationToken)
        {
            return await _addressClientRepository.GetByClientId(request.ClientId);
        }
    }
}
