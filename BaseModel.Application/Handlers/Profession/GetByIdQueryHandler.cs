using BaseModel.Application.Queries.Profession;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Profession
{
    public class GetProfessionByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.Profession?>
    {
        private readonly IProfessionRepository _professionRepository;
        public GetProfessionByIdQueryHandler(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }
        public async Task<Domain.Entities.Profession?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _professionRepository.GetById(request.Id);
        }
    }
}
