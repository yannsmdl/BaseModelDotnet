using BaseModel.Application.Queries.EmailClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.EmailClients
{
    public class GetEmailClientsQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.EmailClient>>
    {
        private readonly IEmailClientRepository _emailClientRepository;
        public GetEmailClientsQueryHandler(IEmailClientRepository emailClientRepository)
        {
            _emailClientRepository = emailClientRepository;
        }

        public async Task<IEnumerable<Domain.Entities.EmailClient>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _emailClientRepository.GetAll();
        }
    }
}
