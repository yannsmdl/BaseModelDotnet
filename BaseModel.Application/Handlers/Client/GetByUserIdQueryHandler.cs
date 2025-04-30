using BaseModel.Application.Queries.Client;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Client
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, Domain.Entities.Client?>
    {
        private readonly IClientRepository _cityRepository;
        public GetByUserIdQueryHandler(IClientRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Domain.Entities.Client?> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetByUserId(request.UserId);
        }
    }
}
