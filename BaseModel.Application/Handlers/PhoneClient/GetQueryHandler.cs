using BaseModel.Application.Queries.PhoneClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.PhoneClients
{
    public class GetPhoneClientsQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.PhoneClient>>
    {
        private readonly IPhoneClientRepository _phoneClientRepository;
        public GetPhoneClientsQueryHandler(IPhoneClientRepository phoneClientRepository)
        {
            _phoneClientRepository = phoneClientRepository;
        }

        public async Task<IEnumerable<Domain.Entities.PhoneClient>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _phoneClientRepository.GetAll();
        }
    }
}
