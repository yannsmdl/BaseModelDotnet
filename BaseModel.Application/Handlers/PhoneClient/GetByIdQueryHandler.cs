using BaseModel.Application.Queries.PhoneClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.PhoneClient
{
    public class GetPhoneClientByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.PhoneClient?>
    {
        private readonly IPhoneClientRepository _phoneClientRepository;
        public GetPhoneClientByIdQueryHandler(IPhoneClientRepository phoneClientRepository)
        {
            _phoneClientRepository = phoneClientRepository;
        }
        public async Task<Domain.Entities.PhoneClient?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _phoneClientRepository.GetById(request.Id);
        }
    }
}
