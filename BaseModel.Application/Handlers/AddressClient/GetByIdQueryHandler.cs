using BaseModel.Application.Queries.AddressClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.AddressClient
{
    public class GetAddressClientByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.AddressClient?>
    {
        private readonly IAddressClientRepository _addressClientRepository;
        public GetAddressClientByIdQueryHandler(IAddressClientRepository addressClientRepository)
        {
            _addressClientRepository = addressClientRepository;
        }
        public async Task<Domain.Entities.AddressClient?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _addressClientRepository.GetById(request.Id);
        }
    }
}
