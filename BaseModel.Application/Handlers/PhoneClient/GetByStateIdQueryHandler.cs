using BaseModel.Application.Queries.PhoneClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.PhoneClient
{
    public class GetByClientIdQueryHandler : IRequestHandler<GetByClientIdQuery, IEnumerable<Domain.Entities.PhoneClient>>
    {
        private readonly IPhoneClientRepository _phoneClientRepository;
        public GetByClientIdQueryHandler(IPhoneClientRepository phoneClientRepository)
        {
            _phoneClientRepository = phoneClientRepository;
        }
        public async Task<IEnumerable<Domain.Entities.PhoneClient>> Handle(GetByClientIdQuery request, CancellationToken cancellationToken)
        {
            return await _phoneClientRepository.GetByClientId(request.ClientId);
        }
    }
}
