using BaseModel.Application.Queries.Client;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Clients
{
    public class GetClientsQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.Client>>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Client>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetAll();
        }
    }
}
