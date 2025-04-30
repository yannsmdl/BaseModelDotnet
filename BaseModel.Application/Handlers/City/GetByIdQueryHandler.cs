using BaseModel.Application.Queries.City;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.City
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.City?>
    {
        private readonly ICityRepository _cityRepository;
        public GetCityByIdQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Domain.Entities.City?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetById(request.Id);
        }
    }
}
