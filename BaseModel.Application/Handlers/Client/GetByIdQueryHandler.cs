using BaseModel.Application.Queries.Client;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Client
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.Client?>
    {
        private readonly IClientRepository _cityRepository;
        public GetClientByIdQueryHandler(IClientRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Domain.Entities.Client?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetById(request.Id);
        }
    }
}
