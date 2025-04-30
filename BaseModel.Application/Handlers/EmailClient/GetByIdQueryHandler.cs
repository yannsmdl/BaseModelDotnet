using BaseModel.Application.Queries.EmailClient;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.EmailClient
{
    public class GetEmailClientByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.EmailClient?>
    {
        private readonly IEmailClientRepository _emailClientRepository;
        public GetEmailClientByIdQueryHandler(IEmailClientRepository emailClientRepository)
        {
            _emailClientRepository = emailClientRepository;
        }
        public async Task<Domain.Entities.EmailClient?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _emailClientRepository.GetById(request.Id);
        }
    }
}
