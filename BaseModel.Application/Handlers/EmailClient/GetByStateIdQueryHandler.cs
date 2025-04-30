using BaseModel.Application.Queries.EmailClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.EmailClient
{
    public class GetByClientIdQueryHandler : IRequestHandler<GetByClientIdQuery, IEnumerable<Domain.Entities.EmailClient>>
    {
        private readonly IEmailClientRepository _emailClientRepository;
        public GetByClientIdQueryHandler(IEmailClientRepository emailClientRepository)
        {
            _emailClientRepository = emailClientRepository;
        }
        public async Task<IEnumerable<Domain.Entities.EmailClient>> Handle(GetByClientIdQuery request, CancellationToken cancellationToken)
        {
            return await _emailClientRepository.GetByClientId(request.ClientId);
        }
    }
}
