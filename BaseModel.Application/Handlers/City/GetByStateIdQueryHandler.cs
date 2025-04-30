using BaseModel.Application.Queries.City;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.City
{
    public class GetByStateIdQueryHandler : IRequestHandler<GetByStateIdQuery, IEnumerable<Domain.Entities.City>>
    {
        private readonly ICityRepository _cityRepository;
        public GetByStateIdQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<IEnumerable<Domain.Entities.City>> Handle(GetByStateIdQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetByStateId(request.StateId);
        }
    }
}
