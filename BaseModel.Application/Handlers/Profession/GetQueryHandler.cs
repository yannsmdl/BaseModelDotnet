using BaseModel.Application.Queries.Profession;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Professions
{
    public class GetProfessionsQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Domain.Entities.Profession>>
    {
        private readonly IProfessionRepository _professionRepository;
        public GetProfessionsQueryHandler(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Profession>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _professionRepository.GetAll();
        }
    }
}
