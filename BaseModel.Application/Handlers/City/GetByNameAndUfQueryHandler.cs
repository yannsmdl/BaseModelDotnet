using BaseModel.Application.Queries.City;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.City
{
    public class GetCityByNameAndUfQueryHandler : IRequestHandler<GetByNameAndUfQuery, Domain.Entities.City?>
    {
        private readonly ICityRepository _cityRepository;
        public GetCityByNameAndUfQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<Domain.Entities.City?> Handle(GetByNameAndUfQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetByNameAndUf(request.Name, request.Uf);
        }
    }
}
