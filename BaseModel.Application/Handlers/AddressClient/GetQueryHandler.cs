using BaseModel.Application.Queries.AddressClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.AddressClients
{
    public class GetAddressClientsQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.AddressClient>>
    {
        private readonly IAddressClientRepository _addressClientRepository;
        public GetAddressClientsQueryHandler(IAddressClientRepository addressClientRepository)
        {
            _addressClientRepository = addressClientRepository;
        }

        public async Task<IEnumerable<Domain.Entities.AddressClient>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _addressClientRepository.GetAll();
        }
    }
}
