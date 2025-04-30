using BaseModel.Application.Queries.City;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Citys
{
    public class GetCitysQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.City>>
    {
        private readonly ICityRepository _cityRepository;
        public GetCitysQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<Domain.Entities.City>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetAll();
        }
    }
}
